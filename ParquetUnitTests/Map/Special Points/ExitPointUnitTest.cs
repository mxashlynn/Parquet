using System;
using ParquetClassLibrary.Map.SpecialPoints;
using ParquetClassLibrary.Stubs;
using Xunit;

namespace ParquetUnitTests.Map.SpecialPoints
{
    public class ExitPointUnitTest
    {
        [Fact]
        public void ExitPointKnowsWhereItLeadsTest()
        {
            var arbitraryGUID = new Guid();
            var exitPoint = new ExitPoint(Vector2Int.Zero, arbitraryGUID);

            Assert.Equal(arbitraryGUID, exitPoint.Destination);
        }
    }
}