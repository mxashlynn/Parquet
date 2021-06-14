using System;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace Parquet
{
    /// <summary>
    /// A simple representation of two coordinate integers, tailored for Parquet's needs.
    /// Instances have value semantics.
    /// </summary>
    public readonly struct Point2D : IEquatable<Point2D>, ITypeConverter
    {
        #region Class Defaults
        /// <summary>The zero point.</summary>
        public static readonly Point2D Origin = new(0, 0);

        /// <summary>The point equivalent to the unit vector.</summary>
        public static readonly Point2D Unit = new(1, 1);

        /// <summary>The point offset to the North.</summary>
        public static readonly Point2D North = new(0, -1);

        /// <summary>The point offset to the South.</summary>
        public static readonly Point2D South = new(0, 1);

        /// <summary>The point offset to the East.</summary>
        public static readonly Point2D East = new(1, 0);

        /// <summary>The point offset to the West.</summary>
        public static readonly Point2D West = new(-1, 0);
        #endregion

        #region Characteristics
        /// <summary>Location along the x axis.</summary>
        public int X { get; }

        /// <summary>Location along the y axis.</summary>
        public int Y { get; }

        /// <summary>Treats the point as a vector, providing its magnitude as an integer, rounded-down.</summary>
        public int Magnitude { get; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="Point2D"/> struct.
        /// </summary>
        /// <param name="inX">The X coordinate.</param>
        /// <param name="inY">The Y coordinate.</param>
        public Point2D(int inX, int inY)
        {
            X = inX;
            Y = inY;
            Magnitude = Convert.ToInt32(Math.Floor(Math.Sqrt((X * X) + (Y * Y))));
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Point2D"/> struct.
        /// </summary>
        /// <param name="inCoordinates">The coordinates.</param>
        public Point2D((int X, int Y) inCoordinates)
            : this(inCoordinates.X, inCoordinates.Y)
        { }
        #endregion

        #region Math
        /// <summary>
        /// Sums the given points as if they were vectors.
        /// </summary>
        /// <param name="inPoint1">First operand.</param>
        /// <param name="inPoint2">Second operand.</param>
        /// <returns>A point representing the sum of the given points.</returns>
        public static Point2D operator +(Point2D inPoint1, Point2D inPoint2)
            => new(inPoint1.X + inPoint2.X, inPoint1.Y + inPoint2.Y);

        /// <summary>
        /// Finds the difference between the given points as if they were points.
        /// </summary>
        /// <param name="inPoint1">First operand.</param>
        /// <param name="inPoint2">Second operand.</param>
        /// <returns>A point representing the difference of the given points.</returns>
        public static Point2D operator -(Point2D inPoint1, Point2D inPoint2)
            => new(inPoint1.X - inPoint2.X, inPoint1.Y - inPoint2.Y);

        /// <summary>
        /// Scales a the point.
        /// </summary>
        /// <param name="inScalar">The scale factor.</param>
        /// <param name="inPoint">The point.</param>
        /// <returns>A point representing the scaled point.</returns>
        public static Point2D operator *(int inScalar, Point2D inPoint)
            => new(inScalar * inPoint.X, inScalar * inPoint.Y);
        #endregion

        #region IEquatable Implementation
        /// <summary>
        /// Serves as a hash function for a <see cref="Point2D"/> struct.
        /// </summary>
        /// <returns>A hash code for this instance that is suitable for use in hashing algorithms and data structures.</returns>
        public override int GetHashCode()
            => (X, Y).GetHashCode();

        /// <summary>
        /// Determines whether the specified <see cref="Point2D"/> is equal to the current <see cref="Point2D"/>.
        /// </summary>
        /// <param name="inPoint">The <see cref="Point2D"/> to compare with the current.</param>
        /// <returns><c>true</c> if the <see cref="Point2D"/>s are equal.</returns>
        public bool Equals(Point2D inPoint)
            => X == inPoint.X
            && Y == inPoint.Y;

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="Point2D"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="Point2D"/>.</param>
        /// <returns><c>true</c> if the specified <see cref="object"/> is equal to the current <see cref="Point2D"/>; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
            => obj is Point2D point
            && Equals(point);

        /// <summary>
        /// Determines whether a specified instance of <see cref="Point2D"/> is equal to
        /// another specified instance of <see cref="Point2D"/>.
        /// </summary>
        /// <param name="inPoint1">The first <see cref="Point2D"/> to compare.</param>
        /// <param name="inPoint2">The second <see cref="Point2D"/> to compare.</param>
        /// <returns><c>true</c> if the two operands are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(Point2D inPoint1, Point2D inPoint2)
            => inPoint1.Equals(inPoint2);

        /// <summary>
        /// Determines whether a specified instance of <see cref="Point2D"/> is not equal
        /// to another specified instance of <see cref="Point2D"/>.
        /// </summary>
        /// <param name="inPoint1">The first <see cref="Point2D"/> to compare.</param>
        /// <param name="inPoint2">The second <see cref="Point2D"/> to compare.</param>
        /// <returns><c>true</c> if the two operands are NOT equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(Point2D inPoint1, Point2D inPoint2)
            => !inPoint1.Equals(inPoint2);
        #endregion

        #region ITypeConverter Implementation
        /// <summary>Allows the converter to construct itself statically.</summary>
        internal static Point2D ConverterFactory { get; } = Origin;

        /// <summary>
        /// Converts the given <see cref="object"/> to a <see cref="string"/> for serialization.
        /// </summary>
        /// <param name="value">The instance to convert.</param>
        /// <param name="row">The current context and configuration.</param>
        /// <param name="memberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance serialized.</returns>
        public string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
            => value is Point2D point
                ? $"{point.X}{Delimiters.ElementDelimiter}" +
                  $"{point.Y}"
                : Logger.DefaultWithConvertLog(value?.ToString() ?? "null", nameof(Point2D), nameof(Origin));

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
                || string.Compare(nameof(Origin), text, StringComparison.OrdinalIgnoreCase) == 0)
            {
                return Origin;
            }

            var parameterText = text.Split(Delimiters.ElementDelimiter);

            var x = int.TryParse(parameterText[0], All.SerializedNumberStyle, CultureInfo.InvariantCulture, out var temp1)
                ? temp1
                : Logger.DefaultWithParseLog(parameterText[0], nameof(X), Origin.X);
            var y = int.TryParse(parameterText[1], All.SerializedNumberStyle, CultureInfo.InvariantCulture, out var temp2)
                ? temp2
                : Logger.DefaultWithParseLog(parameterText[1], nameof(Y), Origin.Y);

            return new Point2D(x, y);
        }
        #endregion

        #region Utilities
        /// <summary>
        /// Deconstructs the current <see cref="Point2D"/> into its constituent coordinates.
        /// </summary>
        /// <param name="x">The X coordinate.</param>
        /// <param name="y">The Y coordinate.</param>
        public void Deconstruct(out int x, out int y)
            => (x, y) = (X, Y);

        /// <summary>
        /// Returns a <see cref="string"/> that represents the current <see cref="Point2D"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override string ToString()
            => $"({X}, {Y})";
        #endregion
    }
}
