using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;
using ParquetClassLibrary.Items;
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
        public int Count => Models?.Count ?? 0;

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
        /// <typeparam name="TRecord">The type to deserialize.</typeparam>
        /// <param name="inBounds">The range in which the records are defined.</param>
        /// <returns>The instances read.</returns>
        public ModelCollection<TModel> GetRecordsForType<TRecord>(Range<ModelID> inBounds)
            where TRecord : TModel
            => GetRecordsForType<TRecord>(new List<Range<ModelID>> { inBounds });

        /// <summary>
        /// Reads all records of the given type from the appropriate file.
        /// </summary>
        /// <typeparam name="TRecord">The type to deserialize.</typeparam>
        /// <param name="inBounds">The range in which the records are defined.</param>
        /// <returns>The instances read.</returns>
        public ModelCollection<TModel> GetRecordsForType<TRecord>(IEnumerable<Range<ModelID>> inBounds)
            where TRecord : TModel
        {
            using var reader = new StreamReader(GetFilePath<TRecord>());
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            csv.Configuration.TypeConverterOptionsCache.AddOptions(typeof(ModelID), All.IdentifierOptions);
            csv.Configuration.PrepareHeaderForMatch = (string header, int index) => header.StartsWith("in", StringComparison.InvariantCulture)
                                                                                        ? header.Substring(2).ToUpperInvariant()
                                                                                        : header.ToUpperInvariant();
            foreach (var kvp in All.ConversionConverters)
            {
                csv.Configuration.TypeConverterCache.AddConverter(kvp.Key, kvp.Value);
            }

            return new ModelCollection<TModel>(inBounds, csv.GetRecords<TRecord>());
        }

        /// <summary>
        /// Writes all of the given type to records to the appropriate file.
        /// </summary>
        /// <typeparam name="TRecord">The type to serialize.</typeparam>
        internal void PutRecordsForType<TRecord>()
            where TRecord : TModel
        {
            using var writer = new StreamWriter(GetFilePath<TRecord>());
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.Configuration.NewLine = NewLine.LF;
            csv.Configuration.TypeConverterOptionsCache.AddOptions(typeof(ModelID), All.IdentifierOptions);
            foreach (var kvp in All.ConversionConverters)
            {
                csv.Configuration.TypeConverterCache.AddConverter(kvp.Key, kvp.Value);
            }

            csv.WriteHeader<TRecord>();
            csv.NextRecord();
            var recordsToWrite = Models.Values.Where(model => model.GetType() == typeof(TRecord)).Cast<TRecord>();
            csv.WriteRecords(recordsToWrite);
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
