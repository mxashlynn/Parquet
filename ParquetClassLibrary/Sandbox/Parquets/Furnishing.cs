using Newtonsoft.Json;
using ParquetClassLibrary.Utilities;
using ParquetClassLibrary.Sandbox.ID;

namespace ParquetClassLibrary.Sandbox.Parquets
{
    /// <summary>
    /// Configurations for a sandbox-mode Furniture and similar items.
    /// </summary>
    public class Furnishing : ParquetParent
    {
        #region Class Defaults
        /// <summary>The set of values that are allowed for Block's allowed ParquetIDs.</summary>
        protected override Range<ParquetID> Bounds { get { return Assembly.FurnishingIDs; } }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ParquetClassLibrary.Sandbox.Parquets.Furnishing"/> class.
        /// </summary>
        /// <param name="in_ID">Unique identifier for the parquet.  Cannot be null.</param>
        /// <param name="in_name">Player-friendly name of the parquet.  Cannot be null.</param>
        /// <param name="in_addsToBiome">
        /// A set of flags indicating which, if any, <see cref="T:ParquetClassLibrary.Sandbox.Biome"/> this parquet helps to generate.
        /// </param>
        [JsonConstructor]
        public Furnishing(ParquetID in_ID, string in_name, BiomeMask in_addsToBiome = BiomeMask.None)
            : base(in_ID, in_name, in_addsToBiome)
        { }
        #endregion
    }
}
