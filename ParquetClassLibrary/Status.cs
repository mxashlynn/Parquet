using System;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace Parquet
{
    /// <summary>
    /// Represents individual game object instances with elements that vary over time or between instances.
    /// </summary>
    /// <remarks>
    /// <see cref="Status{T}"/>es represent the parts of a game object that change while the game
    /// is played.  For this reason, Statuses are designed to be always mutable.
    /// <para />
    /// Most types derived from Status have a companion type derived from <see cref="Model"/>.
    /// These companion classes represent the parts of a game object that do not vary by instance
    /// or with time, and so do not have mutable state during game play.  All such Statuses are
    /// paired with a <see cref="ModelID"/> by manager classes.
    /// <para />
    // TODO [API] Update the following sentence when we update LOCATION.
    /// One Status that does not have a Model companion is <see cref="Location"/>, which can
    /// be applied to any game object with a definite position within the game world.
    /// </remarks>
    public abstract class Status<T> : IEquatable<Status<T>>, ITypeConverter, IDeeplyCloneable<Status<T>>
    {
        #region Initialization
        // NOTE that derived classes should include public constructor that takes a tracked item of type T.
        #endregion

        #region IEquatable Implementation
        /// <summary>
        /// Serves as a hash function for a <see cref="Status{T}"/>.
        /// </summary>
        /// <returns>
        /// A hash code for this instance that is suitable for use in hashing algorithms and data structures.
        /// </returns>
        public abstract override int GetHashCode();

        /// <summary>
        /// Determines whether the specified status is equal to the current status.
        /// </summary>
        /// <param name="inStatus">The status to compare with the current.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public abstract bool Equals<TDerived>(TDerived inStatus)
            where TDerived : Status<T>;

        /// <summary>
        /// Determines whether the specified <see cref="Status{T}"/> is equal to the current <see cref="Status{T}"/>.
        /// </summary>
        /// <param name="inStatus">The <see cref="Status{T}"/> to compare with the current.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public bool Equals(Status<T> inStatus)
            => Equals<Status<T>>(inStatus);

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="ParquetPackStatus"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="ParquetPackStatus"/>.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public abstract override bool Equals(object obj);

        // NOTE that derived classes should also declare static bool operator ==(Status<T> inStatus1, Status<T> inStatus2)
        // NOTE that derived classes should also declare static bool operator !=(Status<T> inStatus1, Status<T> inStatus2)
        #endregion

        #region ITypeConverter Implementation
        // NOTE that derived classes should include an internal static Status ConverterFactory { get; }

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
        public Status<T> DeepClone()
            => DeepClone<Status<T>>();

        /// <summary>
        /// Creates a new instance that is a deep copy of the current instance.
        /// </summary>
        /// <typeparam name="TDerived">The type of the instance that is being cloned.</typeparam>
        /// <returns>A new instance with the same characteristics as the current instance.</returns>
        public abstract TDerived DeepClone<TDerived>()
            where TDerived : Status<T>;
        #endregion
    }

    /// <summary>
    /// Provides extension methods useful when dealing with 2D arrays of <see cref="Status"/>es.
    /// </summary>
    public static class StatusArrayExtensions
    {
        /// <summary>
        /// Determines if the given position corresponds to a point within the current array.
        /// </summary>
        /// <param name="inArray">The array to validate against.</param>
        /// <param name="inPosition">The position to validate.</param>
        /// <returns><c>true</c>, if the position is valid, <c>false</c> otherwise.</returns>
        public static bool IsValidPosition<T>(this Status<T>[,] inArray, Point2D inPosition)
            => inArray is not null
            && inPosition.X > -1
            && inPosition.Y > -1
            && inPosition.X < inArray.GetLength(1)
            && inPosition.Y < inArray.GetLength(0);
    }
}
