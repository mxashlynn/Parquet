using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using CsvHelper.Configuration.Attributes;
using Parquet.Biomes;
using Parquet.Parquets;
using Parquet.Properties;
using Parquet.Rooms;

namespace Parquet.Regions
{
    // TODO HERE!!!!!!!!!!!!!!!!!!!!!!!    Rewrite this class so it conforms to the diagram we came up with!


    /// <summary>
    /// A playable region of the gameworld, composed of parquets.
    /// </summary>
    [SuppressMessage("Design", "CA1033:Interface methods should be callable by subtypes",
                     Justification = "By design, subtypes of Model should never themselves use IMutableModel or derived interfaces to access their own members.  The IMutableModel family of interfaces is for external types that require read/write access.")]
    public partial class RegionModel : Model, IMapConnections, IMutableRegionModel
    {
        #region Class Defaults
        /// <summary>Used to indicate an empty grid.</summary>
        public static readonly RegionModel Empty = new RegionModel(ModelID.None, "Empty Region", "", "");

        /// <summary>The length of each <see cref="RegionModel"/> dimension in parquets.</summary>
        public const int ParquetsPerRegionDimension = MapRegionSketch.ChunksPerRegionDimension * MapChunkModel.ParquetsPerChunkDimension;

        /// <summary>The region's dimensions in parquets.</summary>
        public Vector2D DimensionsInParquets { get; } = new Vector2D(ParquetsPerRegionDimension, ParquetsPerRegionDimension);

        /// <summary>The set of values that are allowed for <see cref="RegionModel"/> <see cref="ModelID"/>s.</summary>
        public static Range<ModelID> Bounds
            => All.MapRegionIDs;

        /// <summary>Default color for new regions.</summary>
        internal const string DefaultColor = "#FFFFFFFF";
        #endregion

        #region Characteristics
        #region Whole-Map Characteristics
        /// <summary>A color to display in any empty areas of the region.</summary>
        [Index(5)]
        public string BackgroundColor { get; private set; }

        /// <summary>The <see cref="ModelID"/> of the region to the north of this one.</summary>
        [Index(6)]
        public ModelID RegionToTheNorth { get; private set; }

        /// <summary>The <see cref="ModelID"/> of the region to the east of this one.</summary>
        [Index(7)]
        public ModelID RegionToTheEast { get; private set; }

        /// <summary>The <see cref="ModelID"/> of the region to the south of this one.</summary>
        [Index(8)]
        public ModelID RegionToTheSouth { get; private set; }

        /// <summary>The <see cref="ModelID"/> of the region to the west of this one.</summary>
        [Index(9)]
        public ModelID RegionToTheWest { get; private set; }

        /// <summary>The <see cref="ModelID"/> of the region above this one.</summary>
        [Index(10)]
        public ModelID RegionAbove { get; private set; }

        /// <summary>The <see cref="ModelID"/> of the region below this one.</summary>
        [Index(11)]
        public ModelID RegionBelow { get; private set; }
        #endregion

        #region Map Contents
        /// <summary>The statuses of parquets in the chunk.</summary>
        [Index(12)]
        // TODO [MAP EDITOR] [API] Should this be an IReadOnlyGrid<ParquetStatus>es instead?
        public ParquetStatusPackGrid ParquetStatuses { get; }

        /// <summary>
        /// Parquets that make up the region.  If changing or replacing one of these,
        /// remember to update the corresponding element in <see cref="ParquetStatuses"/>!
        /// </summary>
        [Index(13)]
        public override ParquetModelPackGrid ParquetDefinitions { get; }

        /// <summary>
        /// All of the <see cref="Room"/>s detected in the <see cref="RegionModel"/>.
        /// </summary>
        [Ignore]
        public IReadOnlyCollection<Room> Rooms { get; private set; }
        #endregion
        #endregion

