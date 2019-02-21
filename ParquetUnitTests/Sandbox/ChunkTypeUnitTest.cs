using Xunit;
using System;
using ParquetClassLibrary.Sandbox;

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
    }
}
