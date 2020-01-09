using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary
{
    /// <summary>
    /// Collects a group of <see cref="EntityModel"/>s.
    /// Provides bounds-checking and type-checking against <typeparamref name="TParentType"/>.
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
    public class ModelCollection<TParentType> : IReadOnlyCollection<TParentType> where TParentType : EntityModel
    {
        /// <summary>A value to use in place of uninitialized <see cref="ModelCollection{T}"/>s.</summary>
        public static readonly ModelCollection<TParentType> Default = new ModelCollection<TParentType>(
            new List<Range<EntityID>> { new Range<EntityID>(int.MinValue, int.MaxValue) },
            Enumerable.Empty<EntityModel>());

        /// <summary>The internal collection mechanism.</summary>
        private IReadOnlyDictionary<EntityID, EntityModel> Models { get; }

        /// <summary>The bounds within which all collected <see cref="EntityModel"/>s must be defined.</summary>
        private List<Range<EntityID>> Bounds { get; }

        /// <summary>The number of <see cref="EntityModel"/>s in the <see cref="ModelCollection{T}"/>.</summary>
        public int Count => Models?.Count ?? 0;

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="ModelCollection{T}"/> class.
        /// </summary>
        /// <param name="inBounds">The bounds within which the collected <see cref="EntityID"/>s are defined.</param>
        /// <param name="inModels">The <see cref="EntityModel"/>s to collect.  Cannot be null.</param>
        public ModelCollection(List<Range<EntityID>> inBounds, IEnumerable<EntityModel> inModels)
        {
            Precondition.IsNotNull(inModels, nameof(inModels));

            // All Collections of EntitieModels implicitly contain the None model.
            var baseDictionary = new Dictionary<EntityID, EntityModel> { { EntityID.None, null } };
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

            Bounds = inBounds;
            Models = baseDictionary;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelCollection{T}"/> class.
        /// </summary>
        /// <param name="inBounds">The bounds within which the collected <see cref="EntityID"/>s are defined.</param>
        /// <param name="inModels">The <see cref="EntityModel"/>s to collect.  Cannot be null.</param>
        public ModelCollection(Range<EntityID> inBounds, IEnumerable<EntityModel> inModels) :
            this(new List<Range<EntityID>> { inBounds }, inModels) { }
        #endregion

        #region Collection Access
        /// <summary>
        /// Determines whether the <see cref="ModelCollection{T}"/> contains the specified <see cref="EntityModel"/>.
        /// </summary>
        /// <param name="inModel">The <see cref="EntityModel"/> to find.</param>
        /// <returns><c>true</c> if the <see cref="EntityModel"/> was found; <c>false</c> otherwise.</returns>
        public bool Contains(EntityModel inModel)
        {
            Precondition.IsNotNull(inModel);

            return Models.ContainsKey(inModel.ID);
        }

        /// <summary>
        /// Determines whether the <see cref="ModelCollection{T}"/> contains an <see cref="EntityModel"/> with the specified <see cref="EntityID"/>.
        /// </summary>
        /// <param name="inID">The <see cref="EntityID"/> of the <see cref="EntityModel"/> to find.</param>
        /// <returns><c>true</c> if the <see cref="EntityID"/> was found; <c>false</c> otherwise.</returns>
        public bool Contains(EntityID inID)
        {
            // TODO Remove this test after debugging.
            Precondition.IsInRange(inID, Bounds, nameof(inID));

            return Models.ContainsKey(inID);
        }

        /// <summary>
        /// Returns the specified <typeparamref name="T"/>.
        /// </summary>
        /// <param name="inID">A valid, defined <typeparamref name="T"/> identifier.</param>
        /// <typeparam name="T">
        /// The type of <typeparamref name="TParentType"/> sought.  Must correspond to the given <paramref name="inID"/>.
        /// </typeparam>
        /// <returns>The specified <typeparamref name="T"/> model.</returns>
        public T Get<T>(EntityID inID) where T : TParentType
        {
            Precondition.IsInRange(inID, Bounds, nameof(inID));

            return (T)Models[inID];
        }

        /// <summary>
        /// Exposes an <see cref="IEnumerator{ParentType}"/> to support simple iteration.
        /// </summary>
        /// <remarks>Used by LINQ. No accessibility modifiers are valid in this context.</remarks>
        /// <returns>An enumerator.</returns>
        IEnumerator<TParentType> IEnumerable<TParentType>.GetEnumerator()
            => Models.Values.Cast<TParentType>().GetEnumerator();

        /// <summary>
        /// Exposes an <see cref="IEnumerator"/> to support simple iteration.
        /// </summary>
        /// <remarks>Used by LINQ. No accessibility modifiers are valid in this context.</remarks>
        /// <returns>An enumerator.</returns>
        IEnumerator IEnumerable.GetEnumerator()
            => Models.Values.GetEnumerator();

        /// <summary>
        /// Retrieves an enumerator for the <see cref="ModelCollection{T}"/>.
        /// </summary>
        /// <returns>An enumerator that iterates through the collection.</returns>
        public IEnumerator<EntityModel> GetEnumerator()
            => Models.Values.GetEnumerator();
        #endregion

        #region Utilities
        /// <summary>
        /// Returns a <see langword="string"/> that represents the current <see cref="ModelCollection{T}"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override string ToString()
        {
            var allBounds = new StringBuilder();
            foreach (var bound in Bounds)
            {
                allBounds.Append($"{bound.ToString()} ");
            }
            return $"Collects {typeof(TParentType)} over {allBounds}.";
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
        /// <summary>A value to use in place of uninitialized <see cref="ModelCollection{T}"/>s.</summary>
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
        /// Returns the specified <see cref="EntityModel"/>.
        /// </summary>
        /// <param name="inID">A valid, defined <see cref="EntityModel"/> identifier.</param>
        /// <returns>The specified <see cref="EntityModel"/>.</returns>
        public EntityModel Get(EntityID inID)
            => Get<EntityModel>(inID);
    }
}
