using System.Collections.Generic;
using ParquetClassLibrary.Parquets;
using ParquetClassLibrary.Utilities;
using Xunit;
using System;
using ParquetClassLibrary;
using ParquetClassLibrary.Rooms;
using System.Linq;

namespace ParquetUnitTests.Rooms
{
    public class RoomUnitTest
    {
        #region Test Values
        private static readonly ParquetStack TestWall = new ParquetStack(TestEntities.TestFloor.ID, TestEntities.TestBlock.ID, EntityID.None, EntityID.None);

        private static readonly ParquetStack TestWalk = new ParquetStack(TestEntities.TestFloor.ID, EntityID.None, EntityID.None, EntityID.None);

        private static readonly ParquetStack TestEntry = new ParquetStack(TestEntities.TestFloor.ID, EntityID.None, TestEntities.TestFurnishing.ID, EntityID.None);

        private static readonly HashSet<MapSpace> TestPerimeter = new HashSet<MapSpace>
        {
            new MapSpace(0, 0, TestWall),
            new MapSpace(1, 0, TestWall),
            new MapSpace(2, 0, TestWall),
            new MapSpace(3, 0, TestWall),
            new MapSpace(0, 1, TestWall),
            new MapSpace(3, 1, TestWall),
            new MapSpace(0, 2, TestWall),
            new MapSpace(3, 2, TestWall),
            new MapSpace(0, 3, TestWall),
            new MapSpace(1, 3, TestWall),
            new MapSpace(2, 3, TestWall),
            new MapSpace(3, 3, TestWall),
        };

        private static readonly HashSet<MapSpace> TestWalkableArea = new HashSet<MapSpace>
        {
            new MapSpace(1, 1, TestWalk),
            new MapSpace(2, 1, TestWalk),
            new MapSpace(1, 2, TestWalk),
            new MapSpace(2, 2, TestEntry),
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
                var _ = new Room(new HashSet<MapSpace>(), TestPerimeter);
            }

            Assert.Throws<IndexOutOfRangeException>(EmptyWalkableArea);
        }

        [Fact]
        internal void EmptyPerimeterThrowsTest()
        {
            void EmptyPerimeter()
            {
                var _ = new Room(TestWalkableArea, new HashSet<MapSpace>());
            }

            Assert.Throws<IndexOutOfRangeException>(EmptyPerimeter);
        }

        [Fact]
        internal void NoEntryThrowsTest()
        {
            var walkableAreaWithNoExit = new HashSet<MapSpace>
            {
                new MapSpace(1, 1, TestWalk),
                new MapSpace(2, 1, TestWalk),
                new MapSpace(1, 2, TestWalk),
                new MapSpace(2, 2, TestWalk),
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
            var otherWalkableArea = new HashSet<MapSpace>
            {
                new MapSpace(1, 1, TestEntry),
                new MapSpace(2, 1, TestWalk),
                new MapSpace(1, 2, TestWalk),
                new MapSpace(2, 2, TestWalk),
            };

            var room1 = new Room(TestWalkableArea, TestPerimeter);
            var room2 = new Room(otherWalkableArea, TestPerimeter);

            Assert.NotEqual(room1, room2);
        }
    }
}
