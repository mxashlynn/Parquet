using System;
using ParquetClassLibrary.Biomes;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Map
{
    /// <summary>
    /// Indicates which parquets constitute this <see cref="MapChunk"/> and how they are arranged.
    /// </summary>
    /// <remarks>
    /// Every chunk is either handmade or procedurally generated.
    ///
    /// Chunks that are not hand made are instead composed of two layers: a base and a modifier.
    /// The base is the underlying structure of the chunk and the modifier overlays it to
    /// produce more complex arrangements than would otherwise be possible.  For example:
    ///
    /// Forest = Base:Grassy Solid, Modifier:Scattered Trees
    /// Seaside = Base:Watery Solid, Modifier:Eastern Sandy
    /// Ruins, Town = Handmade
    /// </remarks>
    public readonly struct ChunkType : IEquatable<ChunkType>
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
        /// <param name="in_baseTopography">The basic form that the <see cref="MapChunk"/> of parquets takes.</param>
        /// <param name="in_baseComposition">Indicates the overall type of parquets in the <see cref="MapChunk"/>.</param>
        /// <param name="in_modifierTopography">Indicates a modifier on the <see cref="MapChunk"/> of parquets.</param>
        /// <param name="in_modifierComposition">Indicates the type of parquets modifying the <see cref="MapChunk"/>.</param>
        public ChunkType(ChunkTopography? in_baseTopography, EntityTag in_baseComposition,
                         ChunkTopography? in_modifierTopography, EntityTag in_modifierComposition)
        {
            Handmade = false;
            BaseTopography = in_baseTopography ?? ChunkTopography.Empty;
            BaseComposition = in_baseComposition ?? EntityTag.None;
            ModifierTopography = in_modifierTopography ?? ChunkTopography.Empty;
            ModifierConstituents = in_modifierComposition ?? EntityTag.None;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ChunkType"/> class.
        /// </summary>
        /// <param name="in_isHandmade">If <c>true</c>, the <see cref="MapChunk"/> is created at design time instead of procedurally generated.</param>
        public ChunkType(bool in_isHandmade)
        {
            Handmade = in_isHandmade;
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
        /// <param name="in_chunkType">The <see cref="ChunkType"/> to compare with the current.</param>
        /// <returns><c>true</c> if the <see cref="ChunkType"/>s are equal.</returns>
        public bool Equals(ChunkType in_chunkType)
            => BaseTopography == in_chunkType.BaseTopography
            && BaseComposition == in_chunkType.BaseComposition
            && ModifierTopography == in_chunkType.ModifierTopography
            && ModifierConstituents == in_chunkType.ModifierConstituents;

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
        /// <param name="in_chunkType1">The first <see cref="ChunkType"/> to compare.</param>
        /// <param name="in_chunkType2">The second <see cref="ChunkType"/> to compare.</param>
        /// <returns><c>true</c> if the two <see cref="ChunkType"/>s are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(ChunkType in_chunkType1, ChunkType in_chunkType2)
            => in_chunkType1.Equals(in_chunkType2.BaseTopography);

        /// <summary>
        /// Determines whether a specified instance of <see cref="ChunkType"/> is unequal to
        /// another specified instance of <see cref="ChunkType"/>.
        /// </summary>
        /// <param name="in_chunkType1">The first <see cref="ChunkType"/> to compare.</param>
        /// <param name="in_chunkType2">The second <see cref="ChunkType"/> to compare.</param>
        /// <returns><c>true</c> if the two <see cref="ChunkType"/>s are NOT equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(ChunkType in_chunkType1, ChunkType in_chunkType2)
            => !in_chunkType1.Equals(in_chunkType2.BaseTopography);
        #endregion

        #region Utility Methods
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
        /// <param name="in_position">The position to validate.</param>
        /// <returns><c>true</c>, if the position is valid, <c>false</c> otherwise.</returns>
        public static bool IsValidPosition(this ChunkType[,] in_chunkArray, Vector2D in_position)
        {
            Precondition.IsNotNull(in_chunkArray, nameof(in_chunkArray));

            return in_position.X > -1
                && in_position.Y > -1
                && in_position.X < in_chunkArray.GetLength(1)
                && in_position.Y < in_chunkArray.GetLength(0);
        }
    }
}
