using System.Collections.Generic;
using ParquetClassLibrary.Sandbox;
using Xunit;
using System;
using ParquetClassLibrary;
using ParquetClassLibrary.Sandbox.Parquets;
using ParquetClassLibrary.Stubs;

namespace ParquetUnitTests.Sandbox
{
    public class RoomRecipeUnitTest
    {
        #region Test Values
        private static readonly ParquetStack TestWall = new ParquetStack(TestEntities.TestFloor, TestEntities.TestBlock, null, null);

        private static readonly ParquetStack TestWalk = new ParquetStack(TestEntities.TestFloor, null, null, null);

        private static readonly ParquetStack TestEntry = new ParquetStack(TestEntities.TestFloor, null, TestEntities.TestFurnishing, null);

        private static readonly HashSet<Space> TestPerimeter = new HashSet<Space>
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

        private static readonly Dictionary<EntityID, int> TestRequiredFurnishings =
            new Dictionary<EntityID, int> { { -All.FurnishingIDs.Minimum, 1 } };

        private static readonly RoomRecipe MinimalRecipe =
            new RoomRecipe(-All.RoomRecipeIDs.Minimum, "Minimal Room Recipe", TestRequiredFurnishings);

        private static readonly Room MinimalRoom = new Room(TestWalkableArea, TestPerimeter);
        #endregion

        [Fact]
        internal void NullRequiredFurnishingsThrowsTest()
        {
            void NullRequiredFurnishings()
            {
                var _ = new RoomRecipe(-All.RoomRecipeIDs.Minimum, "will fail", null);
            }

            Assert.Throws<ArgumentNullException>(NullRequiredFurnishings);
        }

        [Fact]
        internal void EmptyRequiredFurnishingsThrowsTest()
        {
            void EmptyRequiredFurnishings()
            {
                var _ = new RoomRecipe(-All.RoomRecipeIDs.Minimum, "will fail", new Dictionary<EntityID, int>());
            }

            Assert.Throws<IndexOutOfRangeException>(EmptyRequiredFurnishings);
        }

        [Fact]
        internal void NonFurnishingsInRequiredFurnishingsThrowsTest()
        {
            var BadRequiredFurnishings = new Dictionary<EntityID, int> { { -All.BlockIDs.Minimum, 1 } };

            void HasBadRequiredFurnishings()
            {
                var _ = new RoomRecipe(-All.RoomRecipeIDs.Minimum, "will fail", BadRequiredFurnishings);
            }

            Assert.Throws<ArgumentOutOfRangeException>(HasBadRequiredFurnishings);
        }

        [Fact]
        internal void NonFloorInRequiredFloorsThrowsTest()
        {
            var BadRequiredFloors = new List<EntityID> { -All.BlockIDs.Minimum };

            void HasBadRequiredFloors()
            {
                var _ = new RoomRecipe(-All.RoomRecipeIDs.Minimum, "will fail", TestRequiredFurnishings,
                                       in_optionallyRequiredWalkableFloors: BadRequiredFloors);
            }

            Assert.Throws<ArgumentOutOfRangeException>(HasBadRequiredFloors);
        }

        [Fact]
        internal void NonBlockInRequiredBlocksThrowsTest()
        {
            var BadRequiredBlocks = new List<EntityID> { -All.FloorIDs.Minimum };

            void HasBadRequiredBlocks()
            {
                var _ = new RoomRecipe(-All.RoomRecipeIDs.Minimum, "will fail", TestRequiredFurnishings,
                                       in_optionallyRequiredPerimeterBlocks: BadRequiredBlocks);
            }

            Assert.Throws<ArgumentOutOfRangeException>(HasBadRequiredBlocks);
        }

        [Fact]
        internal void MinimumWalkableSpacesBelowGlobalMinimumThrowsTest()
        {
            var BadMinimum = All.Recipes.Rooms.MinWalkableSpaces - 1;

            void HasBadRequiredBlocks()
            {
                var _ = new RoomRecipe(-All.RoomRecipeIDs.Minimum, "will fail", TestRequiredFurnishings,
                    in_MinimumWalkableSpaces: BadMinimum);
            }

            Assert.Throws<ArgumentOutOfRangeException>(HasBadRequiredBlocks);
        }

        [Fact]
        internal void MinimumWalkableSpacesAboveGlobalMaximumThrowsTest()
        {
            var BadMinimum = All.Recipes.Rooms.MaxWalkableSpaces + 1;

            void HasBadRequiredBlocks()
            {
                var _ = new RoomRecipe(-All.RoomRecipeIDs.Minimum, "will fail", TestRequiredFurnishings,
                    in_MinimumWalkableSpaces: BadMinimum);
            }

            Assert.Throws<ArgumentOutOfRangeException>(HasBadRequiredBlocks);
        }

        [Fact]
        internal void StricterRoomRequirementsGenerateHigherPriorityTest()
        {
            var stricterRecipe = TestEntities.TestRoomRecipe;

            Assert.True(MinimalRecipe.Priority < stricterRecipe.Priority);
        }

        [Fact]
        internal void KnownMismatchReturnsFalse()
        {
            var stricterRecipe = TestEntities.TestRoomRecipe;

            Assert.False(stricterRecipe.Matches(MinimalRoom));
        }

        [Fact]
        internal void KnownMatchReturnsTrue()
        {
            Assert.True(MinimalRecipe.Matches(MinimalRoom));
        }
    }
}
