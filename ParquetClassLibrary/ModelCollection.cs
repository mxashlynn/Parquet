using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;
using Parquet.Properties;

namespace Parquet
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
    /// <typeparam name="TModel">The type collected, typically a concrete descendant of <see cref="Model"/>.</typeparam>
    [SuppressMessage("Design", "CA1033:Interface methods should be callable by subtypes",
                     Justification = "By design, ModelCollection should never use IMutableModelCollection to alter its own collection.  IMutableModelCollection is for external types that require read/write access.")]
    public class ModelCollection<TModel> : IReadOnlyCollection<TModel>, IMutableModelCollection<TModel>
        where TModel : Model
    {
        #region Class Defaults
        /// <summary>A value to use in place of uninitialized <see cref="ModelCollection{TModel}"/>s.</summary>
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
        /// Initializes a new instance of the <see cref="ModelCollection{TModel}"/> class.
        /// </summary>
        /// <param name="inBounds">The bounds within which the collected <see cref="ModelID"/>s are defined.</param>
        /// <param name="inModels">The <see cref="Model"/>s to collect.  Cannot be null.</param>
        public ModelCollection(IEnumerable<Range<ModelID>> inBounds, IEnumerable<Model> inModels)
        {
            Precondition.IsNotNull(inModels, nameof(inModels));

            var baseDictionary = new Dictionary<ModelID, Model>();
            foreach (var model in inModels ?? Enumerable.Empty<Model>())
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
                    Logger.Log(LogLevel.Warning, string.Format(CultureInfo.CurrentCulture, Resources.ErrorUnsupportedDuplicate,
                                                               nameof(ModelID), model.ID));
                }
            }

            Bounds = inBounds.ToList();
            Models = baseDictionary;
            EditableModels = baseDictionary;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelCollection{TModel}"/> class.
        /// </summary>
        /// <param name="inBounds">The bounds within which the collected <see cref="ModelID"/>s are defined.</param>
        /// <param name="inModels">The <see cref="Model"/>s to collect.  Cannot be null.</param>
        public ModelCollection(Range<ModelID> inBounds, IEnumerable<Model> inModels) :
            this(new List<Range<ModelID>> { inBounds }, inModels)
        { }
        #endregion

        #region IMutableModelCollection Implementation
        /// <summary>The number of <see cref="TModel"/>s in the <see cref="ModelCollection{TModel}"/>.</summary>
        int ICollection<TModel>.Count => Count;

        /// <summary><c>true</c> if the <see cref="ModelCollection{TModel}"/> is read-only; otherwise, <c>false</c>.</summary>
        bool ICollection<TModel>.IsReadOnly => LibraryState.IsPlayMode;

        /// <summary>
        /// Adds the given <typeparamref name="TModel"/> to the collection.
        /// </summary>
        /// <param name="inModel">A valid, defined <typeparamref name="TModel"/> contained in this collection.</param>
        void ICollection<TModel>.Add(TModel inModel)
        {
            if (LibraryState.IsPlayMode)
            {
                Logger.Log(LogLevel.Warning, string.Format(CultureInfo.CurrentCulture, Resources.WarningUnavailableDuringPlay,
                                                           $"{nameof(IMutableModelCollection<TModel>.Add)}"));
                return;
            }

            Precondition.IsNotNull(inModel);
            Precondition.IsNotNone(inModel.ID);
            Precondition.IsInRange(inModel.ID, Bounds, nameof(inModel.ID));

            if (!Contains(inModel.ID))
            {
                EditableModels[inModel.ID] = inModel;
            }
            else
            {
                Logger.Log(LogLevel.Warning, string.Format(CultureInfo.CurrentCulture, Resources.ErrorCannotAdd,
                                                           typeof(TModel).Name, inModel.Name));
            }
        }

        /// <summary>
        /// Determines whether the <see cref="ModelCollection{TModel}"/> contains the specified <see cref="TModel"/>.
        /// </summary>
        /// <param name="inModel">The <see cref="TModel"/> to find.</param>
        /// <returns><c>true</c> if the <see cref="TModel"/> was found; <c>false</c> otherwise.</returns>
        bool ICollection<TModel>.Contains(TModel item) => Contains(item);

        /// <summary>
        /// Copies the elements of the <see cref="ModelCollection{TModel}"/> to an <see cref="Array"/>, starting at the given index.
        /// </summary>
        /// <param name="inArray">The array to copy to.</param>
        /// <param name="inArrayIndex">The index at which to begin copying.</param>
        void ICollection<TModel>.CopyTo(TModel[] inArray, int inArrayIndex)
        {
            if (LibraryState.IsPlayMode)
            {
                Logger.Log(LogLevel.Warning, string.Format(CultureInfo.CurrentCulture, Resources.WarningUnavailableDuringPlay,
                                                           $"{nameof(IMutableModelCollection<TModel>.CopyTo)}"));
                return;
            }

            EditableModels.Values.CopyTo(inArray, inArrayIndex);
        }

        /// <summary>
        /// Removes the given <typeparamref name="TModel"/> from the collection.
        /// </summary>
        /// <param name="inModel">A valid, defined <typeparamref name="TModel"/> contained in this collection.</param>
        bool ICollection<TModel>.Remove(TModel inModel)
        {
            if (LibraryState.IsPlayMode)
            {
                Logger.Log(LogLevel.Warning, string.Format(CultureInfo.CurrentCulture, Resources.WarningUnavailableDuringPlay,
                                                           $"{nameof(IMutableModelCollection<TModel>.Remove)}"));
                return false;
            }

            Precondition.IsNotNull(inModel);

            return ((IMutableModelCollection<TModel>)this).Remove(inModel?.ID ?? ModelID.None);
        }

        /// <summary>
        /// Removes the <typeparamref name="TModel"/> associated with the given <see cref="ModelID"/> from the collection.
        /// </summary>
        /// <param name="inID">The ID for a valid, defined <typeparamref name="TModel"/> contained in this collection.</param>
        bool IMutableModelCollection<TModel>.Remove(ModelID inID)
        {
            Precondition.IsNotNone(inID);
            Precondition.IsInRange(inID, Bounds, nameof(inID));

            return LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(IMutableModelCollection<TModel>.Remove), false)
                : inID != ModelID.None
                       && EditableModels.Remove(inID);
        }

        /// <summary>
        /// Empties the entire collection.
        /// </summary>
        void ICollection<TModel>.Clear()
        {
            if (LibraryState.IsPlayMode)
            {
                Logger.Log(LogLevel.Warning, string.Format(CultureInfo.CurrentCulture, Resources.WarningUnavailableDuringPlay,
                                                           $"{nameof(IMutableModelCollection<TModel>.Clear)}"));
                return;
            }

            EditableModels.Clear();
        }

        /// <summary>
        /// Replaces a contained <typeparamref name="TModel"/> with the given <typeparamref name="TModel"/> whose
        /// <see cref="ModelID"/> is identical to that of the model being replaced.
        /// </summary>
        /// <param name="inModel">A valid, defined <typeparamref name="TModel"/> contained in this collection.</param>
        /// <remarks>Facilitates updating elements from design tools while maintaining a read-only facade during play.</remarks>
        void IMutableModelCollection<TModel>.Replace(TModel inModel)
        {
            if (LibraryState.IsPlayMode)
            {
                Logger.Log(LogLevel.Warning, string.Format(CultureInfo.CurrentCulture, Resources.WarningUnavailableDuringPlay,
                                                           $"{nameof(IMutableModelCollection<TModel>.Replace)}"));
                return;
            }

            Precondition.IsNotNull(inModel);
            Precondition.IsNotNone(inModel.ID);
            Precondition.IsInRange(inModel.ID, Bounds, nameof(inModel.ID));

            if (Contains(inModel.ID))
            {
                Logger.Log(LogLevel.Warning, string.Format(CultureInfo.CurrentCulture, Resources.ErrorCannotReplace,
                                                           typeof(TModel).Name, inModel.Name));
            }
            else
            {
                EditableModels[inModel.ID] = inModel;
            }
        }
        #endregion

        #region IReadOnlyCollection Implementation
        /// <summary>The number of <see cref="Model"/>s in the <see cref="ModelCollection{TModel}"/>.</summary>
        public int Count
            => Models?.Count ?? 0;

        /// <summary>
        /// Determines whether the <see cref="ModelCollection{TModel}"/> contains the specified <see cref="Model"/>.
        /// </summary>
        /// <param name="inModel">The <see cref="Model"/> to find.</param>
        /// <returns><c>true</c> if the <see cref="Model"/> was found; <c>false</c> otherwise.</returns>
        /// <remarks>A <c>null</c> model is never found and will result in a return value of <c>false</c>.</remarks>
        public bool Contains(Model inModel)
            => inModel is not null
            && Contains(inModel.ID);

        /// <summary>
        /// Determines whether the <see cref="ModelCollection{TModel}"/> contains a <see cref="Model"/>
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
        /// <returns>The specified <typeparamref name="TTarget"/>, or null if no such model exists in this collection.</returns>
        /// <remarks>
        /// This method will return null in the following cases:
        /// 1, if <paramref name="inID"/> is out of range or undefined;
        /// 2, if <paramref name="inID"/> is <see cref="ModelID.None"/>;
        /// 3, if this collection is empty.
        /// </remarks>
        public TTarget GetOrNull<TTarget>(ModelID inID)
            where TTarget : TModel
        {
            if (Models.Count < 1)
            {
                Logger.Log(LogLevel.Warning, string.Format(CultureInfo.CurrentCulture, Resources.ErrorEmptyCollection,
                                                           $"{typeof(TTarget).Name} {inID}", nameof(ModelCollection<TModel>)));
                return null;
            }
            else if (!inID.IsValidForRange(Bounds))
            {
                Logger.Log(LogLevel.Warning, string.Format(CultureInfo.CurrentCulture, Resources.ErrorOutOfBounds,
                                                           nameof(ModelCollection<TModel>), inID, Bounds));
                return null;
            }
            else if (inID == ModelID.None
                     || !Models.ContainsKey(inID))
            {
                Logger.Log(LogLevel.Warning, string.Format(CultureInfo.CurrentCulture, Resources.ErrorModelNotFound,
                                                           typeof(TTarget).Name, nameof(ModelID.None)));
                return null;
            }
            else
            {
                return (TTarget)Models[inID];
            }
        }

        /// <summary>
        /// Exposes an <see cref="IEnumerator{TModel}"/> to support simple iteration.
        /// </summary>
        /// <returns>An enumerator.</returns>
        // Used by LINQ. No accessibility modifiers are valid in this context.
        IEnumerator<TModel> IEnumerable<TModel>.GetEnumerator()
            => Models.Values.Cast<TModel>().GetEnumerator();

        /// <summary>
        /// Exposes an <see cref="IEnumerator"/> to support simple iteration.
        /// </summary>
        /// <returns>An enumerator.</returns>
        // Used by LINQ. No accessibility modifiers are valid in this context.
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
        // TODO If we remove the "in" prefix, remove this routine, too.
        private static string RemoveHeaderPrefix(string inHeaderText, int inHeaderIndex)
            => inHeaderText.StartsWith("in", StringComparison.InvariantCulture)
                ? inHeaderText[2..].ToUpperInvariant()
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
        private static void HandleUnassignedIDs<TModelInner>(string[] inColumnHeaders, ICollection<TModelInner> inModels)
            where TModelInner : TModel
        {
            if (ModelID.RecordsWithMissingIDs.Count > 0)
            {
                var models = inModels.ToList();

                var recordsWithNewIDs = new StringBuilder();
                ReconstructHeader(inColumnHeaders, recordsWithNewIDs);
                AssignMissingIDs(models, recordsWithNewIDs);

                using var stringReader = new StringReader(recordsWithNewIDs.ToString());
                using var stringCSVReader = ConfigureCSVReader(stringReader);

                var modelsWithNewIDs = stringCSVReader.GetRecords<TModelInner>().ToList();
                models.AddRange(modelsWithNewIDs);
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
        private static void AssignMissingIDs<TModelInner>(ICollection<TModelInner> inModelsWithOldIDs,
                                                          StringBuilder inRecordsNeedingIDs)
            where TModelInner : TModel
        {
            var maxAssignedID = inModelsWithOldIDs
                .Aggregate((current, next)
                    => next.ID > current.ID
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
        /// Returns a <see cref="string"/> that represents the current <see cref="ModelCollection{TModel}"/>.
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
    /// Provides the filename and path associated with the definition file for a <see cref="Model"/>-derived type
    /// collected by a <see cref="ModelCollection{TModel}"/>.
    /// </summary>
    [SuppressMessage("Naming", "CA1711:Identifiers should not have incorrect suffix",
        Justification = "This class provides a static utility method used by the generic collection of the same name.")]
    public static class ModelCollection
    {
        /// <summary>
        /// Given a type, returns the filename and path associated with that type's definition file.
        /// </summary>
        /// <typeparam name="TModel">The type whose path and filename are sought.</typeparam>
        /// <returns>A full path to the associated file.</returns>
        public static string GetFilePath<TModel>()
            where TModel : Model
            => $"{All.ProjectDirectory}/{typeof(TModel).Name}s.csv";
    }
}
