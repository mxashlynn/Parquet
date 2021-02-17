using System;
using CsvHelper;
using CsvHelper.Configuration;

namespace Parquet.Parquets
{
    /// <summary>
    /// Tracks the status of a <see cref="FloorModel"/>.
    /// Instances of this class are mutable during play.
    /// </summary>
    public sealed class FloorStatus : ParquetStatus<FloorModel>
    {
        #region Class Defaults
        /// <summary>Provides an instance of the <see cref="FloorStatus"/> class with default values.</summary>
        public static FloorStatus Default { get; } = new FloorStatus();
        #endregion

        #region Status
        /// <summary>Whether or not the <see cref="FloorModel"/> associated with this status has been dug out.</summary>
        public bool IsTrench { get; set; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="FloorStatus"/> class.
        /// </summary>
        /// <param name="inIsTrench">Whether or not the <see cref="FloorModel"/> associated with this status has been dug out.</param>
        public FloorStatus(bool inIsTrench = false)
            => IsTrench = inIsTrench;
        #endregion

        #region IEquatable Implementation
        /// <summary>
        /// Serves as a hash function for a <see cref="FloorStatus"/>.
        /// </summary>
        /// <returns>
        /// A hash code for this instance that is suitable for use in hashing algorithms and data structures.
        /// </returns>
        public override int GetHashCode()
            => IsTrench.GetHashCode();

        /// <summary>
        /// Determines whether the specified <see cref="FloorStatus"/> is equal to the current <see cref="FloorStatus"/>.
        /// </summary>
        /// <param name="inStatus">The <see cref="FloorStatus"/> to compare with the current.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public override bool Equals<T>(T inStatus)
            => inStatus is FloorStatus floorStatus
            && IsTrench == floorStatus.IsTrench;

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="FloorStatus"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="FloorStatus"/>.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
            => obj is FloorStatus status
            && Equals(status);

        /// <summary>
        /// Determines whether a specified instance of <see cref="FloorStatus"/> is equal to another specified instance of <see cref="FloorStatus"/>.
        /// </summary>
        /// <param name="inStatus1">The first <see cref="FloorStatus"/> to compare.</param>
        /// <param name="inStatus2">The second <see cref="FloorStatus"/> to compare.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(FloorStatus inStatus1, FloorStatus inStatus2)
            => inStatus1?.Equals(inStatus2) ?? inStatus2?.Equals(inStatus1) ?? true;

        /// <summary>
        /// Determines whether a specified instance of <see cref="FloorStatus"/> is not equal to another specified instance of <see cref="FloorStatus"/>.
        /// </summary>
        /// <param name="inStatus1">The first <see cref="FloorStatus"/> to compare.</param>
        /// <param name="inStatus2">The second <see cref="FloorStatus"/> to compare.</param>
        /// <returns><c>true</c> if they are NOT equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(FloorStatus inStatus1, FloorStatus inStatus2)
            => !(inStatus1 == inStatus2);
        #endregion

        #region ITypeConverter Implementation
        /// <summary>Allows the converter to construct itself statically.</summary>
        internal static FloorStatus ConverterFactory { get; } = Default;

        /// <summary>
        /// Converts the given <see cref="object"/> to a <see cref="string"/> for serialization.
        /// </summary>
        /// <param name="inValue">The instance to convert.</param>
        /// <param name="inRow">The current context and configuration.</param>
        /// <param name="inMemberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance serialized.</returns>
        public override string ConvertToString(object inValue, IWriterRow inRow, MemberMapData inMemberMapData)
            => inValue is FloorStatus status
                ? $"{status.IsTrench}"
                : Logger.DefaultWithConvertLog(inValue?.ToString() ?? "null", nameof(FloorStatus), nameof(Default));

        /// <summary>
        /// Converts the given <see cref="string"/> to an <see cref="object"/> as deserialization.
        /// </summary>
        /// <param name="inText">The text to convert.</param>
        /// <param name="inRow">The current context and configuration.</param>
        /// <param name="inMemberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance deserialized.</returns>
        public override object ConvertFromString(string inText, IReaderRow inRow, MemberMapData inMemberMapData)
        {
            if (string.IsNullOrEmpty(inText)
                || string.Compare(nameof(Default), inText, StringComparison.OrdinalIgnoreCase) == 0)
            {
                return Default.DeepClone();
            }

            var parsedIsTrench = bool.TryParse(inText, out var temp1)
                ? temp1
                : Logger.DefaultWithParseLog(inText, nameof(IsTrench), false);

            return new FloorStatus(parsedIsTrench);
        }
        #endregion

        #region Utilities
        /// <summary>
        /// Returns a <see cref="string"/> that represents the current <see cref="FloorStatus"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override string ToString()
            => IsTrench
                ? "dug out"
                : "filled in";

        /// <summary>
        /// Creates a new instance that is a deep copy of the current instance.
        /// </summary>
        /// <returns>A new instance with the same characteristics as the current instance.</returns>
        public FloorStatus DeepClone()
            => new FloorStatus(IsTrench);
        #endregion
    }
}
