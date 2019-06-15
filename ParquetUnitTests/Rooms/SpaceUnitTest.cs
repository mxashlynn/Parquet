using ParquetClassLibrary.Parquets;
using ParquetClassLibrary.Rooms;
using ParquetClassLibrary.Stubs;
using Xunit;

namespace ParquetUnitTests.Rooms
{
    public class SpaceUnitTest
    {
        [Fact]
        internal void SpaceDotEmptyIsEmptyTest()
        {
            Assert.True(Space.Empty.Content.IsEmpty);
        }

        [Fact]
        internal void IdenticalSpacesAreEqualTest()
        {
            var x = 10;
            var y = 30;
            var testStack = new ParquetStack(TestEntities.TestFloor.ID,
                                             TestEntities.TestBlock.ID,
                                             TestEntities.TestFurnishing.ID,
                                             TestEntities.TestCollectible.ID);

            var space1 = new Space(new Vector2Int(x, y), testStack);
            var space2 = new Space(new Vector2Int(x, y), testStack);

            Assert.Equal(space1, space2);
        }

        [Fact]
        internal void DifferingPositionsAreUnequalTest()
        {
            var x1 = 10;
            var y1 = 30;
            var x2 = 20;
            var y2 = 20;
            var testStack = new ParquetStack(TestEntities.TestFloor.ID,
                                             TestEntities.TestBlock.ID,
                                             TestEntities.TestFurnishing.ID,
                                             TestEntities.TestCollectible.ID);

            var space1 = new Space(new Vector2Int(x1, y1), testStack);
            var space2 = new Space(new Vector2Int(x2, y2), testStack);

            Assert.NotEqual(space1, space2);
        }

        [Fact]
        internal void DifferingContentsAreUnequalTest()
        {
            var x = 10;
            var y = 30;
            var testStack1 = new ParquetStack(TestEntities.TestFloor.ID,
                                             TestEntities.TestBlock.ID,
                                             TestEntities.TestFurnishing.ID,
                                             TestEntities.TestCollectible.ID);
            var testStack2 = new ParquetStack(TestEntities.TestFloor.ID - 1,
                                             TestEntities.TestBlock.ID - 1,
                                             TestEntities.TestFurnishing.ID - 1,
                                             TestEntities.TestCollectible.ID - 1);

            var space1 = new Space(new Vector2Int(x, y), testStack1);
            var space2 = new Space(new Vector2Int(x, y), testStack2);

            Assert.NotEqual(space1, space2);
        }
    }
}
