using System;
using ParquetClassLibrary;

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

        /// <summary>
        /// A command line tool for working with Parquet configuration files.
        /// </summary>
        /// <param name="args">Command line arguments passed in to the tool.</param>
        internal static int Main(string[] args)
        {
            // Advertise -[character] but also accept /[character]
            // Advertise [verb] but also accept --[verb]
            // Advertise plural properties and categories but accept singular

            Console.WriteLine(DefaultMessage);
            return 0;
        }
    }
}
