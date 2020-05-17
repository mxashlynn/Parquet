using CsvHelper.Configuration.Attributes;
using ParquetClassLibrary.Biomes;

namespace ParquetClassLibrary.Parquets
{
    /// <summary>
    /// Configurations for large sandbox parquet items, such as furniture or plants.
    /// </summary>
    public sealed class FurnishingModel : ParquetModel
    {
        #region Class Defaults
        /// <summary>The set of values that are allowed for Furnishing IDs.</summary>
        public static Range<ModelID> Bounds
            => All.FurnishingIDs;
        #endregion

        #region Characteristics
        /// <summary>Indicates whether this <see cref="FurnishingModel"/> may be walked on.</summary>
        [Index(7)]
        public bool IsWalkable { get; }

        /// <summary>Indicates if and how this <see cref="FurnishingModel"/> serves as an entry to a <see cref="Rooms.Room"/> or <see cref="Maps.MapRegion"/>.</summary>
        [Index(8)]
        public EntryType Entry { get; }

        /// <summary>Indicates whether this <see cref="FurnishingModel"/> serves as part of a perimeter of a <see cref="Rooms.Room"/>.</summary>
        [Index(9)]
        public bool IsEnclosing { get; }

        /// <summary>Whether or not the <see cref="FurnishingModel"/> is flammable.</summary>
        [Index(10)]
        public bool IsFlammable { get; }

        /// <summary>The <see cref="FurnishingModel"/> to swap with this Furnishing on an open/close action.</summary>
        [Index(11)]
        public ModelID SwapID { get; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="FurnishingModel"/> class.
        /// </summary>
        /// <param name="inID">Unique identifier for the <see cref="FurnishingModel"/>.  Cannot be null.</param>
        /// <param name="inName">Player-friendly name of the <see cref="FurnishingModel"/>.  Cannot be null or empty.</param>
        /// <param name="inDescription">Player-friendly description of the parquet.</param>
        /// <param name="inComment">Comment of, on, or by the parquet.</param>
        /// <param name="inItemID">The <see cref="ModelID"/> that represents this <see cref="FurnishingModel"/> in the <see cref="Items.Inventory"/>.</param>
        /// <param name="inAddsToBiome">Indicates which, if any, <see cref="BiomeModel"/> this parquet helps to generate.</param>
        /// <param name="inAddsToRoom">Describes which, if any, <see cref="Rooms.RoomRecipe"/>(s) this parquet helps form.</param>
        /// <param name="inIsWalkable">If <c>true</c> this <see cref="FurnishingModel"/> may be walked on.</param>
        /// <param name="inEntry">If <c>true</c> this <see cref="FurnishingModel"/> serves as an entry to a <see cref="Rooms.Room"/>.</param>
        /// <param name="inIsEnclosing">If <c>true</c> this <see cref="FurnishingModel"/> serves as part of a perimeter of a <see cref="Rooms.Room"/>.</param>
        /// <param name="inIsFlammable">If <c>true</c> this <see cref="FurnishingModel"/> may catch fire.</param>
        /// <param name="inSwapID">A <see cref="FurnishingModel"/> to swap with this furnishing on open/close actions.</param>
        public FurnishingModel(ModelID inID, string inName, string inDescription, string inComment,
                          ModelID? inItemID = null, ModelTag inAddsToBiome = null,
                          ModelTag inAddsToRoom = null, bool inIsWalkable = false,
                          EntryType inEntry = EntryType.None, bool inIsEnclosing = false,
                          bool inIsFlammable = false, ModelID? inSwapID = null)
            : base(Bounds, inID, inName, inDescription, inComment, inItemID ?? ModelID.None,
                   inAddsToBiome ?? ModelTag.None, inAddsToRoom ?? ModelTag.None)
        {
            var nonNullSwapID = inSwapID ?? ModelID.None;
            Precondition.IsInRange(nonNullSwapID, Bounds, nameof(inSwapID));

            IsWalkable = inIsWalkable;
            Entry = inEntry;
            IsEnclosing = inIsEnclosing;
            IsFlammable = inIsFlammable;
            SwapID = nonNullSwapID;
        }
        #endregion
    }
}
