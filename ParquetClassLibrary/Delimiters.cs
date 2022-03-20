namespace Parquet
{
    /// <summary>
    /// Provides a unified source of serialization separators for the library.
    /// </summary>
    /// <remarks>
    /// Every string listed here is reserved by Parquet and cannot be stored in any
    /// <see cref="ModelTag"/> or other library type.<br />
    /// Doing so will cause deserialization to fail.
    /// </remarks>
    public static class Delimiters
    {
        // NOTE that currently delimiters are not stored as chars because PronounGroup requires compile-time
        // delimiter concatenation, which is currently only possible with strings.

        /// <summary>Separator for encoding the dimensions of <see cref="IGrid{TElement}"/> implementations.</summary>
        public const string DimensionalDelimiter = "×";

        /// <summary>Separator for introducting the content of an <see cref="IGrid{TElement}"/> implementations.</summary>
        public const string DimensionalTerminator = "≡";

        /// <summary>Separates primitives within serialized <see cref="Point2D"/>s and <see cref="Range{TElement}"/>s.</summary>
        public const string ElementDelimiter = "–";

        /// <summary>Separates properties within a class when in serialization.</summary>
        public const string InternalDelimiter = "·";

        /// <summary>Separates metadata within serialized <see cref="Regions.MapChunk"/>s.</summary>
        public const string MapChunkDelimiter = "∟";

        /// <summary>Separates family and personal names within serialized <see cref="Beings.CharacterModel"/>s.</summary>
        public const string NameDelimiter = "§";

        /// <summary>Marks out tags that need to be replaced with pronouns from a <see cref="Beings.PronounGroup"/>s.</summary>
        public const string PronounDelimiter = "|";

        /// <summary>Separates collections within files.</summary>
        public const string PrimaryDelimiter = ",";

        /// <summary>Separates objects within unnested, non-<see cref="Pack{T}"/> collections.</summary>
        public const string SecondaryDelimiter = "❟";

        /// <summary>Separates objects within nested or paired collections.</summary>
        public const string TertiaryDelimiter = "❠";

        /// <summary>Separates objects within <see cref="Pack{T}"/>s.</summary>
        public const string PackDelimiter = "⚭";
    }
}
