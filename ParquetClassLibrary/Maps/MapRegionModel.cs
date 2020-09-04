using System;
using System.Linq;
using CsvHelper.Configuration.Attributes;
using ParquetClassLibrary.Biomes;
using ParquetClassLibrary.EditorSupport;
using ParquetClassLibrary.Parquets;
using ParquetClassLibrary.Rooms;

namespace ParquetClassLibrary.Maps
{
    /// <summary>
    /// A playable region of the gameworld, composed of parquets.
    /// </summary>
    public sealed class MapRegionModel : MapModel, IMapRegionEdit
    {
        #region Class Defaults
        /// <summary>Used to indicate an empty grid.</summary>
        public static readonly MapRegionModel Empty = new MapRegionModel(ModelID.None, "Empty Region", "", "");

        /// <summary>The length of each <see cref="MapRegionModel"/> dimension in parquets.</summary>
        public const int ParquetsPerRegionDimension = MapRegionSketch.ChunksPerRegionDimension * MapChunkModel.ParquetsPerChunkDimension;

        /// <summary>The region's dimensions in parquets.</summary>
        public override Vector2D DimensionsInParquets { get; } = new Vector2D(ParquetsPerRegionDimension, ParquetsPerRegionDimension);

        /// <summary>The set of values that are allowed for <see cref="MapRegionModel"/> <see cref="ModelID"/>s.</summary>
        public static Range<ModelID> Bounds
            => All.MapRegionIDs;

        /// <summary>Default color for new regions.</summary>
        internal const string DefaultColor = "#FFFFFFFF";
        #endregion

        #region Characteristics
        #region Whole-Map Characteristics
        /// <summary>What the region is called in-game.</summary>
        [Ignore]
        string IModelEdit.Name
        {
            get => Name;
            set
            {
                IModelEdit editableThis = this;
                editableThis.Name = value;
            }
        }

        /// <summary>A color to display in any empty areas of the region.</summary>
        [Index(5)]
        public string BackgroundColor { get; private set; }

        /// <summary>A color to display in any empty areas of the region.</summary>
        [Ignore]
        string IMapRegionEdit.BackgroundColor { get => BackgroundColor; set => BackgroundColor = value; }

        #region Exit IDs
        /// <summary>The <see cref="ModelID"/> of the region to the north of this one.</summary>
        [Index(6)]
        public ModelID RegionToTheNorth { get; private set; }

        /// <summary>The <see cref="ModelID"/> of the region to the north of this one.</summary>
        [Ignore]
        ModelID IMapRegionEdit.RegionToTheNorthID { get => RegionToTheNorth; set => RegionToTheNorth = value; }

        /// <summary>The <see cref="ModelID"/> of the region to the east of this one.</summary>
        [Index(7)]
        public ModelID RegionToTheEast { get; private set; }

        /// <summary>The <see cref="ModelID"/> of the region to the east of this one.</summary>
        [Ignore]
        ModelID IMapRegionEdit.RegionToTheEastID { get => RegionToTheEast; set => RegionToTheEast = value; }

        /// <summary>The <see cref="ModelID"/> of the region to the south of this one.</summary>
        [Index(8)]
        public ModelID RegionToTheSouth { get; private set; }

        /// <summary>The <see cref="ModelID"/> of the region to the south of this one.</summary>
        [Ignore]
        ModelID IMapRegionEdit.RegionToTheSouthID { get => RegionToTheSouth; set => RegionToTheSouth = value; }

        /// <summary>The <see cref="ModelID"/> of the region to the west of this one.</summary>
        [Index(9)]
        public ModelID RegionToTheWest { get; private set; }

        /// <summary>The <see cref="ModelID"/> of the region to the west of this one.</summary>
        [Ignore]
        ModelID IMapRegionEdit.RegionToTheWestID { get => RegionToTheWest; set => RegionToTheWest = value; }

        /// <summary>The <see cref="ModelID"/> of the region above this one.</summary>
        [Index(10)]
        public ModelID RegionAbove { get; private set; }

        /// <summary>The <see cref="ModelID"/> of the region above this one.</summary>
        [Ignore]
        ModelID IMapRegionEdit.RegionAboveID { get => RegionAbove; set => RegionAbove = value; }

        /// <summary>The <see cref="ModelID"/> of the region below this one.</summary>
        [Index(11)]
        public ModelID RegionBelow { get; private set; }

        /// <summary>The <see cref="ModelID"/> of the region below this one.</summary>
        [Ignore]
        ModelID IMapRegionEdit.RegionBelowID { get => RegionBelow; set => RegionBelow = value; }
        #endregion
        #endregion

        #region Map Contents
        /// <summary>The statuses of parquets in the chunk.</summary>
        [Index(12)]
        public ParquetStatusGrid ParquetStatuses { get; }

        /// <summary>
        /// Parquets that make up the region.  If changing or replacing one of these,
        /// remember to update the corresponding element in <see cref="ParquetStatuses"/>!
        /// </summary>
        [Index(13)]
        public override ParquetStackGrid ParquetDefinitions { get; }

