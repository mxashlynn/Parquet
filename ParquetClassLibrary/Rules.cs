using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary
{
    /// <summary>
    /// Provides rules, dimensions, and parameters for the game.
    /// </summary>
    public static class Rules
    {
        /// <summary>
        /// Provides rules for determining a <see cref="Maps.MapRegion"/>'s <see cref="Biomes.BiomeModel"/>.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design",
            "CA1034:Nested types should not be visible",
            Justification = "No adequate alternative in this instance.")]
        public static class BiomeCriteria
        {
            /// <summary>Used in computing thresholds.</summary>
            public const int ParquetsPerLayer = Dimensions.ParquetsPerRegion * Dimensions.ParquetsPerRegion;

            /// <summary>1 and 1/4th of a layers' worth of parquets must contribute to a land-based <see cref="Biomes.BiomeModel"/>.</summary>
            public const int LandThreshold = ParquetsPerLayer * 5 / 4;

            /// <summary>3/4ths of a layers' worth of parquets must contribute to a fluid-based <see cref="Biomes.BiomeModel"/>.</summary>
            public const int FluidThreshold = ParquetsPerLayer / 4;
        }

        /// <summary>
        /// Provides dimensional parameters for the game.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design",
        "CA1034:Nested types should not be visible",
        Justification = "No adequate alternative in this instance.")]
        public static class Dimensions
        {
            /// <summary>The length of each <see cref="Maps.ChunkTypeGrid"/> dimension in parquets.</summary>
            public const int ParquetsPerChunk = 16;

            /// <summary>The length of each <see cref="Maps.MapRegion"/> dimension in <see cref="Maps.ChunkTypeGrid"/>s.</summary>
            public const int ChunksPerRegion = 4;

            /// <summary>The length of each <see cref="Maps.MapRegion"/> dimension in parquets.</summary>
            public const int ParquetsPerRegion = ChunksPerRegion * ParquetsPerChunk;

            /// <summary>Width of the <see cref="Crafts.StrikePanel"/> pattern in <see cref="Crafts.CraftingRecipe"/>.</summary>
            public const int PanelsPerPatternWidth = 2;

            /// <summary>Height of the <see cref="Crafts.StrikePanel"/> pattern in <see cref="Crafts.CraftingRecipe"/>.</summary>
            public const int PanelsPerPatternHeight = 2;
        }

        /// <summary>
        /// Provides recipe requirements for the game.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design",
            "CA1034:Nested types should not be visible",
            Justification = "No adequate alternative in this instance.")]
        public static class Recipes
        {
            /// <summary>
            /// Provides crafting recipe requirements for the game.
            /// </summary>
            public static class Craft
            {
                /// <summary>Number of ingredient categories per recipe.</summary>
                public static Range<int> IngredientCount { get; } = new Range<int>(1, 5);

                /// <summary>Number of product categories per recipe.</summary>
                public static Range<int> ProductCount { get; } = new Range<int>(1, 5);
            }

            /// <summary>
            /// Provides room recipe requirements for the game.
            /// </summary>
            public static class Room
            {
                /// <summary>Minimum number of open walkable spaces needed for any room to register.</summary>
                public const int MinWalkableSpaces = 4;

                /// <summary>Maximum number of open walkable spaces needed for any room to register.</summary>
                public const int MaxWalkableSpaces = 121;

                /// <summary>Minimum number of enclosing spaces needed for any room to register.</summary>
                public const int MinPerimeterSpaces = MinWalkableSpaces * 3;
            }
        }

        /// <summary>
        /// Provides a unified source of serialization separators for the library.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design",
            "CA1034:Nested types should not be visible",
            Justification = "No adequate alternative in this instance.")]
        public static class Delimiters
        {
            /// <summary>Separates objects within collections.</summary>
            public const string SecondaryDelimiter = "\\";

            /// <summary>Separates properties within a class when in serialization.</summary>
            public const string InternalDelimiter = "|";

            /// <summary>Separates primitives within serialized <see cref="Vector2D"/>s and <see cref="Range{TElement}"/>s.</summary>
            public const string ElementDelimiter = "__";
        }
    }
}
