using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper;
using ParquetClassLibrary.Items;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary
{
    /// <summary>
    /// Collects a group of <see cref="EntityModel"/>s.
    /// Provides bounds-checking and type-checking against <typeparamref name="TModel"/>.
    /// </summary>
    /// <remarks>
    /// All <see cref="ModelCollection{EntityID}"/>s implicitly contain <see cref="EntityID.None"/>.
    /// <para />
    /// This generic version is intended to support <see cref="All.Parquets"/> allowing
    /// the collection to store all parquet types but return only the requested subtype.
    /// <para />
    /// For more details, see remarks on <see cref="EntityModel"/>.<para />
    /// </remarks>
    /// <seealso cref="EntityID"/>
    /// <seealso cref="EntityTag"/>
    /// <seealso cref="All"/>
    /// <typeparam name="TModel">The type collected, typically a decendent of <see cref="EntityModel"/>.</typeparam>
    public class ModelCollection<TModel> : IReadOnlyCollection<TModel>
        where TModel : EntityModel
    {
        #region Class Defaults
        /// <summary>A value to use in place of uninitialized <see cref="ModelCollection{TModelType}"/>s.</summary>
        public static readonly ModelCollection<TModel> Default = new ModelCollection<TModel>(
            new List<Range<EntityID>> { new Range<EntityID>(int.MinValue, int.MaxValue) },
            Enumerable.Empty<EntityModel>());
        #endregion

        #region Characteristics
        /// <summary>The internal collection mechanism.</summary>
        private IReadOnlyDictionary<EntityID, EntityModel> Models { get; }

        /// <summary>The bounds within which all collected <see cref="EntityModel"/>s must be defined.</summary>
        private IReadOnlyList<Range<EntityID>> Bounds { get; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="ModelCollection{TModelType}"/> class.
        /// </summary>
        /// <param name="inBounds">The bounds within which the collected <see cref="EntityID"/>s are defined.</param>
        /// <param name="inModels">The <see cref="EntityModel"/>s to collect.  Cannot be null.</param>
        public ModelCollection(IEnumerable<Range<EntityID>> inBounds, IEnumerable<EntityModel> inModels)
        {
            Precondition.IsNotNull(inModels, nameof(inModels));

            var baseDictionary = new Dictionary<EntityID, EntityModel>();
            foreach (var model in inModels)
            {
                Precondition.IsInRange(model.ID, inBounds, nameof(inModels));

                if (model.ID == EntityID.None)
                {
                    continue;
                }
                if (!baseDictionary.ContainsKey(model.ID))
                {
                    baseDictionary[model.ID] = model;
                }
                else
                {
                    throw new InvalidOperationException($"Tried to duplicate EntityID {model.ID}.");
                }
            }

            Bounds = inBounds.ToList();
            Models = baseDictionary;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelCollection{TModelType}"/> class.
        /// </summary>
        /// <param name="inBounds">The bounds within which the collected <see cref="EntityID"/>s are defined.</param>
        /// <param name="inModels">The <see cref="EntityModel"/>s to collect.  Cannot be null.</param>
        public ModelCollection(Range<EntityID> inBounds, IEnumerable<EntityModel> inModels) :
            this(new List<Range<EntityID>> { inBounds }, inModels)
        { }
        #endregion

        #region Collection Access
        /// <summary>The number of <see cref="EntityModel"/>s in the <see cref="ModelCollection{TModelType}"/>.</summary>
        public int Count => Models?.Count ?? 0;

        /// <summary>
        /// Determines whether the <see cref="ModelCollection{TModelType}"/> contains the specified <see cref="EntityModel"/>.
        /// </summary>
        /// <param name="inModel">The <see cref="EntityModel"/> to find.</param>
        /// <returns><c>true</c> if the <see cref="EntityModel"/> was found; <c>false</c> otherwise.</returns>
        public bool Contains(EntityModel inModel)
        {
            Precondition.IsNotNull(inModel);

            return inModel.ID == EntityID.None
                || Models.ContainsKey(inModel.ID);
        }

        /// <summary>
        /// Determines whether the <see cref="ModelCollection{TModelType}"/> contains an <see cref="EntityModel"/>
        /// with the specified <see cref="EntityID"/>.
        /// </summary>
        /// <param name="inID">The <see cref="EntityID"/> of the <see cref="EntityModel"/> to find.</param>
        /// <returns><c>true</c> if the <see cref="EntityID"/> was found; <c>false</c> otherwise.</returns>
        public bool Contains(EntityID inID)
        {
            // TODO Remove this test after debugging.
            Precondition.IsInRange(inID, Bounds, nameof(inID));

            return inID == EntityID.None
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
        public TTarget Get<TTarget>(EntityID inID)
            where TTarget : TModel
        {
            Precondition.IsInRange(inID, Bounds, nameof(inID));

            // TODO This is a hack to support deserializing InventorySlots before All is initialized.  Find a better way.
            if (inID == ItemModel.ShamModel.ID)
            {
                return (TTarget)(EntityModel)ItemModel.ShamModel;
            }

            return inID == EntityID.None
                ? throw new ArgumentException($"No {typeof(TTarget).Name} exists for {EntityID.None}.")
                : (TTarget)Models[inID];
        }

        /// <summary>
        /// Exposes an <see cref="IEnumerator{TModelType}"/> to support simple iteration.
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
        /// Retrieves an enumerator for the <see cref="ModelCollection{EntityModel}"/>.
        /// </summary>
        /// <returns>An enumerator that iterates through the collection.</returns>
        public IEnumerator<EntityModel> GetEnumerator()
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
        public ModelCollection<TModel> GetRecordsForType<TRecord>(Range<EntityID> inBounds)
            where TRecord : TModel
            => GetRecordsForType<TRecord>(new List<Range<EntityID>> { inBounds });

        /// <summary>
        /// Reads all records of the given type from the appropriate file.
        /// </summary>
        /// <typeparam name="TRecord">The type to deserialize.</typeparam>
        /// <param name="inBounds">The range in which the records are defined.</param>
        /// <returns>The instances read.</returns>
        public ModelCollection<TModel> GetRecordsForType<TRecord>(IEnumerable<Range<EntityID>> inBounds)
            where TRecord : TModel
        {
            var filename = typeof(TRecord) == typeof(Maps.MapRegionSketch)
                ? $"{typeof(TRecord).Name}es.csv"
                : $"{typeof(TRecord).Name}s.csv";
            using var reader = new StreamReader($"{All.WorkingDirectory}/{filename}");
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            csv.Configuration.TypeConverterOptionsCache.AddOptions(typeof(EntityID), All.IdentifierOptions);
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
            using var writer = new StreamWriter($"{All.WorkingDirectory}/{typeof(TRecord).Name}s.csv");
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.Configuration.TypeConverterOptionsCache.AddOptions(typeof(EntityID), All.IdentifierOptions);
            foreach (var kvp in All.ConversionConverters)
            {
                csv.Configuration.TypeConverterCache.AddConverter(kvp.Key, kvp.Value);
            }

            csv.WriteHeader<TRecord>();
            csv.NextRecord();
            csv.WriteRecords(Models.Values.Where(model => model.GetType() == typeof(TRecord)));
        }
        #endregion

        #region Utilities
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
    /// Stores an <see cref="EntityModel"/> collection.
    /// Provides bounds-checking and type-checking against <see cref="EntityModel"/>.
    /// </summary>
    /// <remarks>
    /// All <see cref="ModelCollection"/>s implicitly contain <see cref="EntityID.None"/>.
    /// 
    /// This version supports collections that do not rely heavily on
    /// multiple incompatible subclasses of <see cref="EntityModel"/>.
    ///
    /// For more details, see remarks on <see cref="EntityModel"/>.
    /// </remarks>
    public class ModelCollection : ModelCollection<EntityModel>
    {
        /// <summary>A value to use in place of uninitialized <see cref="ModelCollection{EntityModel}"/>s.</summary>
        public static new readonly ModelCollection Default =
            new ModelCollection(new Range<EntityID>(int.MinValue, int.MaxValue), Enumerable.Empty<EntityModel>());

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelCollection"/> class.
        /// </summary>
        /// <param name="inBounds">The bounds within which the collected <see cref="EntityID"/>s are defined.</param>
        /// <param name="inModels">The <see cref="EntityModel"/>s to collect.  Cannot be null.</param>
        public ModelCollection(Range<EntityID> inBounds, IEnumerable<EntityModel> inModels)
            : base(new List<Range<EntityID>> { inBounds }, inModels) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelCollection"/> class.
        /// </summary>
        /// <param name="inBounds">The bounds within which the collected <see cref="EntityID"/>s are defined.</param>
        /// <param name="inModels">The <see cref="EntityModel"/>s to collect.  Cannot be null.</param>
        public ModelCollection(IEnumerable<Range<EntityID>> inBounds, IEnumerable<EntityModel> inModels)
            : base(inBounds, inModels) { }

        /// <summary>
        /// Returns the specified <see cref="EntityModel"/>.
        /// </summary>
        /// <param name="inID">A valid, defined <see cref="EntityModel"/> identifier.</param>
        /// <returns>The specified <see cref="EntityModel"/>.</returns>
        public EntityModel Get(EntityID inID)
            => Get<EntityModel>(inID);
    }
}
