using CsvHelper.TypeConversion;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Parquets
{
    /// <summary>
    /// Models the status of a stack of sandbox parquets.
    /// </summary>
    public class ParquetStatus : ITypeConverter
    {
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

        /// <summary>If the floor has been dug out.</summary>
        public bool IsTrench { get; set; }

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="ParquetStatus"/> class.
        /// </summary>
        /// <param name="inIsTrench">Whether or not the <see cref="FloorModel"/> associated with this status has been dug out.</param>
        /// <param name="inToughness">The toughness of the <see cref="BlockModel"/> associated with this status.</param>
        /// <param name="inMaxToughness">The native toughness of the <see cref="BlockModel"/> associated with this status.</param>
        public ParquetStatus(bool inIsTrench = false, int? inToughness = null, int inMaxToughness = BlockModel.DefaultMaxToughness)
        {
            IsTrench = inIsTrench;
            Toughness = inToughness ?? inMaxToughness;
            maxToughness = inMaxToughness;
        }
        #endregion

        #region ITypeConverter Implementation
        /// <summary>Allows the converter to construct itself without exposing a public parameterless constructor.</summary>
        internal static readonly ParquetStatus ConverterFactory =
            new System.NotImplementedException();

        /// <summary>
        /// Converts the given <see cref="object"/> to a <see cref="string"/> for serialization.
        /// </summary>
        /// <param name="value">The instance to convert.</param>
        /// <param name="row">The current context and configuration.</param>
        /// <param name="memberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance serialized.</returns>
        public string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
        {
        }

        /// <summary>
        /// Converts the given <see cref="string"/> to an <see cref="object"/> as deserialization.
        /// </summary>
        /// <param name="text">The text to convert.</param>
        /// <param name="row">The current context and configuration.</param>
        /// <param name="memberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance deserialized.</returns>
        public object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
        }
        #endregion

        #region Utilities
        /// <summary>
        /// Returns a <see langword="string"/> that represents the current <see cref="ParquetStatus"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override string ToString()
            => $"{Toughness} toughness, {(IsTrench ? "dug out" : "filled in")}";
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
