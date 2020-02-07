using System;
using System.Collections.Generic;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using ParquetClassLibrary.Serialization;

namespace ParquetClassLibrary.Interactions
{
    /// <summary>
    /// Models a quest that an <see cref="Beings.NPCModel"/> may give to a <see cref="Beings.PlayerCharacterModel"/> embodies.
    /// </summary>
    public sealed class QuestModel : InteractionModel, ITypeConverter
    {
        #region Characteristics
        // TODO Is this completely implemented?  Check paper notes.
        /// <summary>
        /// Describes the criteria for completing this <see cref="QuestModel"/>.
        /// </summary>
        public IReadOnlyList<EntityTag> CompletionRequirements { get; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="QuestModel"/> class.
        /// </summary>
        /// <param name="inID">Unique identifier for the <see cref="QuestModel"/>.  Cannot be null.</param>
        /// <param name="inName">Player-friendly name of the <see cref="QuestModel"/>.  Cannot be null or empty.</param>
        /// <param name="inDescription">Player-friendly description of the <see cref="QuestModel"/>.</param>
        /// <param name="inComment">Comment of, on, or by the <see cref="QuestModel"/>.</param>
        /// <param name="inStartCriteria">Describes the criteria for completing this <see cref="DialogueModel"/>.</param>
        /// <param name="inSteps">Describes the criteria for completing this <see cref="DialogueModel"/>.</param>
        /// <param name="inOutcome">Describes the criteria for completing this <see cref="DialogueModel"/>.</param>
        /// <param name="inCompletionRequirements">Describes the criteria for completing this <see cref="QuestModel"/>.</param>
        public QuestModel(EntityID inID, string inName, string inDescription, string inComment,
                          IEnumerable<EntityTag> inStartCriteria, IEnumerable<EntityTag> inSteps, string inOutcome,
                          IEnumerable<EntityTag> inCompletionRequirements)
            : base(All.QuestIDs, inID, inName, inDescription, inComment, inStartCriteria, inSteps, inOutcome)
        {
            CompletionRequirements = (inCompletionRequirements ?? Enumerable.Empty<EntityTag>()).ToList();
        }
        #endregion

        #region ITypeConverter Implementation
        /// <summary>Allows the converter to construct itself statically.</summary>
        internal static readonly QuestModel ConverterFactory =
            new QuestModel(EntityID.None, nameof(ConverterFactory), "", "", null, null, "", null);

        /// <summary>
        /// Converts the given <see cref="object"/> to a <see cref="string"/> for serialization.
        /// </summary>
        /// <param name="inValue">The instance to convert.</param>
        /// <param name="inRow">The current context and configuration.</param>
        /// <param name="inMemberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance serialized.</returns>
        public string ConvertToString(object inValue, IWriterRow inRow, MemberMapData inMemberMapData)
            => null != inValue
            && inValue is QuestModel quest
                ? $"{quest.ID}{Rules.Delimiters.InternalDelimiter}" +
                  $"{quest.Name}{Rules.Delimiters.InternalDelimiter}" +
                  $"{quest.Description}{Rules.Delimiters.InternalDelimiter}" +
                  $"{quest.Comment}{Rules.Delimiters.InternalDelimiter}" +
                  $"{SeriesConverter<EntityTag, List<EntityTag>>.ConverterFactory.ConvertToString(quest.StartCriteria, inRow, inMemberMapData)}" +
                  $"{Rules.Delimiters.InternalDelimiter}" +
                  $"{SeriesConverter<EntityTag, List<EntityTag>>.ConverterFactory.ConvertToString(quest.Steps, inRow, inMemberMapData)}" +
                  $"{Rules.Delimiters.InternalDelimiter}" +
                  $"{quest.Outcome}{Rules.Delimiters.InternalDelimiter}" +
                  $"{SeriesConverter<EntityTag, List<EntityTag>>.ConverterFactory.ConvertToString(quest.CompletionRequirements, inRow, inMemberMapData)}"
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
                throw new ArgumentException($"Could not convert '{inText}' to {nameof(QuestModel)}.");
            }

            try
            {
                var parameterText = inText.Split(Rules.Delimiters.InternalDelimiter);

                var id = (EntityID)EntityID.ConverterFactory.ConvertFromString(parameterText[0], inRow, inMemberMapData);
                var name = parameterText[1];
                var description = parameterText[2];
                var comment = parameterText[3];
                var criteria = (IReadOnlyList<EntityTag>)SeriesConverter<EntityTag, List<EntityTag>>.ConverterFactory
                    .ConvertFromString(parameterText[4], inRow, inMemberMapData);
                var steps = (IReadOnlyList<EntityTag>)SeriesConverter<EntityTag, List<EntityTag>>.ConverterFactory
                    .ConvertFromString(parameterText[5], inRow, inMemberMapData);
                var outcome = parameterText[6];
                var requirements = (IReadOnlyList<EntityTag>)SeriesConverter<EntityTag, List<EntityTag>>.ConverterFactory
                    .ConvertFromString(parameterText[7], inRow, inMemberMapData);

                return new QuestModel(id, name, description, comment, criteria, steps, outcome, requirements);
            }
            catch (Exception e)
            {
                throw new FormatException($"Could not parse '{inText}' as {nameof(QuestModel)}: {e}");
            }
        }
        #endregion
    }
}
