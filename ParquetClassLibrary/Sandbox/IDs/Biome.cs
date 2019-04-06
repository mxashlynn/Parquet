using ParquetClassLibrary.Items;

namespace ParquetClassLibrary.Sandbox.IDs
{
    /// <summary>
    /// Indicates the biome that a MapRegion embodies.
    /// </summary>
    public enum Biome
    {
        Alpine,
        Cavern,
        Desert,
        Field,
        Forest,
        Heavens,
        Inferno,
        Ruins,
        Seaside,
        Swamp,
        Town,
        Tundra,
        Volcano,
    }

    /// <summary>
    /// Convenience extension methods for <see cref="Biome"/> instances.
    /// </summary>
    internal static class BiomeExtensions
    {
        /// <summary>
        /// Gets the tier-rating of the given biome in terms of number of stars.
        /// </summary>
        /// <param name="in_enumVariable">The Biome under consideration.</param>
        /// <returns>The number of stars for this Biome's tier.</returns>
        public static int GetStarRating(this ref Biome in_enumVariable)
        {
            var stars = 0;

            switch (in_enumVariable)
            {
                case Biome.Field:
                case Biome.Town:
                    stars = 0;
                    break;
                case Biome.Forest:
                case Biome.Seaside:
                    stars = 1;
                    break;
                case Biome.Desert:
                case Biome.Swamp:
                case Biome.Tundra:
                    stars = 2;
                    break;
                case Biome.Cavern:
                    stars = 3;
                    break;
                case Biome.Alpine:
                case Biome.Ruins:
                case Biome.Volcano:
                    stars = 4;
                    break;
                case Biome.Heavens:
                case Biome.Inferno:
                    stars = 5;
                    break;
            }

            return stars;
        }

        /// <summary>
        /// Gets an archtypical <see cref="Elevation"/> for the given biome.
        /// </summary>
        /// <param name="in_enumVariable">The Biome under consideration.</param>
        /// <returns>The elevation of this Biome.</returns>
        public static Elevation GetElevation(this ref Biome in_enumVariable)
        {
            var elevation = Elevation.LevelGround;

            switch (in_enumVariable)
            {
                case Biome.Field:
                case Biome.Town:
                case Biome.Forest:
                case Biome.Seaside:
                case Biome.Desert:
                case Biome.Swamp:
                case Biome.Tundra:
                case Biome.Ruins:
                    elevation = Elevation.LevelGround;
                    break;
                case Biome.Cavern:
                case Biome.Inferno:
                    elevation = Elevation.BelowGround;
                    break;
                case Biome.Alpine:
                case Biome.Volcano:
                case Biome.Heavens:
                    elevation = Elevation.AboveGround;
                    break;
            }

            return elevation;
        }

        /// <summary>
        /// Gets the <see cref="BiomeKey"/> a player character needs to safely access the given biome.
        /// </summary>
        /// <param name="in_enumVariable">The Biome under consideration.</param>
        /// <returns>The requirements needed to enter this Biome.</returns>
        public static BiomeKey GetEntryRequirements(this ref Biome in_enumVariable)
        {
            var key = BiomeKey.None;

            switch (in_enumVariable)
            {
                case Biome.Field:
                case Biome.Town:
                    key = BiomeKey.None;
                    break;
                case Biome.Forest:
                    key = BiomeKey.Knapsack;
                    break;
                case Biome.Seaside:
                    key = BiomeKey.Sunscreen;
                    break;
                case Biome.Desert:
                    key = BiomeKey.Sunscreen | BiomeKey.Canteen | BiomeKey.Boots;
                    break;
                case Biome.Swamp:
                    key = BiomeKey.Knapsack | BiomeKey.BugSpray | BiomeKey.Boots;
                    break;
                case Biome.Tundra:
                    key = BiomeKey.Sunscreen | BiomeKey.WarmGear | BiomeKey.Boots;
                    break;
                case Biome.Cavern:
                    key = BiomeKey.Knapsack | BiomeKey.Lantern | BiomeKey.Boots | BiomeKey.Rope;
                    break;
                case Biome.Alpine:
                    key = BiomeKey.Knapsack | BiomeKey.Lantern | BiomeKey.Boots | BiomeKey.Rope
                        | BiomeKey.Sunscreen | BiomeKey.WarmGear | BiomeKey.ClimbingKit;
                    break;
                case Biome.Ruins:
                    key = BiomeKey.Knapsack | BiomeKey.Lantern | BiomeKey.Boots | BiomeKey.Rope
                        | BiomeKey.Knapsack | BiomeKey.BugSpray | BiomeKey.Charm;
                    break;
                case Biome.Volcano:
                    key = BiomeKey.Knapsack | BiomeKey.Lantern | BiomeKey.Boots | BiomeKey.Rope
                        | BiomeKey.Sunscreen | BiomeKey.Canteen | BiomeKey.GasMask;
                    break;
                case Biome.Heavens:
                    key = BiomeKey.PearlyFeather;
                    break;
                case Biome.Inferno:
                    key = BiomeKey.CharredMask;
                    break;
            }

            return key;
        }
    }
}
