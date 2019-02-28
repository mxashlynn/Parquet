using Newtonsoft.Json;
using ParquetClassLibrary.Sandbox.ID;

namespace ParquetClassLibrary.Sandbox.Parquets
{
    /// <summary>
    /// Configurations for a sandbox-mode Characters, Furnishings, Crafting Materils, etc.
    /// </summary>
    public class Collectable : ParquetParent
    {
        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ParquetClassLibrary.Sandbox.Parquets.Collectable"/> class.
        /// </summary>
        /// <param name="in_ID">Unique identifier for the parquet.  Cannot be null.</param>
        /// <param name="in_name">Player-friendly name of the parquet.  Cannot be null.</param>
        /// <param name="in_addsToBiome">
        /// A set of flags indicating which, if any, <see cref="T:ParquetClassLibrary.Sandbox.Biome"/> this parquet helps to generate.
        /// </param>
        [JsonConstructor]
        public Collectable(ParquetID in_ID, string in_name, BiomeMask in_addsToBiome = BiomeMask.None)
            : base(in_ID, in_name, in_addsToBiome)
        { }
        #endregion
    }
}
