using System.Collections.Generic;
using ParquetClassLibrary;
using ParquetClassLibrary.Biomes;
using ParquetClassLibrary.Characters;
using ParquetClassLibrary.Crafting;
using ParquetClassLibrary.Items;
using ParquetClassLibrary.Map;

using ParquetClassLibrary.Parquets;
using ParquetClassLibrary.Rooms;

namespace ParquetUnitTests
{
    /// <summary>
    /// Stores <see cref="Entity"/> and <see cref="EntityID"/> for use in unit testing.
    /// </summary>
    public static class TestEntities
    {
        #region Test Values
        /// <summary>Used in test patterns in QA routines.</summary>
        public static PlayerCharacter TestPlayer { get; }

        /// <summary>Used in test patterns in QA routines.</summary>
        public static Critter TestCritter { get; }

        /// <summary>Used in test patterns in QA routines.</summary>
        public static NPC TestNPC { get; }

        /// <summary>Used in test patterns in QA routines.</summary>
        public static Floor TestFloor { get; }

        /// <summary>Used in test patterns in QA routines.</summary>
        public static Block TestBlock { get; }

        /// <summary>Used in test patterns in QA routines.</summary>
        public static Furnishing TestFurnishing { get; }

        /// <summary>Used in test patterns in QA routines.</summary>
        public static Collectible TestCollectible { get; }

        /// <summary>Used in test patterns in QA routines.</summary>
        public static RoomRecipe TestRoomRecipe { get; }

        /// <summary>Used in test patterns in QA routines.</summary>
        public static CraftingRecipe TestCraftingRecipe { get; }

        // TODO Update this once Quests are implemented.  Also update type initializer.
        /// <summary>Used in test patterns in QA routines.</summary>
        //public static Quest TestQuest { get; }

        /// <summary>Used in test patterns in QA routines.</summary>
        public static Biome TestBiome { get; }

        /// <summary>Used in test patterns in QA routines.</summary>
        public static Item TestItem { get; }
        #endregion

        static TestEntities()
        {
            var testCraftingElement = new CraftingElement(-All.ItemIDs.Minimum - 100, 1);

            TestPlayer = new PlayerCharacter(-All.PlayerCharacterIDs.Minimum, "0", "Test Player");
            TestCritter = new Critter(-All.CritterIDs.Minimum, "1 Test Critter", All.BiomeIDs.Minimum, Behavior.Still);
            TestNPC = new NPC(-All.NpcIDs.Minimum, "2", "Test NPC", All.BiomeIDs.Minimum, Behavior.Still);
            TestFloor = new Floor(-All.FloorIDs.Minimum, "3 Test Floor");
            TestBlock = new Block(-All.BlockIDs.Minimum, "4 Test Block");
            TestFurnishing = new Furnishing(-All.FurnishingIDs.Minimum, "5 Test Furnishing", in_isEntry: true);
            TestCollectible = new Collectible(-All.CollectibleIDs.Minimum, "6 Test Collectible");
            TestRoomRecipe = new RoomRecipe(-All.RoomRecipeIDs.Minimum - 1, "7 Test Room Recipe",
                                            new Dictionary<EntityID, int> { { -All.FurnishingIDs.Minimum, 1 } },
                                            All.Recipes.Rooms.MinWalkableSpaces + 1,
                                            new List<EntityID> { -All.FloorIDs.Minimum },
                                            new List<EntityID> { -All.BlockIDs.Minimum });
            TestCraftingRecipe = new CraftingRecipe(-All.CraftingRecipeIDs.Minimum, "8 Test Crafting Recipe",
                                                    new List<CraftingElement> { testCraftingElement, },
                                                    new List<CraftingElement> { testCraftingElement, },
                                                    new StrikePanel[All.Dimensions.PanelsPerPatternWidth,
                                                                    All.Dimensions.PanelsPerPatternHeight]);
            //TestQuest = new Quest(-All.QuestIDs.Minimum, "9 Test Quest");
            TestBiome = new Biome(-All.BiomeIDs.Minimum, "10 Test Biome", 1, Elevation.LevelGround, false, null, null);
            TestItem = new Item(-All.ItemIDs.Minimum, ItemType.Other, "11 Test Item", 1, 0, 99, 1, 1,
                                -All.BlockIDs.Minimum);
        }
    }
}
