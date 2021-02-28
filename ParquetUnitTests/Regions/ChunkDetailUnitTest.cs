using Parquet.Regions;
using Xunit;

namespace ParquetUnitTests.Maps
{
    /// <summary>
    /// Unit tests <see cref="ChunkDetail"/>.
    /// </summary>
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