        /// <summary>
        /// All of the <see cref="Rooms.Room"/>s detected in the <see cref="MapRegionModel"/>.
        /// </summary>
        [Ignore]
        public RoomCollection Rooms { get; private set; }
        #endregion
        #endregion

        #region Initialization
        /// <summary>
        /// Constructs a new instance of the <see cref="MapRegionModel"/> class.
        /// </summary>
        /// <param name="inID">Unique identifier for the map.  Cannot be null.</param>
        /// <param name="inName">The player-facing name of the new region.</param>
        /// <param name="inDescription">Player-friendly description of the map.</param>
        /// <param name="inComment">Comment of, on, or by the map.</param>
        /// <param name="inRevision">An option revision count.</param>
        /// <param name="inBackgroundColor">A color to show in the new region when no parquet is present.</param>
        /// <param name="inRegionToTheNorth">The <see cref="ModelID"/> of the region to the north of this one.</param>
        /// <param name="inRegionToTheEast">The <see cref="ModelID"/> of the region to the east of this one.</param>
        /// <param name="inRegionToTheSouth">The <see cref="ModelID"/> of the region to the south of this one.</param>
        /// <param name="inRegionToTheWest">The <see cref="ModelID"/> of the region to the west of this one.</param>
        /// <param name="inRegionAbove">The <see cref="ModelID"/> of the region above this one.</param>
        /// <param name="inRegionBelow">The <see cref="ModelID"/> of the region below this one.</param>
        /// <param name="inParquetStatuses">The statuses of the collected parquets.</param>
        /// <param name="inParquetDefinitions">The definitions of the collected parquets.</param>
        public MapRegionModel(ModelID inID, string inName, string inDescription, string inComment, int inRevision = 0,
                              string inBackgroundColor = DefaultColor,
                              ModelID? inRegionToTheNorth = null,
                              ModelID? inRegionToTheEast = null,
                              ModelID? inRegionToTheSouth = null,
                              ModelID? inRegionToTheWest = null,
                              ModelID? inRegionAbove = null,
                              ModelID? inRegionBelow = null,
                              ParquetStatusGrid inParquetStatuses = null,
                              ParquetStackGrid inParquetDefinitions = null)
            : base(Bounds, inID, inName, inDescription, inComment, inRevision)
        {
            var nonNullRegionToTheNorth = inRegionToTheNorth ?? ModelID.None;
            var nonNullRegionToTheEast = inRegionToTheEast ?? ModelID.None;
            var nonNullRegionToTheSouth = inRegionToTheSouth ?? ModelID.None;
            var nonNullRegionToTheWest = inRegionToTheWest ?? ModelID.None;
            var nonNullRegionAbove = inRegionAbove ?? ModelID.None;
            var nonNullRegionBelow = inRegionBelow ?? ModelID.None;
            var nonNullParquetStatuses = inParquetStatuses ?? new ParquetStatusGrid(ParquetsPerRegionDimension, ParquetsPerRegionDimension);
            var nonNullParquetDefinitions = inParquetDefinitions ?? new ParquetStackGrid(ParquetsPerRegionDimension, ParquetsPerRegionDimension);

            Precondition.IsInRange(nonNullRegionToTheNorth, Bounds, nameof(inRegionToTheNorth));
            Precondition.IsInRange(nonNullRegionToTheEast, Bounds, nameof(inRegionToTheEast));
            Precondition.IsInRange(nonNullRegionToTheSouth, Bounds, nameof(inRegionToTheSouth));
            Precondition.IsInRange(nonNullRegionToTheWest, Bounds, nameof(inRegionToTheWest));
            Precondition.IsInRange(nonNullRegionAbove, Bounds, nameof(inRegionAbove));
            Precondition.IsInRange(nonNullRegionBelow, Bounds, nameof(inRegionBelow));

            BackgroundColor = inBackgroundColor;
            RegionToTheNorth = nonNullRegionToTheNorth;
            RegionToTheEast = nonNullRegionToTheEast;
            RegionToTheSouth = nonNullRegionToTheSouth;
            RegionToTheWest = nonNullRegionToTheWest;
            RegionAbove = nonNullRegionAbove;
            RegionBelow = nonNullRegionBelow;
            ParquetStatuses = nonNullParquetStatuses;
            ParquetDefinitions = nonNullParquetDefinitions;
        }
        #endregion

