﻿using System;
using ParquetClassLibrary.Sandbox.Parquets;

namespace ParquetClassLibrary.Sandbox
{
    /// <summary>
    /// Convenience extension methods for concise coding when working with ParquetSelection instances.
    /// </summary>
    internal static class MapRegionAnalysis
    {
        #region Biome Criteria
        /// <summary>Used in computing thresholds.</summary>
        private static readonly int ParquetsPerLayer = MapRegion.DimensionsInParquets.x * MapRegion.DimensionsInParquets.y;

        /// <summary>1 and 1/4th of a layers' worth of parquets must contribute to a land-based <see cref="T:ParquetClassLibrary.Sandbox.Biome"/>.</summary>
        private static readonly int LandThreshold = (int)Math.Floor(ParquetsPerLayer * 1.25);

        /// <summary>3/4ths of a layers' worth of parquets must contribute to a fluid-based <see cref="T:ParquetClassLibrary.Sandbox.Biome"/>.</summary>
        private static readonly int FluidThreshold = (int)Math.Floor(ParquetsPerLayer * 0.75);
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
            Biome result = Biome.Field;

            if (in_region.HasBuildings())
            {
                result = Biome.Town;
            }
            else
            {
                switch (in_region.ElevationLocal)
                {
                    case Elevation.AboveGround:
                        if (in_region.HasHeavenlyWalkways())
                        {
                            result = Biome.Heavens;
                        }
                        else
                        {
                            result = Biome.Alpine;
                        }
                        break;
                    case Elevation.LevelGround:
                        if (in_region.HasLavaflow())
                        {
                            result = Biome.Volcano;
                        }
                        else if (in_region.HasSea())
                        {
                            result = Biome.Seaside;
                        }
                        else if (in_region.HasSand())
                        {
                            result = Biome.Desert;
                        }
                        else if (in_region.HasSnow())
                        {
                            result = Biome.Tundra;
                        }
                        else if (in_region.HasSwamp())
                        {
                            result = Biome.Swamp;
                        }
                        else if (in_region.HasForest())
                        {
                            result = Biome.Forest;
                        }
                        break;
                    case Elevation.BelowGround:
                        if (in_region.HasLavaflow())
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
        internal static bool HasHeavenlyWalkways(this MapRegion in_region)
        {
            return CountMeetsOrExceedsThreshold(in_region,
                                                (ParquetParent p) => { return p.ContributesToHeavens; },
                                                FluidThreshold);
        }

        /// <summary>
        /// Determines if the region has enough flowing lava to qualify as volcanic.
        /// </summary>
        /// <param name="in_region">The region to test.</param>
        /// <returns><c>true</c>, if the region meets the criteria, <c>false</c> otherwise.</returns>
        internal static bool HasLavaflow(this MapRegion in_region)
        {
            return CountMeetsOrExceedsThreshold(in_region,
                                                (ParquetParent p) => { return p.ContributesToVolcanic; },
                                                FluidThreshold);
        }

        /// <summary>
        /// Determines if the region has enough flowing water to qualify as oceanic.
        /// </summary>
        /// <param name="in_region">The region to test.</param>
        /// <returns><c>true</c>, if the region meets the criteria, <c>false</c> otherwise.</returns>
        internal static bool HasSea(this MapRegion in_region)
        {
            return CountMeetsOrExceedsThreshold(in_region,
                                                (ParquetParent p) => { return p.ContributesToSeaside; },
                                                FluidThreshold);
        }

        /// <summary>
        /// Determines if the region has enough sandy parquets to qualify as a desert.
        /// </summary>
        /// <param name="in_region">The region to test.</param>
        /// <returns><c>true</c>, if the region meets the criteria, <c>false</c> otherwise.</returns>
        internal static bool HasSand(this MapRegion in_region)
        {
            return CountMeetsOrExceedsThreshold(in_region,
                                                (ParquetParent p) => { return p.ContributesToDesert; },
                                                LandThreshold);
        }

        /// <summary>
        /// Determines if the region has enough snowy parquets to qualify as tundra.
        /// </summary>
        /// <param name="in_region">The region to test.</param>
        /// <returns><c>true</c>, if the region meets the criteria, <c>false</c> otherwise.</returns>
        internal static bool HasSnow(this MapRegion in_region)
        {
            return CountMeetsOrExceedsThreshold(in_region,
                                                (ParquetParent p) => { return p.ContributesToTundra; },
                                                LandThreshold);
        }

        /// <summary>
        /// Determines if the region has enough marshy parquets to qualify as a swamp.
        /// </summary>
        /// <param name="in_region">The region to test.</param>
        /// <returns><c>true</c>, if the region meets the criteria, <c>false</c> otherwise.</returns>
        internal static bool HasSwamp(this MapRegion in_region)
        {
            return CountMeetsOrExceedsThreshold(in_region,
                                                (ParquetParent p) => { return p.ContributesToSwamp; },
                                                LandThreshold);
        }

        /// <summary>
        /// Determines if the region has enough trees to qualify as a forest.
        /// </summary>
        /// <param name="in_region">The region to test.</param>
        /// <returns><c>true</c>, if the region meets the criteria, <c>false</c> otherwise.</returns>
        internal static bool HasForest(this MapRegion in_region)
        {
            return CountMeetsOrExceedsThreshold(in_region,
                                                (ParquetParent p) => { return p.ContributesToForest; },
                                                LandThreshold);
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
