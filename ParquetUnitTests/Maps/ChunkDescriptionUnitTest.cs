using ParquetClassLibrary.Maps;
using Xunit;

namespace ParquetUnitTests.Maps
{
    public class ChunkDescriptionUnitTest
    {
        [Fact]
        internal void DefaultChunkTypeIsEmptyTest()
        {
            var defaultChunk = new ChunkDescription();

            Assert.Equal(ChunkDescription.Empty, defaultChunk);
        }
    }
}
