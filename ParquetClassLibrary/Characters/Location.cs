using System;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Characters
{
    /// <summary>
    /// Represents a specific position within a specific <see cref="MapRegion"/>.
    /// </summary>
    public struct Location : IEquatable<Location>
    {
        /// <summary>The identifier for the <see cref="MapRegion"/> this character is located in.</summary>
        public Guid RegionID { get; set; }

        /// <summary>The position within the current <see cref="MapRegion"/> where this character is located.</summary>
        public Vector2D Position { get; set; }

        #region IEquatable Implementation
        /// <summary>
        /// Serves as a hash function for a <see cref="Location"/>.
        /// </summary>
        /// <returns>
        /// A hash code for this instance that is suitable for use in hashing algorithms and data structures.
        /// </returns>
        public override int GetHashCode()
            => (RegionID, Position).GetHashCode();

        /// <summary>
        /// Determines whether the specified <see cref="Location"/> is equal to the current <see cref="Location"/>.
        /// </summary>
        /// <param name="in_location">The <see cref="Location"/> to compare with the current.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public bool Equals(Location in_location)
            => RegionID == in_location.RegionID
            && Position == in_location.Position;

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="Location"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="Location"/>.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
            => obj is Location location && Equals(location);

        /// <summary>
        /// Determines whether a specified instance of <see cref="Location"/> is equal to another specified instance of <see cref="Location"/>.
        /// </summary>
        /// <param name="in_location1">The first <see cref="Location"/> to compare.</param>
        /// <param name="in_location2">The second <see cref="Location"/> to compare.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(Location in_location1, Location in_location2)
            => in_location1.RegionID == in_location2.RegionID
            && in_location1.Position == in_location2.Position;


        /// <summary>
        /// Determines whether a specified instance of <see cref="Location"/> is not equal to another specified instance of <see cref="Location"/>.
        /// </summary>
        /// <param name="in_location1">The first <see cref="Location"/> to compare.</param>
        /// <param name="in_location2">The second <see cref="Location"/> to compare.</param>
        /// <returns><c>true</c> if they are NOT equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(Location in_location1, Location in_location2)
            => in_location1.RegionID != in_location2.RegionID
            || in_location1.Position != in_location2.Position;

        #endregion

        #region Utilities
        /// <summary>
        /// Describes the <see cref="Location"/> as a <see langword="string"/>.
        /// </summary>
        /// <returns>A <see langword="string"/> that represents the current <see cref="Location"/>.</returns>
        public override string ToString()
            => $"{Position} in {RegionID}";
        #endregion
    }
}
