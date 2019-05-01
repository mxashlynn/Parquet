using ParquetClassLibrary.Sandbox;
using ParquetClassLibrary.Stubs;
using Xunit;

namespace ParquetUnitTests.Sandbox
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
