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
        /// <param name="regionID">The identifier for the <see cref="Regions.RegionModel"/> in which the tracked <see cref="Model"/> is located.</param>
        /// <param name="position">The position within the current <see cref="Regions.RegionModel"/> of the tracked <see cref="Model"/>.</param>
        public Location(ModelID? regionID = null, Point2D? position = null)
        {
            RegionID = regionID ?? ModelID.None;
            Position = position ?? Point2D.Origin;
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
        /// <param name="location">The <see cref="Location"/> to compare with the current.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public bool Equals(Location location)
            => RegionID == location.RegionID
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
        /// <param name="location1">The first <see cref="Location"/> to compare.</param>
        /// <param name="location2">The second <see cref="Location"/> to compare.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(Location location1, Location location2)
            => location1.Equals(location2);

        /// <summary>
        /// Determines whether a specified instance of <see cref="Location"/> is not equal to another specified instance of <see cref="Location"/>.
        /// </summary>
        /// <param name="location1">The first <see cref="Location"/> to compare.</param>
        /// <param name="location2">The second <see cref="Location"/> to compare.</param>
        /// <returns><c>true</c> if they are NOT equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(Location location1, Location location2)
            => !(location1 == location2);
        #endregion

        #region ITypeConverter Implementation
        /// <summary>Allows the converter to construct itself statically.</summary>
        internal static Location ConverterFactory { get; } = Nowhere;

        /// <summary>
        /// Converts the given <see cref="string"/> to an <see cref="object"/> as deserialization.
        /// </summary>
        /// <param name="value">The instance to convert.</param>
        /// <param name="row">The current context and configuration.</param>
        /// <param name="memberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance deserialized.</returns>
        public string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
            => value is Location location
                ? $"{location.RegionID.ConvertToString(location.RegionID, row, memberMapData)}{Delimiters.InternalDelimiter}" +
                  $"{location.Position.ConvertToString(location.Position, row, memberMapData)}"
                : Logger.DefaultWithConvertLog(value?.ToString() ?? "null", nameof(Location), nameof(Nowhere));

        /// <summary>
        /// Converts the given <see cref="object"/> to a <see cref="string"/> for serialization.
        /// </summary>
        /// <param name="text">The text to convert.</param>
        /// <param name="row">The current context and configuration.</param>
        /// <param name="memberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance serialized.</returns>
        public object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            if (string.IsNullOrEmpty(text)
                || string.Compare(nameof(Nowhere), text, StringComparison.OrdinalIgnoreCase) == 0)
            {
                return Nowhere;
            }

            var parameterText = text.Split(Delimiters.InternalDelimiter);

            var parsedRegionID = (ModelID)ModelID.ConverterFactory.ConvertFromString(parameterText[0], row, memberMapData);
            var parsedPosition = (Point2D)Point2D.ConverterFactory.ConvertFromString(parameterText[1], row, memberMapData);

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
