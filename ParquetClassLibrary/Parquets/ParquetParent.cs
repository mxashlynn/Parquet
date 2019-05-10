using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using ParquetClassLibrary.Biomes;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Parquets
{
    /// <summary>
    /// Models a sandbox-mode parquet.
    /// </summary>
    public abstract class ParquetParent : Entity
    {
        /// <summary>
        /// A set of <see cref="EntityTag"/>s describing the <see cref="Biome"/>(s) thhat this parquet helps generate.
        /// </summary>
        [JsonProperty(PropertyName = "in_addsToBiome")]
        public IReadOnlyList<EntityTag> AddsToBiome { get; }

        #region Initialization
        /// <summary>
        /// Used by children of the <see cref="ParquetParent"/> class.
        /// </summary>
        /// <param name="in_bounds">The bounds within which the derived parquet type's EntityID is defined.</param>
        /// <param name="in_id">Unique identifier for the parquet.  Cannot be null.</param>
        /// <param name="in_name">Player-friendly name of the parquet.  Cannot be null or empty.</param>
        /// <param name="in_addsToBiome">A set of <see cref="EntityTag"/>s indicating which, if any, <see cref="Biome"/> this parquet helps to generate.</param>
        [JsonConstructor]
        protected ParquetParent(Range<EntityID> in_bounds, EntityID in_id, string in_name, List<EntityTag> in_addsToBiome = null)
            : base(in_bounds, in_id, in_name)
        {
            AddsToBiome = in_addsToBiome ?? Enumerable.Empty<EntityTag>().ToList();
        }
        #endregion
    }
}
