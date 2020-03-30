using System;
using System.Collections.Generic;
using System.Linq;
using ParquetClassLibrary;
using ParquetClassLibrary.Beings;
using ParquetClassLibrary.Items;
using ParquetClassLibrary.Parquets;

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
        /// <summary>What to display when roller is started without any arguments.</summary>
        private static string DefaultMessage { get; } =
@"Usage: roller (command)
Usage: roller list (property) [category]

Commands:
    -h|help                         Display detailed help.
    -v|version                      Display version information.
    -t|templates                    Write CSV templates to current directory.
    -r|roll                         Prepare CSVs in current directory for use.
    -p|pronouns                     List all defined pronoun groups.
    -l|list (property) [category]   Inspect CSV properties and echo results.

    For information on properties and categories consult the detailed help.
";

        /// <summary>Displays roller's current version, and various library-related version strings.</summary>
        private static string VersionMessage { get; } =
$@"Version:
    Roller      {AssemblyInfo.LibraryVersion.Remove(AssemblyInfo.LibraryVersion.Length - 2)}
    Parquet     {AssemblyInfo.LibraryVersion}
    Map Data    {AssemblyInfo.SupportedMapDataVersion}
    Being Data  {AssemblyInfo.SupportedBeingDataVersion}
";

        /// <summary>A detailed help message explaining how to use roller.</summary>
        private static string HelpMessage { get; } =
@"    Roller is a tool for working with Parquet configuration files.
    Parquet uses comma-separated value (CSV) files for configuration.
    Roller provides a quick way to examine the content of existing CSV files, to
    generate blank CSV files, and to prepare existing CSV files for use in-game.

Usage: roller (command)
Usage: roller list (property) [category]

Commands:
    -h|help                         Display detailed help.
    -v|version                      Display version information.
    -t|templates                    Write CSV templates to current directory.
    -r|roll                         Prepare CSVs in current directory for use.
    -p|pronouns                     List all defined pronoun groups.
    -l|list (property) [category]   Inspect CSV properties and echo results.

Properties:
    ranges            Model ID ranges valid for the given category.
    maxids            The largest entity ID in use in the given category.
    tags              All entity tags referenced in the given category.
    names             All entity names referenced in the given category.
    collisions        Any duplicate names used in the given category.

Categories:
    all               Everything, the default.  This can be a long listing.
    beings            All beings.
      critters        Only critter beings.
      characters      Only character beings.
    biomes            All biomes.
    crafts            All crafting recipes.
    interactions      All interactions.
      dialgoues       Only dialogue interactions.
      quests          Only quest interactions.
    items             All items.
      p-items         Only items that correspond to parquets.
      n-items         Only items that don't correspond to parquets.
    parquets          All parquets.
      floors          Only floor parquets.
      blocks          Only block parquets.
      furnishings     Only furnishing parquets.
      collectibles    Only collectible parquets.
    rooms             All room recipes.

