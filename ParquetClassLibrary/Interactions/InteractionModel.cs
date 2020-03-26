using System.Collections.Generic;
using System.Linq;
using CsvHelper.Configuration.Attributes;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Interactions
{
    /// <summary>
    /// Models input, output, and process of an interaction between <see cref="Beings.BeingModel"/>s.
    /// </summary>
    public abstract class InteractionModel : Model
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
        public IReadOnlyList<ModelID> Outcome { get; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="InteractionModel"/> class.
        /// </summary>
        /// <param name="inBounds">The bounds within which the derived type's <see cref="ModelID"/> is defined.</param>
        /// <param name="inID">Unique identifier for the <see cref="InteractionModel"/>.  Cannot be null.</param>
        /// <param name="inName">Player-friendly name of the <see cref="InteractionModel"/>.  Cannot be null or empty.</param>
        /// <param name="inDescription">Player-friendly description of the <see cref="InteractionModel"/>.</param>
        /// <param name="inComment">Comment of, on, or by the <see cref="InteractionModel"/>.</param>
        /// <param name="inStartCriteria">Describes the criteria for completing this <see cref="InteractionModel"/>.</param>
        /// <param name="inSteps">Describes the criteria for completing this <see cref="InteractionModel"/>.</param>
        /// <param name="inStatus">The current status of this <see cref="InteractionModel"/>.</param>
        protected InteractionModel(Range<ModelID> inBounds, ModelID inID, string inName, string inDescription, string inComment,
                                   IEnumerable<ModelID> inStartCriteria, IEnumerable<ModelID> inSteps, IEnumerable<ModelID> inOutcome)
            : base(inBounds, inID, inName, inDescription, inComment)
        {
            Precondition.AreInRange(inStartCriteria, All.ScriptIDs, nameof(inStartCriteria));
            Precondition.AreInRange(inSteps, All.ScriptIDs, nameof(inSteps));
            Precondition.AreInRange(inOutcome, All.ScriptIDs, nameof(inOutcome));

            Prerequisites = inStartCriteria.ToList();
            Steps = inSteps.ToList();
            Outcome = inOutcome.ToList();
        }
        #endregion
    }
}
