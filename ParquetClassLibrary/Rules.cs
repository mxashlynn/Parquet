using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary
{
    /// <summary>
    /// Provides rules, dimensions, and parameters for the game.
    /// </summary>
    public static class Rules
    {
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

            /// <summary>Width of the <see cref="Crafting.StrikePanel"/> pattern in <see cref="Crafting.CraftingRecipe"/>.</summary>
            public const int PanelsPerPatternWidth = 2;

            /// <summary>Height of the <see cref="Crafting.StrikePanel"/> pattern in <see cref="Crafting.CraftingRecipe"/>.</summary>
            public const int PanelsPerPatternHeight = 8;
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
    }
}
