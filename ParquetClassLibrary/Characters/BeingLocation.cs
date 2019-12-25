using System;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Characters
{
    /// <summary>
    /// Represents a specific position within a specific <see cref="MapRegion"/>.
    /// </summary>
    public readonly struct BeingLocation : IEquatable<BeingLocation>
    {
        /// <summary>The identifier for the <see cref="MapRegion"/> this <see cref="Being"/> is located in.</summary>
        public Guid RegionID { get; }

        /// <summary>The position within the current <see cref="MapRegion"/> where this <see cref="Being"/> is located.</summary>
        public Vector2D Position { get; }

        #region IEquatable Implementation
        /// <summary>
        /// Serves as a hash function for a <see cref="BeingLocation"/>.
        /// </summary>
        /// <returns>
        /// A hash code for this instance that is suitable for use in hashing algorithms and data structures.
        /// </returns>
        public override int GetHashCode()
            => (RegionID, Position).GetHashCode();

        /// <summary>
        /// Determines whether the specified <see cref="BeingLocation"/> is equal to the current <see cref="BeingLocation"/>.
        /// </summary>
        /// <param name="in_location">The <see cref="BeingLocation"/> to compare with the current.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public bool Equals(BeingLocation in_location)
            => RegionID == in_location.RegionID
            && Position == in_location.Position;

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="BeingLocation"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="BeingLocation"/>.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
            => obj is BeingLocation location && Equals(location);

        /// <summary>
        /// Determines whether a specified instance of <see cref="BeingLocation"/> is equal to another specified instance of <see cref="BeingLocation"/>.
        /// </summary>
        /// <param name="in_location1">The first <see cref="BeingLocation"/> to compare.</param>
        /// <param name="in_location2">The second <see cref="BeingLocation"/> to compare.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(BeingLocation in_location1, BeingLocation in_location2)
            => in_location1.RegionID == in_location2.RegionID
            && in_location1.Position == in_location2.Position;


        /// <summary>
        /// Determines whether a specified instance of <see cref="BeingLocation"/> is not equal to another specified instance of <see cref="BeingLocation"/>.
        /// </summary>
        /// <param name="in_location1">The first <see cref="BeingLocation"/> to compare.</param>
        /// <param name="in_location2">The second <see cref="BeingLocation"/> to compare.</param>
        /// <returns><c>true</c> if they are NOT equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(BeingLocation in_location1, BeingLocation in_location2)
            => in_location1.RegionID != in_location2.RegionID
            || in_location1.Position != in_location2.Position;

        #endregion

        #region Utilities
        /// <summary>
        /// Describes the <see cref="BeingLocation"/> as a <see langword="string"/>.
        /// </summary>
        /// <returns>A <see langword="string"/> that represents the current <see cref="BeingLocation"/>.</returns>
        public override string ToString()
            => $"{Position} in {RegionID}";
        #endregion
    }
}
