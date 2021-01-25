using System;

namespace Parquet
{
    /// <summary>
    /// Represents a specific position within a specific <see cref="Maps.MapRegionModel"/>.
    /// </summary>
    /// <remarks>
    /// While primarily used in-library by <see cref="Beings.BeingModel"/> this class
    /// is made generally available to support it's general use by game client code.
    /// </remarks>
    sealed public class Location : IEquatable<Location>
    {
        /// <summary>The identifier for the <see cref="Maps.MapRegionModel"/> of this located.</summary>
        public ModelID RegionID { get; }

        /// <summary>The position within the current <see cref="Maps.MapRegionModel"/> of this located.</summary>
        public Vector2D Position { get; }

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
        /// <param name="inLocation">The <see cref="Location"/> to compare with the current.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public bool Equals(Location inLocation)
            => RegionID == inLocation?.RegionID
            && Position == inLocation.Position;

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="Location"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="Location"/>.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
            => obj is Location location
            && Equals(location);

        /// <summary>
        /// Determines whether a specified instance of <see cref="Location"/> is equal to another specified instance of <see cref="Location"/>.
        /// </summary>
        /// <param name="inLocation1">The first <see cref="Location"/> to compare.</param>
        /// <param name="inLocation2">The second <see cref="Location"/> to compare.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(Location inLocation1, Location inLocation2)
            => inLocation1?.Equals(inLocation2) ?? inLocation2?.Equals(inLocation1) ?? true;

        /// <summary>
        /// Determines whether a specified instance of <see cref="Location"/> is not equal to another specified instance of <see cref="Location"/>.
        /// </summary>
        /// <param name="inLocation1">The first <see cref="Location"/> to compare.</param>
        /// <param name="inLocation2">The second <see cref="Location"/> to compare.</param>
        /// <returns><c>true</c> if they are NOT equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(Location inLocation1, Location inLocation2)
            => !(inLocation1 == inLocation2);
        #endregion

        #region Utilities
        /// <summary>
        /// Describes the <see cref="Location"/> as a <see cref="string"/>.
        /// </summary>
        /// <returns>A <see cref="string"/> that represents the current <see cref="Location"/>.</returns>
        public override string ToString()
            => $"{Position} in {RegionID}";
        #endregion
    }
}
