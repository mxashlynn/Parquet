using System;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Maps
{
    /// <summary>
    /// A location at which the player moves from one <see cref="MapRegion"/> to another.
    /// </summary>
    /// <remarks>
    /// Since only one Exit Point can exist in a given location, exit points are considered equal according to their position only.
    /// </remarks>
    public readonly struct ExitPoint : IEquatable<ExitPoint>, ITypeConverter
    {
        #region Characteristics
        /// <summary>Location of this exit point.</summary>
        public Vector2D Position { get; }

        /// <summary>The region this exit leads to.</summary>
        public EntityID Destination { get; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of <see cref="ExitPoint"/>.
        /// </summary>
        /// <param name="inPosition">The location of this point on its containing region.</param>
        /// <param name="inDestinationID">The region this exit leads to.</param>
        public ExitPoint(Vector2D inPosition, EntityID inDestinationID)
        {
            Destination = inDestinationID;
            Position = inPosition;
        }
        #endregion

        #region IEquatable Implementation
        /// <summary>
        /// Hash function for a <see cref="SpecialPoint"/>.
        /// </summary>
        /// <returns>A hash code for this instance that is suitable for use in hashing algorithms and data structures.</returns>
        public override int GetHashCode()
            => Position.GetHashCode();

        /// <summary>
        /// Determines whether the specified <see cref="ExitPoint"/> is equal to the current <see cref="ExitPoint"/>.
        /// </summary>
        /// <param name="inPoint">The <see cref="ExitPoint"/> to compare with.</param>
        /// <returns><c>true</c> if the given <see cref="ExitPoint"/> is equal to the current <see cref="ExitPoint"/>; otherwise, <c>false</c>.</returns>
        public bool Equals(ExitPoint inPoint)
            => null != inPoint && Position == inPoint.Position;

        /// <summary>
        /// Determines whether the given <see cref="object"/> is equal to this <see cref="ExitPoint"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with.</param>
        /// <returns><c>true</c> if the specified <see cref="object"/> is equal to the current <see cref="SpecialPoint"/>; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
            => obj is ExitPoint point && Position == point.Position;

        /// <summary>
        /// Determines whether a specified instance of <see cref="SpecialPoint"/>
        /// is equal to another specified instance of <see cref="SpecialPoint"/>.
        /// </summary>
        /// <param name="inPoint1">The first <see cref="SpecialPoint"/> to compare.</param>
        /// <param name="inPoint2">The second <see cref="SpecialPoint"/> to compare.</param>
        /// <returns><c>true</c> if the two points are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(ExitPoint inPoint1, ExitPoint inPoint2)
            => inPoint1.Position == inPoint2.Position;

        /// <summary>
        /// Determines whether a specified instance of <see cref="SpecialPoint"/>
        /// is not equal to another specified <see cref="SpecialPoint"/>.
        /// </summary>
        /// <param name="inPoint1">The first <see cref="SpecialPoint"/> to compare.</param>
        /// <param name="inPoint2">The second <see cref="SpecialPoint"/> to compare.</param>
        /// <returns>
        /// <c>true</c> if the two points are not equal; otherwise, <c>false</c>.
        /// </returns>
        public static bool operator !=(ExitPoint inPoint1, ExitPoint inPoint2)
            => inPoint1.Position != inPoint2.Position;
        #endregion

        #region ITypeConverter Implementation
        /// <summary>Allows the converter to construct itself statically.</summary>
        internal static readonly ExitPoint ConverterFactory =
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
    }
}
