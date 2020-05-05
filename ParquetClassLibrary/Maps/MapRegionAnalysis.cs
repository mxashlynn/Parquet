using System;
using System.Linq;
using ParquetClassLibrary.Maps;
using ParquetClassLibrary.Parquets;
using ParquetClassLibrary.Rooms;

namespace ParquetClassLibrary.Biomes
{
    /// <summary>
    /// TODO Fill this in!!
    /// </summary>
    internal static class MapRegionAnalysis
    {
        // TODO This should probably be a part of BiomeModel or MapRegion

        /// <summary>
        /// Determines which <see cref="BiomeModel"/> the given <see cref="MapRegion"/> corresponds to.
        /// </summary>
        /// <param name="inRegion">The region to investigate.</param>
        /// <returns>The appropriate <see cref="ModelID"/>.</returns>
        public static ModelID GetBiome(this MapRegion inRegion)
        {
            foreach (BiomeModel biome in All.Biomes)
            {
                if (biome.ElevationCategory == inRegion.ElevationLocal)
                {
                    return FindBiomeByTag(inRegion, biome);
                }
            }

            // TODO Log a warning here.
            // This is a degenerate case, as all three Elevations ought to have BiomeModels defined for them.
            return BiomeModel.None.ID;

            #region Local Helper Methods
            // Determines if the given BiomeModel matches the given Region.
            //     inRegion -> The MapRegion to test.
            //     inBiome -> The BiomeModel to test against.
            // Returns the given BiomeModel's ModelID if they match, otherwise returns the ModelID for the default biome.
            static ModelID FindBiomeByTag(MapRegion inRegion, BiomeModel inBiome)
            {
                var result = BiomeModel.None.ID;

                foreach (ModelTag biomeTag in inBiome.ParquetCriteria)
                {
                    // Prioritization of biome categories is hard-coded in the following way:
                    //    1 Room-based Biomes supercede
                    //    2 Liquid-based Biomes supercede
                    //    3 Land-based Biomes supercede
                    //    4 the default Biome.
                    if (inBiome.IsRoomBased
                        && GetParquetsInRooms(inRegion) <= BiomeConfiguration.RoomThreshold
                        && ConstitutesBiome(inRegion, inBiome, BiomeConfiguration.RoomThreshold))
                    {
                        result = inBiome.ID;
                        break;
                    }
                    else if (inBiome.IsLiquidBased
                             && ConstitutesBiome(inRegion, inBiome, BiomeConfiguration.LiquidThreshold))
                    {
                        result = inBiome.ID;
                        break;
                    }
                    else if (ConstitutesBiome(inRegion, inBiome, BiomeConfiguration.LandThreshold))
                    {
                        result = inBiome.ID;
                        break;
                    }
                }

                return result;
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
                var result = false;
                foreach (ModelTag biomeTag in inBiome.ParquetCriteria)
                {
                    if (CountMeetsOrExceedsThreshold(inRegion, parquet => parquet.AddsToBiome == biomeTag, inThreshold))
                    {
                        result = true;
                    }
                }
                return result;
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
    }
}