        #region Initialization
        /// <summary>
        /// Constructs a new instance of the <see cref="RegionModel"/> class.
        /// </summary>
        /// <param name="inID">Unique identifier for the <see cref="RegionModel"/>.  Cannot be null.</param>
        /// <param name="inName">The player-facing name of the <see cref="RegionModel"/>.</param>
        /// <param name="inDescription">Player-friendly description of the <see cref="RegionModel"/>.</param>
        /// <param name="inComment">Comment of, on, or by the <see cref="RegionModel"/>.</param>
        /// <param name="inTags">Any additional information about the <see cref="RegionModel"/>.</param>
        /// <param name="inBackgroundColor">A color to show in the <see cref="RegionModel"/> when no parquets are present at a location.</param>
        /// <param name="inRegionToTheNorth">The <see cref="ModelID"/> of the <see cref="RegionModel"/> to the north of this one.</param>
        /// <param name="inRegionToTheEast">The <see cref="ModelID"/> of the <see cref="RegionModel"/> to the east of this one.</param>
        /// <param name="inRegionToTheSouth">The <see cref="ModelID"/> of the <see cref="RegionModel"/> to the south of this one.</param>
        /// <param name="inRegionToTheWest">The <see cref="ModelID"/> of the <see cref="RegionModel"/> to the west of this one.</param>
        /// <param name="inRegionAbove">The <see cref="ModelID"/> of the <see cref="RegionModel"/> above this one.</param>
        /// <param name="inRegionBelow">The <see cref="ModelID"/> of the <see cref="RegionModel"/> below this one.</param>
        /// <param name="inParquetStatuses">The statuses of the parquets making up this <see cref="RegionModel"/>.</param>
        /// <param name="inParquetDefinitions">The definitions of the parquets making up this <see cref="RegionModel"/>.</param>
        public RegionModel(ModelID inID, string inName, string inDescription, string inComment,
                           IEnumerable<ModelTag> inTags = null,
                           string inBackgroundColor = DefaultColor,
                           ModelID? inRegionToTheNorth = null,
                           ModelID? inRegionToTheEast = null,
                           ModelID? inRegionToTheSouth = null,
                           ModelID? inRegionToTheWest = null,
                           ModelID? inRegionAbove = null,
                           ModelID? inRegionBelow = null,
                           ParquetStatusPackGrid inParquetStatuses = null,
                           ParquetModelPackGrid inParquetDefinitions = null)
            : base(Bounds, inID, inName, inDescription, inComment, inTags)
        {
            var nonNullRegionToTheNorth = inRegionToTheNorth ?? ModelID.None;
            var nonNullRegionToTheEast = inRegionToTheEast ?? ModelID.None;
            var nonNullRegionToTheSouth = inRegionToTheSouth ?? ModelID.None;
            var nonNullRegionToTheWest = inRegionToTheWest ?? ModelID.None;
            var nonNullRegionAbove = inRegionAbove ?? ModelID.None;
            var nonNullRegionBelow = inRegionBelow ?? ModelID.None;
            var nonNullParquetStatuses = inParquetStatuses ?? new ParquetStatusPackGrid(ParquetsPerRegionDimension, ParquetsPerRegionDimension);
            var nonNullParquetDefinitions = inParquetDefinitions ?? new ParquetModelPackGrid(ParquetsPerRegionDimension, ParquetsPerRegionDimension);

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

        #region IMapRegionEdit Implementation
        /// <summary>What the region is called in-game.</summary>
        [Ignore]
        string IMutableModel.Name
        {
            get => Name;
            set
            {
                IMutableModel editableThis = this;
                editableThis.Name = value;
            }
        }

        /// <summary>A color to display in any empty areas of the region.</summary>
        [Ignore]
        string IMutableRegionModel.BackgroundColor { get => BackgroundColor; set => BackgroundColor = value; }

        /// <summary>The <see cref="ModelID"/> of the region to the north of this one.</summary>
        [Ignore]
        ModelID IMutableRegionModel.RegionToTheNorthID { get => RegionToTheNorth; set => RegionToTheNorth = value; }

        /// <summary>The <see cref="ModelID"/> of the region to the east of this one.</summary>
        [Ignore]
        ModelID IMutableRegionModel.RegionToTheEastID { get => RegionToTheEast; set => RegionToTheEast = value; }

        /// <summary>The <see cref="ModelID"/> of the region to the south of this one.</summary>
        [Ignore]
        ModelID IMutableRegionModel.RegionToTheSouthID { get => RegionToTheSouth; set => RegionToTheSouth = value; }

        /// <summary>The <see cref="ModelID"/> of the region to the west of this one.</summary>
        [Ignore]
        ModelID IMutableRegionModel.RegionToTheWestID { get => RegionToTheWest; set => RegionToTheWest = value; }

        /// <summary>The <see cref="ModelID"/> of the region above this one.</summary>
        [Ignore]
        ModelID IMutableRegionModel.RegionAboveID { get => RegionAbove; set => RegionAbove = value; }

        /// <summary>The <see cref="ModelID"/> of the region below this one.</summary>
        [Ignore]
        ModelID IMutableRegionModel.RegionBelowID { get => RegionBelow; set => RegionBelow = value; }
        #endregion

        #region Analysis
        /// <summary>
        /// Determines which <see cref="BiomeRecipe"/> the given <see cref="RegionModel"/> corresponds to.
        /// </summary>
        /// <remarks>
        /// This method assumes that <see cref="Rooms"/> has already been populated.
        /// </remarks>
        /// <returns>The appropriate <see cref="ModelID"/>.</returns>
        public ModelID GetBiome()
        {
            var result = BiomeRecipe.None.ID;
            // NOTE: OfType() is used here because the iterator returns a Model.  Perhaps this can be improved?
            foreach (var biome in All.BiomeRecipes.OfType<BiomeRecipe>())
            {
                result = FindBiomeByTag(this, biome);
                if (result != BiomeRecipe.None.ID)
                {
                    break;
                }
            }
            return result;

            #region Local Helper Methods
            // Determines if the given BiomeRecipe matches the given Region.
            //     inRegion -> The MapRegionModel to test.
            //     inBiome -> The BiomeRecipe to test against.
            // Returns the given BiomeRecipe's ModelID if they match, otherwise returns the ModelID for the default biome.
            static ModelID FindBiomeByTag(RegionModel inRegion, BiomeRecipe inBiome)
                // Prioritization of biome categories is hard-coded in the following way:
                //    1 Room-based Biomes supersede
                //    2 Liquid-based Biomes, which supersede
                //    3 Land-based Biomes, which supersede
                //    4 the default Biome.
                => (inBiome.IsRoomBased
                    && GetParquetsInRooms(inRegion) >= BiomeConfiguration.RoomThreshold
                    && ConstitutesBiome(inRegion, inBiome, BiomeConfiguration.RoomThreshold))
                || (inBiome.IsLiquidBased
                    && ConstitutesBiome(inRegion, inBiome, BiomeConfiguration.LiquidThreshold))
                || ConstitutesBiome(inRegion, inBiome, BiomeConfiguration.LandThreshold)
                    ? inBiome.ID
                    : BiomeRecipe.None.ID;

            // Determines the number of individual parquets that are present inside Rooms in the given MapRegionModel.
            //     inRegion -> The region to consider.
            // Returns the number of parquets that are part of a known Room.
            static ModelID GetParquetsInRooms(RegionModel inRegion)
            {
                var parquetsInRoom = 0;

                // TODO [OPTIMIZATION] This might be a good place to optimize.
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
            static bool ConstitutesBiome(RegionModel inRegion, BiomeRecipe inBiome, int inThreshold)
                => CountMeetsOrExceedsThreshold(inRegion,
                                                parquet => parquet?.AddsToBiome.Contains(inBiome.ParquetCriteria) ?? false,
                                                inThreshold);

            // Determines if the region has enough parquets satisfying the given predicate to meet or exceed the given threshold.
            //     inRegion -> The region to test.
            //     inPredicate -> A predicate indicating if the parquet should be counted.
            //                    The predicate must accommodate a null argument.
            //     inThreshold -> A total number of parquets that must be met for the region to qualify.
            // Returns true if enough parquets satisfy the conditions given, false otherwise.
            static bool CountMeetsOrExceedsThreshold(RegionModel inRegion, Predicate<ParquetModel> inPredicate, int inThreshold)
            {
                var count = 0;

                foreach (ParquetModelPack pack in inRegion.ParquetDefinitions)
                {
                    if (inPredicate(All.Floors.GetOrNull<FloorModel>(pack.FloorID)))
                    {
                        count++;
                    }
                    if (inPredicate(All.Blocks.GetOrNull<BlockModel>(pack.BlockID)))
                    {
                        count++;
                    }
                    if (inPredicate(All.Furnishings.GetOrNull<FurnishingModel>(pack.FurnishingID)))
                    {
                        count++;
                    }
                    if (inPredicate(All.Collectibles.GetOrNull<CollectibleModel>(pack.CollectibleID)))
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
        /// <summary>The total number of parquets in the entire map.</summary>
        [Ignore]
        protected int ParquetsCount
            => ParquetDefinitions?.Count ?? 0;

        /// <summary>
        /// Determines if the given position corresponds to a point in the region.
        /// </summary>
        /// <param name="inPosition">The position to validate.</param>
        /// <returns><c>true</c>, if the position is valid, <c>false</c> otherwise.</returns>
        public bool IsValidPosition(Vector2D inPosition)
            => ParquetDefinitions.IsValidPosition(inPosition);

        /// <summary>
        /// Provides all parquet definitions within the current map.
        /// </summary>
        /// <returns>The entire map as a subregion.</returns>
        public ParquetModelPackGrid GetSubregion()
            => GetSubregion(Vector2D.Zero, new Vector2D(DimensionsInParquets.X - 1, DimensionsInParquets.Y - 1));

        /// <summary>
        /// Provides all parquet definitions within the specified rectangular subsection of the current map.
        /// </summary>
        /// <param name="inUpperLeft">The position of the upper-leftmost corner of the subregion.</param>
        /// <param name="inLowerRight">The position of the lower-rightmost corner of the subregion.</param>
        /// <returns>A portion of the map as a subregion.</returns>
        /// <remarks>If the coordinates given are not well-formed, the subregion returned will be invalid.</remarks>
        // TODO [MAP EDITOR] [API] Should this return an IReadOnlyGrid<ParquetPack>s instead?
        public ParquetModelPackGrid GetSubregion(Vector2D inUpperLeft, Vector2D inLowerRight)
        {
            if (!ParquetDefinitions.IsValidPosition(inUpperLeft))
            {
                Logger.Log(LogLevel.Warning, string.Format(CultureInfo.CurrentCulture, Resources.ErrorInvalidPosition,
                                                           nameof(inUpperLeft), nameof(ParquetDefinitions)));
            }
            else if (!ParquetDefinitions.IsValidPosition(inLowerRight))
            {
                Logger.Log(LogLevel.Warning, string.Format(CultureInfo.CurrentCulture, Resources.ErrorInvalidPosition,
                                                           nameof(inLowerRight), nameof(ParquetDefinitions)));
            }
            else if (inLowerRight.X < inUpperLeft.X || inLowerRight.Y < inUpperLeft.Y)
            {
                Logger.Log(LogLevel.Warning, string.Format(CultureInfo.CurrentCulture, Resources.ErrorOutOfOrderGTE,
                                                           nameof(inLowerRight), inLowerRight, inUpperLeft));
            }
            else
            {
                var subregion = new ParquetModelPack[inLowerRight.X - inUpperLeft.X + 1,
                                                 inLowerRight.Y - inUpperLeft.Y + 1];

                for (var x = inUpperLeft.X; x <= inLowerRight.X; x++)
                {
                    for (var y = inUpperLeft.Y; y <= inLowerRight.Y; y++)
                    {
                        subregion[y - inUpperLeft.Y, x - inUpperLeft.X] = ParquetDefinitions[y, x];
                    }
                }

                return new ParquetModelPackGrid(subregion);
            }

            return new ParquetModelPackGrid();
        }

        /// <summary>
        /// Describes the <see cref="RegionModel"/>.
        /// </summary>
        /// <returns>A <see cref="string"/> that represents the current <see cref="RegionModel"/>.</returns>
        public override string ToString()
            => $"Region {Name} ({DimensionsInParquets.X }, {DimensionsInParquets.Y}) contains {ParquetsCount} parquets.";
        #endregion
    }
}
