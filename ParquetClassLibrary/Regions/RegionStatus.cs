using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using Parquet.Biomes;
using Parquet.Parquets;
using Parquet.Properties;
using Parquet.Rooms;

namespace Parquet.Regions
{
    /// <summary>
    /// Tracks the status of a <see cref="RegionModel"/> during play.
    /// Instances of this class are mutable during play.
    /// </summary>
    /// <remarks>
    /// Much of the building gameplay takes place in the data represented by instances of this class.
    /// </remarks>
    public class RegionStatus : Status<RegionModel>
    {
        #region Class Defaults
        /// <summary>Provides a throwaway instance of the <see cref="RegionStatus"/> class with default values.</summary>
        public static RegionStatus Unused { get; } = new RegionStatus();

        /// <summary>The length of each <see cref="RegionStatus"/> dimension in parquets.</summary>
        public const int ParquetsPerRegionDimension = RegionModel.ChunksPerRegionDimension * MapChunk.ParquetsPerChunkDimension;

        /// <summary>The region's dimensions in parquets.</summary>
        public static Vector2D DimensionsInParquets { get; } = new Vector2D(ParquetsPerRegionDimension, ParquetsPerRegionDimension);
        #endregion

        #region Status
        /// <summary>The definitions of parquets that make up the region.</summary>
        /// <remarks>When mutating these, the corresponding element in <see cref="ParquetStatuses"/> should also be mutated.</remarks>
        // TODO [MAP EDITOR] [API] Should this be an IGrid<ParquetModel>es instead?
        public ParquetModelPackGrid ParquetModels { get; }

        /// <summary>The statuses of parquets that make up the region.</summary>
        // TODO [MAP EDITOR] [API] Should this be an IGrid<ParquetStatus>es instead?
        public ParquetStatusPackGrid ParquetStatuses { get; }
        #endregion

