using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public static Point2D DimensionsInParquets { get; } = new Point2D(ParquetsPerRegionDimension, ParquetsPerRegionDimension);
        #endregion

        #region Status
        /// <summary>The definitions of parquets that make up the region.</summary>
        /// <remarks>When mutating these, the corresponding element in <see cref="ParquetStatuses"/> should also be mutated.</remarks>
        public ParquetModelPackGrid ParquetModels { get; }

        /// <summary>The statuses of parquets that make up the region.</summary>
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
            UpdateRoomCollection();
        }

        /// <summary>
        /// Initializes a playable instance of the <see cref="RegionStatus"/> class
        /// based on a given <see cref="RegionModel"/> instance.
        /// </summary>
        /// <remarks>This is the entry point for map procedural generation.</remarks>
        /// <param name="inRegionModel">The region definition whose status is being tracked.</param>
        // TODO [PROC GEN] Review and update this entire routine.
        public RegionStatus(RegionModel inRegionModel)
        {
            Precondition.IsNotNull(inRegionModel);
            var nonNullRegionModel = inRegionModel is null
                ? RegionModel.Empty
                : inRegionModel;

            Debug.Assert(nonNullRegionModel.MapChunks.Rows == RegionModel.ChunksPerRegionDimension, "Row size mismatch.");
            Debug.Assert(nonNullRegionModel.MapChunks.Columns == RegionModel.ChunksPerRegionDimension, "Column size mismatch.");

            var parquetModels = new ParquetModelPackGrid(ParquetsPerRegionDimension, ParquetsPerRegionDimension);

            for (var chunkX = 0; chunkX < nonNullRegionModel.MapChunks.Columns; chunkX++)
            {
                for (var chunkY = 0; chunkY < nonNullRegionModel.MapChunks.Rows; chunkY++)
                {
                    // Get potentially ungenerated chunk.
                    var currentChunk = nonNullRegionModel.MapChunks[chunkY, chunkX];
                    if (currentChunk is null)
                    {
                        continue;
                    }

                    // Generate chunk if needed.
                    currentChunk = currentChunk.Generate();

                    // Extract definitions and copy them into the larger grid.
                    var offsetY = chunkY * MapChunk.ParquetsPerChunkDimension;
                    var offsetX = chunkX * MapChunk.ParquetsPerChunkDimension;
                    for (var parquetX = 0; parquetX < RegionModel.ChunksPerRegionDimension; parquetX++)
                    {
                        for (var parquetY = 0; parquetY < RegionModel.ChunksPerRegionDimension; parquetY++)
                        {
                            parquetModels[offsetY + parquetY, offsetX + parquetX] = currentChunk.ParquetDefinitions[parquetY, parquetX];
                        }
                    }
                }
            }

            ParquetModels = parquetModels;
            ParquetStatuses = new ParquetStatusPackGrid(parquetModels);
            UpdateRoomCollection();
        }
        #endregion

        #region Biomes Analysis
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
                        if (inRegion.Rooms.Any(room => room.ContainsPosition(new Point2D(x, y))))
                        {
                            // NOTE that we are counting every parquet, including collectibles.
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

        #region Room Analysis
        /// <summary>
        /// Updates <see cref="Rooms"/>, the collection of all <see cref="Room"/>s currently found within this
        /// <see cref="RegionStatus"/>.
        /// </summary>
        public void UpdateRoomCollection()
            => Rooms = FindRoomsInParquetGrid(ParquetModels);

        /// <summary>
        /// Analyzes the given <see cref="ParquetModelPackGrid"/> to find all valid <see cref="Room"/>s it contains.
        /// </summary>
        /// <remarks>
        /// For a complete explanation of the algorithm implemented here, see:
        /// <a href="https://github.com/mxashlynn/Parquet/blob/master/Documentation/4.-Room_Detection_and_Type_Assignment.md"/>
        /// </remarks>
        /// <param name="inGrid">The current collection of parquets to search for <see cref="Room"/>s.</param>
        /// <returns>An initialized collection of rooms.</returns>
        private static IReadOnlyCollection<Room> FindRoomsInParquetGrid(ParquetModelPackGrid inGrid)
        {
            Precondition.IsNotNull(inGrid, nameof(inGrid));
            if (inGrid is null)
            {
                return new List<Room>();
            }

            var walkableAreas = GetWalkableAreas(inGrid);
            var perimeter = MapSpaceSetExtensions.Empty;
            var rooms =
                walkableAreas
                .Where(walkableArea => walkableArea.TryGetPerimeter(out perimeter)
                                    && walkableArea.Any(space => space.IsWalkableEntry
                                                                || space.Neighbors()
                                                                        .Any(neighbor => neighbor.IsEnclosingEntry(walkableArea))))
                .Select(walkableArea => new Room(walkableArea, perimeter))
                .ToList();
            return rooms;
        }

        /// <summary>
        /// Finds all valid Walkable Areas in a given <see cref="ParquetModelPackGrid"/>.
        /// </summary>
        /// <param name="inGrid">The grid to search.</param>
        /// <returns>The list of valid Walkable Areas.</returns>
        private static IReadOnlyList<IReadOnlySet<MapSpace>> GetWalkableAreas(ParquetModelPackGrid inGrid)
        {
            var PWAs = new List<HashSet<MapSpace>>();
            var subgridRows = inGrid.Rows;
            var subgridCols = inGrid.Columns;

            for (var y = 0; y < subgridRows; y++)
            {
                for (var x = 0; x < subgridCols; x++)
                {
                    if (inGrid[y, x].IsWalkable)
                    {
                        var currentSpace = new MapSpace(x, y, inGrid[y, x], inGrid);

                        var northSpace = y > 0 && inGrid[y - 1, x].IsWalkable
                            ? new MapSpace(x, y - 1, inGrid[y - 1, x], inGrid)
                            : MapSpace.Empty;
                        var westSpace = x > 0 && inGrid[y, x - 1].IsWalkable
                            ? new MapSpace(x - 1, y, inGrid[y, x - 1], inGrid)
                            : MapSpace.Empty;

                        if (MapSpace.Empty == northSpace && MapSpace.Empty == westSpace)
                        {
                            var newPWA = new HashSet<MapSpace> { currentSpace };
                            PWAs.Add(newPWA);
                        }
                        else if (MapSpace.Empty != northSpace && MapSpace.Empty != westSpace)
                        {
                            var northPWA = PWAs.Find(pwa => pwa.Contains(northSpace));
                            var westPWA = PWAs.Find(pwa => pwa.Contains(westSpace));
                            if (northPWA == westPWA)
                            {
                                northPWA.Add(currentSpace);
                            }
                            else
                            {
                                var combinedPWA = new HashSet<MapSpace>(northPWA.Union(westPWA)) { currentSpace };
                                PWAs.Remove(northPWA);
                                PWAs.Remove(westPWA);
                                PWAs.Add(combinedPWA);
                            }
                        }
                        else if (MapSpace.Empty != westSpace)
                        {
                            PWAs.Find(pwa => pwa.Contains(westSpace)).Add(currentSpace);
                        }
                        else if (MapSpace.Empty != northSpace)
                        {
                            PWAs.Find(pwa => pwa.Contains(northSpace)).Add(currentSpace);
                        }
                    }
                }
            }

            var PWAsTooSmall = new HashSet<HashSet<MapSpace>>(PWAs.Where(pwa => pwa.Count < RoomConfiguration.MinWalkableSpaces));
            var PWAsTooLarge = new HashSet<HashSet<MapSpace>>(PWAs.Where(pwa => pwa.Count > RoomConfiguration.MaxWalkableSpaces));
            var PWAsDiscontinuous = new HashSet<HashSet<MapSpace>>(PWAs.Where(pwa => !pwa.AllSpacesAreReachable(space => space.Content.IsWalkable)));
            var results = new List<HashSet<MapSpace>>(PWAs.Except(PWAsTooSmall).Except(PWAsTooLarge).Except(PWAsDiscontinuous));

            return results.Cast<IReadOnlySet<MapSpace>>().ToList();
        }
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
        public bool IsValidPosition(Point2D inPosition)
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
