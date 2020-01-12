using System;
using System.Collections.Generic;
using System.Linq;
using ParquetClassLibrary;
using ParquetClassLibrary.Utilities;

namespace ParquetRoller
{
    /// <summary>
    /// A command line tool that reads in game definitions from CSV files, verifies, modifies, and writes them out.
    /// </summary>
    internal static class Roller
    {
        #region Console Messages
        private static readonly string DefaultMessage = "Usage: roller [option]\nUsage: roller list [property] [category]\n\nOptions:\n    -h|help                         Display detailed help.\n    -v|version                      Display version information.\n    -t|templates                    Write CSV templates to current directory.\n    -r|roll                         Prepare CSVs in current directory for use.\n    -l|list [property] [category]   Inspect CSV properties and echo results.\n\n    For information on properties and categories consult the detailed help.\n";

        private static readonly string VersionMessage = $"Version:\n    Roller      {AssemblyInfo.LibraryVersion.Remove(AssemblyInfo.LibraryVersion.Length - 2)}\n    Parquet     {AssemblyInfo.LibraryVersion}\n    Map Data    {AssemblyInfo.SupportedMapDataVersion}\n    Being Data  {AssemblyInfo.SupportedBeingDataVersion}\n";

        private static readonly string HelpMessage = $"    Roller is a tool for working with Parquet configuration files.\n    Parquet uses comma-separated value (CSV) files for configuration.\n    Roller provides a quick way to examine the content of existing CSV files, to\n    generate blank CSV files, and to prepare existing CSV files for use in-game.\n\nUsage: roller [option]\nUsage: roller list [property] [category]\n\nOptions:\n    -h|help                         Display detailed help.\n    -v|version                      Display version information.\n    -t|templates                    Write CSV templates to current directory.\n    -r|roll                         Prepare CSVs in current directory for use.\n    -l|list [property] [category]   Inspect CSV properties and echo results.\n\nProperties:\n    ranges            Entity ID ranges valid for the given category.\n    maxids            The largest entity ID in use in the given category.\n    tags              All entity tags referenced in the given category.\n    names             All entity names referenced in the given category.\n    collisions        Any duplicate names used in the given category.\n\nCategories:\n    all               Everything, the default.  This can be a long listing.\n    beings            All beings.\n      critters        Only critter beings.\n      npcs            Only NPC beings.\n    biomes            All biomes.\n    crafts            All crafting recipes.\n    interactions      All interactions.\n      dialgoues       Only dialogue interactions.\n      quests          Only quest interactions.\n    items             All items.\n      p-items         Only items that correspond to parquets.\n      n-items         Only items that don't correspond to parquets.\n    parquets          All parquets.\n      floors          Only floor parquets.\n      blocks          Only block parquets.\n      furnishings     Only furnishing parquets.\n      collectibles    Only collectible parquets.\n    rooms             All room recipes.\n\n    Checking for name collisions is especially useful because they can cause\n    runtime errors if IDs are not hand-assigned.\n\n    \"Roller -- The Best Alternative to a 10-Pound Mallet!\"";
        #endregion

        #region Parse Command Line Arguments
        /// <summary>
        /// A command line tool for working with Parquet configuration files.
        /// </summary>
        /// <param name="args">Command line arguments passed in to the tool.</param>
        internal static int Main(string[] args)
        {
            var exitCode = ExitCode.Success;

            var option = args.Length > 0
                ? args[0].ToLower()
                : "";

            // Advertise -[character] but also accept /[character]
            // Advertise [verb] but also accept --[verb]
            switch (option)
            {
                case "/?":
                case "-?":
                case "/h":
                case "-h":
                case "--help":
                case "help":
                    Console.WriteLine(HelpMessage);
                    break;
                case "/v":
                case "-v":
                case "--version":
                case "version":
                    Console.WriteLine(VersionMessage);
                    break;
                case "/t":
                case "-t":
                case "--templates":
                case "templates":
                    exitCode = CreateTemplates();
                    break;
                case "/r":
                case "-r":
                case "--roll":
                case "roll":
                    exitCode = RollCSVs();
                    break;
                case "/l":
                case "-l":
                case "--list":
                case "list":
                    var property = args.Length > 1
                        ? args[1].ToLower()
                        : "";
                    var category = args.Length > 2
                        ? args[2].ToLower()
                        : "";
                    exitCode = ListPropertyCategory(property, category);
                    break;
                default:
                    Console.WriteLine(DefaultMessage);
                    break;
            }

            return (int)exitCode;
        }
        #endregion

