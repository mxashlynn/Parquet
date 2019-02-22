namespace ParquetClassLibrary.Sandbox
{
    /// <summary>
    /// Convenience extension methods for concise coding when working with ParquetSelection instances.
    /// </summary>
    internal static class MapRegionAnalysis
    {
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
                        if (in_region.HasClouds())
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
        /// Determines if the region has enough buildings to qualify as a town.
        /// </summary>
        /// <param name="in_region">The region to test.</param>
        /// <returns><c>true</c>, if the region meets the criteria, <c>false</c> otherwise.</returns>
        public static bool HasBuildings(this MapRegion in_region)
        {
            return false;
        }

        /// <summary>
        /// Determines if the region has enough walkable clouds to qualify as heaven.
        /// </summary>
        /// <param name="in_region">The region to test.</param>
        /// <returns><c>true</c>, if the region meets the criteria, <c>false</c> otherwise.</returns>
        public static bool HasClouds(this MapRegion in_region)
        {
            return false;
        }

        /// <summary>
        /// Determines if the region has enough flowing lava to qualify as volcanic.
        /// </summary>
        /// <param name="in_region">The region to test.</param>
        /// <returns><c>true</c>, if the region meets the criteria, <c>false</c> otherwise.</returns>
        public static bool HasLavaflow(this MapRegion in_region)
        {
            return false;
        }

        /// <summary>
        /// Determines if the region has enough flowing water to qualify as oceanic.
        /// </summary>
        /// <param name="in_region">The region to test.</param>
        /// <returns><c>true</c>, if the region meets the criteria, <c>false</c> otherwise.</returns>
        public static bool HasSea(this MapRegion in_region)
        {
            return false;
        }

        /// <summary>
        /// Determines if the region has enough sandy parquets to qualify as a desert.
        /// </summary>
        /// <param name="in_region">The region to test.</param>
        /// <returns><c>true</c>, if the region meets the criteria, <c>false</c> otherwise.</returns>
        public static bool HasSand(this MapRegion in_region)
        {
            return false;
        }

        /// <summary>
        /// Determines if the region has enough snowy parquets to qualify as tundra.
        /// </summary>
        /// <param name="in_region">The region to test.</param>
        /// <returns><c>true</c>, if the region meets the criteria, <c>false</c> otherwise.</returns>
        public static bool HasSnow(this MapRegion in_region)
        {
            return false;
        }

        /// <summary>
        /// Determines if the region has enough marshy parquets to qualify as a swamp.
        /// </summary>
        /// <param name="in_region">The region to test.</param>
        /// <returns><c>true</c>, if the region meets the criteria, <c>false</c> otherwise.</returns>
        public static bool HasSwamp(this MapRegion in_region)
        {
            return false;
        }

        /// <summary>
        /// Determines if the region has enough trees to qualify as a forest.
        /// </summary>
        /// <param name="in_region">The region to test.</param>
        /// <returns><c>true</c>, if the region meets the criteria, <c>false</c> otherwise.</returns>
        public static bool HasForest(this MapRegion in_region)
        {
            return false;
        }
    }
}