Checking for name collisions is especially useful because they can cause
runtime errors.

    'Roller -- The Best Alternative to a 10-Pound Mallet!'";
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

        #region Command Line Argument Parsing
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
                case "-p":
                case "pronoun":
                case "pronouns":
                    return ListPronouns;
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
                    if (string.IsNullOrEmpty(inProperty))
                    {
                        Console.WriteLine("Specify property.\n");
                    }
                    else
                    {
                        Console.WriteLine($"Unrecognized property {inProperty}.\n");
                    }
                    return DisplayBadArguments;
            }
        }

        /// <summary>
        /// Takes a single argument corresponding to the "category" selection and determines which workload it corresponds to.
        /// </summary>
        /// <param name="inCategory">The third command line argument.</param>
        /// <returns>A collection of <see cref="Model"/>s to take action on.</returns>
        private static ModelCollection ParseCategory(string inCategory)
        {
            ModelCollection workload = null;

            // Default to everything.
            if (string.IsNullOrEmpty(inCategory))
            {
                inCategory = "all";
            }

            All.LoadFromCSV();

            // Advertise plural categories but accept singular
            switch (inCategory)
            {
                case "all":
                    var entireRange = new List<Range<ModelID>>
                    {
                        All.CritterIDs,
                        All.CharacterIDs,
                        All.BiomeIDs,
                        All.CraftingRecipeIDs,
                        All.InteractionIDs,
                        All.MapChunkIDs,
                        All.MapRegionIDs,
                        All.FloorIDs,
                        All.BlockIDs,
                        All.FurnishingIDs,
                        All.CollectibleIDs,
                        All.RoomRecipeIDs,
                        All.ScriptIDs,
                        All.ItemIDs
                    };
                    workload = new ModelCollection(entireRange, ((IEnumerable<Model>)All.Beings)
                                                                .Concat(All.Biomes)
                                                                .Concat(All.CraftingRecipes)
                                                                .Concat(All.Interactions)
                                                                .Concat(All.Parquets)
                                                                .Concat(All.RoomRecipes)
                                                                .Concat(All.Items));
                    break;
                case "being":
                case "beings":
                    workload = new ModelCollection(All.BeingIDs, All.Beings);
                    break;
                case "critter":
                case "critters":
                    IEnumerable<BeingModel> critters = All.Beings.Where(model => model.ID.IsValidForRange(All.CritterIDs));
                    workload = new ModelCollection(All.CritterIDs, critters);
                    break;
                case "character":
                case "characters":
                    IEnumerable<BeingModel> characters = All.Beings.Where(model => model.ID.IsValidForRange(All.CharacterIDs));
                    workload = new ModelCollection(All.CharacterIDs, characters);
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
                    workload = new ModelCollection(All.InteractionIDs, All.Interactions);
                    break;
                case "item":
                case "items":
                    workload = new ModelCollection(All.ItemIDs, All.Items);
                    break;
                case "p-item":
                case "p-items":
                    IEnumerable<ItemModel> pitems = All.Items.Where(model => model.ParquetID != ModelID.None);
                    workload = new ModelCollection(All.ItemIDs, All.Items);
                    break;
                case "n-item":
                case "n-items":
                    IEnumerable<ItemModel> nitems = All.Items.Where(model => model.ParquetID == ModelID.None);
                    workload = new ModelCollection(All.ItemIDs, All.Items);
                    break;
                case "parquet":
                case "parquets":
                    workload = new ModelCollection(All.ParquetIDs, All.Parquets);
                    break;
                case "floor":
                case "floors":
                    IEnumerable<ParquetModel> floors = All.Parquets.Where(model => model.ID.IsValidForRange(All.FloorIDs));
                    workload = new ModelCollection(All.FloorIDs, floors);
                    break;
                case "block":
                case "blocks":
                    IEnumerable<ParquetModel> blocks = All.Parquets.Where(model => model.ID.IsValidForRange(All.BlockIDs));
                    workload = new ModelCollection(All.BlockIDs, blocks);
                    break;
                case "furnishing":
                case "furnishings":
                    IEnumerable<ParquetModel> furnishings = All.Parquets.Where(model => model.ID.IsValidForRange(All.FurnishingIDs));
                    workload = new ModelCollection(All.FurnishingIDs, furnishings);
                    break;
                case "collectible":
                case "collectibles":
                    IEnumerable<ParquetModel> collectibles = All.Parquets.Where(model => model.ID.IsValidForRange(All.CollectibleIDs));
                    workload = new ModelCollection(All.CollectibleIDs, collectibles);
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
        #endregion

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

        /// <summary>
        /// List all defined pronoun groups.
        /// </summary>
        /// <param name="inWorkload">Ignored.</param>
        /// <returns>A value indicating success or the nature of the failure.</returns>
        private static ExitCode ListPronouns(ModelCollection inWorkload)
        {
            All.LoadFromCSV();

            foreach (var pronounGroup in All.PronounGroups)
            {
                Console.WriteLine($"{pronounGroup.ToString()}");
            }

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
        /// Lists the defined ranges for the given <see cref="Model"/>s' <see cref="ModelID"/>s.
        /// </summary>
        /// <param name="inWorkload">The <see cref="Model"/>s to inspect.</param>
        /// <returns><see cref="ExitCode.Success"/></returns>
        private static ExitCode ListRanges(ModelCollection inWorkload)
        {
            if (inWorkload == null || inWorkload.Count == 0)
            {
                Console.WriteLine("No defined content.");
                return ExitCode.Success;
            }

            foreach (var range in inWorkload.Bounds)
            {
                Console.WriteLine(range);
            }

            return ExitCode.Success;
        }

        /// <summary>
        /// Lists the largest <see cref="ModelID"/> actually in use in each of the given categories of <see cref="Model"/>s.
        /// </summary>
        /// <param name="inWorkload">The <see cref="Model"/>s to inspect.</param>
        /// <returns><see cref="ExitCode.Success"/></returns>
        private static ExitCode ListMaxIDs(ModelCollection inWorkload)
        {
            if (inWorkload == null || inWorkload.Count == 0)
            {
                Console.WriteLine("No defined content.");
                return ExitCode.Success;
            }

            var orderedWorkload = inWorkload.OrderBy(x => x.ID);
            Console.WriteLine(orderedWorkload.Last().ID);

            return ExitCode.Success;
        }

        /// <summary>
        /// Lists every unique <see cref="ModelTag"/> in use in each of the given <see cref="Model"/>s.
        /// </summary>
        /// <param name="inWorkload">The <see cref="Model"/>s to inspect.</param>
        /// <returns><see cref="ExitCode.BadArguments"/></returns>
        private static ExitCode ListTags(ModelCollection inWorkload)
        {
            if (inWorkload == null || inWorkload.Count == 0)
            {
                Console.WriteLine("No defined content.");
                return ExitCode.Success;
            }

            HashSet<ModelTag> allTags = new HashSet<ModelTag>();

            foreach (var model in inWorkload)
            {
                foreach (var modelTag in model.GetAllTags())
                {
                    if (!allTags.Any(tag => tag.CompareTo(modelTag) == 0))
                    {
                        allTags.Add(modelTag);
                    }
                }
            }

            foreach (var modelTag in allTags)
            {
                Console.WriteLine(modelTag);
            }

            return ExitCode.Success;
        }

        /// <summary>
        /// Lists every unique <see cref="Model.Name"/> in use in each of the given <see cref="Model"/>s.
        /// </summary>
        /// <param name="inWorkload">The <see cref="Model"/>s to inspect.</param>
        /// <returns><see cref="ExitCode.Success"/></returns>
        private static ExitCode ListNames(ModelCollection inWorkload)
        {
            if (inWorkload == null || inWorkload.Count == 0)
            {
                Console.WriteLine("No defined content.");
                return ExitCode.Success;
            }

            foreach (var model in inWorkload)
            {
                Console.WriteLine(model.Name);
            }

            return ExitCode.Success;
        }

        /// <summary>
        /// If more than one unique <see cref="Model"/> uses the same <see cref="Model.Name"/>, lists that as a name collision.
        /// </summary>
        /// <param name="inWorkload">The <see cref="Model"/>s to inspect.</param>
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
