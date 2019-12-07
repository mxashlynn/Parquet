using ParquetClassLibrary;
using ParquetClassLibrary.Parquets;
using ParquetClassLibrary.Utilities;
using Xunit;

namespace ParquetUnitTests.Rooms
{
    public class MapSpaceUnitTest
    {
        #region Test Values
        private static readonly ParquetStack TVoid = ParquetStack.Empty;
        private static readonly ParquetStack TWall = new ParquetStack(TestEntities.TestFloor.ID, TestEntities.TestBlock.ID, EntityID.None, EntityID.None);
        private static readonly ParquetStack TDoor = new ParquetStack(TestEntities.TestFloor.ID, TestEntities.TestBlock.ID, TestEntities.TestFurnishing.ID, EntityID.None);
        private static readonly ParquetStack TTile = new ParquetStack(TestEntities.TestFloor.ID, EntityID.None, EntityID.None, EntityID.None);

        private static readonly ParquetStack[,] TestRoomMap =
        {
            { TWall, TWall, TWall, TWall, TVoid, },
            { TWall, TTile, TTile, TWall, TVoid, },
            { TWall, TTile, TTile, TDoor, TVoid, },
            { TWall, TWall, TWall, TWall, TVoid, },
        };
        #endregion

        [Fact]
        internal void SpaceDotEmptyIsEmptyTest()
        {
            Assert.True(MapSpace.Empty.Content.IsEmpty);
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

            var space1 = new MapSpace(new Vector2D(x, y), testStack);
            var space2 = new MapSpace(new Vector2D(x, y), testStack);

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

            var space1 = new MapSpace(new Vector2D(x1, y1), testStack);
            var space2 = new MapSpace(new Vector2D(x2, y2), testStack);

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

            var space1 = new MapSpace(new Vector2D(x, y), testStack1);
            var space2 = new MapSpace(new Vector2D(x, y), testStack2);

            Assert.NotEqual(space1, space2);
        }

        [Fact]
        internal void ValidNorthNeighbourIsFoundTest()
        {
            var x = 1;
            var y = 1;

            var space = new MapSpace(new Vector2D(x, y), TestRoomMap[y, x]);
            var neighbour = space.NorthNeighbor(TestRoomMap);

            Assert.NotEqual(space, neighbour);
            Assert.Equal(neighbour.Position.Y, y - 1);
        }

        [Fact]
        internal void InvalidNorthNeighbourIsEmptyTest()
        {
            var x = 0;
            var y = 0;

            var space = new MapSpace(new Vector2D(x, y), TestRoomMap[y, x]);
            var neighbour = space.NorthNeighbor(TestRoomMap);

            Assert.NotEqual(space, neighbour);
            Assert.Equal(neighbour, MapSpace.Empty);
        }

        [Fact]
        internal void ValidSouthNeighbourIsFoundTest()
        {
            var x = 1;
            var y = 1;

            var space = new MapSpace(new Vector2D(x, y), TestRoomMap[y, x]);
            var neighbour = space.SouthNeighbor(TestRoomMap);

            Assert.NotEqual(space, neighbour);
            Assert.Equal(neighbour.Position.Y, y + 1);
        }

        [Fact]
        internal void InvalidSouthNeighbourIsEmptyTest()
        {
            var x = 1;
            var y = TestRoomMap.GetLength(0) - 1;

            var space = new MapSpace(new Vector2D(x, y), TestRoomMap[y, x]);
            var neighbour = space.SouthNeighbor(TestRoomMap);

            Assert.NotEqual(space, neighbour);
            Assert.Equal(neighbour, MapSpace.Empty);
        }

        [Fact]
        internal void ValidEastNeighbourIsFoundTest()
        {
            var x = 1;
            var y = 1;

            var space = new MapSpace(new Vector2D(x, y), TestRoomMap[y, x]);
            var neighbour = space.EastNeighbor(TestRoomMap);

            Assert.NotEqual(space, neighbour);
            Assert.Equal(neighbour.Position.X, x + 1);
        }

        [Fact]
        internal void InvalidEastNeighbourIsEmptyTest()
        {
            var x = TestRoomMap.GetLength(1) - 1;
            var y = 1;

            var space = new MapSpace(new Vector2D(x, y), TestRoomMap[y, x]);
            var neighbour = space.EastNeighbor(TestRoomMap);

            Assert.NotEqual(space, neighbour);
            Assert.Equal(neighbour, MapSpace.Empty);
        }

        [Fact]
        internal void ValidWestNeighbourIsFoundTest()
        {
            var x = 1;
            var y = 1;

            var space = new MapSpace(new Vector2D(x, y), TestRoomMap[y, x]);
            var neighbour = space.WestNeighbor(TestRoomMap);

            Assert.NotEqual(space, neighbour);
            Assert.Equal(neighbour.Position.X, x - 1);
        }

        [Fact]
        internal void InvalidWestNeighbourIsEmptyTest()
        {
            var x = 0;
            var y = 0;

            var space = new MapSpace(new Vector2D(x, y), TestRoomMap[y, x]);
            var neighbour = space.WestNeighbor(TestRoomMap);

            Assert.NotEqual(space, neighbour);
            Assert.Equal(neighbour, MapSpace.Empty);
        }
    }
}