        #region Commands
        /// <summary>
        /// Write CSV templates to current directory.
        /// </summary>
        /// <returns>A value indicating success or the nature of the failure.</returns>
        private static ExitCode CreateTemplates()
        {
            Console.WriteLine("> Create templates.");
            return ExitCode.Success;
        }

        /// <summary>
        /// Prepare CSVs in current directory for use.
        /// </summary>
        /// <returns>A value indicating success or the nature of the failure.</returns>
        private static ExitCode RollCSVs()
        {
            Console.WriteLine("> Roll CSVs.");
            return ExitCode.Success;
        }

        /// <summary>
        /// Inspect CSV properties and echo results.
        /// </summary>
        /// <param name="inProperty">The propery to inspect.</param>
        /// <param name="inCategory">The category to inspect.</param>
        /// <returns>A value indicating success or the nature of the failure.</returns>
        private static ExitCode ListPropertyCategory(string inProperty, string inCategory)
        {
            var result = ExitCode.Success;
            ModelCollection<EntityModel> workingCollection = null;

            #region Construct Categories
            // Default is everything.
            if (string.IsNullOrEmpty(inCategory))
            {
                inCategory = "all";
            }

            // Advertise plural categories but accept singular
            switch (inCategory)
            {
                // Every category.
                case "all":
                    var entireRange = new Range<EntityID>(All.PlayerCharacterIDs.Minimum, All.ItemIDs.Maximum);
                    workingCollection = new ModelCollection<EntityModel>(entireRange,
                                                                         ((IEnumerable<EntityModel>)All.Beings.GetEnumerator())
                                                                         .Concat(All.Biomes)
                                                                         .Concat(All.Biomes)
                                                                         .Concat(All.CraftingRecipes)
                                                                         .Concat(All.Dialogues)
                                                                         /*.Concat(All.Maps)*/  // TODO Should we include these?
                                                                         .Concat(All.Parquets)
                                                                         .Concat(All.Quests)
                                                                         .Concat(All.RoomRecipes)
                                                                         .Concat(All.Items));
                    break;
                // All beings.
                case "being":
                case "beings":
                    workingCollection = new ModelCollection<EntityModel>(All.BeingIDs, All.Beings);
                    break;
                // Only critters.
                case "critter":
                case "critters":
                    var critters = All.Beings.Where(model => model.ID.IsValidForRange(All.CritterIDs));
                    workingCollection = new ModelCollection<EntityModel>(All.CritterIDs, critters);
                    break;
                // Only NPCs.
                case "npc":
                case "npcs":
                    var npcs = All.Beings.Where(model => model.ID.IsValidForRange(All.NpcIDs));
                    workingCollection = new ModelCollection<EntityModel>(All.NpcIDs, npcs);
                    break;
                // All biomes.
                case "biome":
                case "biomes":
                    workingCollection = new ModelCollection<EntityModel>(All.BiomeIDs, All.Biomes);
                    break;
                // All crafting recipes.
                case "craft":
                case "crafts":
                    workingCollection = new ModelCollection<EntityModel>(All.CraftingRecipeIDs, All.CraftingRecipes);
                    break;
                // All interactions.
                case "interaction":
                case "interactions":
                    // TODO Update this part after fixing Interactions.
                    //workingCollection = new ModelCollection<EntityModel>(All.InteractionIDs, All.Interactions);
                    break;
                // Only dialogues.
                case "dialgoue":
                case "dialgoues":
                    // TODO Update this part after fixing Interactions.
                    //var dialogues = All.Interactions.Where(model => model.ID.IsValidForRange(All.DialogueIDs));
                    //workingCollection = new ModelCollection<EntityModel>(All.DialogueIDs, dialogues);
                    break;
                // Only quests.
                case "quest":
                case "quests":
                    // TODO Update this part after fixing Interactions.
                    //var quests = All.Interactions.Where(model => model.ID.IsValidForRange(All.QuestIDs));
                    //workingCollection = new ModelCollection<EntityModel>(All.QuestIDs, quests);
                    break;
                // All items.
                case "item":
                case "items":
                    workingCollection = new ModelCollection<EntityModel>(All.ItemIDs, All.Items);
                    break;
                // Only items that correspond to parquets.
                case "p-item":
                case "p-items":
                    var pitems = All.Items.Where(model => model.AsParquet != EntityID.None);
                    workingCollection = new ModelCollection<EntityModel>(All.ItemIDs, All.Items);
                    break;
                // Only items that don't correspond to parquets.
                case "n-item":
                case "n-items":
                    var nitems = All.Items.Where(model => model.AsParquet == EntityID.None);
                    workingCollection = new ModelCollection<EntityModel>(All.ItemIDs, All.Items);
                    break;
                // All parquets.
                case "parquet":
                case "parquets":
                    workingCollection = new ModelCollection<EntityModel>(All.ParquetIDs, All.Parquets);
                    break;
                // Only floors.
                case "floor":
                case "floors":
                    var floors = All.Parquets.Where(model => model.ID.IsValidForRange(All.FloorIDs));
                    workingCollection = new ModelCollection<EntityModel>(All.FloorIDs, floors);
                    break;
                // Only blocks.
                case "block":
                case "blocks":
                    var blocks = All.Parquets.Where(model => model.ID.IsValidForRange(All.BlockIDs));
                    workingCollection = new ModelCollection<EntityModel>(All.BlockIDs, blocks);
                    break;
                // Only furnishings.
                case "furnishing":
                case "furnishings":
                    var furnishings = All.Parquets.Where(model => model.ID.IsValidForRange(All.FurnishingIDs));
                    workingCollection = new ModelCollection<EntityModel>(All.FurnishingIDs, furnishings);
                    break;
                // Only collectibles.
                case "collectible":
                case "collectibles":
                    var Collectibles = All.Parquets.Where(model => model.ID.IsValidForRange(All.CollectibleIDs));
                    workingCollection = new ModelCollection<EntityModel>(All.CollectibleIDs, Collectibles);
                    break;
                // All room recipes.
                case "room":
                case "rooms":
                    workingCollection = new ModelCollection<EntityModel>(All.RoomRecipeIDs, All.RoomRecipes);
                    break;
                // Unrecognized input.
                default:
                    Console.WriteLine(DefaultMessage);
                    result = ExitCode.BadArguments;
                    break;
            }
            #endregion

            #region Inspect Property
            switch (inProperty)
            {
                case "range":
                case "ranges":
                    Console.WriteLine(workingCollection);
                    break;
                case "maxid":
                case "maxids":
                    Console.WriteLine(workingCollection);
                    break;
                case "tag":
                case "tags":
                    Console.WriteLine(workingCollection);
                    break;
                case "name":
                case "names":
                    Console.WriteLine(workingCollection);
                    break;
                case "collision":
                case "collisions":
                    Console.WriteLine(workingCollection);
                    break;
                // Unrecognized input.
                default:
                    Console.WriteLine(DefaultMessage);
                    result = ExitCode.BadArguments;
                    break;
            }
            #endregion

            return result;
        }
        #endregion
    }
}
