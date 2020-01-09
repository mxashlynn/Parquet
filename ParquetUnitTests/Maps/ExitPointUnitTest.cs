using ParquetClassLibrary;
using ParquetClassLibrary.Maps;
using ParquetClassLibrary.Utilities;
using Xunit;

namespace ParquetUnitTests.Maps.SpecialPoints
{
    public class ExitPointUnitTest
    {
        [Fact]
        public void ExitPointKnowsWhereItLeadsTest()
        {
            EntityID arbitraryID = TestModels.TestMapRegion.ID + 3;
            var exitPoint = new ExitPoint(Vector2D.Zero, arbitraryID);

            Assert.Equal(arbitraryID, exitPoint.Destination);
        }
    }
}
