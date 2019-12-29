using ParquetClassLibrary.Maps;
using Xunit;

namespace ParquetUnitTests.Map
{
    public class ChunkTypeUnitTest
    {
        [Fact]
        internal void DefaultChunkTypeIsEmptyTest()
        {
            var defaultChunk = new ChunkType();

            Assert.False(defaultChunk.Handmade);
            Assert.Equal(ChunkType.Empty, defaultChunk);
        }
    }
}
