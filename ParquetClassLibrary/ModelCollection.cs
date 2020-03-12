using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;
using ParquetClassLibrary.Utilities;

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
    /// <typeparam name="TModel">The type collected, typically a decendent of <see cref="Model"/>.</typeparam>
    public class ModelCollection<TModel> : IReadOnlyCollection<TModel>
        where TModel : Model
    {
        #region Class Defaults
        /// <summary>A value to use in place of uninitialized <see cref="ModelCollection{TModelType}"/>s.</summary>
        public static readonly ModelCollection<TModel> Default = new ModelCollection<TModel>(
            new List<Range<ModelID>> { new Range<ModelID>(int.MinValue, int.MaxValue) },
            Enumerable.Empty<Model>());
        #endregion

        #region Characteristics
        /// <summary>The internal collection mechanism.</summary>
        private IReadOnlyDictionary<ModelID, Model> Models { get; }

        /// <summary>The bounds within which all collected <see cref="Model"/>s must be defined.</summary>
        private IReadOnlyList<Range<ModelID>> Bounds { get; }
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
                    throw new InvalidOperationException($"Tried to duplicate {nameof(ModelID)} {model.ID}.");
                }
            }

            Bounds = inBounds.ToList();
            Models = baseDictionary;
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

        #region Collection Access
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
            Precondition.IsNotNull(inModel);

            return inModel.ID == ModelID.None
                || Models.ContainsKey(inModel.ID);
        }

        /// <summary>
        /// Determines whether the <see cref="ModelCollection{TModelType}"/> contains a <see cref="Model"/>
        /// with the specified <see cref="ModelID"/>.
        /// </summary>
        /// <param name="inID">The <see cref="ModelID"/> of the <see cref="Model"/> to find.</param>
        /// <returns><c>true</c> if the <see cref="ModelID"/> was found; <c>false</c> otherwise.</returns>
        public bool Contains(ModelID inID)
        {
            // TODO Remove this test after debugging.
            Precondition.IsInRange(inID, Bounds, nameof(inID));

            return inID == ModelID.None
                || Models.ContainsKey(inID);
        }

        /// <summary>
        /// Returns the specified <typeparamref name="TModel"/>.
        /// </summary>
        /// <param name="inID">A valid, defined <typeparamref name="TModel"/> identifier.</param>
        /// <typeparam name="TTarget">
        /// The type of <typeparamref name="TModel"/> sought.  Must correspond to the given <paramref name="inID"/>.
        /// </typeparam>
        /// <returns>The specified <typeparamref name="TTarget"/> model.</returns>
        public TTarget Get<TTarget>(ModelID inID)
            where TTarget : TModel
        {
            Precondition.IsInRange(inID, Bounds, nameof(inID));

            return inID == ModelID.None
                ? throw new ArgumentException($"No {typeof(TTarget).Name} exists for {nameof(ModelID.None)}.")
                : (TTarget)Models[inID];
        }

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
            using var reader = new StreamReader(GetFilePath<TModelInner>());
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
        internal void PutRecordsForType<TModelInner>()
            where TModelInner : TModel
        {
            using var fileWriter = new StreamWriter(GetFilePath<TModelInner>());
            using var fileCSV = new CsvWriter(fileWriter, CultureInfo.InvariantCulture);
            fileCSV.Configuration.NewLine = NewLine.LF;
            fileCSV.Configuration.TypeConverterOptionsCache.AddOptions(typeof(ModelID), All.IdentifierOptions);
            foreach (var kvp in All.ConversionConverters)
            {
                fileCSV.Configuration.TypeConverterCache.AddConverter(kvp.Key, kvp.Value);
            }

            fileCSV.WriteHeader<TModelInner>();
            fileCSV.NextRecord();
            var recordsToWrite = Models.Values.Where(model => model.GetType() == typeof(TModelInner)).Cast<TModelInner>();
            fileCSV.WriteRecords(recordsToWrite);
        }
        #endregion

        #region Utilities
        /// <summary>
        /// Given a type, returns the filename and path associated with that type's designer file.
        /// </summary>
        /// <typeparam name="TRecord">The type whose path and filename are sought.</typeparam>
        /// <returns>A full path to the addociated designer file.</returns>
        private string GetFilePath<TRecord>()
            where TRecord : TModel
        {
            var filename = typeof(TRecord) == typeof(Maps.MapRegionSketch)
                ? $"{typeof(TRecord).Name}es.csv"
                : $"{typeof(TRecord).Name}s.csv";
            return $"{All.WorkingDirectory}/{filename}";
        }

        /// <summary>
        /// Returns a <see langword="string"/> that represents the current <see cref="ModelCollection{TModelType}"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override string ToString()
        {
            var allBounds = new StringBuilder();
            foreach (var bound in Bounds)
            {
                allBounds.Append($"{bound.ToString()} ");
            }
            return $"Collects {typeof(TModel)} over {allBounds}.";
        }
        #endregion
    }

    /// <summary>
    /// Stores a <see cref="Model"/> collection.
    /// Provides bounds-checking and type-checking against <see cref="Model"/>.
    /// </summary>
    /// <remarks>
    /// All <see cref="ModelCollection"/>s implicitly contain <see cref="ModelID.None"/>.
    /// 
    /// This version supports collections that do not rely heavily on
    /// multiple incompatible subclasses of <see cref="Model"/>.
    ///
    /// For more details, see remarks on <see cref="Model"/>.
    /// </remarks>
    public class ModelCollection : ModelCollection<Model>
    {
        /// <summary>A value to use in place of uninitialized <see cref="ModelCollection{Model}"/>s.</summary>
        public static new readonly ModelCollection Default =
            new ModelCollection(new Range<ModelID>(int.MinValue, int.MaxValue), Enumerable.Empty<Model>());

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
        /// Returns the specified <see cref="Model"/>.
        /// </summary>
        /// <param name="inID">A valid, defined <see cref="Model"/> identifier.</param>
        /// <returns>The specified <see cref="Model"/>.</returns>
        public Model Get(ModelID inID)
            => Get<Model>(inID);
    }
}
