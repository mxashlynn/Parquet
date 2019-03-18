using System;
using Newtonsoft.Json;
using ParquetClassLibrary.Sandbox.ID;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Sandbox.Parquets
{
    /// <summary>
    /// Models a sandbox-mode parquet.
    /// </summary>
    public abstract class ParquetParent : IEquatable<ParquetParent>
    {
        /// <summary>The set of values that are allowed for specific ParquetIDs.  Defined by child classes.</summary>
        protected abstract Range<ParquetID> Bounds { get; }

        /// <summary>Unique identifier of the parquet.</summary>
        [JsonProperty(PropertyName = "in_ID")]
        public ParquetID ID;

        /// <summary>Player-facing name of the parquet.</summary>
        [JsonProperty(PropertyName = "in_name")]
        public string Name { get; private set; }

        /// <summary>
        /// If a <see cref="T:ParquetClassLibrary.Sandbox.BiomeMask"/> flag is set,
        /// this parquet helps generate the corresponding <see cref="T:ParquetClassLibrary.Sandbox.Biome"/>.
        /// </summary>
        [JsonProperty(PropertyName = "in_addsToBiome")]
        public BiomeMask AddsToBiome { get; private set; }

        #region Initialization
        /// <summary>
        /// Used by children of the <see cref="T:ParquetClassLibrary.Sandbox.Parquets.ParquetParent"/> class.
        /// </summary>
        /// <param name="in_ID">Unique identifier for the parquet.  Cannot be null.</param>
        /// <param name="in_name">Player-friendly name of the parquet.  Cannot be null.</param>
        /// <param name="in_addsToBiome">
        /// A set of flags indicating which, if any, <see cref="T:ParquetClassLibrary.Sandbox.Biome"/>
        /// this parquet helps to generate.
        /// </param>
        [JsonConstructor]
        protected ParquetParent(ParquetID in_ID, string in_name, BiomeMask in_addsToBiome = BiomeMask.None)
        {
            // Ensures that the absolute value of the given parquet identifier lies withint a specified range.
            var absID = Math.Abs(in_ID);
            if (!Bounds.ContainsValue(absID))
            {
                throw new ArgumentOutOfRangeException(nameof(in_ID));
            }

            ID = in_ID;
            Name = in_name ?? throw new ArgumentNullException(nameof(in_name));
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
        /// <returns>
        /// <c>true</c> if the <see cref="ParquetClassLibrary.Sandbox.Parquets.ParquetParent"/>s are equal.
        /// </returns>
        public bool Equals(ParquetParent in_parquet)
        {
            return ID == in_parquet.ID;
        }

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the
        /// current <see cref="T:ParquetClassLibrary.Sandbox.Parquets.ParquetParent"/>.
        /// </summary>
        /// <param name="obj">
        /// The <see cref="object"/> to compare with the current
        /// <see cref="T:ParquetClassLibrary.Sandbox.Parquets.ParquetParent"/>.
        /// </param>
        /// <returns>
        /// <c>true</c> if the specified <see cref="object"/> is equal to the current
        /// <see cref="T:ParquetClassLibrary.Sandbox.Parquets.ParquetParent"/>; otherwise, <c>false</c>.
        /// </returns>
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
        /// <returns><c>true</c> if <c>in_vector1</c> and <c>in_vector2</c> are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(ParquetParent in_parquet1, ParquetParent in_parquet2)
        {
            if (object.ReferenceEquals(in_parquet1, in_parquet2)) return true;
            if (object.ReferenceEquals(in_parquet1, null)) return false;
            if (object.ReferenceEquals(in_parquet2, null)) return false;

            return in_parquet1.ID == in_parquet2.ID;
        }

        /// <summary>
        /// Determines whether a specified instance of <see cref="ParquetClassLibrary.Sandbox.Parquets.ParquetParent"/> is not equal
        /// to another specified instance of <see cref="ParquetClassLibrary.Sandbox.Parquets.ParquetParent"/>.
        /// </summary>
        /// <param name="in_parquet1">The first <see cref="ParquetClassLibrary.Sandbox.Parquets.ParquetParent"/> to compare.</param>
        /// <param name="in_parquet2">The second <see cref="ParquetClassLibrary.Sandbox.Parquets.ParquetParent"/> to compare.</param>
        /// <returns><c>true</c> if <c>in_vector1</c> and <c>in_vector2</c> are NOT equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(ParquetParent in_parquet1, ParquetParent in_parquet2)
        {
            if (object.ReferenceEquals(in_parquet1, in_parquet2)) return false;
            if (object.ReferenceEquals(in_parquet1, null)) return true;
            if (object.ReferenceEquals(in_parquet2, null)) return true;

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
