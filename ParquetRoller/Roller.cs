using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using Parquet;
using Parquet.Beings;
using Parquet.Biomes;
using Parquet.Crafts;
using Parquet.Games;
using Parquet.Items;
using Parquet.Maps;
using Parquet.Parquets;
using Parquet.Rooms;
using Parquet.Scripts;
#if DESIGN
using Parquet.EditorSupport;
#endif
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
        internal delegate ExitCode Command(ModelCollection<Model> inWorkload);

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
            ModelCollection<Model> workload = null;

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
            => inCommandText switch
            {
                "/?" or
                "-?" or
                "/h" or
                "-h" or
                "--help" or
                "help" => DisplayHelp,

                "-v" or
                "version" => DisplayVersion,

                "-t" or
                "template" or
                "templates" => CreateTemplates,

                "-r" or
                "roll" => RollCSVs,

                "-c" or
                "check" => CheckAdjacency,

                "-p" => ListPronouns,

                "-l" or
                "list" => ListPropertyForCategory,

                _ => DisplayDefault,
            };

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
        private static ModelCollection<Model> ParseCategory(string inCategory)
        {
            ModelCollection<Model> workload = null;

            // Default to everything.
            if (string.IsNullOrEmpty(inCategory))
            {
                inCategory = "all";
            }

            if (!All.LoadFromCSVs())
            {
                return ModelCollection<Model>.Default;
            }

            // Advertise plural categories but accept singular
            switch (inCategory)
            {
                case "all":
                    var entireRange = new List<Range<ModelID>>
                    {
                        All.CritterIDs,
                        All.CharacterIDs,
                        All.BiomeRecipeIDs,
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
                    workload = new ModelCollection<Model>(entireRange, ((IEnumerable<Model>)All.Characters)
                                                                       .Concat(All.Critters)
                                                                       .Concat(All.BiomeRecipes)
                                                                       .Concat(All.CraftingRecipes)
                                                                       .Concat(All.Interactions)
                                                                       .Concat(All.Floors)
                                                                       .Concat(All.Blocks)
                                                                       .Concat(All.Furnishings)
                                                                       .Concat(All.Collectibles)
                                                                       .Concat(All.RoomRecipes)
                                                                       .Concat(All.Items));
                    break;
                case "being":
                case "beings":
                    workload = new ModelCollection<Model>(All.BeingIDs, All.Beings);
                    break;
                case "critter":
                case "critters":
                    workload = new ModelCollection<Model>(All.CritterIDs, All.Critters);
                    break;
                case "character":
                case "characters":
                    workload = new ModelCollection<Model>(All.CharacterIDs, All.Characters);
                    break;
                case "biome":
                case "biomes":
                    workload = new ModelCollection<Model>(All.BiomeRecipeIDs, All.BiomeRecipes);
                    break;
                case "craft":
                case "crafts":
                    workload = new ModelCollection<Model>(All.CraftingRecipeIDs, All.CraftingRecipes);
                    break;
                case "interaction":
                case "interactions":
                    workload = new ModelCollection<Model>(All.InteractionIDs, All.Interactions);
                    break;
                case "item":
                case "items":
                    workload = new ModelCollection<Model>(All.ItemIDs, All.Items);
                    break;
                case "p-item":
                case "p-items":
                    var pitems = All.Items.Where(model => model.ParquetID != ModelID.None);
                    workload = new ModelCollection<Model>(All.ItemIDs, pitems);
                    break;
                case "n-item":
                case "n-items":
                    var nitems = All.Items.Where(model => model.ParquetID == ModelID.None);
                    workload = new ModelCollection<Model>(All.ItemIDs, nitems);
                    break;
                case "map":
                case "maps":
                    workload = new ModelCollection<Model>(All.MapIDs, All.Maps);
                    break;
                case "chunk":
                case "chunks":
                    workload = new ModelCollection<Model>(All.MapChunkIDs, All.Maps);
                    break;
                case "region":
                case "regions":
                    workload = new ModelCollection<Model>(All.MapRegionIDs, All.Maps);
                    break;
                case "parquet":
                case "parquets":
                    workload = new ModelCollection<Model>(All.ParquetIDs, All.Parquets);
                    break;
                case "floor":
                case "floors":
                    workload = new ModelCollection<Model>(All.FloorIDs, All.Floors);
                    break;
                case "block":
                case "blocks":
                    workload = new ModelCollection<Model>(All.BlockIDs, All.Blocks);
                    break;
                case "furnishing":
                case "furnishings":
                    workload = new ModelCollection<Model>(All.FurnishingIDs, All.Furnishings);
                    break;
                case "collectible":
                case "collectibles":
                    workload = new ModelCollection<Model>(All.CollectibleIDs, All.Collectibles);
                    break;
                case "room":
                case "rooms":
                    workload = new ModelCollection<Model>(All.RoomRecipeIDs, All.RoomRecipes);
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
        private static ExitCode DisplayDefault(ModelCollection<Model> inWorkload)
        {
            Console.WriteLine(Resources.MessageDefault);
            return ExitCode.Success;
        }

        /// <summary>
        /// Displays a detailed help message to the user.
        /// </summary>
        /// <param name="inWorkload">Ignored.</param>
        /// <returns><see cref="ExitCode.Success"/></returns>
        private static ExitCode DisplayHelp(ModelCollection<Model> inWorkload)
        {
            Console.WriteLine(Resources.MessageHelp);
            return ExitCode.Success;
        }

        /// <summary>
        /// Displays version information to the user.
        /// </summary>
        /// <param name="inWorkload">Ignored.</param>
        /// <returns><see cref="ExitCode.Success"/></returns>
        private static ExitCode DisplayVersion(ModelCollection<Model> inWorkload)
        {
            Console.WriteLine(string.Format(CultureInfo.CurrentCulture, Resources.MessageVersion,
                                            AssemblyInfo.LibraryVersion.Remove(AssemblyInfo.LibraryVersion.Length - 2),
                                            AssemblyInfo.LibraryVersion));
            return ExitCode.Success;
        }

        /// <summary>
        /// Write CSV templates to current directory.
        /// </summary>
        /// <param name="inWorkload">Ignored.</param>
        /// <returns>A value indicating success or the nature of the failure.</returns>
        private static ExitCode CreateTemplates(ModelCollection<Model> inWorkload)
        {
            if (!File.Exists(PronounGroup.FilePath))
            {
                PronounGroup.PutRecords(Enumerable.Empty<PronounGroup>());
            }
            if (!File.Exists(BiomeConfiguration.FilePath))
            {
                BiomeConfiguration.PutRecord();
            }
            if (!File.Exists(CraftConfiguration.FilePath))
            {
                CraftConfiguration.PutRecord();
            }
            if (!File.Exists(RoomConfiguration.FilePath))
            {
                RoomConfiguration.PutRecord();
            }
            
            if (!File.Exists(ModelCollection.GetFilePath<GameModel>()))
            {
                ModelCollection<GameModel>.Default.PutRecordsForType<GameModel>();
            }
            if (!File.Exists(ModelCollection.GetFilePath<CritterModel>()))
            {
                ModelCollection<BeingModel>.Default.PutRecordsForType<CritterModel>();
            }
            if (!File.Exists(ModelCollection.GetFilePath<CharacterModel>()))
            {
                ModelCollection<BeingModel>.Default.PutRecordsForType<CharacterModel>();
            }
            if (!File.Exists(ModelCollection.GetFilePath<BiomeRecipe>()))
            {
                ModelCollection<BiomeRecipe>.Default.PutRecordsForType<BiomeRecipe>();
            }
            if (!File.Exists(ModelCollection.GetFilePath<CraftingRecipe>()))
            {
                ModelCollection<CraftingRecipe>.Default.PutRecordsForType<CraftingRecipe>();
            }
            if (!File.Exists(ModelCollection.GetFilePath<InteractionModel>()))
            {
                ModelCollection<InteractionModel>.Default.PutRecordsForType<InteractionModel>();
            }
            if (!File.Exists(ModelCollection.GetFilePath<MapChunkModel>()))
            {
                ModelCollection<MapModel>.Default.PutRecordsForType<MapChunkModel>();
            }
            if (!File.Exists(ModelCollection.GetFilePath<MapRegionSketch>()))
            {
                ModelCollection<MapModel>.Default.PutRecordsForType<MapRegionSketch>();
            }
            if (!File.Exists(ModelCollection.GetFilePath<MapRegionModel>()))
            {
                ModelCollection<MapModel>.Default.PutRecordsForType<MapRegionModel>();
            }
            if (!File.Exists(ModelCollection.GetFilePath<FloorModel>()))
            {
                ModelCollection<ParquetModel>.Default.PutRecordsForType<FloorModel>();
            }
            if (!File.Exists(ModelCollection.GetFilePath<BlockModel>()))
            {
                ModelCollection<ParquetModel>.Default.PutRecordsForType<BlockModel>();
            }
            if (!File.Exists(ModelCollection.GetFilePath<FurnishingModel>()))
            {
                ModelCollection<ParquetModel>.Default.PutRecordsForType<FurnishingModel>();
            }
            if (!File.Exists(ModelCollection.GetFilePath<CollectibleModel>()))
            {
                ModelCollection<ParquetModel>.Default.PutRecordsForType<CollectibleModel>();
            }
            if (!File.Exists(ModelCollection.GetFilePath<RoomRecipe>()))
            {
                ModelCollection<RoomRecipe>.Default.PutRecordsForType<RoomRecipe>();
            }
            if (!File.Exists(ModelCollection.GetFilePath<ScriptModel>()))
            {
                ModelCollection<ScriptModel>.Default.PutRecordsForType<ScriptModel>();
            }
            if (!File.Exists(ModelCollection.GetFilePath<ItemModel>()))
            {
                ModelCollection<ItemModel>.Default.PutRecordsForType<ItemModel>();
            }

            return ExitCode.Success;
        }

        /// <summary>
        /// Prepare CSVs in current directory for use.
        /// </summary>
        /// <param name="inWorkload">Ignored.</param>
        /// <returns>A value indicating success or the nature of the failure.</returns>
        private static ExitCode RollCSVs(ModelCollection<Model> inWorkload)
        {
            // Currently, all that has to be done is assigning ModelIDs.  Loading and saving will accomplish this.
            if (!All.LoadFromCSVs())
            {
                Console.WriteLine(Resources.ErrorLoading);
                return ExitCode.ReadFault;
            }
            else if (!All.SaveToCSVs())
            {
                Console.WriteLine(Resources.ErrorSaving);
                return ExitCode.WriteFault;
            }
            else
            {
                return ExitCode.Success;
            }
        }

        /// <summary>
        /// Check for inconsistent adjacency information in all defined <see cref="MapRegionModel"/>s and <see cref="MapRegionSketch"/>es.
        /// </summary>
        /// <param name="inWorkload">Ignored.</param>
        /// <returns>A value indicating success or the nature of the failure.</returns>
        private static ExitCode CheckAdjacency(ModelCollection<Model> inWorkload)
        {
#if DESIGN
            if (!All.LoadFromCSVs())
            {
                Console.WriteLine(Resources.ErrorLoading);
                return ExitCode.ReadFault;
            }

            var sketches = new ModelCollection<Model>(All.MapRegionIDs, All.Maps.Where(map => map is MapRegionSketch));
            var orderedWorkload = sketches.OrderBy(x => x.ID);
            Console.WriteLine(string.Format(CultureInfo.CurrentCulture, Resources.MessageChecking,
                                            $"{nameof(MapRegionSketch)}es"));
            foreach (var model in orderedWorkload)
            {
                var results = MapAnalysis.CheckExitConsistency<MapRegionSketch>(model.ID);
                foreach (var result in results)
                {
                    Console.WriteLine(result);
                }
            }

            var regions = new ModelCollection<Model>(All.MapRegionIDs, All.Maps.Where(map => map is MapRegionModel));
            orderedWorkload = regions.OrderBy(x => x.ID);
            Console.WriteLine(string.Format(CultureInfo.CurrentCulture, Resources.MessageChecking,
                                            $"{nameof(MapRegionModel)}s"));
            foreach (var model in orderedWorkload)
            {
                var results = MapAnalysis.CheckExitConsistency<MapRegionModel>(model.ID);
                foreach (var result in results)
                {
                    Console.WriteLine(result);
                }
            }

            return ExitCode.Success;
#else
                Console.WriteLine(Resources.ErrorEditorSupport);
                return ExitCode.NotSupported;
#endif
        }

        /// <summary>
        /// List all defined pronoun groups.
        /// </summary>
        /// <param name="inWorkload">Ignored.</param>
        /// <returns>A value indicating success or the nature of the failure.</returns>
        private static ExitCode ListPronouns(ModelCollection<Model> inWorkload)
        {
            if (!All.LoadFromCSVs())
            {
                Console.WriteLine(Resources.ErrorLoading);
                return ExitCode.ReadFault;
            }

            foreach (var PronounGroup in All.PronounGroups)
            {
                Console.WriteLine(PronounGroup);
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
        private static ExitCode DisplayBadArguments(ModelCollection<Model> inWorkload)
        {
            DisplayHelp(null);
            return ExitCode.BadArguments;
        }

        /// <summary>
        /// Lists the defined ranges for the given <see cref="Model"/>s' <see cref="ModelID"/>s.
        /// </summary>
        /// <param name="inWorkload">The <see cref="Model"/>s to inspect.</param>
        /// <returns><see cref="ExitCode.Success"/></returns>
        private static ExitCode ListRanges(ModelCollection<Model> inWorkload)
        {
            if (inWorkload is null || inWorkload.Count == 0)
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
        private static ExitCode ListMaxIDs(ModelCollection<Model> inWorkload)
        {
            if (inWorkload is null || inWorkload.Count == 0)
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
        private static ExitCode ListTags(ModelCollection<Model> inWorkload)
        {
            if (inWorkload is null || inWorkload.Count == 0)
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
        private static ExitCode ListNames(ModelCollection<Model> inWorkload)
        {
            if (inWorkload is null || inWorkload.Count == 0)
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
        private static ExitCode ListCollisions(ModelCollection<Model> inWorkload)
        {
            if (inWorkload is null || inWorkload.Count == 0)
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
