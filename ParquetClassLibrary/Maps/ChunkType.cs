using System;
using CsvHelper.TypeConversion;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Maps
{
    /// <summary>
    /// Indicates which parquets constitute this <see cref="MapChunk"/> and how they are arranged.
    /// </summary>
    /// <remarks>
    /// Every chunk is either handmade or procedurally generated.<para />
    ///<para />
    /// Chunks that are not hand made are instead composed of two layers: a base and a modifier.
    /// The base is the underlying structure of the chunk and the modifier overlays it to
    /// produce more complex arrangements than would otherwise be possible.  For example:
    /// <list type="bullet">
    /// <item><term>Forest</term>
    /// <description>Base:Grassy Solid, Modifier:Scattered Trees</description></item>
    /// <item><term>Seaside</term>
    /// <description>Base:Watery Solid, Modifier:Eastern Sandy</description></item>
    /// <item><term>Town</term>
    /// <description>Handmade</description></item>
    /// </list>
    /// </remarks>
    public readonly struct ChunkType : IEquatable<ChunkType>, ITypeConverter
    {
        /// <summary>The null <see cref="ChunkType"/>, which generates an empty <see cref="MapChunk"/>.</summary>
        public static readonly ChunkType Empty = new ChunkType();

        /// <summary>If <c>true</c>, the <see cref="MapChunk"/> is created at design time instead of procedurally generated.</summary>
        public bool Handmade { get; }

        /// <summary>Indicates the basic form that the <see cref="MapChunk"/> of parquets takes.</summary>
        public ChunkTopography BaseTopography { get; }

        /// <summary>Indicates the overall type of parquets in the <see cref="MapChunk"/>.</summary>
        public EntityTag BaseComposition { get; }

        /// <summary>Indicates a modifier on the <see cref="MapChunk"/> of parquets.</summary>
        public ChunkTopography ModifierTopography { get; }

        /// <summary>Indicates the type of parquets modifying the <see cref="MapChunk"/>.</summary>
        public EntityTag ModifierConstituents { get; }

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="ChunkType"/> class.
        /// </summary>
        /// <param name="inBaseTopography">The basic form that the <see cref="MapChunk"/> of parquets takes.</param>
        /// <param name="inBaseComposition">Indicates the overall type of parquets in the <see cref="MapChunk"/>.</param>
        /// <param name="inModifierTopography">Indicates a modifier on the <see cref="MapChunk"/> of parquets.</param>
        /// <param name="inModifierComposition">Indicates the type of parquets modifying the <see cref="MapChunk"/>.</param>
        public ChunkType(ChunkTopography? inBaseTopography, EntityTag inBaseComposition,
                         ChunkTopography? inModifierTopography, EntityTag inModifierComposition)
        {
            Handmade = false;
            BaseTopography = inBaseTopography ?? ChunkTopography.Empty;
            BaseComposition = inBaseComposition ?? EntityTag.None;
            ModifierTopography = inModifierTopography ?? ChunkTopography.Empty;
            ModifierConstituents = inModifierComposition ?? EntityTag.None;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChunkType"/> class.
        /// </summary>
        /// <param name="inIsHandmade">If <c>true</c>, the <see cref="MapChunk"/> is created at design time instead of procedurally generated.</param>
        public ChunkType(bool inIsHandmade)
        {
            Handmade = inIsHandmade;
            BaseTopography = ChunkTopography.Empty;
            BaseComposition = EntityTag.None;
            ModifierTopography = ChunkTopography.Empty;
            ModifierConstituents = EntityTag.None;
        }
        #endregion

        #region IEquatable Implementation
        /// <summary>
        /// Serves as a hash function for a <see cref="ChunkType"/> struct.
        /// </summary>
        /// <returns>A hash code for this instance that is suitable for use in hashing algorithms and data structures.</returns>
        public override int GetHashCode()
            => (BaseTopography, BaseComposition, ModifierTopography, ModifierConstituents).GetHashCode();

        /// <summary>
        /// Determines whether the specified <see cref="ChunkType"/> is equal to the current <see cref="ChunkType"/>.
        /// </summary>
        /// <param name="inChunkType">The <see cref="ChunkType"/> to compare with the current.</param>
        /// <returns><c>true</c> if the <see cref="ChunkType"/>s are equal.</returns>
        public bool Equals(ChunkType inChunkType)
            => BaseTopography == inChunkType.BaseTopography
            && BaseComposition == inChunkType.BaseComposition
            && ModifierTopography == inChunkType.ModifierTopography
            && ModifierConstituents == inChunkType.ModifierConstituents;

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="ChunkType"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="ChunkType"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="object"/> is equal to the current <see cref="ChunkType"/>; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
            => obj is ChunkType chunkType && Equals(chunkType);

        /// <summary>
        /// Determines whether a specified instance of <see cref="ChunkType"/> is equal to
        /// another specified instance of <see cref="ChunkType"/>.
        /// </summary>
        /// <param name="inChunkType1">The first <see cref="ChunkType"/> to compare.</param>
        /// <param name="inChunkType2">The second <see cref="ChunkType"/> to compare.</param>
        /// <returns><c>true</c> if the two <see cref="ChunkType"/>s are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(ChunkType inChunkType1, ChunkType inChunkType2)
            => inChunkType1.Equals(inChunkType2.BaseTopography);

        /// <summary>
        /// Determines whether a specified instance of <see cref="ChunkType"/> is unequal to
        /// another specified instance of <see cref="ChunkType"/>.
        /// </summary>
        /// <param name="inChunkType1">The first <see cref="ChunkType"/> to compare.</param>
        /// <param name="inChunkType2">The second <see cref="ChunkType"/> to compare.</param>
        /// <returns><c>true</c> if the two <see cref="ChunkType"/>s are NOT equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(ChunkType inChunkType1, ChunkType inChunkType2)
            => !inChunkType1.Equals(inChunkType2.BaseTopography);
        #endregion

        #region ITypeConverter Implementation
        /// <summary>Allows the converter to construct itself without exposing a public parameterless constructor.</summary>
        internal static readonly ChunkType ConverterFactory =
            new NotImplementedException();

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
        /// Returns a <see langword="string"/> that represents the current <see cref="MapSpace"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override string ToString()
            => $"[{BaseTopography}{BaseComposition} % {ModifierTopography}{ModifierConstituents}";
        #endregion
    }

    /// <summary>
    /// Convenience extension methods for concise coding when working with <see cref="ChunkType"/> instances.
    /// </summary>
    internal static class ChunkTypeExtensions
    {
        /// <summary>
        /// Determines if the given position corresponds to a point within the current array.
        /// </summary>
        /// <param name="inPosition">The position to validate.</param>
        /// <returns><c>true</c>, if the position is valid, <c>false</c> otherwise.</returns>
        public static bool IsValidPosition(this ChunkType[,] inChunkTypeArray, Vector2D inPosition)
        {
            Precondition.IsNotNull(inChunkTypeArray, nameof(inChunkTypeArray));

            return inPosition.X > -1
                && inPosition.Y > -1
                && inPosition.X < inChunkTypeArray.GetLength(1)
                && inPosition.Y < inChunkTypeArray.GetLength(0);
        }
    }
}
