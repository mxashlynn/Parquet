using System;
using CsvHelper;
using CsvHelper.Configuration;

namespace Parquet.Parquets
{
    /// <summary>
    /// Simple container for collocated stateful <see cref="ParquetStatus{ParquetModel}"/>s.
    /// Instances of this class are mutable during play.
    /// </summary>
    public sealed class ParquetStatusPack : Pack<ParquetStatus<ParquetModel>>
    {
        #region Class Defaults
        /// <summary>Canonical null <see cref="ParquetStatusPack"/>, representing an arbitrary standard pack.</summary>
        public static ParquetStatusPack Default
            => new ParquetStatusPack(FloorStatus.Default, BlockStatus.Default);
        #endregion

        #region Characteristics
        /// <summary>The <see cref="FloorStatus"/> contained in this <see cref="ParquetStatusPack"/>.</summary>
        public FloorStatus CurrentFloorStatus { get; set; }

        /// <summary>The <see cref="BlockStatus"/> contained in this <see cref="ParquetStatusPack"/>.</summary>
        public BlockStatus CurrentBlockStatus { get; set; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new default instance of the <see cref="ParquetStatusPack"/> class.
        /// </summary>
        /// <remarks>This is primarily useful for serialization.</remarks>
        public ParquetStatusPack() :
            this(FloorStatus.Default, BlockStatus.Default)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ParquetStatusPack"/> class.
        /// </summary>
        /// <param name="inFloorStatus">The status of the tracked floor-layer parquet.</param>
        /// <param name="inBlockStatus">The status of the tracked block-layer parquet.</param>
        public ParquetStatusPack(FloorStatus inFloorStatus = null, BlockStatus inBlockStatus = null)
        {
            CurrentFloorStatus = inFloorStatus ?? FloorStatus.Default;
            CurrentBlockStatus = inBlockStatus ?? BlockStatus.Default;
        }

        /// <summary>
        /// Initializes an instance of the <see cref="ParquetStatusPack"/> class
        /// based on a given <see cref="ParquetModelPack"/> instance.
        /// </summary>
        /// <param name="inParquetModelPack">The definitions being tracked.</param>
        public ParquetStatusPack(ParquetModelPack inParquetModelPack)
        {
            Precondition.IsNotNull(inParquetModelPack);
            var nonNullParquetModelPack = inParquetModelPack is null
                ? ParquetModelPack.Empty
                : inParquetModelPack;

            CurrentFloorStatus = new FloorStatus(nonNullParquetModelPack.FloorID);
            CurrentBlockStatus = new BlockStatus(nonNullParquetModelPack.BlockID);
        }
        #endregion

        #region IEquatable Implementation
        /// <summary>
        /// Serves as a hash function for a <see cref="ParquetStatusPack"/>.
        /// </summary>
        /// <returns>
        /// A hash code for this instance that is suitable for use in hashing algorithms and data structures.
        /// </returns>
        public override int GetHashCode()
            => (CurrentFloorStatus, CurrentBlockStatus).GetHashCode();

        /// <summary>
        /// Determines whether the specified <see cref="ParquetStatusPack"/> is equal to the current <see cref="ParquetStatusPack"/>.
        /// </summary>
        /// <param name="inStack">The <see cref="ParquetStatusPack"/> to compare with the current.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public override bool Equals<T>(T inPack)
            => inPack is ParquetStatusPack pack
            && CurrentFloorStatus == pack.CurrentFloorStatus
            && CurrentBlockStatus == pack.CurrentBlockStatus;

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="ParquetStatusPack"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="ParquetStatusPack"/>.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
            => obj is ParquetStatusPack pack
            && Equals(pack);

        /// <summary>
        /// Determines whether a specified instance of <see cref="ParquetStatusPack"/> is equal to another specified instance of <see cref="ParquetStatusPack"/>.
        /// </summary>
        /// <param name="inPack1">The first <see cref="ParquetStatusPack"/> to compare.</param>
        /// <param name="inPack2">The second <see cref="ParquetStatusPack"/> to compare.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(ParquetStatusPack inPack1, ParquetStatusPack inPack2)
            => inPack1?.Equals(inPack2) ?? inPack2?.Equals(inPack1) ?? true;

        /// <summary>
        /// Determines whether a specified instance of <see cref="ParquetStatusPack"/> is not equal to another specified instance of <see cref="ParquetStatusPack"/>.
        /// </summary>
        /// <param name="inPack1">The first <see cref="ParquetStatusPack"/> to compare.</param>
        /// <param name="inPack2">The second <see cref="ParquetStatusPack"/> to compare.</param>
        /// <returns><c>true</c> if they are NOT equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(ParquetStatusPack inPack1, ParquetStatusPack inPack2)
            => !(inPack1 == inPack2);
        #endregion

        #region ITypeConverter Implementation
        /// <summary>Allows the converter to construct itself statically.</summary>
        internal static ParquetStatusPack ConverterFactory { get; } = Default;

        /// <summary>
        /// Converts the given <see cref="object"/> to a <see cref="string"/> for serialization.
        /// </summary>
        /// <param name="inValue">The instance to convert.</param>
        /// <param name="inRow">The current context and configuration.</param>
        /// <param name="inMemberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance serialized.</returns>
        public override string ConvertToString(object inValue, IWriterRow inRow, MemberMapData inMemberMapData)
            => inValue is ParquetStatusPack pack
                ? $"{pack.CurrentFloorStatus.ConvertToString(pack.CurrentFloorStatus, inRow, inMemberMapData)}{Delimiters.PackDelimiter}" +
                  $"{pack.CurrentBlockStatus.ConvertToString(pack.CurrentBlockStatus, inRow, inMemberMapData)}"
                : Logger.DefaultWithConvertLog(inValue?.ToString() ?? "null", nameof(ParquetStatusPack), nameof(Default));

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
                return Default;
            }

            var parameterText = inText.Split(Delimiters.PackDelimiter);

            var parsedFloorStatus = (FloorStatus)FloorStatus.ConverterFactory.ConvertFromString(parameterText[0], inRow, inMemberMapData);
            var parsedBlockStatus = (BlockStatus)BlockStatus.ConverterFactory.ConvertFromString(parameterText[1], inRow, inMemberMapData);

            return new ParquetStatusPack(parsedFloorStatus, parsedBlockStatus);
        }
        #endregion

        #region IDeeplyCloneable Implementation
        /// <summary>
        /// Creates a new instance that is a deep copy of the current instance.
        /// </summary>
        /// <returns>A new instance with the same characteristics as the current instance.</returns>
        public override ParquetStatusPack DeepClone()
            => new ParquetStatusPack((FloorStatus)CurrentFloorStatus.DeepClone(),
                                     (BlockStatus)CurrentBlockStatus.DeepClone());

        /// <summary>
        /// Creates a new instance that is a deep copy of the current instance.
        /// </summary>
        /// <returns>A new instance with the same characteristics as the current instance.</returns>
        public override T DeepClone<T>()
            => DeepClone() as T;
        #endregion

        #region Utilities
        /// <summary>
        /// Returns a <see cref="string"/> that represents the current <see cref="ParquetStatusPack"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override string ToString()
            => $"[{CurrentFloorStatus} {CurrentBlockStatus}]";
        #endregion
    }
}
