using System;
using System.Collections.Generic;
using ParquetClassLibrary;
using ParquetClassLibrary.Parquets;
using ParquetClassLibrary.Rooms;
using Xunit;

namespace ParquetUnitTests.Rooms
{
    public class RoomRecipeUnitTest
    {
        #region Test Values
        private static readonly ParquetStack TestWall = new ParquetStack(TestModels.TestFloor.ID, TestModels.TestBlock.ID, EntityID.None, EntityID.None);

        private static readonly ParquetStack TestWalk = new ParquetStack(TestModels.TestFloor.ID, EntityID.None, EntityID.None, EntityID.None);

        private static readonly ParquetStack TestEntry = new ParquetStack(TestModels.TestFloor.ID, EntityID.None, TestModels.TestFurnishing.ID, EntityID.None);

        private static readonly HashSet<MapSpace> TestPerimeter = new HashSet<MapSpace>
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

        private static readonly HashSet<MapSpace> TestWalkableArea = new HashSet<MapSpace>
        {
            new MapSpace(1, 1, TestWalk, null),
            new MapSpace(2, 1, TestWalk, null),
            new MapSpace(1, 2, TestWalk, null),
            new MapSpace(2, 2, TestEntry, null),
        };

        private static readonly IReadOnlyList<RecipeElement> TestRequiredFurnishings = TestModels.TestRecipeElementList;

        private static readonly RoomRecipe MinimalRecipe =
            new RoomRecipe(-All.RoomRecipeIDs.Minimum, "Minimal Room Recipe", "", "", Rules.Recipes.Room.MinWalkableSpaces, TestRequiredFurnishings);

        private static readonly Room MinimalRoom = new Room(TestWalkableArea, TestPerimeter);
        #endregion

        [Fact]
        internal void MinimumWalkableSpacesBelowGlobalMinimumThrowsTest()
        {
            var BadMinimum = Rules.Recipes.Room.MinWalkableSpaces - 1;

            void HasBadRequiredBlocks()
            {
                var _ = new RoomRecipe(-All.RoomRecipeIDs.Minimum, "will fail", "", "", BadMinimum);
            }

            Assert.Throws<ArgumentOutOfRangeException>(HasBadRequiredBlocks);
        }

        [Fact]
        internal void MinimumWalkableSpacesAboveGlobalMaximumThrowsTest()
        {
            var BadMinimum = Rules.Recipes.Room.MaxWalkableSpaces + 1;

            void HasBadRequiredBlocks()
            {
                var _ = new RoomRecipe(-All.RoomRecipeIDs.Minimum, "will fail", "", "", BadMinimum);
            }

            Assert.Throws<ArgumentOutOfRangeException>(HasBadRequiredBlocks);
        }

        [Fact]
        internal void StricterRoomRequirementsGenerateHigherPriorityTest()
        {
            var stricterRecipe = TestModels.TestRoomRecipe;

            Assert.True(MinimalRecipe.Priority < stricterRecipe.Priority);
        }

        [Fact]
        internal void KnownMismatchReturnsFalse()
        {
            var stricterRecipe = TestModels.TestRoomRecipe;

            Assert.False(stricterRecipe.Matches(MinimalRoom));
        }

        [Fact]
        internal void KnownMatchReturnsTrue()
        {
            Assert.True(MinimalRecipe.Matches(MinimalRoom));
        }
    }
}
