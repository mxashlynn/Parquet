using System;
using ParquetClassLibrary.Sandbox.SpecialPoints;
using ParquetClassLibrary.Stubs;
using Xunit;

namespace ParquetUnitTests.Sandbox
{
    public class ExitPointUnitTest
    {
        [Fact]
        public void ExitPointKnowsWhereItLeadsTest()
        {
            var arbitraryGUID = new Guid();
            var exitPoint = new ExitPoint(Vector2Int.ZeroVector, arbitraryGUID);

            Assert.Equal(arbitraryGUID, exitPoint.Destination);
        }
    }
}