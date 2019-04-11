using System;
using ParquetClassLibrary.Sandbox.IDs;
using Xunit;

namespace ParquetUnitTests.Sandbox
{
    public class ChunkTypeUnitTest
    {
        [Fact]
        internal void ChunkTypeToElevationNeverReturnsNoneTest()
        {
            foreach (ChunkType chunk in Enum.GetValues(typeof(ChunkType)))
            {
                var elevation = chunk.ToElevation();

                Assert.NotEqual(ElevationMask.None, elevation);
            }
        }

        [Fact]
        internal void ChunkTypeIsNotLoadableForAllButHandmadeTest()
        {
            foreach (ChunkType chunk in Enum.GetValues(typeof(ChunkType)))
            {
                if (chunk == ChunkType.Handmade)
                {
                    continue;
                }

                var result = chunk.IsLoadable();

                Assert.False(result);
            }
        }
        [Fact]
        internal void ChunkTypeIsLoadableReturnsTrueForHandmadeTest()
        {
            var result = ChunkType.Handmade.IsLoadable();

            Assert.True(result);
        }
    }
}
