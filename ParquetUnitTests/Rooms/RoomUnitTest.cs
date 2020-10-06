using System;
using System.Collections.Generic;
using System.Linq;
using ParquetClassLibrary;
using ParquetClassLibrary.Parquets;
using ParquetClassLibrary.Rooms;
using Xunit;

namespace ParquetUnitTests.Rooms
{
    public class RoomUnitTest
    {
        #region Test Values
        private static readonly ParquetStack TestWall = new ParquetStack(TestModels.TestFloor.ID, TestModels.TestBlock.ID, ModelID.None, ModelID.None);

        private static readonly ParquetStack TestWalk = new ParquetStack(TestModels.TestFloor.ID, ModelID.None, ModelID.None, ModelID.None);

        private static readonly ParquetStack TestEntry = new ParquetStack(TestModels.TestFloor.ID, ModelID.None, TestModels.TestFurnishing.ID, ModelID.None);

        private static readonly IReadOnlySet<MapSpace> TestPerimeter = (IReadOnlySet<MapSpace>)new HashSet<MapSpace>
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

        private static readonly IReadOnlySet<MapSpace> TestWalkableArea = (IReadOnlySet<MapSpace>)new HashSet<MapSpace>
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
            void NullWalkableArea()
            {
                var _ = new Room(null, TestPerimeter);
            }

            Assert.Throws<ArgumentNullException>(NullWalkableArea);
        }

        [Fact]
        internal void NullPerimeterThrowsTest()
        {
            void NullPerimeter()
            {
                var _ = new Room(TestWalkableArea, null);
            }

            Assert.Throws<ArgumentNullException>(NullPerimeter);
        }

        [Fact]
        internal void EmptyWalkableAreaThrowsTest()
        {
            void EmptyWalkableArea()
            {
                var _ = new Room((IReadOnlySet<MapSpace>)new HashSet<MapSpace>(), TestPerimeter);
            }

            Assert.Throws<IndexOutOfRangeException>(EmptyWalkableArea);
        }

        [Fact]
        internal void EmptyPerimeterThrowsTest()
        {
            void EmptyPerimeter()
            {
                var _ = new Room(TestWalkableArea, (IReadOnlySet<MapSpace>)new HashSet<MapSpace>());
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

            void BadWalkableAre()
            {
                var _ = new Room(walkableAreaWithNoExit, TestPerimeter);
            }

            Assert.Throws<ArgumentException>(BadWalkableAre);
        }

        [Fact]
        internal void ContainedPositionIsFoundTest()
        {
            var ContainedPosition = TestWalkableArea.ToList().ElementAt(0).Position;

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
