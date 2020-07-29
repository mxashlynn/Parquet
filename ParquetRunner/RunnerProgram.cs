using System;
using ParquetClassLibrary;
using ParquetClassLibrary.Beings;
using ParquetClassLibrary.Games;

namespace ParquetRunner
{
    /// <summary>
    /// A simple program used to run some basic features of the <see cref="ParquetClassLibrary"/>.
    /// </summary>
    internal class MainClass
    {
        /// <summary>
        /// A simple program used to run some basic features of the <see cref="ParquetClassLibrary"/>.
        /// </summary>
        public static void Main()
        {
            All.LoadFromCSVs();

            var game = new GameModel(All.GameIDs.Minimum + 1, "Sample Game", "", "", false, "", -1, All.CharacterIDs.Minimum, All.ScriptIDs.Minimum);
            var episode = new GameModel(All.GameIDs.Minimum + 2, "Sample Episode", "", "", true, "In Which A Library Is Tested", 1, All.CharacterIDs.Minimum, All.ScriptIDs.Minimum);
            Console.WriteLine(game);
            Console.WriteLine(episode);
            Console.WriteLine($"Item range = {All.ItemIDs}");

            All.SaveToCSVs();
        }
    }
}
