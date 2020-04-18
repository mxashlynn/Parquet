using System.Collections.Generic;
using System.Linq;
using CsvHelper.Configuration.Attributes;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Scripts
{
    /// <summary>
    /// Models input, output, and process of an in-game interaction.
    /// This could be a quest, cutscene, environmental effect, or dialogue between <see cref="Beings.CharacterModel"/>s
    /// </summary>
    public class InteractionModel : Model
    {
        #region Characteristics
        /// <summary>
        /// Describes the criteria for begining this interaction.
        /// </summary>
        [Index(4)]
        public IReadOnlyList<ModelID> Prerequisites { get; }

        /// <summary>
        /// Everything this interaction entails.
        /// </summary>
        [Index(5)]
        public IReadOnlyList<ModelID> Steps { get; }

        /// <summary>
        /// Describes the results of finishing this interaction.
        /// </summary>
        [Index(6)]
        public IReadOnlyList<ModelID> Outcomes { get; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="InteractionModel"/> class.
        /// </summary>
        /// <param name="inID">Unique identifier for the <see cref="InteractionModel"/>.  Cannot be null.</param>
        /// <param name="inName">Player-friendly name of the <see cref="InteractionModel"/>.  Cannot be null or empty.</param>
        /// <param name="inDescription">Player-friendly description of the <see cref="InteractionModel"/>.</param>
        /// <param name="inComment">Comment of, on, or by the <see cref="InteractionModel"/>.</param>
        /// <param name="inPrerequisites">Describes the criteria for beginning this <see cref="InteractionModel"/>.</param>
        /// <param name="inSteps">Describes the criteria for completing this <see cref="InteractionModel"/>.</param>
        /// <param name="inOutcomes">Describes the results of finishing this <see cref="InteractionModel"/>.</param>
        public InteractionModel(ModelID inID, string inName, string inDescription, string inComment,
                                IEnumerable<ModelID> inPrerequisites, IEnumerable<ModelID> inSteps, IEnumerable<ModelID> inOutcomes)
            : base(All.InteractionIDs, inID, inName, inDescription, inComment)
        {
            var nonNullPrerequisites = inPrerequisites ?? Enumerable.Empty<ModelID>();
            var nonNullSteps = inSteps ?? Enumerable.Empty<ModelID>();
            var nonNullOutcomes = inOutcomes ?? Enumerable.Empty<ModelID>();
            Precondition.AreInRange(nonNullPrerequisites, All.ScriptIDs, nameof(inPrerequisites));
            Precondition.AreInRange(nonNullSteps, All.ScriptIDs, nameof(inSteps));
            Precondition.AreInRange(nonNullOutcomes, All.ScriptIDs, nameof(inOutcomes));

            Prerequisites = nonNullPrerequisites.ToList();
            Steps = nonNullSteps.ToList();
            Outcomes = nonNullOutcomes.ToList();

            // TODO When implementing dialogue processing (displaying on screen), rememeber to replace a key such as ":they:" with the appropriate pronoun.
        }
        #endregion
    }
}
