using System.Collections.Generic;
using ParquetClassLibrary;
using ParquetClassLibrary.Characters;
using ParquetClassLibrary.Crafting;
using ParquetClassLibrary.Items;
using ParquetClassLibrary.Sandbox.IDs;
using ParquetClassLibrary.Sandbox.Parquets;

namespace ParquetUnitTests
{
    /// <summary>
    /// Stores <see cref="Entity"/> and <see cref="EntityID"/> for use in unit testing.
    /// </summary>
    public static class TestEntities
    {
        #region Test Values
        // TODO Update this once players are implemented.
        /// <summary>Used in test patterns in QA routines.</summary>
        //public static readonly PlayerCharacter TestPlayer = new PlayerCharacter(-All.PlayerCharacterIDs.Minimum, "0 Test Player");

        /// <summary>Used in test patterns in QA routines.</summary>
        public static readonly Critter TestCritter = new Critter(-All.CritterIDs.Minimum, "1 Test Critter", Biome.Field, Behavior.Still);

        /// <summary>Used in test patterns in QA routines.</summary>
        public static readonly NPC TestNpc = new NPC(-All.NpcIDs.Minimum, "2 Test NPC", Biome.Field, Behavior.Still);

        /// <summary>Used in test patterns in QA routines.</summary>
        public static readonly Floor TestFloor = new Floor(-All.FloorIDs.Minimum, "3 Test Floor");

        /// <summary>Used in test patterns in QA routines.</summary>
        public static readonly Block TestBlock = new Block(-All.BlockIDs.Minimum, "4 Test Block");

        /// <summary>Used in test patterns in QA routines.</summary>
        public static readonly Furnishing TestFurnishing = new Furnishing(-All.FurnishingIDs.Minimum, "5 Test Furnishing");

        /// <summary>Used in test patterns in QA routines.</summary>
        public static readonly Collectible TestCollectible = new Collectible(-All.CollectibleIDs.Minimum, "6 Test Collectible");

        // TODO Update this once Room recipes are implemented.
        /// <summary>Used in test patterns in QA routines.</summary>
        //public static readonly Floor TestRoomRecipe = new RoomRecipe(-All.RoomRecipeIDs.Minimum, "7 Test Room Recipe");

        // TODO Update this once Crafting Recipe has been derived from Entity.   <---
        /// <summary>Used in test patterns in QA routines.</summary>
        //public static readonly Block TestCraftingRecipe = new CraftingRecipe(-All.CraftingRecipeIDs.Minimum, "8 Test Crafting Recipe");

        // TODO Update this once Quests are implemented.
        /// <summary>Used in test patterns in QA routines.</summary>
        //public static readonly Furnishing TestQuest = new Quest(-All.QuestIDs.Minimum, "9 Test Quest");

        /// <summary>Used in test patterns in QA routines.</summary>
        public static readonly Item TestItem = new Item(-All.ItemIDs.Minimum, ItemType.Other, "10 Test Item",
                                                        1, 0, 99, 1, 1, TestBlock.ID, KeyItem.None, null);
        #endregion

        /// <summary>A collection of all test parquets of all subtypes.</summary>
        private static readonly Dictionary<EntityID, Entity> entityDefinitions = new Dictionary<EntityID, Entity>
        {
            { TestFloor.ID, TestFloor },
            { TestBlock.ID, TestBlock },
            { TestFurnishing.ID, TestFurnishing },
            { TestCollectible.ID, TestCollectible },
        };

        /// <summary>
        /// Returns the specified <see cref="Entity"/>.
        /// </summary>
        /// <param name="in_ID">A valid, defined <see cref="EntityID"/>.</param>
        /// <typeparam name="T">The subtype of the entity sought.  Must correspond to the given ID.</typeparam>
        /// <returns>The specified <see cref="Entity"/>, or <c>null</c>.</returns>
        /// <exception cref="System.InvalidCastException">
        /// Thrown when the specified type does not correspond to the given <see cref="EntityID"/>.
        /// </exception>
        public static T Get<T>(EntityID in_ID) where T : Entity
        {
            return (T)entityDefinitions[in_ID];
        }
    }
}
