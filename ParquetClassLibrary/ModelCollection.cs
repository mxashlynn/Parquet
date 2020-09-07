using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;
using ParquetClassLibrary.EditorSupport;
using ParquetClassLibrary.Properties;

namespace ParquetClassLibrary
{
    /// <summary>
    /// Collects a group of <see cref="Model"/>s.
    /// Provides bounds-checking and type-checking against <typeparamref name="TModel"/>.
    /// </summary>
    /// <remarks>
    /// All <see cref="ModelCollection{ModelID}"/>s implicitly contain <see cref="ModelID.None"/>.
    /// <para />
    /// This generic version is intended to support <see cref="All.Parquets"/> allowing
    /// the collection to store all parquet types but return only the requested subtype.
    /// <para />
    /// For more details, see remarks on <see cref="Model"/>.<para />
    /// </remarks>
    /// <seealso cref="ModelID"/>
    /// <seealso cref="ModelTag"/>
    /// <seealso cref="All"/>
    /// <typeparam name="TModel">The type collected, typically a concrete decendent of <see cref="Model"/>.</typeparam>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1033:Interface methods should be callable by subtypes",
        Justification = "By design, ModelCollection should never use IModelCollectionEdit to alter its own collection.  IModelCollectionEdit is for external types that require read/write access.")]
    public class ModelCollection<TModel> : IReadOnlyCollection<TModel>, IModelCollectionEdit<TModel>
        where TModel : Model
    {
        #region Class Defaults
        /// <summary>A value to use in place of uninitialized <see cref="ModelCollection{TModelType}"/>s.</summary>
        public static readonly ModelCollection<TModel> Default = new ModelCollection<TModel>(
            new List<Range<ModelID>> { new Range<ModelID>(int.MinValue, int.MaxValue) },
            Enumerable.Empty<Model>());
        #endregion

        #region Characteristics
        /// <summary>An editable facade onto the internal collection mechanism.</summary>
        /// <remarks>Should only be accessed from constructor and <see cref="IModelCollectionEdit{TModel}"/>.</remarks>
        private Dictionary<ModelID, Model> EditableModels { get; }

        /// <summary>The internal collection mechanism.</summary>
        private IReadOnlyDictionary<ModelID, Model> Models { get; }

        /// <summary>The bounds within which all collected <see cref="Model"/>s must be defined.</summary>
        public IReadOnlyList<Range<ModelID>> Bounds { get; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="ModelCollection{TModelType}"/> class.
        /// </summary>
        /// <param name="inBounds">The bounds within which the collected <see cref="ModelID"/>s are defined.</param>
        /// <param name="inModels">The <see cref="Model"/>s to collect.  Cannot be null.</param>
        public ModelCollection(IEnumerable<Range<ModelID>> inBounds, IEnumerable<Model> inModels)
        {
            Precondition.IsNotNull(inModels, nameof(inModels));

            var baseDictionary = new Dictionary<ModelID, Model>();
            foreach (var model in inModels)
            {
                Precondition.IsInRange(model.ID, inBounds, nameof(inModels));

                if (model.ID == ModelID.None)
                {
                    continue;
                }
                if (!baseDictionary.ContainsKey(model.ID))
                {
                    baseDictionary[model.ID] = model;
                }
                else
                {
                    throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Resources.ErrorUnsupportedDuplicate,
                                                                      nameof(ModelID), model.ID));
                }
            }

            Bounds = inBounds.ToList();
            Models = baseDictionary;
            EditableModels = baseDictionary;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelCollection{TModelType}"/> class.
        /// </summary>
        /// <param name="inBounds">The bounds within which the collected <see cref="ModelID"/>s are defined.</param>
        /// <param name="inModels">The <see cref="Model"/>s to collect.  Cannot be null.</param>
        public ModelCollection(Range<ModelID> inBounds, IEnumerable<Model> inModels) :
            this(new List<Range<ModelID>> { inBounds }, inModels)
        { }
        #endregion

        #region IReadOnlyCollection Implementation
        /// <summary>The number of <see cref="Model"/>s in the <see cref="ModelCollection{TModelType}"/>.</summary>
        public int Count
            => Models?.Count ?? 0;

        /// <summary>
        /// Determines whether the <see cref="ModelCollection{TModelType}"/> contains the specified <see cref="Model"/>.
        /// </summary>
        /// <param name="inModel">The <see cref="Model"/> to find.</param>
        /// <returns><c>true</c> if the <see cref="Model"/> was found; <c>false</c> otherwise.</returns>
        public bool Contains(Model inModel)
        {
            Precondition.IsNotNull(inModel, nameof(inModel));

            return Contains(inModel.ID);
        }

        /// <summary>
        /// Determines whether the <see cref="ModelCollection{TModelType}"/> contains a <see cref="Model"/>
        /// with the specified <see cref="ModelID"/>.
        /// </summary>
        /// <param name="inID">The <see cref="ModelID"/> of the <see cref="Model"/> to find.</param>
        /// <returns><c>true</c> if the <see cref="ModelID"/> was found; <c>false</c> otherwise.</returns>
        public bool Contains(ModelID inID)
        {
            Debug.Assert(inID.IsValidForRange(Bounds), string.Format(CultureInfo.CurrentCulture, Resources.ErrorOutOfBounds,
                                                                     nameof(ModelCollection), inID, Bounds));
            return inID == ModelID.None
                || Models.ContainsKey(inID);
        }

        /// <summary>
        /// Retrieves a specified <typeparamref name="TModel"/>.
        /// </summary>
        /// <param name="inID">A valid, defined <typeparamref name="TModel"/> identifier.</param>
        /// <typeparam name="TTarget">
        /// The type of <typeparamref name="TModel"/> sought.  Must correspond to the given <paramref name="inID"/>.
        /// </typeparam>
        /// <returns>The specified <typeparamref name="TTarget"/>.</returns>
        public TTarget Get<TTarget>(ModelID inID)
            where TTarget : TModel
        {
            Precondition.IsInRange(inID, Bounds, nameof(inID));

            return inID == ModelID.None
                ? throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.ErrorModelNotFound,
                                                            typeof(TTarget).Name, nameof(ModelID.None)))
                : (TTarget)Models[inID];
        }

        /// <summary>
        /// Retrieves a specified <typeparamref name="TModel"/> if possible.
        /// </summary>
        /// <param name="inID">A valid <typeparamref name="TModel"/> identifier.</param>
        /// <returns>The specified <typeparamref name="TModel"/>, or <c>null</c> if no such model can be found.</returns>
        /// <remarks>
        /// Note that this method will silently fail by returning null if <paramref name="inID"/> is out of range or undefined.
        /// This method exists primarily to support design-time tools that expect undefined models as part of the normal workflow.
        /// </remarks>
        public TModel GetOrNull(ModelID inID)
            => ModelID.None != inID
                && inID.IsValidForRange(Bounds)
                ? (TModel)Models[inID]
                : null;

        /// <summary>
        /// Exposes an <see cref="IEnumerator{TModel}"/> to support simple iteration.
        /// </summary>
        /// <remarks>Used by LINQ. No accessibility modifiers are valid in this context.</remarks>
        /// <returns>An enumerator.</returns>
        IEnumerator<TModel> IEnumerable<TModel>.GetEnumerator()
            => Models.Values.Cast<TModel>().GetEnumerator();

        /// <summary>
        /// Exposes an <see cref="IEnumerator"/> to support simple iteration.
        /// </summary>
        /// <remarks>Used by LINQ. No accessibility modifiers are valid in this context.</remarks>
        /// <returns>An enumerator.</returns>
        IEnumerator IEnumerable.GetEnumerator()
            => Models.Values.GetEnumerator();

        /// <summary>
        /// Retrieves an enumerator for the <see cref="ModelCollection{Model}"/>.
        /// </summary>
        /// <returns>An enumerator that iterates through the collection.</returns>
        public IEnumerator<Model> GetEnumerator()
            => Models.Values.GetEnumerator();
        #endregion

        #region IModelCollectionEdit Implementation
        /// <summary>
        /// Adds the given <typeparamref name="TModel"/> to the collection.
        /// </summary>
        /// <param name="inModel">A valid, defined <typeparamref name="TModel"/> contianed in this collection.</param>
        void IModelCollectionEdit<TModel>.Add(TModel inModel)
        {
            Precondition.IsNotNull(inModel);
            Precondition.IsNotNone(inModel.ID);
            Precondition.IsInRange(inModel.ID, Bounds, nameof(inModel.ID));

            EditableModels[inModel.ID] = !Contains(inModel.ID)
                ? inModel
                : throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.ErrorCannotAdd,
                                                            typeof(TModel).Name, inModel.Name));
        }

        /// <summary>
        /// Removes the given <typeparamref name="TModel"/> from the collection.
        /// </summary>
        /// <param name="inModel">A valid, defined <typeparamref name="TModel"/> contianed in this collection.</param>
        void IModelCollectionEdit<TModel>.Remove(TModel inModel)
            => ((IModelCollectionEdit<TModel>)this).Remove(inModel?.ID
                ?? throw new ArgumentNullException(string.Format(CultureInfo.CurrentCulture, Resources.ErrorMustNotBeNull, nameof(inModel))));


        /// <summary>
        /// Removes the <typeparamref name="TModel"/> associated with the given <see cref="ModelID"/> from the collection.
        /// </summary>
        /// <param name="inID">The ID for a valid, defined <typeparamref name="TModel"/> contianed in this collection.</param>
        void IModelCollectionEdit<TModel>.Remove(ModelID inID)
        {
            Precondition.IsNotNone(inID);
            Precondition.IsInRange(inID, Bounds, nameof(inID));

            if (!EditableModels.Remove(inID))
            {
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.ErrorCannotRemove,
                                                          typeof(TModel).Name, inID));
            }
        }

        /// <summary>
        /// Empties the entire collection.
        /// </summary>
        void IModelCollectionEdit<TModel>.Clear()
            => EditableModels.Clear();


        /// <summary>
        /// Replaces a contained <typeparamref name="TModel"/> with the given <typeparamref name="TModel"/> whose
        /// <see cref="ModelID"/> is identicle to that of the model being replaced.
        /// </summary>
        /// <param name="inModel">A valid, defined <typeparamref name="TModel"/> contianed in this collection.</param>
        /// <remarks>Facilitates updating elements from design tools while maintaining a read-only facade during play.</remarks>
        void IModelCollectionEdit<TModel>.Replace(TModel inModel)
        {
            Precondition.IsNotNull(inModel);
            Precondition.IsNotNone(inModel.ID);
            Precondition.IsInRange(inModel.ID, Bounds, nameof(inModel.ID));

            EditableModels[inModel.ID] = Contains(inModel.ID)
                ? inModel
                : throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.ErrorCannotReplace,
                                                            typeof(TModel).Name, inModel.Name));
        }
        #endregion

        #region Self Serialization
        /// <summary>Allows the converter to construct itself statically.</summary>
        internal static ModelCollection<TModel> ConverterFactory { get; } = Default;

        /// <summary>
        /// Reads all records of the given type from the appropriate file.
        /// </summary>
        /// <typeparam name="TModelInner">The type to deserialize.</typeparam>
        /// <param name="inBounds">The range in which the records are defined.</param>
        /// <returns>The instances read.</returns>
        public ModelCollection<TModel> GetRecordsForType<TModelInner>(Range<ModelID> inBounds)
            where TModelInner : TModel
            => GetRecordsForType<TModelInner>(new List<Range<ModelID>> { inBounds });

        /// <summary>
        /// Reads all records of the given type from the appropriate file.
        /// </summary>
        /// <typeparam name="TModelInner">The type to deserialize.</typeparam>
        /// <param name="inBounds">The range in which the records are defined.</param>
        /// <returns>The instances read.</returns>
        public ModelCollection<TModel> GetRecordsForType<TModelInner>(IEnumerable<Range<ModelID>> inBounds)
            where TModelInner : TModel
        {
            using var reader = new StreamReader(ModelCollection.GetFilePath<TModelInner>());
            using var csv = ConfigureCSVReader(reader);
            var models = csv.GetRecords<TModelInner>().ToList();
            HandleUnassignedIDs(csv.Context.HeaderRecord, models);
            return new ModelCollection<TModel>(inBounds, models);
        }

        #region GetRecordsForType Helper Methods
        /// <summary>
        /// Sets up a <see cref="TextReader"/> to work with Parquet's CSV files.
        /// </summary>
        /// <param name="inReader">The reader to configure.</param>
        /// <returns>A new, configured reader that will need to be disposed.</returns>
        private static CsvReader ConfigureCSVReader(TextReader inReader)
        {
            var csvReader = new CsvReader(inReader, CultureInfo.InvariantCulture);
            csvReader.Configuration.TypeConverterOptionsCache.AddOptions(typeof(ModelID), All.IdentifierOptions);
            csvReader.Configuration.PrepareHeaderForMatch = RemoveHeaderPrefix;
            foreach (var kvp in All.ConversionConverters)
            {
                csvReader.Configuration.TypeConverterCache.AddConverter(kvp.Key, kvp.Value);
            }

            return csvReader;
        }

        /// <summary>
        /// Removes the "in" element used in the Parquet C# style from appearing in CSV file headers.
        /// </summary>
        /// <param name="inHeaderText">The text to modify.</param>
        /// <param name="inHeaderIndex">Ignored.</param>
        /// <returns>The modified text.</returns>
        private static string RemoveHeaderPrefix(string inHeaderText, int inHeaderIndex)
            => inHeaderText.StartsWith("in", StringComparison.InvariantCulture)
                ? inHeaderText.Substring(2).ToUpperInvariant()
                : inHeaderText.ToUpperInvariant();

        /// <summary>
        /// Assigns <see cref="ModelID"/>s to any models that need them.
        /// </summary>
        /// <remarks>
        /// Optionally, a subset of deserialized records may not have <see cref="ModelID"/>s.
        /// This detects such records and assigns an ID to all models created from them.
        /// </remarks>
        /// <typeparam name="TModelInner">The type to assign IDs to.</typeparam>
        /// <param name="inColumnHeaders">Text indicating which value corresponds to which model member.</param>
        /// <param name="inModels">Models created by the most recent call to CsvReader.GetRecords.</param>
        private static void HandleUnassignedIDs<TModelInner>(string[] inColumnHeaders, List<TModelInner> inModels)
            where TModelInner : TModel
        {
            if (ModelID.RecordsWithMissingIDs.Count > 0)
            {
                var recordsWithNewIDs = new StringBuilder();
                ReconstructHeader(inColumnHeaders, recordsWithNewIDs);
                AssignMissingIDs(inModels, recordsWithNewIDs);

                using var stringReader = new StringReader(recordsWithNewIDs.ToString());
                using var stringCSVReader = ConfigureCSVReader(stringReader);

                var modelsWithNewIDs = stringCSVReader.GetRecords<TModelInner>().ToList();
                inModels.AddRange(modelsWithNewIDs);
                ModelID.RecordsWithMissingIDs.Clear();
            }
        }

        /// <summary>
        /// Reconstructs the header that would be used by <see cref="CsvReader"/> to deserialize models from the given records.
        /// </summary>
        /// <param name="inColumnHeaders">Individual header elements.</param>
        /// <param name="inRecordsWithNewIDs">Data laid out in CSV-fashion in need of a header.</param>
        private static void ReconstructHeader(string[] inColumnHeaders, StringBuilder inRecordsWithNewIDs)
        {
            foreach (var columnName in inColumnHeaders)
            {
                inRecordsWithNewIDs.Append($"{columnName},");
            }
            inRecordsWithNewIDs.Remove(inRecordsWithNewIDs.Length - 1, 1);
        }

        /// <summary>
        /// Assigns <see cref="ModelID"/>s to the given <see cref="Model"/>s and adds them to the given <see cref="List{T}"/>.
        /// </summary>
        /// <typeparam name="TModelInner">The type to assign IDs to.</typeparam>
        /// <param name="inModelsWithOldIDs">Models that already had IDs.</param>
        /// <param name="inRecordsNeedingIDs">Records of models that have not yet had their IDs assigned.</param>
        private static void AssignMissingIDs<TModelInner>(List<TModelInner> inModelsWithOldIDs, StringBuilder inRecordsNeedingIDs)
            where TModelInner : TModel
        {
            var maxAssignedID = inModelsWithOldIDs
                .Aggregate((current, next) =>
                    next.ID > current.ID
                        ? next
                        : current).ID;
            foreach (var record in ModelID.RecordsWithMissingIDs)
            {
                maxAssignedID++;
                inRecordsNeedingIDs.Append($"\n{maxAssignedID}{record}");
            }
        }
        #endregion

        /// <summary>
        /// Writes all of the given type to records to the appropriate file.
        /// </summary>
        /// <typeparam name="TModelInner">The type to serialize.</typeparam>
        public void PutRecordsForType<TModelInner>()
            where TModelInner : TModel
        {
            using var fileWriter = new StreamWriter(ModelCollection.GetFilePath<TModelInner>(), false, new UTF8Encoding(true, true));
            using var csvWriter = new CsvWriter(fileWriter, CultureInfo.InvariantCulture);
            csvWriter.Configuration.NewLine = NewLine.LF;
            csvWriter.Configuration.TypeConverterOptionsCache.AddOptions(typeof(ModelID), All.IdentifierOptions);
            foreach (var kvp in All.ConversionConverters)
            {
                csvWriter.Configuration.TypeConverterCache.AddConverter(kvp.Key, kvp.Value);
            }

            csvWriter.WriteHeader<TModelInner>();
            csvWriter.NextRecord();
            var recordsToWrite = Models.Values.Where(model => model.GetType() == typeof(TModelInner)).Cast<TModelInner>();
            csvWriter.WriteRecords(recordsToWrite);
        }
        #endregion

        #region Utilities
        /// <summary>
        /// Returns a <see cref="string"/> that represents the current <see cref="ModelCollection{TModelType}"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override string ToString()
        {
            var allBounds = new StringBuilder();
            foreach (var bound in Bounds)
            {
                allBounds.Append($"{bound} ");
            }
            return $"Collects {typeof(TModel)}s over {allBounds}";
        }
        #endregion
    }

    /// <summary>
    /// Stores a <see cref="Model"/> collection.
    /// Provides bounds-checking and type-checking against <see cref="Model"/>.
    /// </summary>
    /// <remarks>
    /// All <see cref="ModelCollection"/>s implicitly contain <see cref="ModelID.None"/>.
    /// For more details, see remarks on <see cref="Model"/>.
    /// </remarks>
    // TODO Should this class be removed, or reduced to static?
    public class ModelCollection : ModelCollection<Model>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModelCollection"/> class.
        /// </summary>
        /// <param name="inBounds">The bounds within which the collected <see cref="ModelID"/>s are defined.</param>
        /// <param name="inModels">The <see cref="Model"/>s to collect.  Cannot be null.</param>
        public ModelCollection(Range<ModelID> inBounds, IEnumerable<Model> inModels)
            : base(new List<Range<ModelID>> { inBounds }, inModels) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelCollection"/> class.
        /// </summary>
        /// <param name="inBounds">The bounds within which the collected <see cref="ModelID"/>s are defined.</param>
        /// <param name="inModels">The <see cref="Model"/>s to collect.  Cannot be null.</param>
        public ModelCollection(IEnumerable<Range<ModelID>> inBounds, IEnumerable<Model> inModels)
            : base(inBounds, inModels) { }

        /// <summary>
        /// Given a type, returns the filename and path associated with that type's definition file.
        /// </summary>
        /// <typeparam name="TModel">The type whose path and filename are sought.</typeparam>
        /// <returns>A full path to the associated file.</returns>
        public static string GetFilePath<TModel>()
            where TModel : Model
        {
            var filename = typeof(TModel) == typeof(Maps.MapRegionSketch)
                ? $"{typeof(TModel).Name}es.csv"
                : $"{typeof(TModel).Name}s.csv";
            return $"{All.ProjectDirectory}/{filename}";
        }
    }
}
