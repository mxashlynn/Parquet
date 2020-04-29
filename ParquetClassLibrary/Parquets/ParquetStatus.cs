using System;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using ParquetClassLibrary.Properties;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Parquets
{
    /// <summary>
    /// Models the status of a stack of sandbox parquets.
    /// </summary>
    public class ParquetStatus : IEquatable<ParquetStatus>, ITypeConverter
    {
        #region Class Defaults
        /// <summary>Provides a throwaway instance of the <see cref="ParquetStatus"/> class with default values.</summary>
        public static ParquetStatus Unused { get; } = new ParquetStatus();
        #endregion

        #region Status
        /// <summary>If the floor has been dug out.</summary>
        public bool IsTrench { get; set; }

        /// <summary>The <see cref="BlockModel"/>'s native toughness.</summary>
        private readonly int maxToughness;

        /// <summary>The <see cref="BlockModel"/>'s current toughness.</summary>
        private int toughness;

        /// <summary>
        /// The <see cref="BlockModel"/>'s current toughness, from <see cref="BlockModel.LowestPossibleToughness"/> to <see cref="BlockModel.MaxToughness"/>.
        /// </summary>
        public int Toughness
        {
            get => toughness;
            set => toughness = value.Normalize(BlockModel.LowestPossibleToughness, maxToughness);
        }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="ParquetStatus"/> class with default values.
        /// </summary>
        /// <remarks>
        /// Primarily useful in the context of serialization.
        /// </remarks>
        public ParquetStatus()
            : this(false, BlockModel.DefaultMaxToughness, BlockModel.DefaultMaxToughness) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ParquetStatus"/> class.
        /// </summary>
        /// <param name="inIsTrench">Whether or not the <see cref="FloorModel"/> associated with this status has been dug out.</param>
        /// <param name="inToughness">The toughness of the <see cref="BlockModel"/> associated with this status.</param>
        /// <param name="inMaxToughness">The native toughness of the <see cref="BlockModel"/> associated with this status.</param>
        public ParquetStatus(bool inIsTrench = false, int inToughness = BlockModel.DefaultMaxToughness, int inMaxToughness = BlockModel.DefaultMaxToughness)
        {
            IsTrench = inIsTrench;
            Toughness = inToughness;
            maxToughness = inMaxToughness;
        }
        #endregion

        #region IEquatable Implementation
        /// <summary>
        /// Serves as a hash function for a <see cref="ParquetStatus"/>.
        /// </summary>
        /// <returns>
        /// A hash code for this instance that is suitable for use in hashing algorithms and data structures.
        /// </returns>
        public override int GetHashCode()
            => (IsTrench, Toughness, maxToughness).GetHashCode();

        /// <summary>
        /// Determines whether the specified <see cref="ParquetStatus"/> is equal to the current <see cref="ParquetStatus"/>.
        /// </summary>
        /// <param name="inStatus">The <see cref="ParquetStatus"/> to compare with the current.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public bool Equals(ParquetStatus inStatus)
            => IsTrench == inStatus?.IsTrench
            && Toughness == inStatus.Toughness
            && maxToughness == inStatus.maxToughness;

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="ParquetStatus"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="ParquetStatus"/>.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
            => obj is ParquetStatus status
            && Equals(status);

        /// <summary>
        /// Determines whether a specified instance of <see cref="ParquetStatus"/> is equal to another specified instance of <see cref="ParquetStatus"/>.
        /// </summary>
        /// <param name="inStatus1">The first <see cref="ParquetStatus"/> to compare.</param>
        /// <param name="inStatus2">The second <see cref="ParquetStatus"/> to compare.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(ParquetStatus inStatus1, ParquetStatus inStatus2)
            => inStatus1?.Equals(inStatus2) ?? inStatus2?.Equals(inStatus1) ?? true;

        /// <summary>
        /// Determines whether a specified instance of <see cref="ParquetStatus"/> is not equal to another specified instance of <see cref="ParquetStack"/>.
        /// </summary>
        /// <param name="inStatus1">The first <see cref="ParquetStatus"/> to compare.</param>
        /// <param name="inStatus2">The second <see cref="ParquetStatus"/> to compare.</param>
        /// <returns><c>true</c> if they are NOT equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(ParquetStatus inStatus1, ParquetStatus inStatus2)
            => !(inStatus1 == inStatus2);
        #endregion

        #region ITypeConverter Implementation
        /// <summary>Allows the converter to construct itself statically.</summary>
        internal static ParquetStatus ConverterFactory { get; } = Unused;

        /// <summary>
        /// Converts the given <see cref="object"/> to a <see cref="string"/> for serialization.
        /// </summary>
        /// <param name="inValue">The instance to convert.</param>
        /// <param name="inRow">The current context and configuration.</param>
        /// <param name="inMemberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance serialized.</returns>
        public string ConvertToString(object inValue, IWriterRow inRow, MemberMapData inMemberMapData)
            => inValue is ParquetStatus status
            && null != status
                ? $"{status.IsTrench}{Rules.Delimiters.InternalDelimiter}" +
                  $"{status.Toughness}{Rules.Delimiters.InternalDelimiter}" +
                  $"{status.maxToughness}"
            : throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.ErrorCannotConvert,
                                                        inValue, nameof(ParquetStatus)));

        /// <summary>
        /// Converts the given <see cref="string"/> to an <see cref="object"/> as deserialization.
        /// </summary>
        /// <param name="inText">The text to convert.</param>
        /// <param name="inRow">The current context and configuration.</param>
        /// <param name="inMemberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance deserialized.</returns>
        public object ConvertFromString(string inText, IReaderRow inRow, MemberMapData inMemberMapData)
        {
            if (string.IsNullOrEmpty(inText))
            {
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.ErrorCannotConvert,
                                                          inText, nameof(ParquetStatus)));
            }

            try
            {
                var numberStyle = inMemberMapData?.TypeConverterOptions?.NumberStyle ?? All.SerializedNumberStyle;
                var parameterText = inText.Split(Rules.Delimiters.InternalDelimiter);

                var isTrench = bool.Parse(parameterText[0]);
                var toughness = int.Parse(parameterText[1], numberStyle, CultureInfo.InvariantCulture);
                var maxToughness = int.Parse(parameterText[2], numberStyle, CultureInfo.InvariantCulture);

                return new ParquetStatus(isTrench, toughness, maxToughness);
            }
            catch (Exception e)
            {
                throw new FormatException(string.Format(CultureInfo.CurrentCulture, Resources.ErrorCannotParse,
                                                        inText, nameof(ParquetStatus)), e);
            }
        }
        #endregion

        #region Utilities
        /// <summary>
        /// Returns a <see cref="string"/> that represents the current <see cref="ParquetStatus"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override string ToString()
            => $"{Toughness} toughness, {(IsTrench ? "dug out" : "filled in")}";

        /// <summary>
        /// Creates a new instance with the same characteristics as the current instance.
        /// </summary>
        /// <returns></returns>
        public ParquetStatus Clone()
            => new ParquetStatus(IsTrench, Toughness, maxToughness);
        #endregion
    }

    /// <summary>
    /// Provides extension methods useful when dealing with 2D arrays of <see cref="ParquetStack"/>s.
    /// </summary>
    public static class ParquetStatusArrayExtensions
    {
        /// <summary>
        /// Determines if the given position corresponds to a point within the current array.
        /// </summary>
        /// <param name="inSubregion">The <see cref="ParquetStatus"/> array to validate against.</param>
        /// <param name="inPosition">The position to validate.</param>
        /// <returns><c>true</c>, if the position is valid, <c>false</c> otherwise.</returns>
        public static bool IsValidPosition(this ParquetStatus[,] inSubregion, Vector2D inPosition)
        {
            Precondition.IsNotNull(inSubregion, nameof(inSubregion));

            return inPosition.X > -1
                && inPosition.Y > -1
                && inPosition.X < inSubregion.GetLength(1)
                && inPosition.Y < inSubregion.GetLength(0);
        }
    }
}
