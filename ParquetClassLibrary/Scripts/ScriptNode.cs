using System;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace ParquetClassLibrary.Scripts
{
    /// <summary>
    /// Models the an element within a scripted element of gameplay.
    /// For example, a precondition, postcondition, or step in an <see cref="Interactions.InteractionModel"/>
    /// or the effect of an <see cref="Items.ItemModel"/>.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design",
        "CA1036:Override methods on comparable types",
        Justification = "{ScriptNode is designed to operate like a string, and string does not implement these operators.")]
    public class ScriptNode : IComparable<ScriptNode>, ITypeConverter
    {
        #region Class Defaults
        /// <summary>Indicates the lack of any <see cref="ScriptNode"/>s.</summary>
        public static readonly ScriptNode None = "";
        #endregion

        #region Characteristics
        /// <summary>Backing type for the <see cref="ScriptNode"/>.</summary>
        private string nodeContent = "";
        #endregion

        #region Construction and Destruction
        /// <summary>
        /// Transforms the <see cref="ScriptNode"/> into an <see cref="Action"/> to be invoked.
        /// </summary>
        /// <returns>The action to perform.</returns>
        public static ScriptNode Construct(string inCommandText, string inSourceText, string inTargetText)
            => (ScriptNode)
                $"{inCommandText}{Rules.Delimiters.InternalDelimiter}" +
                $"{inSourceText}{Rules.Delimiters.InternalDelimiter}" +
                $"{inTargetText}";
        #endregion

        #region Parsing
        /// <summary>
        /// Transforms the <see cref="ScriptNode"/> into an <see cref="Action"/> to be invoked.
        /// </summary>
        /// <returns>The action to perform.</returns>
        public Action GetAction()
        {
            var contents = nodeContent.Split(Rules.Delimiters.InternalDelimiter);
            return ParseCommand(contents[0], contents[1], contents[2]);
        }

        /// <summary>
        /// Transforms the given texts into an <see cref="Action"/> to be invoked.
        /// </summary>
        /// <param name="inCommandText">The name of the command.</param>
        /// <param name="inSourceText">The source or subject of the command.</param>
        /// <param name="inTargetText">The target or object of the command.</param>
        /// <returns>The action to perform.</returns>
        private static Action ParseCommand(string inCommandText, string inSourceText, string inTargetText)
            => inCommandText.ToUpperInvariant() switch
            {
                Commands.None => () => { },
                Commands.Alert => () => Console.WriteLine($"UI: [{inTargetText}]"),
                Commands.CallCharacter => () => Console.WriteLine($"The character {inSourceText} stands near the character {inTargetText}."),
                Commands.ClearFlag => () => Console.WriteLine($"The flag {inTargetText} is cleared."),
                Commands.GiveItem => () => Console.WriteLine($"{inTargetText} is awarded the {inSourceText}"),
                Commands.GiveQuest => () => Console.WriteLine($"{inTargetText} is tasked with {inSourceText}"),
                Commands.Jump => () => Console.WriteLine($"Load the script {inTargetText}."),
                Commands.JumpIf => () => Console.WriteLine($"If {inSourceText}, then Load the script {inTargetText}."),
                Commands.Put => () => Console.WriteLine($"Place {inSourceText} at {inTargetText}"),
                Commands.Say => () => Console.WriteLine($"{inSourceText}: {inTargetText}"),
                Commands.SetBehavior => () => Console.WriteLine($"{inTargetText} begins behaving {inSourceText}"),
                Commands.SetDialogue => () => Console.WriteLine($"{inTargetText} can now say {inSourceText}"),
                Commands.SetPronoun => () => Console.WriteLine($"{inTargetText} uses the pronouns {inSourceText}"),
                Commands.SetFlag => () => Console.WriteLine($"The flag {inTargetText} is raised."),
                Commands.ShowLocation => () => Console.WriteLine($"Highlight {inTargetText}"),
                _ => throw new InvalidOperationException($"Unknown {nameof(ScriptNode)} {inCommandText}."),
            };
        #endregion

        #region Implicit Conversion To/From Underlying Type
        /// <summary>
        /// Enables <see cref="ScriptNode"/>s to be treated as their backing type.
        /// </summary>
        /// <param name="inValue">Any valid tag value.  Invalid values will be sanitized.</param>
        /// <returns>The given value as a tag.</returns>
        /// <seealso cref="Sanitize(string)"/>
        public static implicit operator ScriptNode(string inValue)
            => new ScriptNode { nodeContent = inValue };

        /// <summary>
        /// Enables <see cref="ScriptNode"/>s to be treated as their backing type.
        /// </summary>
        /// <param name="inNode">Any tag.</param>
        /// <returns>The tag's value.</returns>
        public static implicit operator string(ScriptNode inNode)
            => inNode?.nodeContent ?? "";
        #endregion

        #region IComparable Implementation
        /// <summary>
        /// Enables <see cref="ScriptNode"/>s to be compared one another.
        /// </summary>
        /// <param name="inTag">Any valid <see cref="ScriptNode"/>.</param>
        /// <returns>
        /// A value indicating the relative ordering of the <see cref="ScriptNode"/>s being compared.
        /// The return value has these meanings:
        ///     Less than zero indicates that the current instance precedes the given <see cref="ScriptNode"/> in the sort order.
        ///     Zero indicates that the current instance occurs in the same position in the sort order as the given <see cref="ScriptNode"/>.
        ///     Greater than zero indicates that the current instance follows the given <see cref="ScriptNode"/> in the sort order.
        /// </returns>
        public int CompareTo(ScriptNode inTag)
            => string.Compare(nodeContent, inTag?.nodeContent ?? "", StringComparison.Ordinal);
        #endregion

        #region ITypeConverter Implementation
        /// <summary>Allows the converter to construct itself statically.</summary>
        internal static ScriptNode ConverterFactory { get; } =
            None;

        /// <summary>
        /// Converts the given <see langword="string"/> to a <see cref="ScriptNode"/>.
        /// </summary>
        /// <param name="inText">The <see langword="string"/> to convert to an object.</param>
        /// <param name="inRow">The <see cref="IReaderRow"/> for the current record.</param>
        /// <param name="inMemberMapData">The <see cref="MemberMapData"/> for the member being created.</param>
        /// <returns>The <see cref="ScriptNode"/> created from the <see langword="string"/>.</returns>
        public object ConvertFromString(string inText, IReaderRow inRow, MemberMapData inMemberMapData)
            => (ScriptNode)inText;

        /// <summary>
        /// Converts the given <see cref="ScriptNode"/> to a record column.
        /// </summary>
        /// <param name="inValue">The instance to convert.</param>
        /// <param name="inRow">The <see cref="IReaderRow"/> for the current record.</param>
        /// <param name="inMemberMapData">The <see cref="MemberMapData"/> for the member being serialized.</param>
        /// <returns>The <see cref="ScriptNode"/> as a CSV record.</returns>
        public string ConvertToString(object inValue, IWriterRow inRow, MemberMapData inMemberMapData)
            => inValue is ScriptNode node
                ? (string)node
                : throw new ArgumentException($"Could not serialize '{inValue}' as {nameof(ScriptNode)}.");
        #endregion

        #region Utilities
        /// <summary>
        /// Returns a <see langword="string"/> that represents the current <see cref="ScriptNode"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override string ToString()
            => nodeContent;
        #endregion
    }
}
