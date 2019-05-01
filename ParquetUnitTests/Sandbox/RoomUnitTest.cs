using System.Collections.Generic;
using ParquetClassLibrary.Sandbox.Parquets;
using ParquetClassLibrary.Sandbox;
using ParquetClassLibrary.Stubs;
using Xunit;
using System;

namespace ParquetUnitTests.Sandbox
{
    public class RoomUnitTest
    {
        #region Test Values
        private static readonly ParquetStack TestWall = new ParquetStack(TestEntities.TestFloor, TestEntities.TestBlock, null, null);

        private static readonly ParquetStack TestWalk = new ParquetStack(TestEntities.TestFloor, null, null, null);

        private static readonly ParquetStack TestEntry = new ParquetStack(TestEntities.TestFloor, null, TestEntities.TestFurnishing, null);

        private static readonly HashSet<Space> TestPerimeter= new HashSet<Space>
        {
            new Space(new Vector2Int(0, 0), TestWall),
            new Space(new Vector2Int(1, 0), TestWall),
            new Space(new Vector2Int(2, 0), TestWall),
            new Space(new Vector2Int(3, 0), TestWall),
            new Space(new Vector2Int(0, 1), TestWall),
            new Space(new Vector2Int(3, 1), TestWall),
            new Space(new Vector2Int(0, 2), TestWall),
            new Space(new Vector2Int(3, 2), TestWall),
            new Space(new Vector2Int(0, 3), TestWall),
            new Space(new Vector2Int(1, 3), TestWall),
            new Space(new Vector2Int(2, 3), TestWall),
            new Space(new Vector2Int(3, 3), TestWall),
        };

        private static readonly HashSet<Space> TestWalkableArea = new HashSet<Space>
        {
            new Space(new Vector2Int(1, 1), TestWalk),
            new Space(new Vector2Int(2, 1), TestWalk),
            new Space(new Vector2Int(1, 2), TestWalk),
            new Space(new Vector2Int(2, 2), TestEntry),
        };
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
    }
}
