using System;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace Parquet
{
    /// <summary>
    /// Simple container for collocated game objects.
    /// Instances of these classes are mutable during play.
    /// </summary>
    public abstract class Pack<T> :  IEquatable<Pack<T>>, ITypeConverter, IDeeplyCloneable<Pack<T>>
    {
        #region IEquatable Implementation
        /// <summary>
        /// Serves as a hash function for a <see cref="Pack{T}"/>.
        /// </summary>
        /// <returns>A hash code for this instance that is suitable for use in hashing algorithms and data structures.</returns>
        public abstract override int GetHashCode();

        /// <summary>
        /// Determines whether the specified Pack is equal to the current Pack.
        /// </summary>
        /// <param name="inPack">The Pack to compare with the current.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public abstract bool Equals<TDerived>(TDerived inPack)
            where TDerived : Pack<T>;

        /// <summary>
        /// Determines whether the specified <see cref="Pack{T}"/> is equal to the current <see cref="Pack{T}"/>.
        /// </summary>
        /// <param name="inPack">The <see cref="Pack{T}"/> to compare with the current.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public bool Equals(Pack<T> inPack)
            => Equals<Pack<T>>(inPack);

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="ParquetPackPack"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="ParquetPackPack"/>.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public abstract override bool Equals(object obj);

        // NOTE that derived classes should also declare static bool operator ==(Pack<T> inPack1, Pack<T> inPack2)
        // NOTE that derived classes should also declare static bool operator !=(Pack<T> inPack1, Pack<T> inPack2)
        #endregion

        #region ITypeConverter Implementation
        // NOTE that derived classes should include an internal static Pack ConverterFactory { get; }

        /// <summary>
        /// Converts the given <see cref="object"/> to a <see cref="string"/> for serialization.
        /// </summary>
        /// <param name="inValue">The instance to convert.</param>
        /// <param name="inRow">The current context and configuration.</param>
        /// <param name="inMemberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance serialized.</returns>
        public abstract object ConvertFromString(string inText, IReaderRow inRow, MemberMapData inMemberMapData);

        /// <summary>
        /// Converts the given <see cref="string"/> to an <see cref="object"/> as deserialization.
        /// </summary>
        /// <param name="inText">The text to convert.</param>
        /// <param name="inRow">The current context and configuration.</param>
        /// <param name="inMemberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance deserialized.</returns>
        public abstract string ConvertToString(object inValue, IWriterRow inRow, MemberMapData inMemberMapData);
        #endregion

        #region IDeeplyCloneable Implementation
        /// <summary>
        /// Creates a new instance that is a deep copy of the current instance.
        /// </summary>
        /// <returns>A new instance with the same characteristics as the current instance.</returns>
        public virtual Pack<T> DeepClone()
            => DeepClone<Pack<T>>();

        /// <summary>
        /// Creates a new instance that is a deep copy of the current instance.
        /// </summary>
        /// <typeparam name="TDerived">The type of the instance that is being cloned.</typeparam>
        /// <returns>A new instance with the same characteristics as the current instance.</returns>
        public abstract TDerived DeepClone<TDerived>()
            where TDerived : Pack<T>;
        #endregion
    }

    /// <summary>
    /// Provides extension methods useful when dealing with 2D arrays of <see cref="Pack"/>s.
    /// </summary>
    public static class PackArrayExtensions
    {
        /// <summary>
        /// Determines if the given position corresponds to a point within the current array.
        /// </summary>
        /// <param name="inArray">The <see cref="Pack{T}"/> array to validate against.</param>
        /// <param name="inPosition">The position to validate.</param>
        /// <returns><c>true</c>, if the position is valid, <c>false</c> otherwise.</returns>
        public static bool IsValidPosition<T>(this Pack<T>[,] inArray, Vector2D inPosition)
            => inArray is not null
            && inPosition.X > -1
            && inPosition.Y > -1
            && inPosition.X < inArray.GetLength(1)
            && inPosition.Y < inArray.GetLength(0);
    }
}
