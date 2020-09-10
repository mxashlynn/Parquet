using System;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using ParquetClassLibrary.Properties;

namespace ParquetClassLibrary
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
        /// Creates a new <see cref="EmptyTolerantEnumConverter"/> for the given <see cref="Enum"/> <see cref="System.Type"/>.
        /// </summary>
        /// <param name="inType">The type of the enumeration.</param>
        public EmptyTolerantEnumConverter(Type inType)
            : base(inType)
            => EnumType = (inType?.IsEnum ?? false)
                ? inType
                : throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Resources.ErrorInvalidCast,
                                                            nameof(inType), inType.Name, nameof(Enum)));

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
