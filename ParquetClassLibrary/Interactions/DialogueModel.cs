using System.Collections.Generic;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace ParquetClassLibrary.Interactions
{
    /// <summary>
    /// Models dialogue that an <see cref="Beings.NPCModel"/> may communicate.
    /// </summary>
    public sealed class DialogueModel : InteractionModel, ITypeConverter
    {
        // TODO This is a stub.
        #region Characteristics

        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="DialogueModel"/> class.
        /// </summary>
        /// <param name="inID">Unique identifier for the <see cref="DialogueModel"/>.  Cannot be null.</param>
        /// <param name="inName">Player-friendly name of the <see cref="DialogueModel"/>.  Cannot be null or empty.</param>
        /// <param name="inDescription">Player-friendly description of the <see cref="DialogueModel"/>.</param>
        /// <param name="inComment">Comment of, on, or by the <see cref="DialogueModel"/>.</param>
        /// <param name="inStartCriteria">Describes the criteria for completing this <see cref="DialogueModel"/>.</param>
        /// <param name="inSteps">Describes the criteria for completing this <see cref="DialogueModel"/>.</param>
        /// <param name="inOutcome">Describes the criteria for completing this <see cref="DialogueModel"/>.</param>
        public DialogueModel(EntityID inID, string inName, string inDescription, string inComment,
            IEnumerable<EntityTag> inStartCriteria, IEnumerable<string> inSteps, string inOutcome)
            : base(All.DialogueIDs, inID, inName, inDescription, inComment, inStartCriteria, inSteps, inOutcome)
        {
            // TODO When implementing dialogue processing (displaying on screen), rememeber to replace a key such as ":they:" with the appropriate pronoun.
        }
        #endregion

        #region ITypeConverter Implementation
        /// <summary>Allows the converter to construct itself statically.</summary>
        internal static readonly DialogueModel ConverterFactory =
            new DialogueModel();

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
