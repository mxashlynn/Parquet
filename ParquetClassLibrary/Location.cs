using System;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace Parquet
{
    /// <summary>
    /// Represents a specific <see cref="Point2D"/> within a specific <see cref="Regions.RegionModel"/>.
    /// Instances have value semantics.
    /// </summary>
    public readonly struct Location : IEquatable<Location>, ITypeConverter
    {
        #region Class Defaults
        /// <summary>Provides an instance of the <see cref="Location"/> class with default values.</summary>
        public static Location Nowhere { get; }
        #endregion

        #region Characteristics
        /// <summary>The identifier for the <see cref="Regions.RegionModel"/> in which the tracked <see cref="Model"/> is located.</summary>
        public ModelID RegionID { get; }

        /// <summary>The position within the current <see cref="Regions.RegionModel"/> of the tracked <see cref="Model"/>.</summary>
        public Point2D Position { get; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="Location"/> class.
        /// </summary>
        /// <param name="inRegionID">The identifier for the <see cref="Regions.RegionModel"/> in which the tracked <see cref="Model"/> is located.</param>
        /// <param name="inPosition">The position within the current <see cref="Regions.RegionModel"/> of the tracked <see cref="Model"/>.</param>
        public Location(ModelID? inRegionID = null, Point2D? inPosition = null)
        {
            RegionID = inRegionID ?? ModelID.None;
            Position = inPosition ?? Point2D.Origin;
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
        public bool Equals(Location inLocation)
            => RegionID == inLocation.RegionID
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
            => inLocation1.Equals(inLocation2);

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
        /// <param name="inValue">The instance to convert.</param>
        /// <param name="inRow">The current context and configuration.</param>
        /// <param name="inMemberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance deserialized.</returns>
        public string ConvertToString(object inValue, IWriterRow inRow, MemberMapData inMemberMapData)
            => inValue is Location location
                ? $"{location.RegionID.ConvertToString(location.RegionID, inRow, inMemberMapData)}{Delimiters.InternalDelimiter}" +
                  $"{location.Position.ConvertToString(location.Position, inRow, inMemberMapData)}"
                : Logger.DefaultWithConvertLog(inValue?.ToString() ?? "null", nameof(Location), nameof(Nowhere));

        /// <summary>
        /// Converts the given <see cref="object"/> to a <see cref="string"/> for serialization.
        /// </summary>
        /// <param name="inText">The text to convert.</param>
        /// <param name="inRow">The current context and configuration.</param>
        /// <param name="inMemberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance serialized.</returns>
        public object ConvertFromString(string inText, IReaderRow inRow, MemberMapData inMemberMapData)
        {
            if (string.IsNullOrEmpty(inText)
                || string.Compare(nameof(Nowhere), inText, StringComparison.OrdinalIgnoreCase) == 0)
            {
                return Nowhere;
            }

            var parameterText = inText.Split(Delimiters.InternalDelimiter);

            var parsedRegionID = (ModelID)ModelID.ConverterFactory.ConvertFromString(parameterText[0], inRow, inMemberMapData);
            var parsedPosition = (Point2D)Point2D.ConverterFactory.ConvertFromString(parameterText[1], inRow, inMemberMapData);

            return new Location(parsedRegionID, parsedPosition);
        }
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
