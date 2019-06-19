using System.Collections.Generic;
using ParquetClassLibrary.Parquets;
using ParquetClassLibrary.Stubs;
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

        private static readonly HashSet<Space> TestPerimeter= new HashSet<Space>
        {
            new Space(0, 0, TestWall),
            new Space(1, 0, TestWall),
            new Space(2, 0, TestWall),
            new Space(3, 0, TestWall),
            new Space(0, 1, TestWall),
            new Space(3, 1, TestWall),
            new Space(0, 2, TestWall),
            new Space(3, 2, TestWall),
            new Space(0, 3, TestWall),
            new Space(1, 3, TestWall),
            new Space(2, 3, TestWall),
            new Space(3, 3, TestWall),
        };

        private static readonly HashSet<Space> TestWalkableArea = new HashSet<Space>
        {
            new Space(1, 1, TestWalk),
            new Space(2, 1, TestWalk),
            new Space(1, 2, TestWalk),
            new Space(2, 2, TestEntry),
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
                var _ = new Room(new HashSet<Space>(), TestPerimeter);
            }

            Assert.Throws<IndexOutOfRangeException>(EmptyWalkableArea);
        }

        [Fact]
        internal void EmptyPerimeterThrowsTest()
        {
            void EmptyPerimeter()
            {
                var _ = new Room(TestWalkableArea, new HashSet<Space>());
            }

            Assert.Throws<IndexOutOfRangeException>(EmptyPerimeter);
        }

        [Fact]
        internal void NoEntryThrowsTest()
        {
            var walkableAreaWithNoExit = new HashSet<Space>
            {
                new Space(new Vector2Int(1, 1), TestWalk),
                new Space(new Vector2Int(2, 1), TestWalk),
                new Space(new Vector2Int(1, 2), TestWalk),
                new Space(new Vector2Int(2, 2), TestWalk),
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
            var UncontainedPosition = new Vector2Int(TestPerimeter.Select(space => space.Position.X).Min() - 1,
                                                     TestPerimeter.Select(space => space.Position.Y).Min() - 1);

            Assert.False(ValidRoom.ContainsPosition(UncontainedPosition));
        }
    }
}
