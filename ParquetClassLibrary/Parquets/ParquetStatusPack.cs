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
            => new(FloorStatus.Default, BlockStatus.Default);
        #endregion

        #region Characteristics
        /// <summary>The <see cref="FloorStatus"/> contained in this <see cref="ParquetStatusPack"/>.</summary>
        public FloorStatus CurrentFloorStatus { get; set; }

        /// <summary>The <see cref="BlockStatus"/> contained in this <see cref="ParquetStatusPack"/>.</summary>
        public BlockStatus CurrentBlockStatus { get; set; }

        /// <summary>The <see cref="FurnishingStatus"/> contained in this <see cref="ParquetStatusPack"/>.</summary>
        public FurnishingStatus CurrentFurnishingStatus { get; set; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new default instance of the <see cref="ParquetStatusPack"/> class.
        /// </summary>
        /// <remarks>This is primarily useful for serialization.</remarks>
        public ParquetStatusPack()
            : this(FloorStatus.Default, BlockStatus.Default, FurnishingStatus.Default)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ParquetStatusPack"/> class.
        /// </summary>
        /// <param name="floorStatus">The status of the tracked floor-layer parquet.</param>
        /// <param name="blockStatus">The status of the tracked block-layer parquet.</param>
        /// <param name="furnishingStatus">The status of the tracked furnishing-layer parquet.</param>
        public ParquetStatusPack(FloorStatus floorStatus = null, BlockStatus blockStatus = null, FurnishingStatus furnishingStatus = null)
        {
            CurrentFloorStatus = floorStatus ?? FloorStatus.Default;
            CurrentBlockStatus = blockStatus ?? BlockStatus.Default;
            CurrentFurnishingStatus = furnishingStatus ?? FurnishingStatus.Default;
        }

        /// <summary>
        /// Initializes an instance of the <see cref="ParquetStatusPack"/> class
        /// based on a given <see cref="ParquetModelPack"/> instance.
        /// </summary>
        /// <param name="parquetModelPack">The definitions being tracked.</param>
        public ParquetStatusPack(ParquetModelPack parquetModelPack)
        {
            Precondition.IsNotNull(parquetModelPack);
            var nonNullParquetModelPack = parquetModelPack ?? ParquetModelPack.Empty;

            CurrentFloorStatus = nonNullParquetModelPack.FloorID != ModelID.None
                ? new FloorStatus(nonNullParquetModelPack.FloorID)
                : null;
            CurrentBlockStatus = nonNullParquetModelPack.BlockID != ModelID.None
                ? new BlockStatus(nonNullParquetModelPack.BlockID)
                : null;
            CurrentFurnishingStatus = nonNullParquetModelPack.FurnishingID != ModelID.None
                ? new FurnishingStatus(nonNullParquetModelPack.FurnishingID)
                : null;
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
            => (CurrentFloorStatus, CurrentBlockStatus, CurrentFurnishingStatus).GetHashCode();

        /// <summary>
        /// Determines whether the specified <see cref="ParquetStatusPack"/> is equal to the current <see cref="ParquetStatusPack"/>.
        /// </summary>
        /// <param name="pack">The <see cref="ParquetStatusPack"/> to compare with the current.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public override bool Equals<T>(T pack)
            => pack is ParquetStatusPack statusPack
            && CurrentFloorStatus == statusPack.CurrentFloorStatus
            && CurrentBlockStatus == statusPack.CurrentBlockStatus
            && CurrentFurnishingStatus == statusPack.CurrentFurnishingStatus;

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
        /// <param name="pack1">The first <see cref="ParquetStatusPack"/> to compare.</param>
        /// <param name="pack2">The second <see cref="ParquetStatusPack"/> to compare.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(ParquetStatusPack pack1, ParquetStatusPack pack2)
            => pack1?.Equals(pack2) ?? pack2?.Equals(pack1) ?? true;

        /// <summary>
        /// Determines whether a specified instance of <see cref="ParquetStatusPack"/> is not equal to another specified instance of <see cref="ParquetStatusPack"/>.
        /// </summary>
        /// <param name="pack1">The first <see cref="ParquetStatusPack"/> to compare.</param>
        /// <param name="pack2">The second <see cref="ParquetStatusPack"/> to compare.</param>
        /// <returns><c>true</c> if they are NOT equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(ParquetStatusPack pack1, ParquetStatusPack pack2)
            => !(pack1 == pack2);
        #endregion

        #region ITypeConverter Implementation
        /// <summary>Allows the converter to construct itself statically.</summary>
        internal static ParquetStatusPack ConverterFactory { get; } = Default;

        /// <summary>
        /// Converts the given <see cref="object"/> to a <see cref="string"/> for serialization.
        /// </summary>
        /// <param name="value">The instance to convert.</param>
        /// <param name="row">The current context and configuration.</param>
        /// <param name="memberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance serialized.</returns>
        public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
            => value is ParquetStatusPack pack
                ? $"{pack.CurrentFloorStatus.ConvertToString(pack.CurrentFloorStatus, row, memberMapData)}{Delimiters.PackDelimiter}" +
                  $"{pack.CurrentBlockStatus.ConvertToString(pack.CurrentFloorStatus, row, memberMapData)}{Delimiters.PackDelimiter}" +
                  $"{pack.CurrentFurnishingStatus.ConvertToString(pack.CurrentBlockStatus, row, memberMapData)}"
                : Logger.DefaultWithConvertLog(value?.ToString() ?? "null", nameof(ParquetStatusPack), nameof(Default));

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
                || string.Compare(nameof(Default), text, StringComparison.OrdinalIgnoreCase) == 0)
            {
                return Default;
            }

            var parameterText = text.Split(Delimiters.PackDelimiter);

            var parsedFloorStatus = (FloorStatus)FloorStatus.ConverterFactory.ConvertFromString(parameterText[0], row, memberMapData);
            var parsedBlockStatus = (BlockStatus)BlockStatus.ConverterFactory.ConvertFromString(parameterText[1], row, memberMapData);
            var parsedFurnishingtatus = (FurnishingStatus)FurnishingStatus.ConverterFactory.ConvertFromString(parameterText[2], row, memberMapData);

            return new ParquetStatusPack(parsedFloorStatus, parsedBlockStatus, parsedFurnishingtatus);
        }
        #endregion

        #region IDeeplyCloneable Implementation
        /// <summary>
        /// Creates a new instance that is a deep copy of the current instance.
        /// </summary>
        /// <returns>A new instance with the same status as the current instance.</returns>
        public override ParquetStatusPack DeepClone()
            => new((FloorStatus)CurrentFloorStatus.DeepClone(),
                   (BlockStatus)CurrentBlockStatus.DeepClone(),
                   (FurnishingStatus)CurrentFurnishingStatus.DeepClone());

        /// <summary>
        /// Creates a new instance that is a deep copy of the current instance.
        /// </summary>
        /// <returns>A new instance with the same status as the current instance.</returns>
        public override T DeepClone<T>()
            => DeepClone() as T;
        #endregion

        #region Utilities
        /// <summary>
        /// Returns a <see cref="string"/> that represents the current <see cref="ParquetStatusPack"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override string ToString()
            => $"[{CurrentFloorStatus} {CurrentBlockStatus} {CurrentFurnishingStatus}]";
        #endregion
    }
}