        #region Analysis
        /// <summary>
        /// Determines which <see cref="BiomeRecipe"/> the given <see cref="MapRegionModel"/> corresponds to.
        /// </summary>
        /// <remarks>
        /// This method assumes that <see cref="MapRegionModel.Rooms"/> has already been populated.
        /// </remarks>
        /// <returns>The appropriate <see cref="ModelID"/>.</returns>
        public ModelID GetBiome()
        {
            var result = BiomeRecipe.None.ID;
            foreach (BiomeRecipe biome in All.Biomes)
            {
                result = FindBiomeByTag(this, biome);
                if (result != BiomeRecipe.None.ID)
                {
                    break;
                }
            }
            // TODO Log this result as INFO or WARNING.
            return result;

            #region Local Helper Methods
            // Determines if the given BiomeRecipe matches the given Region.
            //     inRegion -> The MapRegionModel to test.
            //     inBiome -> The BiomeRecipe to test against.
            // Returns the given BiomeRecipe's ModelID if they match, otherwise returns the ModelID for the default biome.
            static ModelID FindBiomeByTag(MapRegionModel inRegion, BiomeRecipe inBiome)
            {
                // TODO The following FOR EACH seems to make no sense in that it does not examine the element it is iterating over!
                foreach (ModelTag biomeElement in inBiome.ParquetCriteria)
                {
                    // Prioritization of biome categories is hard-coded in the following way:
                    //    1 Room-based Biomes supercede
                    //    2 Liquid-based Biomes supercede
                    //    3 Land-based Biomes supercede
                    //    4 the default Biome.
                    if ((inBiome.IsRoomBased
                            && GetParquetsInRooms(inRegion) <= BiomeConfiguration.RoomThreshold
                            && ConstitutesBiome(inRegion, inBiome, BiomeConfiguration.RoomThreshold))
                        || (inBiome.IsLiquidBased
                            && ConstitutesBiome(inRegion, inBiome, BiomeConfiguration.LiquidThreshold))
                        || ConstitutesBiome(inRegion, inBiome, BiomeConfiguration.LandThreshold))
                    {
                        return inBiome.ID;
                    }
                }
                return BiomeRecipe.None.ID;
            }

            // Determines the number of individual parquets that are present inside Rooms in the given MapRegionModel.
            //     inRegion -> The region to consider.
            // Returns the number of parquets that are part of a known Room.
            static ModelID GetParquetsInRooms(MapRegionModel inRegion)
            {
                var parquetsInRoom = 0;

                // TODO This might be a good place to optimise.
                for (var y = 0; y < inRegion.ParquetDefinitions.Rows; y++)
                {
                    for (var x = 0; x < inRegion.ParquetDefinitions.Columns; x++)
                    {
                        if (inRegion.Rooms.Any(room => room.ContainsPosition(new Vector2D(x, y))))
                        {
                            // Note that we are counting every parquet, including collectibles.
                            parquetsInRoom += inRegion.ParquetDefinitions[y, x].Count;
                        }
                    }
                }

                return parquetsInRoom;
            }

            // Determines if the given region has enough parquets contributing to the given biome to exceed the given threshold.
            //     inRegion -> The region to test.
            //     inBiome -> The biome to test against.
            //     inThreshold -> A total number of parquets that must be met for the region to qualify.
            // Returns true if enough parquets contribute to the biome, false otherwise.
            static bool ConstitutesBiome(MapRegionModel inRegion, BiomeRecipe inBiome, int inThreshold)
            {
                foreach (ModelTag biomeTag in inBiome.ParquetCriteria)
                {
                    // TODO This logic needs to be checked, at a glance it seems wrong.
                    if (CountMeetsOrExceedsThreshold(inRegion, parquet => parquet.AddsToBiome == biomeTag, inThreshold))
                    {
                        return true;
                    }
                }
                return false;
            }

            // Determines if the region has enough parquets satisfying the given predicate to meet or exceed the given threshold.
            //     inRegion -> The region to test.
            //     inPredicate -> A predicate indicating if the parquet should be counted.
            //     inThreshold -> A total number of parquets that must be met for the region to qualify.
            // Returns true if enough parquets satisfy the conditions given, false otherwise.
            static bool CountMeetsOrExceedsThreshold(MapRegionModel inRegion, Predicate<ParquetModel> inPredicate, int inThreshold)
            {
                var count = 0;

                foreach (ParquetStack stack in inRegion.ParquetDefinitions)
                {
                    if (inPredicate(All.Floors.Get<FloorModel>(stack.FloorID)))
                    {
                        count++;
                    }
                    if (inPredicate(All.Blocks.Get<BlockModel>(stack.BlockID)))
                    {
                        count++;
                    }
                    if (inPredicate(All.Furnishings.Get<FurnishingModel>(stack.FurnishingID)))
                    {
                        count++;
                    }
                    if (inPredicate(All.Collectibles.Get<CollectibleModel>(stack.CollectibleID)))
                    {
                        count++;
                    }
                }

                return count >= inThreshold;
            }
            #endregion
        }
        #endregion

        #region Utilities
        /// <summary>
        /// Describes the <see cref="MapRegionModel"/>.
        /// </summary>
        /// <returns>A <see cref="string"/> that represents the current <see cref="MapRegionModel"/>.</returns>
        public override string ToString()
            => $"Region {Name} {base.ToString()}";
        #endregion
    }
}
