using System;
using CsvHelper.Configuration;
using ParquetClassLibrary.Biomes;
using ParquetClassLibrary.Items;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Parquets
{
    /// <summary>
    /// Configurations for a sandbox parquet walking surface.
    /// </summary>
    public sealed class FloorModel : ParquetModel
    {
        #region Class Defaults
        /// <summary>A name to employ for parquets when IsTrench is set, if none is provided.</summary>
        private const string defaultTrenchName = "dark hole";

        /// <summary>The set of values that are allowed for Floor IDs.</summary>
        public static Range<EntityID> Bounds => All.FloorIDs;
        #endregion

        #region Parquet Mechanics
        /// <summary>The tool used to dig out or fill in the floor.</summary>
        public ModificationTool ModTool { get; }

        /// <summary>Player-facing name of the parquet, used when it has been dug out.</summary>
        public string TrenchName { get; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="FloorModel"/> class.
        /// </summary>
        /// <param name="inID">Unique identifier for the parquet.  Cannot be null.</param>
        /// <param name="inName">Player-friendly name of the parquet.  Cannot be null.</param>
        /// <param name="inDescription">Player-friendly description of the parquet.</param>
        /// <param name="inComment">Comment of, on, or by the parquet.</param>
        /// <param name="inItemID">The <see cref="EntityID"/> of the <see cref="Items.ItemModel"/> awarded to the player when a character gathers this parquet.</param>
        /// <param name="inAddsToBiome">Which, if any, <see cref="BiomeModel"/> this parquet helps to generate.</param>
        /// <param name="inAddsToRoom">Describes which, if any, <see cref="Rooms.RoomRecipe"/>(s) this parquet helps form.</param>
        /// <param name="inModTool">The tool used to modify this floor.</param>
        /// <param name="inTrenchName">The name to use for this floor when it has been dug out.</param>
        public FloorModel(EntityID inID, string inName, string inDescription, string inComment,
                     EntityID? inItemID = null, EntityTag inAddsToBiome = null,
                     EntityTag inAddsToRoom = null, ModificationTool inModTool = ModificationTool.None,
                     string inTrenchName = defaultTrenchName)
            : base(Bounds, inID, inName, inDescription, inComment, inItemID ?? EntityID.None,
                   inAddsToBiome ?? EntityTag.None, inAddsToRoom ?? EntityTag.None)
        {
            ModTool = inModTool;
            TrenchName = inTrenchName;
        }
        #endregion

        #region Serialization
        #region Serializer Shim
        /// <summary>
        /// Provides a default public parameterless constructor for a <see cref="FloorModel"/>-like
        /// class that CSVHelper can instantiate.
        /// 
        /// Provides the ability to generate a <see cref="FloorModel"/> from this class.
        /// </summary>
        internal class FloorShim : Serialization.Shims.ParquetParentShim
        {
            /// <summary>The tool used to dig out or fill in the floor.</summary>
            public ModificationTool ModTool;

            /// <summary>Player-facing name of the parquet, used when it has been dug out.</summary>
            public string TrenchName;

            /// <summary>
            /// Converts a shim into the class it corresponds to.
            /// </summary>
            /// <typeparam name="TModel">The type to convert this shim to.</typeparam>
            /// <returns>An instance of a child class of <see cref="ParquetModel"/>.</returns>
            public override TModel ToEntity<TModel>()
            {
                Precondition.IsOfType<TModel, FloorModel>(typeof(TModel).ToString());

                return (TModel)(EntityModel)new FloorModel(ID, Name, Description, Comment, ItemID, AddsToBiome,
                                                           AddsToRoom, ModTool, TrenchName);
            }
        }
        #endregion

        #region Class Map
        /// <summary>
        /// Maps the values in a <see cref="FloorShim"/> to records that CSVHelper recognizes.
        /// </summary>
        internal sealed class FloorClassMap : ClassMap<FloorShim>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="FloorClassMap"/> class.
            /// </summary>
            public FloorClassMap()
            {
                // Properties are ordered by index to facilitate a logical layout in spreadsheet apps.
                Map(m => m.ID).Index(0);
                Map(m => m.Name).Index(1);
                Map(m => m.Description).Index(2);
                Map(m => m.Comment).Index(3);

                Map(m => m.ItemID).Index(4);
                Map(m => m.AddsToBiome).Index(5);
                Map(m => m.AddsToRoom).Index(6);

                Map(m => m.ModTool).Index(7);
                Map(m => m.TrenchName).Index(8);
            }
        }
        #endregion

        /// <summary>Caches a class mapper.</summary>
        private static FloorClassMap classMapCache;

        /// <summary>
        /// Provides the means to map all members of this class to a CSV file.
        /// </summary>
        /// <returns>The member mapping.</returns>
        internal static ClassMap GetClassMap()
            => classMapCache
            ?? (classMapCache = new FloorClassMap());

        /// <summary>
        /// Provides the means to map all members of this class to a CSV file.
        /// </summary>
        /// <returns>The member mapping.</returns>
        internal static Type GetShimType()
            => typeof(FloorShim);
        #endregion
    }
}
