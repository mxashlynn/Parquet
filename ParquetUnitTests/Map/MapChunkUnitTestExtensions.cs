using ParquetClassLibrary.Maps;
using ParquetClassLibrary.Utilities;

namespace ParquetUnitTests.Map
{
    /// <summary>
    /// Provides extension methods of <see cref="MapChunk"/> used in unit testing.
    /// </summary>
    internal static class MapChunkUnitTestExtensions
    {
        /// <summary>Fills the chunk with a test pattern.</summary>
        public static MapChunk FillTestPattern(this MapChunk inMapChunk)
        {
            for (var y = 0; y < inMapChunk.DimensionsInParquets.Y; y++)
            {
                for (var x = 0; x < inMapChunk.DimensionsInParquets.X; x++)
                {
                    inMapChunk.TrySetFloorDefinition(TestEntities.TestFloor.ID, new Vector2D(x, y));
                }

                inMapChunk.TrySetBlockDefinition(TestEntities.TestBlock.ID, new Vector2D(0, y));
                inMapChunk.TrySetBlockDefinition(TestEntities.TestBlock.ID, new Vector2D(inMapChunk.DimensionsInParquets.X - 1, y));
            }
            for (var x = 0; x < inMapChunk.DimensionsInParquets.X; x++)
            {
                inMapChunk.TrySetBlockDefinition(TestEntities.TestBlock.ID, new Vector2D(x, 0));
                inMapChunk.TrySetBlockDefinition(TestEntities.TestBlock.ID, new Vector2D(x, inMapChunk.DimensionsInParquets.Y - 1));
            }
            inMapChunk.TrySetFurnishingDefinition(TestEntities.TestFurnishing.ID, new Vector2D(1, 2));
            inMapChunk.TrySetCollectibleDefinition(TestEntities.TestCollectible.ID, new Vector2D(3, 3));

            return inMapChunk;
        }
    }
}
