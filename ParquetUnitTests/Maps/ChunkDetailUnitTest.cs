using ParquetClassLibrary.Maps;
using Xunit;

namespace ParquetUnitTests.Maps
{
    public class ChunkDetailUnitTest
    {
        [Fact]
        internal void DefaultChunkTypeIsEmptyTest()
        {
            var defaultChunk = new ChunkDetail();

            Assert.Equal(ChunkDetail.None, defaultChunk);
        }
    }
}
