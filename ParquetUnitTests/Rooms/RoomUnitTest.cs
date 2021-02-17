using System;
using System.Collections.Generic;
using System.Linq;
using Parquet;
using Parquet.Parquets;
using Parquet.Rooms;
using Xunit;

namespace ParquetUnitTests.Rooms
{
    public class RoomUnitTest
    {
        #region Test Values
        private static readonly ParquetModelPack TestWall = new ParquetModelPack(TestModels.TestFloor.ID, TestModels.TestBlock.ID, ModelID.None, ModelID.None);

        private static readonly ParquetModelPack TestWalk = new ParquetModelPack(TestModels.TestFloor.ID, ModelID.None, ModelID.None, ModelID.None);

        private static readonly ParquetModelPack TestEntry = new ParquetModelPack(TestModels.TestFloor.ID, ModelID.None, TestModels.TestFurnishing.ID, ModelID.None);

        private static readonly IReadOnlySet<MapSpace> TestPerimeter = new HashSet<MapSpace>
        {
            new MapSpace(0, 0, TestWall, null),
            new MapSpace(1, 0, TestWall, null),
            new MapSpace(2, 0, TestWall, null),
            new MapSpace(3, 0, TestWall, null),
            new MapSpace(0, 1, TestWall, null),
            new MapSpace(3, 1, TestWall, null),
            new MapSpace(0, 2, TestWall, null),
            new MapSpace(3, 2, TestWall, null),
            new MapSpace(0, 3, TestWall, null),
            new MapSpace(1, 3, TestWall, null),
            new MapSpace(2, 3, TestWall, null),
            new MapSpace(3, 3, TestWall, null),
        };

        private static readonly IReadOnlySet<MapSpace> TestWalkableArea = new HashSet<MapSpace>
        {
            new MapSpace(1, 1, TestWalk, null),
            new MapSpace(2, 1, TestWalk, null),
            new MapSpace(1, 2, TestWalk, null),
            new MapSpace(2, 2, TestEntry, null),
        };

        private static readonly Room ValidRoom = new Room(TestWalkableArea, TestPerimeter);
        #endregion

        [Fact]
        internal void NullWalkableAreaThrowsTest()
        {
            static void NullWalkableArea()
            {
                var _ = new Room(null, TestPerimeter);
            }

            Assert.Throws<ArgumentNullException>(NullWalkableArea);
        }

        [Fact]
        internal void NullPerimeterThrowsTest()
        {
            static void NullPerimeter()
            {
                var _ = new Room(TestWalkableArea, null);
            }

            Assert.Throws<ArgumentNullException>(NullPerimeter);
        }

        [Fact]
        internal void EmptyWalkableAreaThrowsTest()
        {
            static void EmptyWalkableArea()
            {
                var _ = new Room(new HashSet<MapSpace>(), TestPerimeter);
            }

            Assert.Throws<IndexOutOfRangeException>(EmptyWalkableArea);
        }

        [Fact]
        internal void EmptyPerimeterThrowsTest()
        {
            static void EmptyPerimeter()
            {
                var _ = new Room(TestWalkableArea, new HashSet<MapSpace>());
            }

            Assert.Throws<IndexOutOfRangeException>(EmptyPerimeter);
        }

        [Fact]
        internal void NoEntryThrowsTest()
        {
            var walkableAreaWithNoExit = (IReadOnlySet<MapSpace>)new HashSet<MapSpace>
            {
                new MapSpace(1, 1, TestWalk, null),
                new MapSpace(2, 1, TestWalk, null),
                new MapSpace(1, 2, TestWalk, null),
                new MapSpace(2, 2, TestWalk, null),
            };

            void BadWalkableArea()
            {
                var _ = new Room(walkableAreaWithNoExit, TestPerimeter);
            }

            Assert.Throws<ArgumentException>(BadWalkableArea);
        }

        [Fact]
        internal void ContainedPositionIsFoundTest()
        {
            var ContainedPosition = TestWalkableArea.ElementAt(0).Position;

            Assert.True(ValidRoom.ContainsPosition(ContainedPosition));
        }

        [Fact]
        internal void UncontainedPositionIsNotFoundTest()
        {
            var UncontainedPosition = new Vector2D(TestPerimeter.Select(space => space.Position.X).Min() - 1,
                                                     TestPerimeter.Select(space => space.Position.Y).Min() - 1);

            Assert.False(ValidRoom.ContainsPosition(UncontainedPosition));
        }

        [Fact]
        internal void IdenticalRoomsAreEqualTest()
        {
            var room1 = new Room(TestWalkableArea, TestPerimeter);
            var room2 = new Room(TestWalkableArea, TestPerimeter);

            Assert.Equal(room1, room2);
        }

        [Fact]
        internal void DifferingRoomsAreUnequalTest()
        {
            var otherWalkableArea = (IReadOnlySet<MapSpace>)new HashSet<MapSpace>
            {
                new MapSpace(1, 1, TestEntry, null),
                new MapSpace(2, 1, TestWalk, null),
                new MapSpace(1, 2, TestWalk, null),
                new MapSpace(2, 2, TestWalk, null),
            };

            var room1 = new Room(TestWalkableArea, TestPerimeter);
            var room2 = new Room(otherWalkableArea, TestPerimeter);

            Assert.NotEqual(room1, room2);
        }
    }
}
