using System;
using System.Linq;
using CsvHelper.Configuration.Attributes;
using ParquetClassLibrary.Biomes;
using ParquetClassLibrary.Parquets;
using ParquetClassLibrary.Rooms;

namespace ParquetClassLibrary.Maps
{
    /// <summary>
    /// A playable region in sandbox.
    /// </summary>
    public sealed class MapRegion : MapModel, IMapRegionEdit
    {
        #region Class Defaults
        /// <summary>Used to indicate an empty grid.</summary>
        public static readonly MapRegion Empty = new MapRegion(ModelID.None, "Empty Region");

        /// <summary>The length of each <see cref="MapRegion"/> dimension in <see cref="ChunkTypeGrid"/>s.</summary>
        public const int ChunksPerRegionDimension = 4;

        /// <summary>The length of each <see cref="MapRegion"/> dimension in parquets.</summary>
        public const int ParquetsPerRegionDimension = ChunksPerRegionDimension * MapChunk.ParquetsPerChunkDimension;

        /// <summary>The region's dimensions in parquets.</summary>
        public override Vector2D DimensionsInParquets { get; } = new Vector2D(ParquetsPerRegionDimension, ParquetsPerRegionDimension);

        /// <summary>The set of values that are allowed for <see cref="MapRegion"/> <see cref="ModelID"/>s.</summary>
        public static Range<ModelID> Bounds
            => All.MapRegionIDs;

        /// <summary>Default name for new regions.</summary>
        internal const string DefaultName = "New Region";

        /// <summary>Default color for new regions.</summary>
        internal const string DefaultColor = "#FFFFFFFF";
        #endregion

        #region Characteristics
        #region Whole-Map Characteristics
        /// <summary>What the region is called in-game.</summary>
        [Ignore]
        string IMapRegionEdit.Name
        {
            get => Name;
            set
            {
                IModelEdit editableThis = this;
                editableThis.Name = value;
            }
        }

        /// <summary>A color to display in any empty areas of the region.</summary>
        [Index(6)]
        public string BackgroundColor { get; private set; }

        /// <summary>A color to display in any empty areas of the region.</summary>
        [Ignore]
        string IMapRegionEdit.BackgroundColor { get => BackgroundColor; set => BackgroundColor = value; }
        #endregion

        #region Map Contents
        /// <summary>The statuses of parquets in the chunk.</summary>
        [Index(7)]
        public override ParquetStatusGrid ParquetStatuses { get; }

        /// <summary>
        /// Parquets that make up the region.  If changing or replacing one of these,
        /// remember to update the corresponding element in <see cref="ParquetStatuses"/>!
        /// </summary>
        [Index(8)]
        public override ParquetStackGrid ParquetDefinitions { get; }

        /// <summary>
        /// All of the <see cref="Rooms.Room"/>s detected in the <see cref="MapRegion"/>.
        /// </summary>
        [Ignore]
        public RoomCollection Rooms { get; private set; }
        #endregion
        #endregion

        #region Initialization
        /// <summary>
        /// Constructs a new instance of the <see cref="MapRegion"/> class.
        /// </summary>
        /// <param name="inID">Unique identifier for the map.  Cannot be null.</param>
        /// <param name="inName">The player-facing name of the new region.</param>
        /// <param name="inDescription">Player-friendly description of the map.</param>
        /// <param name="inComment">Comment of, on, or by the map.</param>
        /// <param name="inRevision">An option revision count.</param>
        /// <param name="inBackgroundColor">A color to show in the new region when no parquet is present.</param>
        /// <param name="inParquetStatuses">The statuses of the collected parquets.</param>
        /// <param name="inParquetDefinitions">The definitions of the collected parquets.</param>
        public MapRegion(ModelID inID, string inName = null, string inDescription = null, string inComment = null,
                         int inRevision = 0, string inBackgroundColor = DefaultColor,
                         ParquetStatusGrid inParquetStatuses = null,
                         ParquetStackGrid inParquetDefinitions = null)
            : base(Bounds, inID, string.IsNullOrEmpty(inName) ? DefaultName : inName, inDescription, inComment, inRevision)
        {
            BackgroundColor = inBackgroundColor;
            ParquetStatuses = inParquetStatuses ?? new ParquetStatusGrid(ParquetsPerRegionDimension, ParquetsPerRegionDimension);
            ParquetDefinitions = inParquetDefinitions ?? new ParquetStackGrid(ParquetsPerRegionDimension, ParquetsPerRegionDimension);
        }
        #endregion

        #region Analysis
        /// <summary>
        /// Determines which <see cref="BiomeModel"/> the given <see cref="MapRegion"/> corresponds to.
        /// </summary>
        /// <remarks>
        /// This method assumes that <see cref="MapRegion.Rooms"/> has already been populated.
        /// </remarks>
        /// <returns>The appropriate <see cref="ModelID"/>.</returns>
        public ModelID GetBiome()
        {
            var result = BiomeModel.None.ID;
            foreach (BiomeModel biome in All.Biomes)
            {
                result = FindBiomeByTag(this, biome);
                if (result != BiomeModel.None.ID)
                {
                    break;
                }
            }
            // TODO Log this result as INFO or WARNING.
            return result;

            #region Local Helper Methods
            // Determines if the given BiomeModel matches the given Region.
            //     inRegion -> The MapRegion to test.
            //     inBiome -> The BiomeModel to test against.
            // Returns the given BiomeModel's ModelID if they match, otherwise returns the ModelID for the default biome.
            static ModelID FindBiomeByTag(MapRegion inRegion, BiomeModel inBiome)
            {
                foreach (ModelTag biomeTag in inBiome.ParquetCriteria)
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
                return BiomeModel.None.ID;
            }

            // Determines the number of individual parquets that are present inside Rooms in the given MapRegion.
            //     inRegion -> The region to consider.
            // Returns the number of parquets that are part of a known Room.
            static ModelID GetParquetsInRooms(MapRegion inRegion)
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
            static bool ConstitutesBiome(MapRegion inRegion, BiomeModel inBiome, int inThreshold)
            {
                foreach (ModelTag biomeTag in inBiome.ParquetCriteria)
                {
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
            static bool CountMeetsOrExceedsThreshold(MapRegion inRegion, Predicate<ParquetModel> inPredicate, int inThreshold)
            {
                var count = 0;

                foreach (ParquetStack stack in inRegion.ParquetDefinitions)
                {
                    if (inPredicate(All.Parquets.Get<FloorModel>(stack.Floor)))
                    {
                        count++;
                    }
                    if (inPredicate(All.Parquets.Get<BlockModel>(stack.Block)))
                    {
                        count++;
                    }
                    if (inPredicate(All.Parquets.Get<FurnishingModel>(stack.Furnishing)))
                    {
                        count++;
                    }
                    if (inPredicate(All.Parquets.Get<CollectibleModel>(stack.Collectible)))
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
        /// Describes the <see cref="MapRegion"/>.
        /// </summary>
        /// <returns>A <see cref="string"/> that represents the current <see cref="MapRegion"/>.</returns>
        public override string ToString()
            => $"Region {Name} {base.ToString()}";
        #endregion
    }
}
