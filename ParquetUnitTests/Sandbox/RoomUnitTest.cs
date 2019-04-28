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

        private static readonly ParquetStack TestFloor = new ParquetStack(TestEntities.TestFloor, null, null, null);

        private static readonly ParquetStack TestExit = new ParquetStack(TestEntities.TestFloor, null, TestEntities.TestFurnishing, null);

        private static readonly HashSet<Space> TestPerimeter= new HashSet<Space>
        {
            new Space(new Vector2Int(0, 0), TestWall),
            new Space(new Vector2Int(1, 0), TestWall),
            new Space(new Vector2Int(2, 0), TestWall),
            new Space(new Vector2Int(3, 0), TestWall),
            new Space(new Vector2Int(0, 1), TestWall),
            new Space(new Vector2Int(3, 1), TestWall),
            new Space(new Vector2Int(0, 2), TestWall),
            new Space(new Vector2Int(1, 2), TestWall),
            new Space(new Vector2Int(2, 2), TestWall),
            new Space(new Vector2Int(3, 2), TestWall),
        };

        private static readonly HashSet<Space> TestWalkableArea = new HashSet<Space>
        {
            new Space(new Vector2Int(1, 1), TestFloor),
            new Space(new Vector2Int(2, 1), TestExit),
        };
        #endregion

        [Fact]
        internal void NullOrEmptyParametersThrowTest()
        {
            void NullWalkableArea()
            {
                var _ = new Room(null, TestPerimeter);
            }

            void NullPerimeter()
            {
                var _ = new Room(TestWalkableArea, null);
            }

            void EmptyWalkableAre()
            {
                var _ = new Room(new HashSet<Space>(), TestPerimeter);
            }

            void EmptyPerimeter()
            {
                var _ = new Room(TestWalkableArea, new HashSet<Space>());
            }

            Assert.Throws<ArgumentNullException>(NullWalkableArea);
            Assert.Throws<ArgumentNullException>(NullPerimeter);
            Assert.Throws<IndexOutOfRangeException>(EmptyWalkableAre);
            Assert.Throws<IndexOutOfRangeException>(EmptyPerimeter);
        }

        [Fact]
        internal void NoEntryThrowsTest()
        {
            var walkableAreaWithNoExit = new HashSet<Space>
            {
                new Space(new Vector2Int(1, 1), TestFloor),
                new Space(new Vector2Int(2, 1), TestFloor),
            };

            void BadWalkableAre()
            {
                var _ = new Room(walkableAreaWithNoExit, TestPerimeter);
            }

            Assert.Throws<ArgumentException>(BadWalkableAre);
        }
    }
}
