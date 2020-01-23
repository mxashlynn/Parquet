using System;
using CsvHelper.Configuration;
using ParquetClassLibrary.Biomes;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Parquets
{
    /// <summary>
    /// Configurations for large sandbox parquet items, such as furniture or plants.
    /// </summary>
    public sealed class FurnishingModel : ParquetModel
    {
        #region Class Defaults
        /// <summary>The set of values that are allowed for Furnishing IDs.</summary>
        public static Range<EntityID> Bounds => All.FurnishingIDs;
        #endregion

        #region Characteristics
        /// <summary>Indicates whether this <see cref="FurnishingModel"/> may be walked on.</summary>
        public bool IsWalkable { get; }

        /// <summary>Indicates whether this <see cref="FurnishingModel"/> serves as an entry to a <see cref="Room"/>.</summary>
        public bool IsEntry { get; }

        /// <summary>Indicates whether this <see cref="FurnishingModel"/> serves as part of a perimeter of a <see cref="Room"/>.</summary>
        public bool IsEnclosing { get; }

        /// <summary>The <see cref="FurnishingModel"/> to swap with this Furnishing on an open/close action.</summary>
        public EntityID SwapID { get; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="FurnishingModel"/> class.
        /// </summary>
        /// <param name="inID">Unique identifier for the <see cref="FurnishingModel"/>.  Cannot be null.</param>
        /// <param name="inName">Player-friendly name of the <see cref="FurnishingModel"/>.  Cannot be null or empty.</param>
        /// <param name="inItemID">The <see cref="EntityID"/> that represents this <see cref="FurnishingModel"/> in the <see cref="Inventory"/>.</param>
        /// <param name="inDescription">Player-friendly description of the parquet.</param>
        /// <param name="inComment">Comment of, on, or by the parquet.</param>
        /// <param name="inAddsToBiome">Indicates which, if any, <see cref="BiomeModel"/> this parquet helps to generate.</param>
        /// <param name="inAddsToRoom">Describes which, if any, <see cref="Rooms.RoomRecipe"/>(s) this parquet helps form.</param>
        /// <param name="inIsWalkable">If <c>true</c> this <see cref="FurnishingModel"/> may be walked on.</param>
        /// <param name="inIsEntry">If <c>true</c> this <see cref="FurnishingModel"/> serves as an entry to a <see cref="Room"/>.</param>
        /// <param name="inIsEnclosing">If <c>true</c> this <see cref="FurnishingModel"/> serves as part of a perimeter of a <see cref="Room"/>.</param>
        /// <param name="inSwapID">A <see cref="FurnishingModel"/> to swap with this furnishing on open/close actions.</param>
        public FurnishingModel(EntityID inID, string inName, string inDescription, string inComment,
                          EntityID? inItemID = null, EntityTag inAddsToBiome = null,
                          EntityTag inAddsToRoom = null, bool inIsWalkable = false,
                          bool inIsEntry = false, bool inIsEnclosing = false, EntityID? inSwapID = null)
            : base(Bounds, inID, inName, inDescription, inComment, inItemID ?? EntityID.None,
                   inAddsToBiome ?? EntityTag.None, inAddsToRoom ?? EntityTag.None)
        {
            var nonNullSwapID = inSwapID ?? EntityID.None;
            Precondition.IsInRange(nonNullSwapID, Bounds, nameof(inSwapID));

            IsWalkable = inIsWalkable;
            IsEntry = inIsEntry;
            IsEnclosing = inIsEnclosing;
            SwapID = nonNullSwapID;
        }
        #endregion

        #region Serialization
        #region Serializer Shim
        /// <summary>
        /// Provides a default public parameterless constructor for a <see cref="FurnishingModel"/>-like
        /// class that CSVHelper can instantiate.
        /// 
        /// Provides the ability to generate a <see cref="FurnishingModel"/> from this class.
        /// </summary>
        internal class FurnishingShim : ParquetModelShim
        {
            /// <summary>Indicates if the furnishing may be walked on.</summary>
            public bool IsWalkable;

            /// <summary>Indicates if the furnishing may be entered through.</summary>
            public bool IsEntry;

            /// <summary>Indicates if the furnishing acts like a wall.</summary>
            public bool IsEnclosing;

            /// <summary>The furnishing to swap with this furnishing on an open/close action.</summary>
            public EntityID SwapID;

            /// <summary>
            /// Converts a shim into the class it corresponds to.
            /// </summary>
            /// <typeparam name="TModel">The type to convert this shim to.</typeparam>
            /// <returns>An instance of a child class of <see cref="ParquetModel"/>.</returns>
            public override TModel ToEntity<TModel>()
            {
                Precondition.IsOfType<TModel, FurnishingModel>(typeof(TModel).ToString());

                return (TModel)(EntityModel)new FurnishingModel(ID, Name, Description, Comment, ItemID, AddsToBiome,
                                                                AddsToBiome, IsWalkable, IsEntry, IsEnclosing, SwapID);
            }
        }
        #endregion

        #region Class Map
        /// <summary>
        /// Maps the values in a <see cref="FurnishingShim"/> to records that CSVHelper recognizes.
        /// </summary>
        internal sealed class FurnishingClassMap : ClassMap<FurnishingShim>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="FurnishingClassMap"/> class.
            /// </summary>
            public FurnishingClassMap()
            {
                // Properties are ordered by index to facilitate a logical layout in spreadsheet apps.
                Map(m => m.ID).Index(0);
                Map(m => m.Name).Index(1);
                Map(m => m.Description).Index(2);
                Map(m => m.Comment).Index(3);

                Map(m => m.ItemID).Index(4);
                Map(m => m.AddsToBiome).Index(5);
                Map(m => m.AddsToRoom).Index(6);

                Map(m => m.IsWalkable).Index(7);
                Map(m => m.IsEntry).Index(8);
                Map(m => m.IsEnclosing).Index(9);
                Map(m => m.SwapID).Index(10);
            }
        }
        #endregion

        /// <summary>Caches a class mapper.</summary>
        private static FurnishingClassMap classMapCache;

        /// <summary>
        /// Provides the means to map all members of this class to a CSV file.
        /// </summary>
        /// <returns>The member mapping.</returns>
        internal static ClassMap GetClassMap()
            => classMapCache
            ?? (classMapCache = new FurnishingClassMap());

        /// <summary>
        /// Provides the means to map all members of this class to a CSV file.
        /// </summary>
        /// <returns>The member mapping.</returns>
        internal static Type GetShimType()
            => typeof(FurnishingShim);
        #endregion
    }
}
