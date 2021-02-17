using System;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace Parquet.Parquets
{
    /// <summary>
    /// Tracks the status of a <see cref="BlockModel"/>.
    /// Instances of this class are mutable during play.
    /// </summary>
    public sealed class BlockStatus : ParquetStatus<BlockModel>
    {
        #region Class Defaults
        /// <summary>Provides an instance of the <see cref="BlockStatus"/> class with default values.</summary>
        public static BlockStatus Default { get; } = new BlockStatus();
        #endregion

        #region Status
        /// <summary>The <see cref="BlockModel"/>'s native toughness.</summary>
        private readonly int MaxToughness;

        /// <summary>The <see cref="BlockModel"/>'s current toughness.</summary>
        private int backingToughness;

        /// <summary>
        /// The <see cref="BlockModel"/>'s current toughness, from <see cref="BlockModel.MinToughness"/> to <see cref="BlockModel.MaxToughness"/>.
        /// </summary>
        public int Toughness
        {
            get => backingToughness;
            set => backingToughness = value.Normalize(BlockModel.MinToughness, MaxToughness);
        }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="BlockStatus"/> class.
        /// </summary>
        /// <param name="inIsTrench">Whether or not the <see cref="FloorModel"/> associated with this status has been dug out.</param>
        /// <param name="inToughness">The toughness of the <see cref="BlockModel"/> associated with this status.</param>
        /// <param name="inMaxToughness">The native toughness of the <see cref="BlockModel"/> associated with this status.</param>
        public BlockStatus(int inToughness = BlockModel.DefaultMaxToughness, int inMaxToughness = BlockModel.DefaultMaxToughness)
        {
            Toughness = inToughness;
            MaxToughness = inMaxToughness;
        }
        #endregion

        #region IEquatable Implementation
        /// <summary>
        /// Serves as a hash function for a <see cref="BlockStatus"/>.
        /// </summary>
        /// <returns>A hash code for this instance that is suitable for use in hashing algorithms and data structures.</returns>
        public override int GetHashCode()
            => (Toughness, MaxToughness).GetHashCode();

        /// <summary>
        /// Determines whether the specified <see cref="BlockStatus"/> is equal to the current <see cref="BlockStatus"/>.
        /// </summary>
        /// <param name="inStatus">The <see cref="BlockStatus"/> to compare with the current.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public override bool Equals<T>(T inStatus)
            => inStatus is BlockStatus blockStatus
            && Toughness == blockStatus.Toughness
            && MaxToughness == blockStatus.MaxToughness;

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="BlockStatus"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="BlockStatus"/>.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
            => obj is BlockStatus status
            && Equals(status);

        /// <summary>
        /// Determines whether a specified instance of <see cref="BlockStatus"/> is equal to another specified instance of <see cref="BlockStatus"/>.
        /// </summary>
        /// <param name="inStatus1">The first <see cref="BlockStatus"/> to compare.</param>
        /// <param name="inStatus2">The second <see cref="BlockStatus"/> to compare.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(BlockStatus inStatus1, BlockStatus inStatus2)
            => inStatus1?.Equals(inStatus2) ?? inStatus2?.Equals(inStatus1) ?? true;

        /// <summary>
        /// Determines whether a specified instance of <see cref="BlockStatus"/> is not equal to another specified instance of <see cref="BlockStatus"/>.
        /// </summary>
        /// <param name="inStatus1">The first <see cref="BlockStatus"/> to compare.</param>
        /// <param name="inStatus2">The second <see cref="BlockStatus"/> to compare.</param>
        /// <returns><c>true</c> if they are NOT equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(BlockStatus inStatus1, BlockStatus inStatus2)
            => !(inStatus1 == inStatus2);
        #endregion

        #region ITypeConverter Implementation
        /// <summary>Allows the converter to construct itself statically.</summary>
        internal static BlockStatus ConverterFactory { get; } = Default;

        /// <summary>
        /// Converts the given <see cref="object"/> to a <see cref="string"/> for serialization.
        /// </summary>
        /// <param name="inValue">The instance to convert.</param>
        /// <param name="inRow">The current context and configuration.</param>
        /// <param name="inMemberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance serialized.</returns>
        public override string ConvertToString(object inValue, IWriterRow inRow, MemberMapData inMemberMapData)
            => inValue is BlockStatus status
                ? $"{status.Toughness}{Delimiters.InternalDelimiter}" +
                  $"{status.MaxToughness}"
                : Logger.DefaultWithConvertLog(inValue?.ToString() ?? "null", nameof(BlockStatus), nameof(Default));

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

            var parameterText = inText.Split(Delimiters.InternalDelimiter);

            var parsedToughness = int.TryParse(parameterText[0], All.SerializedNumberStyle,
                                               CultureInfo.InvariantCulture, out var temp0)
                ? temp0
                : Logger.DefaultWithParseLog(parameterText[0], nameof(Toughness), MaxToughness);
            var parsedMaxToughness = int.TryParse(parameterText[1], All.SerializedNumberStyle,
                                                  CultureInfo.InvariantCulture, out var temp1)
                ? temp1
                : Logger.DefaultWithParseLog(parameterText[1], nameof(MaxToughness), BlockModel.DefaultMaxToughness);

            return new BlockStatus(parsedToughness, parsedMaxToughness);
        }
        #endregion

        #region Utilities
        /// <summary>
        /// Returns a <see cref="string"/> that represents the current <see cref="BlockStatus"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override string ToString()
            => $"{nameof(Toughness)}: {Toughness}";

        /// <summary>
        /// Creates a new instance that is a deep copy of the current instance.
        /// </summary>
        /// <returns>A new instance with the same characteristics as the current instance.</returns>
        // TODO, all DeepClone methods in Parquet must be implementations of IDeepClonable and they should use
        // .DeepClone on their elements whenever applicable, as:
        //     => new BlockStatus(IsTrench, Toughness.DeepClone(), maxToughness);
        public BlockStatus DeepClone()
            => new BlockStatus(Toughness, MaxToughness);
        #endregion
    }
}
