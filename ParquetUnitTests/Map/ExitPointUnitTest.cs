using ParquetClassLibrary;
using ParquetClassLibrary.Maps;
using ParquetClassLibrary.Utilities;
using Xunit;

namespace ParquetUnitTests.Map.SpecialPoints
{
    public class ExitPointUnitTest
    {
        [Fact]
        public void ExitPointKnowsWhereItLeadsTest()
        {
            EntityID arbitraryID = TestEntities.TestMapRegion.ID + 3;
            var exitPoint = new ExitPoint(Vector2D.Zero, arbitraryID);

            Assert.Equal(arbitraryID, exitPoint.Destination);
        }
    }
}
