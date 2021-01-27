using System;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using Parquet.Properties;

namespace Parquet
{
    /// <summary>
    /// Converts an <see cref="Enum"/> to and from a <see cref="string"/>
    /// providing sensible default values in case of <c>null</c> or the <see cref="string.Empty"/>.
    /// </summary>
    public class EmptyTolerantEnumConverter : EnumConverter
    {
        /// <summary>Stores the type information for the kind of enumeration being converted.</summary>
        private readonly Type EnumType;

        /// <summary>
        /// Creates a new <see cref="EmptyTolerantEnumConverter"/> for the given <see cref="Enum"/> <see cref="Type"/>.
        /// </summary>
        /// <param name="inType">The type of the enumeration.</param>
        public EmptyTolerantEnumConverter(Type inType)
            : base(inType)
            => EnumType = (inType?.IsEnum ?? false)
                ? inType
                : DefaultWithCastLog(nameof(inType), inType?.Name ?? "null", nameof(Enum), default(Type));

        /// <summary>
        /// Convenience method that logs a casting error and returns the given default value.
        /// This is a fatal error as the library will be unable to handle a default type in place of an enumeration.
        /// </summary>
        /// <typeparam name="T">The type of value to return.</typeparam>
        /// <param name="inValue">The value that could not be case.</param>
        /// <param name="inActualTypeName">The name of type received.</param>
        /// <param name="inExpectedTypeName">The name of type expected.</param>
        /// <param name="inDefaultValue">The default value to return.</param>
        /// <returns>The default value given.</returns>
        private static T DefaultWithCastLog<T>(string inValue, string inActualTypeName, string inExpectedTypeName, T inDefaultValue)
        {
            Logger.Log(LogLevel.Fatal, string.Format(CultureInfo.CurrentCulture, Resources.ErrorInvalidCast,
                                                     inValue, inActualTypeName, inExpectedTypeName), null);

            return inDefaultValue;
        }

        /// <summary>
        /// Converts the <c>string</c> to an <c>object</c>.
        /// </summary>
        /// <param name="inText">The string to convert.</param>
        /// <param name="inRow">The <see cref="IReaderRow"/> for the current record.</param>
        /// <param name="inMemberMapData">The <see cref="MemberMapData"/> for the member being created.</param>
        /// <returns>The object created from the string.</returns>
        public override object ConvertFromString(string inText, IReaderRow inRow, MemberMapData inMemberMapData)
            => string.IsNullOrEmpty(inText)
                ? Activator.CreateInstance(EnumType)
                : base.ConvertFromString(inText, inRow, inMemberMapData);
    }
}