        #region Collections
        /// <summary>
        /// All of the <see cref="Room"/>s detected.
        /// </summary>
        public IReadOnlyCollection<Room> Rooms { get; private set; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new <see cref="RegionStatus"/> with no contents.
        /// </summary>
        public RegionStatus()
            : this(null, null) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="RegionStatus"/> class.
        /// </summary>
        /// <param name="inParquetModels">The definitions of parquets that make up the region.</param>
        /// <param name="inParquetStatuses">The statuses of parquets that make up the region.</param>
        public RegionStatus(ParquetModelPackGrid inParquetModels, ParquetStatusPackGrid inParquetStatuses)
        {
            var nonNullParquetModels = inParquetModels ?? ParquetModelPackGrid.Empty;
            var nonNullParquetStatuses = inParquetStatuses ?? ParquetStatusPackGrid.Empty;

            // Ensure grid dimensions are equal.
            if (nonNullParquetModels.Columns != nonNullParquetStatuses.Columns
                || nonNullParquetModels.Rows != nonNullParquetStatuses.Rows)
            {
                Logger.Log(LogLevel.Error, Resources.ErrorDimensionsMustMatch);
                nonNullParquetModels = ParquetModelPackGrid.Empty;
                nonNullParquetStatuses = ParquetStatusPackGrid.Empty;
            }

            ParquetModels = nonNullParquetModels;
            ParquetStatuses = nonNullParquetStatuses;
        }
        #endregion

        #region Analysis
        #region Finding Biomes
        /// <summary>
        /// Determines which <see cref="BiomeRecipe"/> this <see cref="RegionStatus"/> corresponds to.
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
            static ModelID FindBiomeByTag(RegionStatus inRegion, BiomeRecipe inBiome)
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
            static ModelID GetParquetsInRooms(RegionStatus inRegion)
            {
                var parquetsInRoom = 0;

                // TODO [OPTIMIZATION] This might be a good place to optimize.
                for (var y = 0; y < inRegion.ParquetModels.Rows; y++)
                {
                    for (var x = 0; x < inRegion.ParquetModels.Columns; x++)
                    {
                        if (inRegion.Rooms.Any(room => room.ContainsPosition(new Vector2D(x, y))))
                        {
                            // Note that we are counting every parquet, including collectibles.
                            parquetsInRoom += inRegion.ParquetModels[y, x].Count;
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
            static bool ConstitutesBiome(RegionStatus inRegion, BiomeRecipe inBiome, int inThreshold)
                => CountMeetsOrExceedsThreshold(inRegion,
                                                parquet => parquet?.AddsToBiome.Contains(inBiome.ParquetCriteria) ?? false,
                                                inThreshold);

            // Determines if the region has enough parquets satisfying the given predicate to meet or exceed the given threshold.
            //     inRegion -> The region to test.
            //     inPredicate -> A predicate indicating if the parquet should be counted.
            //                    The predicate must accommodate a null argument.
            //     inThreshold -> A total number of parquets that must be met for the region to qualify.
            // Returns true if enough parquets satisfy the conditions given, false otherwise.
            static bool CountMeetsOrExceedsThreshold(RegionStatus inRegion, Predicate<ParquetModel> inPredicate, int inThreshold)
            {
                var count = 0;

                foreach (ParquetModelPack pack in inRegion.ParquetModels)
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

        #region Finding Exits
        /// <summary>
        /// Takes a <see cref="RegionModel"/> and returns the <see cref="ModelID" /> of an adjacent RegionModel.
        /// </summary>
        internal delegate ModelID IDByDirection(RegionModel inRegion);

        /// <summary>
        /// A database of directions and their opposites, together with the properties needed to inspect both.
        /// </summary>
        internal static readonly IReadOnlyCollection<(IDByDirection GetLeavingRegionID,
                                                      string LeavingDirection,
                                                      IDByDirection GetReturningRegionID,
                                                      string ReturningDirection)> Directions
            = new List<(IDByDirection, string, IDByDirection, string)>
            {
                { (region => region.RegionToTheNorth, Resources.DirectionNorth,
                   region => region.RegionToTheSouth, Resources.DirectionSouth) },
                { (region => region.RegionToTheEast, Resources.DirectionEast,
                   region => region.RegionToTheWest, Resources.DirectionWest) },
                { (region => region.RegionToTheSouth, Resources.DirectionSouth,
                   region => region.RegionToTheNorth, Resources.DirectionNorth) },
                { (region => region.RegionToTheWest, Resources.DirectionWest,
                   region => region.RegionToTheEast, Resources.DirectionEast) },
                { (region => region.RegionAbove, Resources.DirectionAbove,
                   region => region.RegionBelow, Resources.DirectionBelow) },
                { (region => region.RegionBelow, Resources.DirectionBelow,
                   region => region.RegionAbove, Resources.DirectionAbove) },
            };

        /// <summary>
        /// Finds adjacent maps from which the given map is not adjacent in the expected direction.
        ///
        /// That is, if the player leaves Region 1 by going North and cannot then return to Region 1 by going south,
        /// that is considered inconsistent and will be reported.
        /// </summary>
        /// <param name="inRegionID">The <see cref="ModelID"/> of the origination and destination map.</param>
        /// <returns>A report of all exit directions leading to regions whose own exits are inconsistent.</returns>
        [SuppressMessage("Style", "IDE0042:Deconstruct variable declaration",
            Justification = "In this instance it makes the code less readable.")]
        public static ICollection<string> CheckExitConsistency(ModelID inRegionID)
        {
            var inconsistentExitDirections = new List<string>();

            if (inRegionID == ModelID.None)
            {
                return inconsistentExitDirections;
            }

            var currentRegion = All.RegionModels.GetOrNull<RegionModel>(inRegionID);

            if (currentRegion is null)
            {
                return inconsistentExitDirections;
            }

            foreach (var directionPair in Directions)
            {
                var adjacentRegionID = directionPair.GetLeavingRegionID(currentRegion);
                if (adjacentRegionID == ModelID.None)
                {
                    continue;
                }

                var adjacentRegion = All.RegionModels.GetOrNull<RegionModel>(adjacentRegionID);
                if (adjacentRegion is not null)
                {
                    continue;
                }

                if (directionPair.GetReturningRegionID(adjacentRegion) != inRegionID)
                {
                    inconsistentExitDirections.Add(
                        $"{adjacentRegion.Name} is {directionPair.LeavingDirection} of {currentRegion.Name} but " +
                        $"{currentRegion.Name} is not {directionPair.ReturningDirection} of {adjacentRegion.Name}.\n");
                }
            }

            return inconsistentExitDirections;
        }
        #endregion
        #endregion

        #region IEquatable Implementation
        /// <summary>
        /// Serves as a hash function for a <see cref="RegionStatus"/>.
        /// </summary>
        /// <returns>
        /// A hash code for this instance that is suitable for use in hashing algorithms and data structures.
        /// </returns>
        public override int GetHashCode()
            => (ParquetModels, ParquetStatuses).GetHashCode();

        /// <summary>
        /// Determines whether the specified <see cref="RegionStatus"/> is equal to the current <see cref="RegionStatus"/>.
        /// </summary>
        /// <param name="inStatus">The <see cref="RegionStatus"/> to compare with the current.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public override bool Equals<T>(T inStatus)
            => inStatus is RegionStatus regionStatus
            && ParquetModels == regionStatus.ParquetModels
            && ParquetStatuses == regionStatus.ParquetStatuses;

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="RegionStatus"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="RegionStatus"/>.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
            => obj is RegionStatus status
            && Equals(status);

        /// <summary>
        /// Determines whether a specified instance of <see cref="RegionStatus"/> is equal to another specified instance of <see cref="RegionStatus"/>.
        /// </summary>
        /// <param name="inStatus1">The first <see cref="RegionStatus"/> to compare.</param>
        /// <param name="inStatus2">The second <see cref="RegionStatus"/> to compare.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(RegionStatus inStatus1, RegionStatus inStatus2)
            => inStatus1?.Equals(inStatus2) ?? inStatus2?.Equals(inStatus1) ?? true;

        /// <summary>
        /// Determines whether a specified instance of <see cref="RegionStatus"/> is not equal to another specified instance of <see cref="RegionStatus"/>.
        /// </summary>
        /// <param name="inStatus1">The first <see cref="RegionStatus"/> to compare.</param>
        /// <param name="inStatus2">The second <see cref="RegionStatus"/> to compare.</param>
        /// <returns><c>true</c> if they are NOT equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(RegionStatus inStatus1, RegionStatus inStatus2)
            => !(inStatus1 == inStatus2);
        #endregion

        #region ITypeConverter Implementation
        /// <summary>Allows the converter to construct itself statically.</summary>
        internal static RegionStatus ConverterFactory { get; } = Unused;

        /// <summary>
        /// Converts the given <see cref="object"/> to a <see cref="string"/> for serialization.
        /// </summary>
        /// <param name="inValue">The instance to convert.</param>
        /// <param name="inRow">The current context and configuration.</param>
        /// <param name="inMemberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance serialized.</returns>
        public override string ConvertToString(object inValue, IWriterRow inRow, MemberMapData inMemberMapData)
            => inValue is RegionStatus status
                // NOTE Tertiary delimiter is used here to separate ParquetModelPackGrid from ParquetStatusPackGrid.
                ? $"{GridConverter<ParquetModelPack, ParquetModelPackGrid>.ConverterFactory.ConvertToString(ParquetModels, inRow, inMemberMapData)}{Delimiters.TertiaryDelimiter}" +
                  $"{GridConverter<ParquetStatusPack, ParquetStatusPackGrid>.ConverterFactory.ConvertToString(ParquetStatuses, inRow, inMemberMapData)}"
                : Logger.DefaultWithConvertLog(inValue?.ToString() ?? "null", nameof(MapChunk), nameof(Unused));

        /// <summary>
        /// Converts the given <see cref="string"/> to an <see cref="object"/> as deserialization.
        /// </summary>
        /// <param name="inText">The text to convert.</param>
        /// <param name="inRow">The current context and configuration.</param>
        /// <param name="inMemberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance deserialized.</returns>
        public override object ConvertFromString(string inText, IReaderRow inRow, MemberMapData inMemberMapData)
        {
            if (string.IsNullOrEmpty(inText)
                || string.Compare(nameof(Unused), inText, StringComparison.OrdinalIgnoreCase) == 0)
            {
                return Unused.DeepClone();
            }

            var parameterText = inText.Split(Delimiters.TertiaryDelimiter);
            var parsedParquetModels = (ParquetModelPackGrid)GridConverter<ParquetModelPack, ParquetModelPackGrid>
                .ConverterFactory
                .ConvertFromString(parameterText[0], inRow, inMemberMapData);
            var parsedParquetStatuses = (ParquetStatusPackGrid)GridConverter<ParquetStatusPack, ParquetStatusPackGrid>
                .ConverterFactory
                .ConvertFromString(parameterText[1], inRow, inMemberMapData);

            return new RegionStatus(parsedParquetModels, parsedParquetStatuses);
        }
        #endregion

        #region IDeeplyCloneable Implementation
        /// <summary>
        /// Creates a new instance that is a deep copy of the current instance.
        /// </summary>
        /// <returns>A new instance with the same characteristics as the current instance.</returns>
        public override T DeepClone<T>()
            => new RegionStatus(ParquetModels, ParquetStatuses) as T;
        #endregion

        #region Utilities
        /// <summary>
        /// Determines if the given position corresponds to a point in the region.
        /// </summary>
        /// <param name="inPosition">The position to validate.</param>
        /// <returns><c>true</c>, if the position is valid, <c>false</c> otherwise.</returns>
        public bool IsValidPosition(Vector2D inPosition)
            => ParquetModels.IsValidPosition(inPosition)
            && ParquetStatuses.IsValidPosition(inPosition);

        /// <summary>
        /// Returns a <see cref="string"/> that represents the current <see cref="RegionStatus"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override string ToString()
            => $"[{ParquetModels.Count} {nameof(Parquets)}]";
        #endregion
    }
}
