using System;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace Parquet.Parquets
{
    /// <summary>
    /// Tracks the status of a <see cref="ParquetPack"/>.
    /// </summary>
    public sealed class ParquetPackStatus : ModelStatus<ParquetPack>
    {
        #region Class Defaults
        /// <summary>Provides a throwaway instance of the <see cref="ParquetPackStatus"/> class with default values.</summary>
        public static ParquetPackStatus Unused { get; } = new ParquetPackStatus();
        #endregion

        #region Status
        /// <summary>If the floor has been dug out.</summary>
        public bool IsTrench { get; set; }

        /// <summary>The <see cref="BlockModel"/>'s native toughness.</summary>
        private readonly int maxToughness;

        /// <summary>The <see cref="BlockModel"/>'s current toughness.</summary>
        private int backingToughness;

        /// <summary>
        /// The <see cref="BlockModel"/>'s current toughness, from <see cref="BlockModel.LowestPossibleToughness"/> to <see cref="BlockModel.MaxToughness"/>.
        /// </summary>
        public int Toughness
        {
            get => backingToughness;
            set => backingToughness = value.Normalize(BlockModel.LowestPossibleToughness, maxToughness);
        }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="ParquetPackStatus"/> class with default values.
        /// </summary>
        /// <remarks>
        /// Primarily useful in the context of serialization.
        /// </remarks>
        public ParquetPackStatus()
            : this(false, BlockModel.DefaultMaxToughness, BlockModel.DefaultMaxToughness) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ParquetPackStatus"/> class.
        /// </summary>
        /// <param name="inIsTrench">Whether or not the <see cref="FloorModel"/> associated with this status has been dug out.</param>
        /// <param name="inToughness">The toughness of the <see cref="BlockModel"/> associated with this status.</param>
        /// <param name="inMaxToughness">The native toughness of the <see cref="BlockModel"/> associated with this status.</param>
        public ParquetPackStatus(bool inIsTrench, int inToughness, int inMaxToughness = BlockModel.DefaultMaxToughness)
        {
            IsTrench = inIsTrench;
            Toughness = inToughness;
            maxToughness = inMaxToughness;
        }
        #endregion

        #region IEquatable Implementation
        /// <summary>
        /// Serves as a hash function for a <see cref="ParquetPackStatus"/>.
        /// </summary>
        /// <returns>
        /// A hash code for this instance that is suitable for use in hashing algorithms and data structures.
        /// </returns>
        public override int GetHashCode()
            => (IsTrench, Toughness, maxToughness).GetHashCode();

        /// <summary>
        /// Determines whether the specified <see cref="ParquetPackStatus"/> is equal to the current <see cref="ParquetPackStatus"/>.
        /// </summary>
        /// <param name="inStatus">The <see cref="ParquetPackStatus"/> to compare with the current.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public override bool Equals<T>(T inStatus)
            => inStatus is ParquetPackStatus packStatus
            && IsTrench == packStatus.IsTrench
            && Toughness == packStatus.Toughness
            && maxToughness == packStatus.maxToughness;

        /*
        /// <summary>
        /// Determines whether the specified <see cref="ModelStatus{ParquetPack}"/> is equal to the current <see cref="ModelStatus{ParquetPack}"/>.
        /// </summary>
        /// <param name="inStatus">The <see cref="ModelStatus{ParquetPack}"/> to compare with the current.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public override bool Equals(ModelStatus<ParquetPack> inStatus)
            => Equals((ParquetPackStatus)inStatus);
        */

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="ParquetPackStatus"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="ParquetPackStatus"/>.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
            => obj is ParquetPackStatus status
            && Equals(status);

        /// <summary>
        /// Determines whether a specified instance of <see cref="ParquetPackStatus"/> is equal to another specified instance of <see cref="ParquetPackStatus"/>.
        /// </summary>
        /// <param name="inStatus1">The first <see cref="ParquetPackStatus"/> to compare.</param>
        /// <param name="inStatus2">The second <see cref="ParquetPackStatus"/> to compare.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(ParquetPackStatus inStatus1, ParquetPackStatus inStatus2)
            => inStatus1?.Equals(inStatus2) ?? inStatus2?.Equals(inStatus1) ?? true;

        /// <summary>
        /// Determines whether a specified instance of <see cref="ParquetPackStatus"/> is not equal to another specified instance of <see cref="ParquetPack"/>.
        /// </summary>
        /// <param name="inStatus1">The first <see cref="ParquetPackStatus"/> to compare.</param>
        /// <param name="inStatus2">The second <see cref="ParquetPackStatus"/> to compare.</param>
        /// <returns><c>true</c> if they are NOT equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(ParquetPackStatus inStatus1, ParquetPackStatus inStatus2)
            => !(inStatus1 == inStatus2);
        #endregion

        #region ITypeConverter Implementation
        /// <summary>Allows the converter to construct itself statically.</summary>
        internal static ParquetPackStatus ConverterFactory { get; } = Unused;

        /// <summary>
        /// Converts the given <see cref="object"/> to a <see cref="string"/> for serialization.
        /// </summary>
        /// <param name="inValue">The instance to convert.</param>
        /// <param name="inRow">The current context and configuration.</param>
        /// <param name="inMemberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance serialized.</returns>
        public override string ConvertToString(object inValue, IWriterRow inRow, MemberMapData inMemberMapData)
            => inValue is ParquetPackStatus status
                ? $"{status.IsTrench}{Delimiters.InternalDelimiter}" +
                  $"{status.Toughness}{Delimiters.InternalDelimiter}" +
                  $"{status.maxToughness}"
                : Logger.DefaultWithConvertLog(inValue?.ToString() ?? "null", nameof(ParquetPackStatus), nameof(Unused));

        /// <summary>
        /// Converts the given <see cref="string"/> to an <see cref="object"/> as deserialization.
        /// </summary>
        /// <param name="inText">The text to convert.</param>
        /// <param name="inRow">The current context and configuration.</param>
        /// <param name="inMemberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance deserialized.</returns>
        public override object ConvertFromString(string inText, IReaderRow inRow, MemberMapData inMemberMapData)
        {
            if (string.IsNullOrEmpty(inText))
            {
                return Logger.DefaultWithConvertLog(inText, nameof(ParquetPack), Unused);
            }

            var numberStyle = inMemberMapData?.TypeConverterOptions?.NumberStyles ?? All.SerializedNumberStyle;
            var parameterText = inText.Split(Delimiters.InternalDelimiter);

            var parsedIsTrench = bool.TryParse(parameterText[0], out var temp1)
                ? temp1
                : Logger.DefaultWithParseLog(parameterText[0], nameof(IsTrench), false);
            var parsedToughness = int.TryParse(parameterText[1], All.SerializedNumberStyle,
                                               CultureInfo.InvariantCulture, out var temp2)
                ? temp2
                : Logger.DefaultWithParseLog(parameterText[1], nameof(Toughness), maxToughness);
            var parsedMaxToughness = int.TryParse(parameterText[2], All.SerializedNumberStyle,
                                                  CultureInfo.InvariantCulture, out var temp3)
                ? temp3
                : Logger.DefaultWithParseLog(parameterText[2], nameof(maxToughness), BlockModel.DefaultMaxToughness);

            return new ParquetPackStatus(parsedIsTrench, parsedToughness, parsedMaxToughness);
        }
        #endregion

        #region Utilities
        /// <summary>
        /// Returns a <see cref="string"/> that represents the current <see cref="ParquetPackStatus"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override string ToString()
            => $"{Toughness} toughness, {(IsTrench ? "dug out" : "filled in")}";

        /// <summary>
        /// Creates a new instance with the same characteristics as the current instance.
        /// </summary>
        /// <returns></returns>
        public ParquetPackStatus Clone()
            => new ParquetPackStatus(IsTrench, Toughness, maxToughness);
        #endregion

    }
}
