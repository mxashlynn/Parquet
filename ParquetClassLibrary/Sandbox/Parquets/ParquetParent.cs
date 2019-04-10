using System;
using Newtonsoft.Json;
using ParquetClassLibrary.Sandbox.IDs;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Sandbox.Parquets
{
    /// <summary>
    /// Models a sandbox-mode parquet.
    /// </summary>
    public abstract class ParquetParent : IEquatable<ParquetParent>
    {
        /// <summary>Unique identifier of the parquet.</summary>
        [JsonProperty(PropertyName = "in_ID")]
        public EntityID ID { get; }

        /// <summary>Player-facing name of the parquet.</summary>
        [JsonProperty(PropertyName = "in_name")]
        public string Name { get; }

        /// <summary>
        /// If a <see cref="T:ParquetClassLibrary.Sandbox.BiomeMask"/> flag is set,
        /// this parquet helps generate the corresponding <see cref="T:ParquetClassLibrary.Sandbox.Biome"/>.
        /// </summary>
        [JsonProperty(PropertyName = "in_addsToBiome")]
        public BiomeMask AddsToBiome { get; }

        #region Initialization
        /// <summary>
        /// Used by children of the <see cref="T:ParquetClassLibrary.Sandbox.Parquets.ParquetParent"/> class.
        /// </summary>
        /// <param name="in_bounds">The bounds within which the derived parquet type's EntityID is defined.</param>
        /// <param name="in_id">Unique identifier for the parquet.  Cannot be null.</param>
        /// <param name="in_name">Player-friendly name of the parquet.  Cannot be null or empty.</param>
        /// <param name="in_addsToBiome">
        /// A set of flags indicating which, if any, <see cref="T:ParquetClassLibrary.Sandbox.Biome"/>
        /// this parquet helps to generate.
        /// </param>
        [JsonConstructor]
        protected ParquetParent(Range<EntityID> in_bounds, EntityID in_id, string in_name, BiomeMask in_addsToBiome = BiomeMask.None)
        {
            if (!in_id.IsValidForRange(in_bounds))
            {
                throw new ArgumentOutOfRangeException(nameof(in_id));
            }
            if (string.IsNullOrEmpty(in_name))
            {
                throw new ArgumentNullException(nameof(in_name));
            }

            ID = in_id;
            Name = in_name;
            AddsToBiome = in_addsToBiome;
        }
        #endregion

        #region IEquatable Implementation
        /// <summary>
        /// Serves as a hash function for a <see cref="T:ParquetClassLibrary.Sandbox.Parquets.ParquetParent"/> struct.
        /// </summary>
        /// <returns>
        /// A hash code for this instance that is suitable for use in hashing algorithms and data structures.
        /// </returns>
        public override int GetHashCode()
        {
            return ID.GetHashCode();
        }

        /// <summary>
        /// Determines whether the specified <see cref="ParquetClassLibrary.Sandbox.Parquets.ParquetParent"/>
        /// is equal to the current <see cref="T:ParquetClassLibrary.Sandbox.Parquets.ParquetParent"/>.
        /// </summary>
        /// <param name="in_parquet">
        /// The <see cref="ParquetClassLibrary.Sandbox.Parquets.ParquetParent"/> to compare with the current.
        /// </param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public bool Equals(ParquetParent in_parquet)
        {
            return in_parquet != null && ID == in_parquet.ID;
        }

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the
        /// current <see cref="T:ParquetClassLibrary.Sandbox.Parquets.ParquetParent"/>.
        /// </summary>
        /// <param name="obj">
        /// The <see cref="object"/> to compare with the current
        /// <see cref="T:ParquetClassLibrary.Sandbox.Parquets.ParquetParent"/>.
        /// </param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        // ReSharper disable once InconsistentNaming
        public override bool Equals(object obj)
        {
            var result = false;

            if (obj is ParquetParent parquet)
            {
                result = Equals(parquet);
            }

            return result;
        }

        /// <summary>
        /// Determines whether a specified instance of <see cref="ParquetClassLibrary.Sandbox.Parquets.ParquetParent"/> is equal to
        /// another specified instance of <see cref="ParquetClassLibrary.Sandbox.Parquets.ParquetParent"/>.
        /// </summary>
        /// <param name="in_parquet1">The first <see cref="ParquetClassLibrary.Sandbox.Parquets.ParquetParent"/> to compare.</param>
        /// <param name="in_parquet2">The second <see cref="ParquetClassLibrary.Sandbox.Parquets.ParquetParent"/> to compare.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(ParquetParent in_parquet1, ParquetParent in_parquet2)
        {
            if (ReferenceEquals(in_parquet1, in_parquet2)) return true;
            if (ReferenceEquals(in_parquet1, null)) return false;
            if (ReferenceEquals(in_parquet2, null)) return false;

            return in_parquet1.ID == in_parquet2.ID;
        }

        /// <summary>
        /// Determines whether a specified instance of <see cref="ParquetClassLibrary.Sandbox.Parquets.ParquetParent"/> is not equal
        /// to another specified instance of <see cref="ParquetClassLibrary.Sandbox.Parquets.ParquetParent"/>.
        /// </summary>
        /// <param name="in_parquet1">The first <see cref="ParquetClassLibrary.Sandbox.Parquets.ParquetParent"/> to compare.</param>
        /// <param name="in_parquet2">The second <see cref="ParquetClassLibrary.Sandbox.Parquets.ParquetParent"/> to compare.</param>
        /// <returns><c>true</c> if they are NOT equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(ParquetParent in_parquet1, ParquetParent in_parquet2)
        {
            if (ReferenceEquals(in_parquet1, in_parquet2)) return false;
            if (ReferenceEquals(in_parquet1, null)) return true;
            if (ReferenceEquals(in_parquet2, null)) return true;

            return in_parquet1.ID != in_parquet2.ID;
        }
        #endregion

        #region Utility Methods
        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:ParquetClassLibrary.Sandbox.Parquets.ParquetParent"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override string ToString()
        {
            return Name[0].ToString();
        }
        #endregion
    }
}
