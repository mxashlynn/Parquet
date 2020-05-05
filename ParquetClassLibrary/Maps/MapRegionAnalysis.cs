using System;
using ParquetClassLibrary.Maps;
using ParquetClassLibrary.Parquets;

namespace ParquetClassLibrary.Biomes
{
    /// <summary>
    /// TODO Fill this in!!
    /// </summary>
    internal static class MapRegionAnalysis
    {
        // TODO This should probably be a part of BiomeModel!
        // TODO These should employ ModelTags instead of being hard-coded
        // TODO These should probably be configurable -- maybe ModelTags is enough to satisfy that?

        #region Biome Analysis
        /// <summary>
        /// Determines which <see cref="Biome"/> the given <see cref="MapRegion"/> corresponds to.
        /// </summary>
        /// <param name="inRegion">The region to investigate.</param>
        /// <returns>The appropriate <see cref="Biome"/>.</returns>
        public static BiomeModel GetBiome(this MapRegion inRegion)
        {
            var result = Biome.Field;

            if (inRegion.HasBuildings())
            {
                result = Biome.Town;
            }
            else
            {
                switch (inRegion.ElevationLocal)
                {
                    case Elevation.AboveGround:
                        if (inRegion.IsHeavenly())
                        {
                            result = Biome.Heavens;
                        }
                        else
                        {
                            result = Biome.Alpine;
                        }
                        break;
                    case Elevation.LevelGround:
                        if (inRegion.IsVolcanic())
                        {
                            result = Biome.Volcano;
                        }
                        else if (inRegion.IsCoastal())
                        {
                            result = Biome.Seaside;
                        }
                        else if (inRegion.IsDeserted())
                        {
                            result = Biome.Desert;
                        }
                        else if (inRegion.IsFrozen())
                        {
                            result = Biome.Tundra;
                        }
                        else if (inRegion.IsSwampy())
                        {
                            result = Biome.Swamp;
                        }
                        else if (inRegion.IsForested())
                        {
                            result = Biome.Forest;
                        }
                        break;
                    case Elevation.BelowGround:
                        if (inRegion.IsVolcanic())
                        {
                            result = Biome.Inferno;
                        }
                        else
                        {
                            result = Biome.Cavern;
                        }
                        break;
                }
            }

            return result;
        }

        /// <summary>
        /// Determines if the region has enough heavenly parquets to qualify as heaven.
        /// </summary>
        /// <param name="inRegion">The region to test.</param>
        /// <returns><c>true</c>, if the region meets the criteria, <c>false</c> otherwise.</returns>
        internal static bool IsHeavenly(this MapRegion inRegion)
            => CountMeetsOrExceedsThreshold(inRegion,
                                            parquet => parquet.AddsToBiome.IsHeavenly(),
                                            BiomeConfiguration.FluidThreshold);

        /// <summary>
        /// Determines if the region has enough flowing lava to qualify as volcanic.
        /// </summary>
        /// <param name="inRegion">The region to test.</param>
        /// <returns><c>true</c>, if the region meets the criteria, <c>false</c> otherwise.</returns>
        internal static bool IsVolcanic(this MapRegion inRegion)
            => CountMeetsOrExceedsThreshold(inRegion,
                                            parquet => parquet.AddsToBiome.IsVolcanic(),
                                            BiomeConfiguration.FluidThreshold);

        /// <summary>
        /// Determines if the region has enough flowing water to qualify as oceanic.
        /// </summary>
        /// <param name="inRegion">The region to test.</param>
        /// <returns><c>true</c>, if the region meets the criteria, <c>false</c> otherwise.</returns>
        internal static bool IsCoastal(this MapRegion inRegion)
            => CountMeetsOrExceedsThreshold(inRegion,
                                            parquet => parquet.AddsToBiome.IsCoastal(),
                                            BiomeConfiguration.FluidThreshold);

        /// <summary>
        /// Determines if the region has enough sandy parquets to qualify as a desert.
        /// </summary>
        /// <param name="inRegion">The region to test.</param>
        /// <returns><c>true</c>, if the region meets the criteria, <c>false</c> otherwise.</returns>
        internal static bool IsDeserted(this MapRegion inRegion)
            => CountMeetsOrExceedsThreshold(inRegion,
                                            parquet => parquet.AddsToBiome.IsDeserted(),
                                            BiomeConfiguration.LandThreshold);

        /// <summary>
        /// Determines if the region has enough snowy parquets to qualify as tundra.
        /// </summary>
        /// <param name="inRegion">The region to test.</param>
        /// <returns><c>true</c>, if the region meets the criteria, <c>false</c> otherwise.</returns>
        internal static bool IsFrozen(this MapRegion inRegion)
            => CountMeetsOrExceedsThreshold(inRegion,
                                            parquet => parquet.AddsToBiome.IsFrozen(),
                                            BiomeConfiguration.LandThreshold);

        /// <summary>
        /// Determines if the region has enough marshy parquets to qualify as a swamp.
        /// </summary>
        /// <param name="inRegion">The region to test.</param>
        /// <returns><c>true</c>, if the region meets the criteria, <c>false</c> otherwise.</returns>
        internal static bool IsSwampy(this MapRegion inRegion)
            => CountMeetsOrExceedsThreshold(inRegion,
                                            parquet => parquet.AddsToBiome.IsSwampy(),
                                            BiomeConfiguration.LandThreshold);

        /// <summary>
        /// Determines if the region has enough trees to qualify as a forest.
        /// </summary>
        /// <param name="inRegion">The region to test.</param>
        /// <returns><c>true</c>, if the region meets the criteria, <c>false</c> otherwise.</returns>
        internal static bool IsForested(this MapRegion inRegion)
            => CountMeetsOrExceedsThreshold(inRegion,
                                            parquet => parquet.AddsToBiome.IsForested(),
                                            BiomeConfiguration.LandThreshold);

        /// <summary>
        /// Helper method determines if the region has enough parquets satisfying the given predicate
        /// to meet or exceed the given threshold.
        /// </summary>
        /// <param name="inRegion">The region to test.</param>
        /// <param name="inPredicate">A predicate indicating if the parquet should be counted.</param>
        /// <param name="inThreshold">A total number of parquets that must be met for the region to qualify.</param>
        /// <returns><c>true</c>, if enough parquets satisfy the conditions given, <c>false</c> otherwise.</returns>
        private static bool CountMeetsOrExceedsThreshold(MapRegion inRegion, Predicate<ParquetModel> inPredicate, int inThreshold)
        {
            var count = 0;

            foreach (var parquet in inRegion.ParquetDefinitions.GetAllParquets())
            {
                if (inPredicate(parquet))
                {
                    count++;
                }
            }

            return count >= inThreshold;
        }
        #endregion
    }
}
