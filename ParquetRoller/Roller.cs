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
        /// <summary>
        /// Represents an action that the user may ask <see cref="Roller"/> to perform.
        /// </summary>
        /// <param name="inWorkload">The <see cref="ModelCollection" /> to act on, if any.</param>
        /// <returns>A value indicating success or the manner of failure.</returns>
        internal delegate ExitCode Command(ModelCollection inWorkload);

        /// <summary>
        /// A flag indicating that a subcommand must be executed.
        /// </summary>
        private static Command ListPropertyForCategory { get; } = null;


        #region Console Messages
        private static string DefaultMessage { get; } = "Usage: roller (command)\nUsage: roller list (property) [category]\n\nCommands:\n    -h|help                         Display detailed help.\n    -v|version                      Display version information.\n    -t|templates                    Write CSV templates to current directory.\n    -r|roll                         Prepare CSVs in current directory for use.\n    -l|list (property) [category]   Inspect CSV properties and echo results.\n\n    For information on properties and categories consult the detailed help.\n";

        private static string VersionMessage { get; } = $"Version:\n    Roller      {AssemblyInfo.LibraryVersion.Remove(AssemblyInfo.LibraryVersion.Length - 2)}\n    Parquet     {AssemblyInfo.LibraryVersion}\n    Map Data    {AssemblyInfo.SupportedMapDataVersion}\n    Being Data  {AssemblyInfo.SupportedBeingDataVersion}\n";

        private static string HelpMessage { get; } = $"    Roller is a tool for working with Parquet configuration files.\n    Parquet uses comma-separated value (CSV) files for configuration.\n    Roller provides a quick way to examine the content of existing CSV files, to\n    generate blank CSV files, and to prepare existing CSV files for use in-game.\n\nUsage: roller (command)\nUsage: roller list (property) [category]\n\nCommands:\n    -h|help                         Display detailed help.\n    -v|version                      Display version information.\n    -t|templates                    Write CSV templates to current directory.\n    -r|roll                         Prepare CSVs in current directory for use.\n    -l|list (property) [category]   Inspect CSV properties and echo results.\n\nProperties:\n    ranges            Entity ID ranges valid for the given category.\n    maxids            The largest entity ID in use in the given category.\n    tags              All entity tags referenced in the given category.\n    names             All entity names referenced in the given category.\n    collisions        Any duplicate names used in the given category.\n\nCategories:\n    all               Everything, the default.  This can be a long listing.\n    beings            All beings.\n      critters        Only critter beings.\n      npcs            Only NPC beings.\n    biomes            All biomes.\n    crafts            All crafting recipes.\n    interactions      All interactions.\n      dialgoues       Only dialogue interactions.\n      quests          Only quest interactions.\n    items             All items.\n      p-items         Only items that correspond to parquets.\n      n-items         Only items that don't correspond to parquets.\n    parquets          All parquets.\n      floors          Only floor parquets.\n      blocks          Only block parquets.\n      furnishings     Only furnishing parquets.\n      collectibles    Only collectible parquets.\n    rooms             All room recipes.\n\n    Checking for name collisions is especially useful because they can cause\n    runtime errors.\n\n    \"Roller -- The Best Alternative to a 10-Pound Mallet!\"";
        #endregion

        /// <summary>
        /// A command line tool for working with Parquet configuration files.
        /// </summary>
        /// <param name="args">Command line arguments passed in to the tool.</param>
        internal static int Main(string[] args)
        {
            var optionText = args.Length > 0
                ? args[0].ToLower()
                : "";
            var property = args.Length > 1
                ? args[1].ToLower()
                : "";
            var category = args.Length > 2
                ? args[2].ToLower()
                : "";

            Command command = ParseCommand(optionText);
            ModelCollection workload = null;

            if (command == ListPropertyForCategory)
            {
                command = ParseProperty(property);
                if (command != DisplayBadArguments)
                {
                    workload = ParseCategory(category);
                }
            }

            return (int)command(workload);
        }

        /// <summary>
        /// Takes a single argument corresponding to the "command" selection and determines which command it corresponds to.
        /// </summary>
        /// <param name="inCommandText">The first command line argument.</param>
        /// <returns>An action for <see cref="Roller"/> to take.</returns>
        private static Command ParseCommand(string inCommandText)
        {
            switch (inCommandText)
            {
                case "/?":
                case "-?":
                case "/h":
                case "-h":
                case "--help":
                case "help":
                    return DisplayHelp;
                case "-v":
                case "version":
                    return DisplayVersion;
                case "-t":
                case "template":
                case "templates":
                    return CreateTemplates;
                case "-r":
                case "roll":
                    return RollCSVs;
                case "-l":
                case "list":
                    return ListPropertyForCategory;
                default:
                    return DisplayDefault;
            }
        }

        /// <summary>
        /// Takes a single argument corresponding to the "property" selection and determines which subcommand it corresponds to.
        /// </summary>
        /// <param name="inProperty">The second command line argument.</param>
        /// <returns>An action for <see cref="Roller"/> to take.</returns>
        private static Command ParseProperty(string inProperty)
        {
            switch (inProperty)
            {
                case "range":
                case "ranges":
                    return ListRanges;
                case "maxid":
                case "maxids":
                    return ListMaxIDs;
                case "tag":
                case "tags":
                    return ListTags;
                case "name":
                case "names":
                    return ListNames;
                case "collision":
                case "collisions":
                    return ListCollisions;
                default:
                    Console.WriteLine($"Unrecognized property {inProperty}");
                    return DisplayBadArguments;
            }
        }

        /// <summary>
        /// Takes a single argument corresponding to the "category" selection and determines which workload it corresponds to.
        /// </summary>
        /// <param name="inCategory">The third command line argument.</param>
        /// <returns>A collection of <see cref="EntityModel"/>s to take action on.</returns>
        private static ModelCollection ParseCategory(string inCategory)
        {
            ModelCollection workload = null;

            // Default to everything.
            if (string.IsNullOrEmpty(inCategory))
            {
                inCategory = "all";
            }

            // Advertise plural categories but accept singular
            switch (inCategory)
            {
                case "all":
                    var entireRange = new Range<EntityID>(All.PlayerCharacterIDs.Minimum, All.ItemIDs.Maximum);
                    workload = new ModelCollection(entireRange,
                                                                ((IEnumerable<EntityModel>)All.Beings.GetEnumerator())
                                                                                .Concat(All.Biomes)
                                                                                .Concat(All.Biomes)
                                                                                .Concat(All.CraftingRecipes)
                                                                                .Concat(All.Dialogues)
                                                                                .Concat(All.Parquets)
                                                                                .Concat(All.Quests)
                                                                                .Concat(All.RoomRecipes)
                                                                                .Concat(All.Items));
                    break;
                case "being":
                case "beings":
                    workload = new ModelCollection(All.BeingIDs, All.Beings);
                    break;
                case "critter":
                case "critters":
                    var critters = All.Beings.Where(model => model.ID.IsValidForRange(All.CritterIDs));
                    workload = new ModelCollection(All.CritterIDs, critters);
                    break;
                case "npc":
                case "npcs":
                    var npcs = All.Beings.Where(model => model.ID.IsValidForRange(All.NpcIDs));
                    workload = new ModelCollection(All.NpcIDs, npcs);
                    break;
                case "biome":
                case "biomes":
                    workload = new ModelCollection(All.BiomeIDs, All.Biomes);
                    break;
                case "craft":
                case "crafts":
                    workload = new ModelCollection(All.CraftingRecipeIDs, All.CraftingRecipes);
                    break;
                case "interaction":
                case "interactions":
                    // TODO Update this part after fixing Interactions.
                    //workingCollection = new ModelCollection<EntityModel>(All.InteractionIDs, All.Interactions);
                    break;
                case "dialgoue":
                case "dialgoues":
                    // TODO Update this part after fixing Interactions.
                    //var dialogues = All.Interactions.Where(model => model.ID.IsValidForRange(All.DialogueIDs));
                    //workingCollection = new ModelCollection<EntityModel>(All.DialogueIDs, dialogues);
                    break;
                case "quest":
                case "quests":
                    // TODO Update this part after fixing Interactions.
                    //var quests = All.Interactions.Where(model => model.ID.IsValidForRange(All.QuestIDs));
                    //workingCollection = new ModelCollection<EntityModel>(All.QuestIDs, quests);
                    break;
                case "item":
                case "items":
                    workload = new ModelCollection(All.ItemIDs, All.Items);
                    break;
                case "p-item":
                case "p-items":
                    var pitems = All.Items.Where(model => model.AsParquet != EntityID.None);
                    workload = new ModelCollection(All.ItemIDs, All.Items);
                    break;
                case "n-item":
                case "n-items":
                    var nitems = All.Items.Where(model => model.AsParquet == EntityID.None);
                    workload = new ModelCollection(All.ItemIDs, All.Items);
                    break;
                case "parquet":
                case "parquets":
                    workload = new ModelCollection(All.ParquetIDs, All.Parquets);
                    break;
                case "floor":
                case "floors":
                    var floors = All.Parquets.Where(model => model.ID.IsValidForRange(All.FloorIDs));
                    workload = new ModelCollection(All.FloorIDs, floors);
                    break;
                case "block":
                case "blocks":
                    var blocks = All.Parquets.Where(model => model.ID.IsValidForRange(All.BlockIDs));
                    workload = new ModelCollection(All.BlockIDs, blocks);
                    break;
                case "furnishing":
                case "furnishings":
                    var furnishings = All.Parquets.Where(model => model.ID.IsValidForRange(All.FurnishingIDs));
                    workload = new ModelCollection(All.FurnishingIDs, furnishings);
                    break;
                case "collectible":
                case "collectibles":
                    var Collectibles = All.Parquets.Where(model => model.ID.IsValidForRange(All.CollectibleIDs));
                    workload = new ModelCollection(All.CollectibleIDs, Collectibles);
                    break;
                case "room":
                case "rooms":
                    workload = new ModelCollection(All.RoomRecipeIDs, All.RoomRecipes);
                    break;
                default:
                    Console.WriteLine($"Unrecognized category {inCategory}");
                    break;
            }

            return workload;
        }

        #region Commands
        /// <summary>
        /// Displays the default message to the user.
        /// </summary>
        /// <param name="inWorkload">Ignored.</param>
        /// <returns><see cref="ExitCode.Success"/></returns>
        private static ExitCode DisplayDefault(ModelCollection inWorkload)
        {
            Console.WriteLine(DefaultMessage);
            return ExitCode.Success;
        }

        /// <summary>
        /// Displays a detailed help message to the user.
        /// </summary>
        /// <param name="inWorkload">Ignored.</param>
        /// <returns><see cref="ExitCode.Success"/></returns>
        private static ExitCode DisplayHelp(ModelCollection inWorkload)
        {
            Console.WriteLine(HelpMessage);
            return ExitCode.Success;
        }

        /// <summary>
        /// Displays version information to the user.
        /// </summary>
        /// <param name="inWorkload">Ignored.</param>
        /// <returns><see cref="ExitCode.Success"/></returns>
        private static ExitCode DisplayVersion(ModelCollection inWorkload)
        {
            Console.WriteLine(VersionMessage);
            return ExitCode.Success;
        }

        /// <summary>
        /// Write CSV templates to current directory.
        /// </summary>
        /// <param name="inWorkload">Ignored.</param>
        /// <returns>A value indicating success or the nature of the failure.</returns>
        private static ExitCode CreateTemplates(ModelCollection inWorkload)
        {
            // TODO This is a stub.
            Console.WriteLine("> Create templates.");
            return ExitCode.Success;
        }

        /// <summary>
        /// Prepare CSVs in current directory for use.
        /// </summary>
        /// <param name="inWorkload">Ignored.</param>
        /// <returns>A value indicating success or the nature of the failure.</returns>
        private static ExitCode RollCSVs(ModelCollection inWorkload)
        {
            // TODO This is a stub.
            Console.WriteLine("> Roll CSVs.");
            return ExitCode.Success;
        }
        #endregion

        #region Subcommands
        /// <summary>
        /// Displays the help message to the user, also indicating that the arguments given were not understood.
        /// </summary>
        /// <param name="inWorkload">Ignored.</param>
        /// <returns><see cref="ExitCode.BadArguments"/></returns>
        private static ExitCode DisplayBadArguments(ModelCollection inWorkload)
        {
            DisplayHelp(null);
            return ExitCode.BadArguments;
        }

        /// <summary>
        /// Lists the defined ranges for the given <see cref="EntityModel"/>s' <see cref="EntityID"/>s.
        /// </summary>
        /// <param name="inWorkload">The <see cref="EntityModel"/>s to inspect.</param>
        /// <returns><see cref="ExitCode.BadArguments"/></returns>
        private static ExitCode ListRanges(ModelCollection inWorkload)
        {
            // TODO This is a stub.
            Console.WriteLine(inWorkload);
            return ExitCode.BadArguments;
        }

        /// <summary>
        /// Lists the largest <see cref="EntityID"/> actually in use in each of the given categories of <see cref="EntityModel"/>s.
        /// </summary>
        /// <param name="inWorkload">The <see cref="EntityModel"/>s to inspect.</param>
        /// <returns><see cref="ExitCode.BadArguments"/></returns>
        private static ExitCode ListMaxIDs(ModelCollection inWorkload)
        {
            // TODO This is a stub.
            Console.WriteLine(inWorkload);
            return ExitCode.BadArguments;
        }

        /// <summary>
        /// Lists every unique <see cref="EntityTag"/> in use in each of the given <see cref="EntityModel"/>s.
        /// </summary>
        /// <param name="inWorkload">The <see cref="EntityModel"/>s to inspect.</param>
        /// <returns><see cref="ExitCode.BadArguments"/></returns>
        private static ExitCode ListTags(ModelCollection inWorkload)
        {
            // TODO This is a stub.
            Console.WriteLine(inWorkload);
            return ExitCode.BadArguments;
        }

        /// <summary>
        /// Lists every unique <see cref="EntityModel.Name"/> in use in each of the given <see cref="EntityModel"/>s.
        /// </summary>
        /// <param name="inWorkload">The <see cref="EntityModel"/>s to inspect.</param>
        /// <returns><see cref="ExitCode.BadArguments"/></returns>
        private static ExitCode ListNames(ModelCollection inWorkload)
        {
            // TODO This is a stub.
            Console.WriteLine(inWorkload);
            return ExitCode.BadArguments;
        }

        /// <summary>
        /// If more than one unique <see cref="EntityModel"/> uses the same <see cref="EntityModel.Name"/>, lists that as a name collision.
        /// </summary>
        /// <param name="inWorkload">The <see cref="EntityModel"/>s to inspect.</param>
        /// <returns><see cref="ExitCode.BadArguments"/></returns>
        private static ExitCode ListCollisions(ModelCollection inWorkload)
        {
            // TODO This is a stub.
            Console.WriteLine(inWorkload);
            return ExitCode.BadArguments;
        }
        #endregion
    }
}
