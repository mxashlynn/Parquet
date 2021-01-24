using Parquet;
using Parquet.Parquets;
using Parquet.Rooms;
using Xunit;

namespace ParquetUnitTests.Parquets
{
    public class MapSpaceUnitTest
    {
        #region Test Values
        private static readonly ParquetPack TVoid = ParquetPack.Empty;
        private static readonly ParquetPack TWall = new ParquetPack(TestModels.TestFloor.ID, TestModels.TestBlock.ID, ModelID.None, ModelID.None);
        private static readonly ParquetPack TDoor = new ParquetPack(TestModels.TestFloor.ID, TestModels.TestBlock.ID, TestModels.TestFurnishing.ID, ModelID.None);
        private static readonly ParquetPack TTile = new ParquetPack(TestModels.TestFloor.ID, ModelID.None, ModelID.None, ModelID.None);

        private static readonly ParquetPack[,] TestRoomMap =
        {
            { TWall, TWall, TWall, TWall, TVoid, },
            { TWall, TTile, TTile, TWall, TVoid, },
            { TWall, TTile, TTile, TDoor, TVoid, },
            { TWall, TWall, TWall, TWall, TVoid, },
        };
        #endregion

        [Fact]
        internal void SpaceDotEmptyIsEmptyTest() => Assert.True(MapSpace.Empty.Content.IsEmpty);

        [Fact]
        internal void IdenticalSpacesAreEqualTest()
        {
            var x = 10;
            var y = 30;
            var testStack = new ParquetPack(TestModels.TestFloor.ID,
                                             TestModels.TestBlock.ID,
                                             TestModels.TestFurnishing.ID,
                                             TestModels.TestCollectible.ID);

            var space1 = new MapSpace(new Vector2D(x, y), testStack, null);
            var space2 = new MapSpace(new Vector2D(x, y), testStack, null);

            Assert.Equal(space1, space2);
        }

        [Fact]
        internal void DifferingPositionsAreUnequalTest()
        {
            var x1 = 10;
            var y1 = 30;
            var x2 = 20;
            var y2 = 20;
            var testStack = new ParquetPack(TestModels.TestFloor.ID,
                                             TestModels.TestBlock.ID,
                                             TestModels.TestFurnishing.ID,
                                             TestModels.TestCollectible.ID);

            var space1 = new MapSpace(new Vector2D(x1, y1), testStack, null);
            var space2 = new MapSpace(new Vector2D(x2, y2), testStack, null);

            Assert.NotEqual(space1, space2);
        }

        [Fact]
        internal void DifferingContentsAreUnequalTest()
        {
            var x = 10;
            var y = 30;
            var testStack1 = new ParquetPack(TestModels.TestFloor.ID,
                                             TestModels.TestBlock.ID,
                                             TestModels.TestFurnishing.ID,
                                             TestModels.TestCollectible.ID);
            var testStack2 = new ParquetPack(TestModels.TestFloor.ID - 1,
                                             TestModels.TestBlock.ID - 1,
                                             TestModels.TestFurnishing.ID - 1,
                                             TestModels.TestCollectible.ID - 1);

            var space1 = new MapSpace(new Vector2D(x, y), testStack1, null);
            var space2 = new MapSpace(new Vector2D(x, y), testStack2, null);

            Assert.NotEqual(space1, space2);
        }

        [Fact]
        internal void ValidNorthNeighbourIsFoundTest()
        {
            var x = 1;
            var y = 1;

            var space = new MapSpace(new Vector2D(x, y), TestRoomMap[y, x], new ParquetPackGrid(TestRoomMap));
            var neighbour = space.NorthNeighbor();

            Assert.NotEqual(space, neighbour);
            Assert.Equal(neighbour.Position.Y, y - 1);
        }

        [Fact]
        internal void InvalidNorthNeighbourIsEmptyTest()
        {
            var x = 0;
            var y = 0;

            var space = new MapSpace(new Vector2D(x, y), TestRoomMap[y, x], new ParquetPackGrid(TestRoomMap));
            var neighbour = space.NorthNeighbor();

            Assert.NotEqual(space, neighbour);
            Assert.Equal(neighbour, MapSpace.Empty);
        }

        [Fact]
        internal void ValidSouthNeighbourIsFoundTest()
        {
            var x = 1;
            var y = 1;

            var space = new MapSpace(new Vector2D(x, y), TestRoomMap[y, x], new ParquetPackGrid(TestRoomMap));
            var neighbour = space.SouthNeighbor();

            Assert.NotEqual(space, neighbour);
            Assert.Equal(neighbour.Position.Y, y + 1);
        }

        [Fact]
        internal void InvalidSouthNeighbourIsEmptyTest()
        {
            var x = 1;
            var y = TestRoomMap.GetLength(0) - 1;

            var space = new MapSpace(new Vector2D(x, y), TestRoomMap[y, x], new ParquetPackGrid(TestRoomMap));
            var neighbour = space.SouthNeighbor();

            Assert.NotEqual(space, neighbour);
            Assert.Equal(neighbour, MapSpace.Empty);
        }

        [Fact]
        internal void ValidEastNeighbourIsFoundTest()
        {
            var x = 1;
            var y = 1;

            var space = new MapSpace(new Vector2D(x, y), TestRoomMap[y, x], new ParquetPackGrid(TestRoomMap));
            var neighbour = space.EastNeighbor();

            Assert.NotEqual(space, neighbour);
            Assert.Equal(neighbour.Position.X, x + 1);
        }

        [Fact]
        internal void InvalidEastNeighbourIsEmptyTest()
        {
            var x = TestRoomMap.GetLength(1) - 1;
            var y = 1;

            var space = new MapSpace(new Vector2D(x, y), TestRoomMap[y, x], new ParquetPackGrid(TestRoomMap));
            var neighbour = space.EastNeighbor();

            Assert.NotEqual(space, neighbour);
            Assert.Equal(neighbour, MapSpace.Empty);
        }

        [Fact]
        internal void ValidWestNeighbourIsFoundTest()
        {
            var x = 1;
            var y = 1;

            var space = new MapSpace(new Vector2D(x, y), TestRoomMap[y, x], new ParquetPackGrid(TestRoomMap));
            var neighbour = space.WestNeighbor();

            Assert.NotEqual(space, neighbour);
            Assert.Equal(neighbour.Position.X, x - 1);
        }

        [Fact]
        internal void InvalidWestNeighbourIsEmptyTest()
        {
            var x = 0;
            var y = 0;

            var space = new MapSpace(new Vector2D(x, y), TestRoomMap[y, x], new ParquetPackGrid(TestRoomMap));
            var neighbour = space.WestNeighbor();

            Assert.NotEqual(space, neighbour);
            Assert.Equal(neighbour, MapSpace.Empty);
        }
    }
}
