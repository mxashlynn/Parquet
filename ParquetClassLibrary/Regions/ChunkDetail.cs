using System;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace Parquet.Regions
{
    /// <summary>
    /// Indicates which parquets constitute this <see cref="MapChunk"/> and how they are arranged.
    /// Instances of this class are mutable during play.
    /// </summary>
    /// <remarks>
    /// Every chunk is either handmade at design time or procedurally generated during play.
    /// A chunk that is not handmade may have already been procedurally generated; if so, it
    /// is termed "filled out".  If not, it will become filled out once it undergoes generation.
    /// Handmade chunks are always filled out.
    /// <para />
    /// Chunks that are not filled out are instead composed of two layers: a base and a modifier.
    /// The base is the underlying structure of the chunk and the modifier overlays it to
    /// produce more complex arrangements than would otherwise be possible.
    /// <para />
    /// For example:<br />
    /// - Forest:  Base·Grassy Solid · Modifier·Scattered Trees<br />
    /// - Seaside: Base·Watery Solid · Modifier·Eastern Sandy<br />
    /// - Town:    Handmade<br />
    /// </remarks>
    public sealed class ChunkDetail : IEquatable<ChunkDetail>, ITypeConverter, IDeeplyCloneable<ChunkDetail>
    {
        #region Class Defaults
        /// <summary>The null <see cref="ChunkDetail"/>, which generates an empty <see cref="MapChunk"/>.</summary>
        public static readonly ChunkDetail None = new();
        #endregion

        #region Characteristics
        /// <summary>Indicates the basic form that the <see cref="MapChunk"/> of parquets takes.</summary>
        public ChunkTopography BaseTopography { get; }

        /// <summary>Indicates the overall type of parquets in the <see cref="MapChunk"/>.</summary>
        public ModelTag BaseComposition { get; }

        /// <summary>Indicates a modifier on the <see cref="MapChunk"/> of parquets.</summary>
        public ChunkTopography ModifierTopography { get; }

        /// <summary>Indicates the type of parquets modifying the <see cref="MapChunk"/>.</summary>
        public ModelTag ModifierComposition { get; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new default instance of the <see cref="ChunkDetail"/> class for use with serialization.
        /// </summary>
        public ChunkDetail()
        {
            BaseTopography = ChunkTopography.Empty;
            BaseComposition = ModelTag.None;
            ModifierTopography = ChunkTopography.Empty;
            ModifierComposition = ModelTag.None;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChunkDetail"/> class.
        /// </summary>
        /// <param name="baseTopography">The basic form that the <see cref="MapChunk"/> of parquets takes.</param>
        /// <param name="baseComposition">Indicates the overall type of parquets in the <see cref="MapChunk"/>.</param>
        /// <param name="modifierTopography">Indicates a modifier on the <see cref="MapChunk"/> of parquets.</param>
        /// <param name="modifierComposition">Indicates the type of parquets modifying the <see cref="MapChunk"/>.</param>
        public ChunkDetail(ChunkTopography baseTopography, ModelTag baseComposition,
                                ChunkTopography modifierTopography, ModelTag modifierComposition)
        {
            BaseTopography = baseTopography;
            BaseComposition = baseComposition ?? ModelTag.None;
            ModifierTopography = modifierTopography;
            ModifierComposition = modifierComposition ?? ModelTag.None;
        }
        #endregion

        #region IEquatable Implementation
        /// <summary>
        /// Serves as a hash function for a <see cref="ChunkDetail"/> class.
        /// </summary>
        /// <returns>A hash code for this instance that is suitable for use in hashing algorithms and data structures.</returns>
        public override int GetHashCode()
            => (BaseTopography, BaseComposition, ModifierTopography, ModifierComposition).GetHashCode();

        /// <summary>
        /// Determines whether the specified <see cref="ChunkDetail"/> is equal to the current <see cref="ChunkDetail"/>.
        /// </summary>
        /// <param name="other">The <see cref="ChunkDetail"/> to compare with the current.</param>
        /// <returns><c>true</c> if the <see cref="ChunkDetail"/>s are equal.</returns>
        public bool Equals(ChunkDetail other)
            => BaseTopography == other?.BaseTopography
            && BaseComposition == other.BaseComposition
            && ModifierTopography == other.ModifierTopography
            && ModifierComposition == other.ModifierComposition;

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="ChunkDetail"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="ChunkDetail"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="object"/> is equal to the current <see cref="ChunkDetail"/>; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
            => obj is ChunkDetail chunkType
            && Equals(chunkType);

        /// <summary>
        /// Determines whether a specified instance of <see cref="ChunkDetail"/> is equal to
        /// another specified instance of <see cref="ChunkDetail"/>.
        /// </summary>
        /// <param name="chunkType1">The first <see cref="ChunkDetail"/> to compare.</param>
        /// <param name="chunkType2">The second <see cref="ChunkDetail"/> to compare.</param>
        /// <returns><c>true</c> if the two <see cref="ChunkDetail"/>s are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(ChunkDetail chunkType1, ChunkDetail chunkType2)
            => chunkType1?.Equals(chunkType2) ?? chunkType2?.Equals(chunkType1) ?? true;

        /// <summary>
        /// Determines whether a specified instance of <see cref="ChunkDetail"/> is unequal to
        /// another specified instance of <see cref="ChunkDetail"/>.
        /// </summary>
        /// <param name="chunkType1">The first <see cref="ChunkDetail"/> to compare.</param>
        /// <param name="chunkType2">The second <see cref="ChunkDetail"/> to compare.</param>
        /// <returns><c>true</c> if the two <see cref="ChunkDetail"/>s are NOT equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(ChunkDetail chunkType1, ChunkDetail chunkType2)
            => !(chunkType1 == chunkType2);
        #endregion

        #region ITypeConverter Implementation
        /// <summary>Allows the converter to construct itself statically.</summary>
        internal static ChunkDetail ConverterFactory { get; } = None;

        /// <summary>
        /// Converts the given <see cref="object"/> to a <see cref="string"/> for serialization.
        /// </summary>
        /// <param name="value">The instance to convert.</param>
        /// <param name="row">The current context and configuration.</param>
        /// <param name="memberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance serialized.</returns>
        public string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
            => value is ChunkDetail chunk
                ? chunk == None
                    ? nameof(None)
                    : $"{chunk.BaseTopography}{Delimiters.InternalDelimiter}" +
                      $"{chunk.BaseComposition}{Delimiters.InternalDelimiter}" +
                      $"{chunk.ModifierTopography}{Delimiters.InternalDelimiter}" +
                      $"{chunk.ModifierComposition}"
                : Logger.DefaultWithConvertLog(value?.ToString() ?? "null", nameof(ChunkDetail), nameof(None));

        /// <summary>
        /// Converts the given <see cref="string"/> to an <see cref="object"/> as deserialization.
        /// </summary>
        /// <param name="text">The text to convert.</param>
        /// <param name="row">The current context and configuration.</param>
        /// <param name="memberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance deserialized.</returns>
        public object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            if (string.IsNullOrEmpty(text)
                || string.Equals(nameof(None), text, StringComparison.OrdinalIgnoreCase))
            {
                return None;
            }
            else
            {
                var parameterText = text.Split(Delimiters.InternalDelimiter);

                var baseTopography = Enum.TryParse(typeof(ChunkTopography), parameterText[0], true, out var temp1)
                    ? (ChunkTopography)temp1
                    : Logger.DefaultWithParseLog(parameterText[0], nameof(BaseTopography), ChunkTopography.Empty);
                var baseComposition = (ModelTag)ModelTag.ConverterFactory.ConvertFromString(parameterText[1], row, memberMapData);
                var modifierTopography = Enum.TryParse(typeof(ChunkTopography), parameterText[2], true, out var temp2)
                    ? (ChunkTopography)temp2
                    : Logger.DefaultWithParseLog(parameterText[2], nameof(ModifierTopography), ChunkTopography.Empty);
                var modifierComposition = (ModelTag)ModelTag.ConverterFactory.ConvertFromString(parameterText[3], row, memberMapData);

                return new ChunkDetail(baseTopography, baseComposition, modifierTopography, modifierComposition);
            }
        }
        #endregion

        #region IDeeplyCloneable Implementation
        /// <summary>
        /// Creates a new instance that is a deep copy of the current instance.
        /// </summary>
        /// <returns>A new instance with the same characteristics as the current instance.</returns>
        public ChunkDetail DeepClone()
            // NOTE that I believe no additional cloning is needed here as enums and strings have value semantics.
            => new(BaseTopography, BaseComposition, ModifierTopography, ModifierComposition);
        #endregion

        #region Utilities
        /// <summary>
        /// Returns a <see cref="string"/> that represents the current <see cref="ChunkDetail"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override string ToString()
            => $"[{BaseTopography} {(string.IsNullOrEmpty(BaseComposition) ? "void" : BaseComposition.ToString())} above {ModifierTopography} {(string.IsNullOrEmpty(ModifierComposition) ? "void" : ModifierComposition.ToString())}]";
        #endregion
    }
}
