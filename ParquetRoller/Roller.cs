using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using ParquetClassLibrary;
using ParquetClassLibrary.Beings;
using ParquetClassLibrary.Biomes;
using ParquetClassLibrary.Crafts;
using ParquetClassLibrary.Items;
using ParquetClassLibrary.Maps;
using ParquetClassLibrary.Parquets;
using ParquetClassLibrary.Rooms;
using ParquetClassLibrary.Scripts;
using ParquetRoller.Properties;

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

            var command = ParseCommand(optionText);
            ModelCollection workload = null;

            if (command == ListPropertyForCategory)
            {
                command = ParseProperty(property);
                if (command != ListPronouns
                    && command != DisplayBadArguments)
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
                case "pronoun":
                case "pronouns":
                    return ListPronouns;
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
                        Console.WriteLine(Resources.ErrorNoProperty);
                    }
                    else
                    {
                        Console.WriteLine(string.Format(CultureInfo.CurrentCulture, Resources.ErrorUnknownProperty, inProperty));
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

            All.LoadFromCSVs();

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
                    var critters = All.Beings.Where(model => model.ID.IsValidForRange(All.CritterIDs));
                    workload = new ModelCollection(All.CritterIDs, critters);
                    break;
                case "character":
                case "characters":
                    var characters = All.Beings.Where(model => model.ID.IsValidForRange(All.CharacterIDs));
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
                    var pitems = All.Items.Where(model => model.ParquetID != ModelID.None);
                    workload = new ModelCollection(All.ItemIDs, All.Items);
                    break;
                case "n-item":
                case "n-items":
                    var nitems = All.Items.Where(model => model.ParquetID == ModelID.None);
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
                    var collectibles = All.Parquets.Where(model => model.ID.IsValidForRange(All.CollectibleIDs));
                    workload = new ModelCollection(All.CollectibleIDs, collectibles);
                    break;
                case "room":
                case "rooms":
                    workload = new ModelCollection(All.RoomRecipeIDs, All.RoomRecipes);
                    break;
                default:
                    Console.WriteLine(string.Format(CultureInfo.CurrentCulture, Resources.ErrorUnknownCategory, inCategory));
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
            Console.WriteLine(Resources.MessageDefault);
            return ExitCode.Success;
        }

        /// <summary>
        /// Displays a detailed help message to the user.
        /// </summary>
        /// <param name="inWorkload">Ignored.</param>
        /// <returns><see cref="ExitCode.Success"/></returns>
        private static ExitCode DisplayHelp(ModelCollection inWorkload)
        {
            Console.WriteLine(Resources.MessageHelp);
            return ExitCode.Success;
        }

        /// <summary>
        /// Displays version information to the user.
        /// </summary>
        /// <param name="inWorkload">Ignored.</param>
        /// <returns><see cref="ExitCode.Success"/></returns>
        private static ExitCode DisplayVersion(ModelCollection inWorkload)
        {
            Console.WriteLine(string.Format(CultureInfo.CurrentCulture, Resources.MessageVersion,
                                            AssemblyInfo.LibraryVersion.Remove(AssemblyInfo.LibraryVersion.Length - 2),
                                            AssemblyInfo.LibraryVersion,
                                            AssemblyInfo.SupportedBeingDataVersion,
                                            AssemblyInfo.SupportedMapDataVersion,
                                            AssemblyInfo.SupportedScriptDataVersion));
            return ExitCode.Success;
        }

        /// <summary>
        /// Write CSV templates to current directory.
        /// </summary>
        /// <param name="inWorkload">Ignored.</param>
        /// <returns>A value indicating success or the nature of the failure.</returns>
        private static ExitCode CreateTemplates(ModelCollection inWorkload)
        {
            if (!File.Exists(PronounGroup.GetFilePath()))
            {
                PronounGroup.PutRecords(Enumerable.Empty<PronounGroup>());
            }
            if (!File.Exists(ModelCollection.GetFilePath<CritterModel>()))
            {
                new ModelCollection<BeingModel>(All.BeingIDs, Enumerable.Empty<CritterModel>()).PutRecordsForType<CritterModel>();
            }
            if (!File.Exists(ModelCollection.GetFilePath<CharacterModel>()))
            {
                new ModelCollection<BeingModel>(All.BeingIDs, Enumerable.Empty<CharacterModel>()).PutRecordsForType<CharacterModel>();
            }
            if (!File.Exists(ModelCollection.GetFilePath<BiomeModel>()))
            {
                new ModelCollection<BiomeModel>(All.BiomeIDs, Enumerable.Empty<BiomeModel>()).PutRecordsForType<BiomeModel>();
            }
            if (!File.Exists(ModelCollection.GetFilePath<CraftingRecipe>()))
            {
                new ModelCollection<CraftingRecipe>(All.CraftingRecipeIDs, Enumerable.Empty<CraftingRecipe>()).PutRecordsForType<CraftingRecipe>();
            }
            if (!File.Exists(ModelCollection.GetFilePath<InteractionModel>()))
            {
                new ModelCollection<InteractionModel>(All.InteractionIDs, Enumerable.Empty<InteractionModel>()).PutRecordsForType<InteractionModel>();
            }
            if (!File.Exists(ModelCollection.GetFilePath<MapChunk>()))
            {
                new ModelCollection<MapModel>(All.MapIDs, Enumerable.Empty<MapChunk>()).PutRecordsForType<MapChunk>();
            }
            if (!File.Exists(ModelCollection.GetFilePath<MapRegionSketch>()))
            {
                new ModelCollection<MapModel>(All.MapIDs, Enumerable.Empty<MapRegionSketch>()).PutRecordsForType<MapRegionSketch>();
            }
            if (!File.Exists(ModelCollection.GetFilePath<MapRegion>()))
            {
                new ModelCollection<MapModel>(All.MapIDs, Enumerable.Empty<MapRegion>()).PutRecordsForType<MapRegion>();
            }
            if (!File.Exists(ModelCollection.GetFilePath<FloorModel>()))
            {
                new ModelCollection<ParquetModel>(All.ParquetIDs, Enumerable.Empty<FloorModel>()).PutRecordsForType<FloorModel>();
            }
            if (!File.Exists(ModelCollection.GetFilePath<BlockModel>()))
            {
                new ModelCollection<ParquetModel>(All.ParquetIDs, Enumerable.Empty<BlockModel>()).PutRecordsForType<BlockModel>();
            }
            if (!File.Exists(ModelCollection.GetFilePath<FurnishingModel>()))
            {
                new ModelCollection<ParquetModel>(All.ParquetIDs, Enumerable.Empty<FurnishingModel>()).PutRecordsForType<FurnishingModel>();
            }
            if (!File.Exists(ModelCollection.GetFilePath<CollectibleModel>()))
            {
                new ModelCollection<ParquetModel>(All.ParquetIDs, Enumerable.Empty<CollectibleModel>()).PutRecordsForType<CollectibleModel>();
            }
            if (!File.Exists(ModelCollection.GetFilePath<RoomRecipe>()))
            {
                new ModelCollection<RoomRecipe>(All.RoomRecipeIDs, Enumerable.Empty<RoomRecipe>()).PutRecordsForType<RoomRecipe>();
            }
            if (!File.Exists(ModelCollection.GetFilePath<ScriptModel>()))
            {
                new ModelCollection<ScriptModel>(All.ScriptIDs, Enumerable.Empty<ScriptModel>()).PutRecordsForType<ScriptModel>();
            }
            if (!File.Exists(ModelCollection.GetFilePath<ItemModel>()))
            {
                new ModelCollection<ItemModel>(All.ItemIDs, Enumerable.Empty<ItemModel>()).PutRecordsForType<ItemModel>();
            }

            return ExitCode.Success;
        }

        /// <summary>
        /// Prepare CSVs in current directory for use.
        /// </summary>
        /// <param name="inWorkload">Ignored.</param>
        /// <returns>A value indicating success or the nature of the failure.</returns>
        private static ExitCode RollCSVs(ModelCollection inWorkload)
        {
            // Currently, all that has to be done is assigning ModelIDs.  Loading and saving will accomplish this.
            All.LoadFromCSVs();
            All.SaveToCSVs();
            return ExitCode.Success;
        }

        /// <summary>
        /// List all defined pronoun groups.
        /// </summary>
        /// <param name="inWorkload">Ignored.</param>
        /// <returns>A value indicating success or the nature of the failure.</returns>
        private static ExitCode ListPronouns(ModelCollection inWorkload)
        {
            All.LoadFromCSVs();

            foreach (var pronounGroup in All.PronounGroups)
            {
                Console.WriteLine(pronounGroup);
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
                Console.WriteLine(Resources.InfoNoContent);
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
                Console.WriteLine(Resources.InfoNoContent);
                return ExitCode.Success;
            }

            var orderedWorkload = inWorkload.OrderBy(x => x.ID);
            foreach (var range in inWorkload.Bounds)
            {
                Console.WriteLine(orderedWorkload.Last(x => x.ID <= range.Maximum).ID);
            }

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
                Console.WriteLine(Resources.InfoNoContent);
                return ExitCode.Success;
            }

            var allTags = new HashSet<ModelTag>();

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
                Console.WriteLine(Resources.InfoNoContent);
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
            if (inWorkload == null || inWorkload.Count == 0)
            {
                Console.WriteLine(Resources.InfoNoContent);
                return ExitCode.Success;
            }

            var IDs = new Dictionary<string, ModelID>();
            foreach (var range in inWorkload.Bounds)
            {
                Console.WriteLine(string.Format(CultureInfo.CurrentCulture, Resources.InfoCollisionsHeader, range));
                foreach (var model in inWorkload.Where(x => x.ID >= range.Minimum && x.ID <= range.Maximum))
                {
                    if (IDs.ContainsKey(model.Name))
                    {
                        Console.WriteLine(string.Format(CultureInfo.CurrentCulture, Resources.InfoCollision,
                                                        model.Name, model.ID, IDs[model.Name]));
                    }
                    else
                    {
                        IDs[model.Name] = model.ID;
                    }
                }
                IDs.Clear();
            }

            return ExitCode.Success;
        }
        #endregion
    }
}
