using System;
using System.Collections.Generic;
using ParquetClassLibrary.Sandbox.ID;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Sandbox.Parquets
{
    /// <summary>
    /// Models a sandbox-mode parquet.
    /// </summary>
    public abstract class ParquetParent : IEquatable<ParquetParent>
    {
        /// <summary>Used to ensure only unique IDs are used during parquet creation.</summary>
        private static readonly HashSet<ParquetID> KnownIDs = new HashSet<ParquetID>();

        /// <summary>Backing field for the ID property.</summary>
        private ParquetID _id;

        /// <summary>Unique identifier of the parquet.</summary>
        internal ParquetID ID
        {
            get
            {
                return _id;

            }
            private protected set
            {
                if (KnownIDs.Contains(value))
                {
                    Error.Handle($"Tried to create duplicate parquet with ID {value}.");
                }
                else
                {
                    KnownIDs.Add(value);
                    _id = value;
                }
            }
        }

        /// <summary>Player-facing name of the parquet.</summary>
        internal string Name { get; private protected set; }

        /// <summary>
        /// If a <see cref="T:ParquetClassLibrary.Sandbox.BiomeMask"/> flag is set,
        /// this parquet helps generate the corresponding <see cref="T:ParquetClassLibrary.Sandbox.Biome"/>.
        /// </summary>
        internal BiomeMask AddsToBiome { get; private protected set; }

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
        protected ParquetParent(ParquetID in_ID, string in_name, BiomeMask in_addsToBiome = BiomeMask.None)
        {
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
