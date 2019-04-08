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
        /// Gets the <see cref="KeyItem"/> a player character needs to safely access the given biome.
        /// </summary>
        /// <param name="in_enumVariable">The Biome under consideration.</param>
        /// <returns>The requirements needed to enter this Biome.</returns>
        public static KeyItem GetEntryRequirements(this ref Biome in_enumVariable)
        {
            var key = KeyItem.None;

            switch (in_enumVariable)
            {
                // Tier 0
                case Biome.Field:
                case Biome.Town:
                    key = KeyItem.None;
                    break;
                // Tier 1
                case Biome.Forest:
                    key = KeyItem.ForestKey;
                    break;
                case Biome.Seaside:
                    key = KeyItem.SeasideKey;
                    break;
                // Tier 2
                case Biome.Desert:
                    key = KeyItem.SeasideKey | KeyItem.DesertKey | KeyItem.Tier2Key;
                    break;
                case Biome.Swamp:
                    key = KeyItem.ForestKey | KeyItem.SwampKey | KeyItem.Tier2Key;
                    break;
                case Biome.Tundra:
                    key = KeyItem.SeasideKey | KeyItem.TundraKey | KeyItem.Tier2Key;
                    break;
                // Tier 3
                case Biome.Cavern:
                    key = KeyItem.ForestKey | KeyItem.CavernKey | KeyItem.Tier2Key | KeyItem.Tier3Key;
                    break;
                // Tier 4
                case Biome.Alpine:
                    key = KeyItem.ForestKey | KeyItem.CavernKey | KeyItem.Tier2Key | KeyItem.Tier3Key
                        | KeyItem.SeasideKey | KeyItem.TundraKey | KeyItem.AlpineKey;
                    break;
                case Biome.Ruins:
                    key = KeyItem.ForestKey | KeyItem.CavernKey | KeyItem.Tier2Key | KeyItem.Tier3Key
                        | KeyItem.ForestKey | KeyItem.SwampKey | KeyItem.RuinsKey;
                    break;
                case Biome.Volcano:
                    key = KeyItem.ForestKey | KeyItem.CavernKey | KeyItem.Tier2Key | KeyItem.Tier3Key
                        | KeyItem.SeasideKey | KeyItem.DesertKey | KeyItem.VolcanoKey;
                    break;
                // Tier 5
                case Biome.Heavens:
                    key = KeyItem.HeavenlyKey;
                    break;
                case Biome.Inferno:
                    key = KeyItem.InfernalKey;
                    break;
            }

            return key;
        }
    }
}
