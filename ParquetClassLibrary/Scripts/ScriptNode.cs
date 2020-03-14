using System;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary
{
    /// <summary>
    /// Models the category and amount of a <see cref="Model"/> from a recipe, e.g. <see cref="Crafts.CraftingRecipe"/>
    /// or <see cref="Rooms.RoomRecipe"/>.  The <see cref="RecipeElement"/> may either be consumed as an ingredient
    /// or returned as the final product.
    /// </summary>
    /// <remarks>
    /// The pairing of ElementTag with an ElementAmount achieves two ends:
    /// <list type="number">
    /// <item><term /><description>
    /// It allows multiple instances of an element to be required without having to store and count multiple objects
    /// representing that element.
    /// </description></item>
    /// <item><term /><description>
    /// It allows various Models to be used interchangably for the same recipe purpose; see <see cref="ModelTag"/>.
    /// </description></item>
    /// </remarks>
    public class ScriptNode : IEquatable<ScriptNode>, ITypeConverter
    {
        #region Class Defaults
        /// <summary>Indicates the lack of any <see cref="ScriptNode"/>s.</summary>
        public static readonly ScriptNode None = new ScriptNode();
        #endregion

        #region Characteristics
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes an empty instance of <see cref="ScriptNode"/> with default values.
        /// </summary>
        /// <remarks>
        /// Useful primarily in the context of serialization.
        /// </remarks>
        public ScriptNode()
        : this(???) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ScriptNode"/> class.
        /// </summary>
        /// <param name="???">???.</param>
        public ScriptNode(???)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region IEquatable Implementation
        /// <summary>
        /// Serves as a hash function for a <see cref="RecipeElement"/>.
        /// </summary>
        /// <returns>
        /// A hash code for this instance that is suitable for use in hashing algorithms and data structures.
        /// </returns>
        public override int GetHashCode()
            => (ElementTag, ElementAmount).GetHashCode();

        /// <summary>
        /// Determines whether the specified <see cref="RecipeElement"/> is equal to the current <see cref="RecipeElement"/>.
        /// </summary>
        /// <param name="inElement">The <see cref="RecipeElement"/> to compare with the current.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public bool Equals(RecipeElement inElement)
            => inElement?.ElementTag == ElementTag
            && inElement.ElementAmount == ElementAmount;

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="RecipeElement"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="RecipeElement"/>.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
            => obj is RecipeElement element
            && Equals(element);

        /// <summary>
        /// Determines whether a specified instance of <see cref="RecipeElement"/> is equal to another specified instance of <see cref="RecipeElement"/>.
        /// </summary>
        /// <param name="inElement1">The first <see cref="RecipeElement"/> to compare.</param>
        /// <param name="inElement2">The second <see cref="RecipeElement"/> to compare.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(RecipeElement inElement1, RecipeElement inElement2)
            => inElement1?.Equals(inElement2) ?? inElement2?.Equals(inElement1) ?? true;

        /// <summary>
        /// Determines whether a specified instance of <see cref="RecipeElement"/> is not equal to another specified instance of <see cref="RecipeElement"/>.
        /// </summary>
        /// <param name="inElement1">The first <see cref="RecipeElement"/> to compare.</param>
        /// <param name="inElement2">The second <see cref="RecipeElement"/> to compare.</param>
        /// <returns><c>true</c> if they are NOT equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(RecipeElement inElement1, RecipeElement inElement2)
            => !(inElement1 == inElement2);
        #endregion

        #region ITypeConverter Implementation
        /// <summary>Allows the converter to construct itself statically.</summary>
        internal static ScriptNode ConverterFactory { get; } = None;

        /// <summary>
        /// Converts the given record column to <see cref="ScriptNode"/>.
        /// </summary>
        /// <param name="inText">The record column to convert to an object.</param>
        /// <param name="inRow">The <see cref="IReaderRow"/> for the current record.</param>
        /// <param name="inMemberMapData">The <see cref="MemberMapData"/> for the member being created.</param>
        /// <returns>The <see cref="ModelTag"/> created from the record column.</returns>
        public object ConvertFromString(string inText, IReaderRow inRow, MemberMapData inMemberMapData)
        {
            if (string.IsNullOrEmpty(inText)
                || string.Compare(nameof(None), inText, StringComparison.InvariantCultureIgnoreCase) == 0)
            {
                return None;
            }

            try
            {
                throw new NotImplementedException();
            }
            catch (Exception e)
            {
                throw new FormatException($"Could not parse {nameof(ScriptNode)} '{inText}': {e}", e);
            }
        }

        /// <summary>
        /// Converts the given <see cref="ScriptNode"/> to a record column.
        /// </summary>
        /// <param name="inValue">The instance to convert.</param>
        /// <param name="inRow">The <see cref="IReaderRow"/> for the current record.</param>
        /// <param name="inMemberMapData">The <see cref="MemberMapData"/> for the member being serialized.</param>
        /// <returns>The <see cref="RecipeElement"/> as a CSV record.</returns>
        public string ConvertToString(object inValue, IWriterRow inRow, MemberMapData inMemberMapData)
            => inValue is ScriptNode node
            && null != node
                ? node == None
                    ? nameof(None)
                    : $"{throw new NotImplementedException()}{Rules.Delimiters.InternalDelimiter}" +
                      $"{throw new NotImplementedException()}"
                : throw new ArgumentException($"Could not serialize '{inValue}' as {nameof(ScriptNode)}.");
        #endregion

        #region Utilities
        /// <summary>
        /// Returns a <see langword="string"/> that represents the current <see cref="ScriptNode"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override string ToString()
            => throw new NotImplementedException();
        #endregion
    }
}
