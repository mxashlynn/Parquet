using System;
using ParquetClassLibrary.Map;
using ParquetClassLibrary.Utilities;
using Xunit;

namespace ParquetUnitTests.Map.SpecialPoints
{
    public class ExitPointUnitTest
    {
        [Fact]
        public void ExitPointKnowsWhereItLeadsTest()
        {
            var arbitraryGUID = new Guid();
            var exitPoint = new ExitPoint(Vector2D.Zero, arbitraryGUID);

            Assert.Equal(arbitraryGUID, exitPoint.Destination);
        }
    }
}
