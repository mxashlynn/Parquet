using System;
using System.Diagnostics.CodeAnalysis;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace Parquet.Scripts
{
    /// <summary>
    /// Models an element within scripted gameplay.
    /// For example, a precondition, postcondition, or step in an <see cref="InteractionModel"/>
    /// or the effect of an <see cref="Items.ItemModel"/>.
    /// </summary>
    [SuppressMessage("Design", "CA1036:Override methods on comparable types",
                     Justification = "Implementing these operators would prevent ScriptNode from operating like a string.")]
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

        #region Parsing
        /// <summary>
        /// Transforms the <see cref="ScriptNode"/> into an <see cref="Action"/> to be invoked.
        /// </summary>
        /// <returns>The action to perform.</returns>
        public Action GetAction()
        {
            var contents = nodeContent.Split(Delimiters.InternalDelimiter);
            return ParseCommand(contents[0], contents[1], contents[2]);
        }

        /// <summary>
        /// Transforms the given texts into an <see cref="Action"/> to be invoked.
        /// </summary>
        /// <param name="commandText">The name of the command.</param>
        /// <param name="sourceText">The source or subject of the command.</param>
        /// <param name="targetText">The target or object of the command.</param>
        /// <returns>The action to perform.</returns>
        private static Action ParseCommand(string commandText, string sourceText, string targetText)
            => commandText.ToUpperInvariant() switch
            {
                Commands.None => () => { },
                Commands.Alert => () => Logger.Log(LogLevel.Info, $"UI: [{targetText}]"),
                Commands.CallCharacter => () => Logger.Log(LogLevel.Info, $"The character {sourceText} stands near the character {targetText}."),
                Commands.ClearFlag => () => Logger.Log(LogLevel.Info, $"The flag {targetText} is cleared."),
                Commands.GiveItem => () => Logger.Log(LogLevel.Info, $"{targetText} is awarded the {sourceText}"),
                Commands.GiveQuest => () => Logger.Log(LogLevel.Info, $"{targetText} is tasked with {sourceText}"),
                Commands.Jump => () => Logger.Log(LogLevel.Info, $"Load the script {targetText}."),
                Commands.JumpIf => () => Logger.Log(LogLevel.Info, $"If {sourceText}, then Load the script {targetText}."),
                Commands.Put => () => Logger.Log(LogLevel.Info, $"Place {sourceText} at {targetText}"),
                Commands.Say => () => Logger.Log(LogLevel.Info, $"{sourceText}: {targetText}"),
                Commands.SetBehavior => () => Logger.Log(LogLevel.Info, $"{targetText} begins behaving {sourceText}"),
                Commands.SetDialogue => () => Logger.Log(LogLevel.Info, $"{targetText} can now say {sourceText}"),
                Commands.SetPronoun => () => Logger.Log(LogLevel.Info, $"{targetText} uses the pronouns {sourceText}"),
                Commands.SetFlag => () => Logger.Log(LogLevel.Info, $"The flag {targetText} is raised."),
                Commands.ShowLocation => () => Logger.Log(LogLevel.Info, $"Highlight {targetText}"),
                _ => Logger.DefaultWithUnsupportedNodeLog<Action>(nameof(ScriptNode), commandText, () => { }),
            };
        #endregion

        #region Implicit Conversion To/From Underlying Type
        /// <summary>
        /// Enables <see cref="ScriptNode"/>s to be treated as their backing type.
        /// </summary>
        /// <param name="value">Any valid tag value.  Invalid values will be sanitized.</param>
        /// <returns>The given value as a tag.</returns>
        public static implicit operator ScriptNode(string value)
            => new() { nodeContent = value };

        /// <summary>
        /// Enables <see cref="ScriptNode"/>s to be treated as their backing type.
        /// </summary>
        /// <param name="node">Any tag.</param>
        /// <returns>The tag's value.</returns>
        public static implicit operator string(ScriptNode node)
            => node?.nodeContent ?? "";
        #endregion

        #region IComparable Implementation
        /// <summary>
        /// Enables <see cref="ScriptNode"/>s to be compared one another.
        /// </summary>
        /// <param name="tag">Any valid <see cref="ScriptNode"/>.</param>
        /// <returns>
        /// A value indicating the relative ordering of the <see cref="ScriptNode"/>s being compared.
        /// The return value has these meanings:
        ///     Less than zero indicates that the current instance precedes the given <see cref="ScriptNode"/> in the sort order.
        ///     Zero indicates that the current instance occurs in the same position in the sort order as the given <see cref="ScriptNode"/>.
        ///     Greater than zero indicates that the current instance follows the given <see cref="ScriptNode"/> in the sort order.
        /// </returns>
        /// <remarks>This comparison is case insensitive.</remarks>
        public int CompareTo(ScriptNode tag)
            => string.Compare(nodeContent, tag?.nodeContent ?? "", StringComparison.OrdinalIgnoreCase);
        #endregion

        #region ITypeConverter Implementation
        /// <summary>Allows the converter to construct itself statically.</summary>
        internal static ScriptNode ConverterFactory { get; } =
            None;

        /// <summary>
        /// Converts the given <see cref="string"/> to a <see cref="ScriptNode"/>.
        /// </summary>
        /// <param name="text">The <see cref="string"/> to convert to an object.</param>
        /// <param name="row">The <see cref="IReaderRow"/> for the current record.</param>
        /// <param name="memberMapData">The <see cref="MemberMapData"/> for the member being created.</param>
        /// <returns>The <see cref="ScriptNode"/> created from the <see cref="string"/>.</returns>
        public object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
            => string.IsNullOrEmpty(text)
                ? None
                : (ScriptNode)$"{char.ToUpperInvariant(text[0])}{text[1..]}";

        /// <summary>
        /// Converts the given <see cref="ScriptNode"/> to a record column.
        /// </summary>
        /// <param name="value">The instance to convert.</param>
        /// <param name="row">The <see cref="IReaderRow"/> for the current record.</param>
        /// <param name="memberMapData">The <see cref="MemberMapData"/> for the member being serialized.</param>
        /// <returns>The <see cref="ScriptNode"/> as a CSV record.</returns>
        public string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
            => value is ScriptNode node
                ? (string)node
                : Logger.DefaultWithConvertLog(value?.ToString() ?? "null", nameof(RecipeElement), nameof(None));
        #endregion

        #region Utilities
        /// <summary>
        /// Returns a <see cref="string"/> that represents the current <see cref="ScriptNode"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override string ToString()
            => nodeContent;
        #endregion
    }
}
