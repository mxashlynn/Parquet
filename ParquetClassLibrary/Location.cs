using System;
using CsvHelper;
using CsvHelper.Configuration;

namespace Parquet
{
    /// <summary>
    /// Tracks a specific position within a specific <see cref="Regions.RegionModel"/>.
    /// Instances of this class are mutable during play.
    /// </summary>
    /// <remarks>
    /// Could meaningfully apply to any object that has a specific position with in the game world.<br />
    /// In practice, is often used for <see cref="Model"/>s in addition to that Model's
    /// <see cref="Status{T}"/> class.
    /// </remarks>
    sealed public class Location : Status<object>
    {
        #region Class Defaults
        /// <summary>Provides a throwaway instance of the <see cref="Location"/> class with default values.</summary>
        public static Location Nowhere { get; } = new Location();
        #endregion

        #region Characteristics
        /// <summary>The identifier for the <see cref="Regions.RegionModel"/> in which the tracked <see cref="Model"/> is located.</summary>
        public ModelID RegionID { get; }

        /// <summary>The position within the current <see cref="Regions.RegionModel"/> of the tracked <see cref="Model"/>.</summary>
        public Vector2D Position { get; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="Location"/> class.
        /// </summary>
        /// <param name="inRegionID">The identifier for the <see cref="Regions.RegionModel"/> in which the tracked <see cref="Model"/> is located.</param>
        /// <param name="inPosition">The position within the current <see cref="Regions.RegionModel"/> of the tracked <see cref="Model"/>.</param>
        public Location(ModelID? inRegionID = null, Vector2D? inPosition = null)
        {
            RegionID = inRegionID ?? ModelID.None;
            Position = inPosition ?? Vector2D.Zero;
        }
        #endregion

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
        public override bool Equals<T>(T inLocation)
            => inLocation is Location location
            && RegionID == location.RegionID
            && Position == location.Position;

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

        #region ITypeConverter Implementation
        /// <summary>Allows the converter to construct itself statically.</summary>
        internal static Location ConverterFactory { get; } = Nowhere;

        /// <summary>
        /// Converts the given <see cref="string"/> to an <see cref="object"/> as deserialization.
        /// </summary>
        /// <param name="inText">The text to convert.</param>
        /// <param name="inRow">The current context and configuration.</param>
        /// <param name="inMemberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance deserialized.</returns>
        public override string ConvertToString(object inValue, IWriterRow inRow, MemberMapData inMemberMapData)
            => inValue is Location location
                ? $"{location.RegionID.ConvertToString(location.RegionID, inRow, inMemberMapData)}{Delimiters.InternalDelimiter}" +
                  $"{location.Position.ConvertToString(location.Position, inRow, inMemberMapData)}"
                : Logger.DefaultWithConvertLog(inValue?.ToString() ?? "null", nameof(Location), nameof(Nowhere));

        /// <summary>
        /// Converts the given <see cref="object"/> to a <see cref="string"/> for serialization.
        /// </summary>
        /// <param name="inValue">The instance to convert.</param>
        /// <param name="inRow">The current context and configuration.</param>
        /// <param name="inMemberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance serialized.</returns>
        public override object ConvertFromString(string inText, IReaderRow inRow, MemberMapData inMemberMapData)
        {
            if (string.IsNullOrEmpty(inText)
                || string.Compare(nameof(Nowhere), inText, StringComparison.OrdinalIgnoreCase) == 0)
            {
                return Nowhere;
            }

            var parameterText = inText.Split(Delimiters.InternalDelimiter);

            var parsedRegionID = (ModelID)ModelID.ConverterFactory.ConvertFromString(parameterText[0], inRow, inMemberMapData);
            var parsedPosition = (Vector2D)Vector2D.ConverterFactory.ConvertFromString(parameterText[1], inRow, inMemberMapData);

            return new Location(parsedRegionID, parsedPosition);
        }
        #endregion

        #region IDeeplyCloneable Implementation
        /// <summary>
        /// Creates a new instance that is a deep copy of the current instance.
        /// </summary>
        /// <returns>A new instance with the same characteristics as the current instance.</returns>
        public override T DeepClone<T>()
            // Note that I believe no additional cloning is needed here as structs have value semantics.
            => new Location(RegionID, Position) as T;
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
