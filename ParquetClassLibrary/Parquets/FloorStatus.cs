using System;
using System.Diagnostics.CodeAnalysis;
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
        /// Initializes a new default instance of the <see cref="FloorStatus"/> class.
        /// </summary>
        /// <remarks>This is primarily useful for serialization.</remarks>
        public FloorStatus()
            : this(false)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="FloorStatus"/> class.
        /// </summary>
        /// <param name="isTrench">Whether or not the <see cref="FloorModel"/> associated with this status has been dug out.</param>
        public FloorStatus(bool isTrench)
            => IsTrench = isTrench;

        /// <summary>
        /// Initializes an instance of the <see cref="FloorStatus"/> class
        /// based on a given <see cref="FloorModel"/> identifier.
        /// </summary>
        /// <param name="floorID">The <see cref="ModelID"/> of the definitions being tracked.</param>
        [SuppressMessage("Style", "IDE0060:Remove unused parameter",
            Justification = "This constructor is provided for consistency.  The parameter is currently ignored, but may not be in the future.")]
        public FloorStatus(ModelID floorID)
            // NOTE Currently, by design, no Floor starts as a trench.
            : this(false)
        { }
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
        /// <param name="status">The <see cref="FloorStatus"/> to compare with the current.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public override bool Equals<T>(T status)
            => status is FloorStatus floorStatus
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
        /// <param name="status1">The first <see cref="FloorStatus"/> to compare.</param>
        /// <param name="status2">The second <see cref="FloorStatus"/> to compare.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(FloorStatus status1, FloorStatus status2)
            => status1?.Equals(status2) ?? status2?.Equals(status1) ?? true;

        /// <summary>
        /// Determines whether a specified instance of <see cref="FloorStatus"/> is not equal to another specified instance of <see cref="FloorStatus"/>.
        /// </summary>
        /// <param name="status1">The first <see cref="FloorStatus"/> to compare.</param>
        /// <param name="status2">The second <see cref="FloorStatus"/> to compare.</param>
        /// <returns><c>true</c> if they are NOT equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(FloorStatus status1, FloorStatus status2)
            => !(status1 == status2);
        #endregion

        #region ITypeConverter Implementation
        /// <summary>Allows the converter to construct itself statically.</summary>
        internal static FloorStatus ConverterFactory { get; } = Default;

        /// <summary>
        /// Converts the given <see cref="object"/> to a <see cref="string"/> for serialization.
        /// </summary>
        /// <param name="value">The instance to convert.</param>
        /// <param name="row">The current context and configuration.</param>
        /// <param name="memberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance serialized.</returns>
        public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
            => value is FloorStatus status
                ? $"{status.IsTrench}"
                : Logger.DefaultWithConvertLog(value?.ToString() ?? "null", nameof(FloorStatus), nameof(Default));

        /// <summary>
        /// Converts the given <see cref="string"/> to an <see cref="object"/> as deserialization.
        /// </summary>
        /// <param name="text">The text to convert.</param>
        /// <param name="row">The current context and configuration.</param>
        /// <param name="memberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance deserialized.</returns>
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            if (string.IsNullOrEmpty(text)
                || string.Equals(nameof(Default), text, StringComparison.OrdinalIgnoreCase))
            {
                return Default.DeepClone();
            }

            var parsedIsTrench = bool.TryParse(text, out var temp1)
                ? temp1
                : Logger.DefaultWithParseLog(text, nameof(IsTrench), false);

            return new FloorStatus(parsedIsTrench);
        }
        #endregion

        #region IDeeplyCloneable Interface
        /// <summary>
        /// Creates a new instance that is a deep copy of the current instance.
        /// </summary>
        /// <returns>A new instance with the same status as the current instance.</returns>
        public override T DeepClone<T>()
            => new FloorStatus(IsTrench) as T;
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
        #endregion
    }
}
