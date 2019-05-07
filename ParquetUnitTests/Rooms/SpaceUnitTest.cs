using ParquetClassLibrary.Map;
using ParquetClassLibrary.Rooms;
using ParquetClassLibrary.Stubs;
using Xunit;

namespace ParquetUnitTests.Rooms
{
    public class SpaceUnitTest
    {
        [Fact]
        internal void SpaceDotEmptyIsEmpty()
        {
            Assert.True(Space.Empty.Content.IsEmpty);
            Assert.Equal(Vector2Int.ZeroVector, Space.Empty.Position);
        }
    }
}
