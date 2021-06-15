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
        /// <param name="type">The type of the enumeration.</param>
        public EmptyTolerantEnumConverter(Type type)
            : base(type)
            => EnumType = (type?.IsEnum ?? false)
                ? type
                : DefaultWithCastLog(nameof(type), type?.Name ?? "null", nameof(Enum), default(Type));

        /// <summary>
        /// Convenience method that logs a casting error and returns the given default value.
        /// This is a fatal error as the library will be unable to handle a default type in place of an enumeration.
        /// </summary>
        /// <typeparam name="T">The type of value to return.</typeparam>
        /// <param name="value">The value that could not be case.</param>
        /// <param name="actualTypeName">The name of type received.</param>
        /// <param name="expectedTypeName">The name of type expected.</param>
        /// <param name="defaultValue">The default value to return.</param>
        /// <returns>The default value given.</returns>
        private static T DefaultWithCastLog<T>(string value, string actualTypeName, string expectedTypeName, T defaultValue)
        {
            Logger.Log(LogLevel.Fatal, string.Format(CultureInfo.CurrentCulture, Resources.ErrorInvalidCast,
                                                     value, actualTypeName, expectedTypeName), null);

            return defaultValue;
        }

        /// <summary>
        /// Converts the <c>string</c> to an <c>object</c>.
        /// </summary>
        /// <param name="text">The string to convert.</param>
        /// <param name="row">The <see cref="IReaderRow"/> for the current record.</param>
        /// <param name="memberMapData">The <see cref="MemberMapData"/> for the member being created.</param>
        /// <returns>The object created from the string.</returns>
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
            => string.IsNullOrEmpty(text)
                ? Activator.CreateInstance(EnumType)
                : base.ConvertFromString(text, row, memberMapData);
    }
}
