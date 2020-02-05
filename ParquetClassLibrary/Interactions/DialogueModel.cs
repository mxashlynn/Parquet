using System;
using System.Collections.Generic;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using ParquetClassLibrary.Serialization;

namespace ParquetClassLibrary.Interactions
{
    /// <summary>
    /// Models dialogue that an <see cref="Beings.NPCModel"/> may communicate.
    /// </summary>
    public sealed class DialogueModel : InteractionModel, ITypeConverter
    {
        #region Characteristics
        // TODO This is a stub.
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
            IEnumerable<EntityTag> inStartCriteria, IEnumerable<EntityTag> inSteps, string inOutcome)
            : base(All.DialogueIDs, inID, inName, inDescription, inComment, inStartCriteria, inSteps, inOutcome)
        {
            // TODO When implementing dialogue processing (displaying on screen), rememeber to replace a key such as ":they:" with the appropriate pronoun.
        }
        #endregion

        #region ITypeConverter Implementation
        /// <summary>Allows the converter to construct itself statically.</summary>
        internal static readonly DialogueModel ConverterFactory =
            new DialogueModel(EntityID.None, nameof(ConverterFactory), "", "", null, null, "");

        /// <summary>
        /// Converts the given <see cref="object"/> to a <see cref="string"/> for serialization.
        /// </summary>
        /// <param name="inValue">The instance to convert.</param>
        /// <param name="inRow">The current context and configuration.</param>
        /// <param name="inMemberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance serialized.</returns>
        public string ConvertToString(object inValue, IWriterRow inRow, MemberMapData inMemberMapData)
            => null != inValue
            && inValue is DialogueModel dialogue
                ? $"{dialogue.ID}{Rules.Delimiters.InternalDelimiter}" +
                  $"{dialogue.Name}{Rules.Delimiters.InternalDelimiter}" +
                  $"{dialogue.Description}{Rules.Delimiters.InternalDelimiter}" +
                  $"{dialogue.Comment}{Rules.Delimiters.InternalDelimiter}" +
                  $"{SeriesConverter<EntityTag, List<EntityTag>>.ConverterFactory.ConvertToString(dialogue.StartCriteria, inRow, inMemberMapData)}" +
                  $"{Rules.Delimiters.InternalDelimiter}" +
                  $"{SeriesConverter<EntityTag, List<EntityTag>>.ConverterFactory.ConvertToString(dialogue.Steps, inRow, inMemberMapData)}" +
                  $"{Rules.Delimiters.InternalDelimiter}" +
                  $"{dialogue.Outcome}"
            : throw new ArgumentException($"Could not serialize {inValue} as {nameof(DialogueModel)}.");

        /// <summary>
        /// Converts the given <see cref="string"/> to an <see cref="object"/> as deserialization.
        /// </summary>
        /// <param name="text">The text to convert.</param>
        /// <param name="row">The current context and configuration.</param>
        /// <param name="memberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance deserialized.</returns>
        public object ConvertFromString(string inText, IReaderRow inRow, MemberMapData inMemberMapData)
        {
            if (string.IsNullOrEmpty(inText))
            {
                throw new ArgumentException($"Could not convert '{inText}' to {nameof(DialogueModel)}.");
            }

            var parameterText = inText.Split(Rules.Delimiters.InternalDelimiter);
            try
            {
                var id = (EntityID)EntityID.ConverterFactory.ConvertFromString(parameterText[0], inRow, inMemberMapData);
                var name = parameterText[1];
                var description = parameterText[2];
                var comment = parameterText[3];
                var criteria = (IReadOnlyList<EntityTag>)SeriesConverter<EntityTag, List<EntityTag>>.ConverterFactory
                    .ConvertFromString(parameterText[4], inRow, inMemberMapData);
                var steps = (IReadOnlyList<EntityTag>)SeriesConverter<EntityTag, List<EntityTag>>.ConverterFactory
                    .ConvertFromString(parameterText[5], inRow, inMemberMapData);
                var outcome = parameterText[6];

                return new DialogueModel(id, name, description, comment, criteria, steps, outcome);
            }
            catch (Exception e)
            {
                throw new FormatException($"Could not parse '{inText}' as {nameof(DialogueModel)}: {e}");
            }
        }
        #endregion
    }
}
