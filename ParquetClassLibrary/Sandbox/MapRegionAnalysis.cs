using System;
using ParquetClassLibrary.Sandbox.IDs;
using ParquetClassLibrary.Sandbox.Parquets;

// ReSharper disable InconsistentNaming

namespace ParquetClassLibrary.Sandbox
{
    /// <summary>
    /// Convenience extension methods for concise coding when working with <see cref="MapRegion"/> instances.
    /// </summary>
    internal static class MapRegionAnalysis
    {
        #region Biome Criteria
        /// <summary>Used in computing thresholds.</summary>
        private static readonly int parquetsPerLayer = AssemblyInfo.ParquetsPerRegionDimension * AssemblyInfo.ParquetsPerRegionDimension;

        /// <summary>1 and 1/4th of a layers' worth of parquets must contribute to a land-based <see cref="T:ParquetClassLibrary.Sandbox.Biome"/>.</summary>
        private static readonly int landThreshold = (int)Math.Floor(parquetsPerLayer * 1.25);

        /// <summary>3/4ths of a layers' worth of parquets must contribute to a fluid-based <see cref="T:ParquetClassLibrary.Sandbox.Biome"/>.</summary>
        private static readonly int fluidThreshold = (int)Math.Floor(parquetsPerLayer * 0.75);
        #endregion

        #region Biome Analysis Methods
        /// <summary>
        /// Determines which <see cref="T:ParquetClassLibrary.Sandbox.Biome"/> the 
        /// given <see cref="T:ParquetClassLibrary.Sandbox.MapRegion"/> corresponds to.
        /// </summary>
        /// <param name="in_region">The region to investigate.</param>
        /// <returns>The appropriate <see cref="T:ParquetClassLibrary.Sandbox.Biome"/>.</returns>
        public static Biome GetBiome(this MapRegion in_region)
        {
            var result = Biome.Field;

            if (in_region.HasBuildings())
            {
                result = Biome.Town;
            }
            else
            {
                switch (in_region.ElevationLocal)
                {
                    case Elevation.AboveGround:
                        if (in_region.IsHeavenly())
                        {
                            result = Biome.Heavens;
                        }
                        else
                        {
                            result = Biome.Alpine;
                        }
                        break;
                    case Elevation.LevelGround:
                        if (in_region.IsVolcanic())
                        {
                            result = Biome.Volcano;
                        }
                        else if (in_region.IsCoastal())
                        {
                            result = Biome.Seaside;
                        }
                        else if (in_region.IsDeserted())
                        {
                            result = Biome.Desert;
                        }
                        else if (in_region.IsFrozen())
                        {
                            result = Biome.Tundra;
                        }
                        else if (in_region.IsSwampy())
                        {
                            result = Biome.Swamp;
                        }
                        else if (in_region.IsForested())
                        {
                            result = Biome.Forest;
                        }
                        break;
                    case Elevation.BelowGround:
                        if (in_region.IsVolcanic())
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
        /// <param name="in_region">The region to test.</param>
        /// <returns><c>true</c>, if the region meets the criteria, <c>false</c> otherwise.</returns>
        internal static bool IsHeavenly(this MapRegion in_region)
        {
            return CountMeetsOrExceedsThreshold(in_region,
                                                p => p.AddsToBiome.IsHeavenly(),
                                                fluidThreshold);
        }

        /// <summary>
        /// Determines if the region has enough flowing lava to qualify as volcanic.
        /// </summary>
        /// <param name="in_region">The region to test.</param>
        /// <returns><c>true</c>, if the region meets the criteria, <c>false</c> otherwise.</returns>
        internal static bool IsVolcanic(this MapRegion in_region)
        {
            return CountMeetsOrExceedsThreshold(in_region,
                                                p => p.AddsToBiome.IsVolcanic(),
                                                fluidThreshold);
        }

        /// <summary>
        /// Determines if the region has enough flowing water to qualify as oceanic.
        /// </summary>
        /// <param name="in_region">The region to test.</param>
        /// <returns><c>true</c>, if the region meets the criteria, <c>false</c> otherwise.</returns>
        internal static bool IsCoastal(this MapRegion in_region)
        {
            return CountMeetsOrExceedsThreshold(in_region,
                                                p => p.AddsToBiome.IsCoastal(),
                                                fluidThreshold);
        }

        /// <summary>
        /// Determines if the region has enough sandy parquets to qualify as a desert.
        /// </summary>
        /// <param name="in_region">The region to test.</param>
        /// <returns><c>true</c>, if the region meets the criteria, <c>false</c> otherwise.</returns>
        internal static bool IsDeserted(this MapRegion in_region)
        {
            return CountMeetsOrExceedsThreshold(in_region,
                                                p => p.AddsToBiome.IsDeserted(),
                                                landThreshold);
        }

        /// <summary>
        /// Determines if the region has enough snowy parquets to qualify as tundra.
        /// </summary>
        /// <param name="in_region">The region to test.</param>
        /// <returns><c>true</c>, if the region meets the criteria, <c>false</c> otherwise.</returns>
        internal static bool IsFrozen(this MapRegion in_region)
        {
            return CountMeetsOrExceedsThreshold(in_region,
                                                p => p.AddsToBiome.IsFrozen(),
                                                landThreshold);
        }

        /// <summary>
        /// Determines if the region has enough marshy parquets to qualify as a swamp.
        /// </summary>
        /// <param name="in_region">The region to test.</param>
        /// <returns><c>true</c>, if the region meets the criteria, <c>false</c> otherwise.</returns>
        internal static bool IsSwampy(this MapRegion in_region)
        {
            return CountMeetsOrExceedsThreshold(in_region,
                                                p => p.AddsToBiome.IsSwampy(),
                                                landThreshold);
        }

        /// <summary>
        /// Determines if the region has enough trees to qualify as a forest.
        /// </summary>
        /// <param name="in_region">The region to test.</param>
        /// <returns><c>true</c>, if the region meets the criteria, <c>false</c> otherwise.</returns>
        internal static bool IsForested(this MapRegion in_region)
        {
            return CountMeetsOrExceedsThreshold(in_region,
                                                p => p.AddsToBiome.IsForested(),
                                                landThreshold);
        }

        /// <summary>
        /// Helper method determines if the region has enough parquets satisfying the given predicate
        /// to meet or exceed the given threshold.
        /// </summary>
        /// <param name="in_region">The region to test.</param>
        /// <param name="in_predicate">A predicate indicating if the parquet should be counted.</param>
        /// <param name="in_threshold">A total number of parquets that must be met for the region to qualify.</param>
        /// <returns><c>true</c>, if enough parquets satisfy the conditions given, <c>false</c> otherwise.</returns>
        private static bool CountMeetsOrExceedsThreshold(MapRegion in_region, Predicate<ParquetParent> in_predicate, int in_threshold)
        {
            var count = 0;

            foreach (var parquet in in_region.GetAllParquets())
            {
                if (in_predicate(parquet))
                {
                    count++;
                }
            }

            return count >= in_threshold;
        }
        #endregion

        #region Buildings Analysis Methods
        /// <summary>
        /// Determines if the region has enough buildings to qualify as a town.
        /// </summary>
        /// <param name="in_region">The region to test.</param>
        /// <returns><c>true</c>, if the region meets the criteria, <c>false</c> otherwise.</returns>
        internal static bool HasBuildings(this MapRegion in_region)
        {
            // TODO Implement this!
            return false;
        }
        #endregion
    }
}
