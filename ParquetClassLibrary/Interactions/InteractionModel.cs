using System.Collections.Generic;
using System.Linq;
using CsvHelper.Configuration.Attributes;

namespace ParquetClassLibrary.Interactions
{
    /// <summary>
    /// Models input, output, and process of an interaction between <see cref="Beings.BeingModel"/>s.
    /// </summary>
    public abstract class InteractionModel : EntityModel
    {
        #region Characteristics
        /// <summary>
        /// Describes the criteria for begining this interaction.
        /// </summary>
        [Index(4)]
        public IReadOnlyList<EntityTag> StartCriteria { get; }

        /// <summary>
        /// Everything this interaction entails.
        /// </summary>
        // TODO This is may actually be a list of EntityTags, we need a new InteractionStep class.
        [Index(5)]
        public IReadOnlyList<EntityTag> Steps { get; }

        /// <summary>
        /// Describes the results of finishing this interaction.
        /// </summary>
        // TODO This is not actually a string, not sure how we're going to handle this yet.
        [Index(6)]
        public string Outcome { get; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="InteractionModel"/> class.
        /// </summary>
        /// <param name="inBounds">The bounds within which the derived type's <see cref="EntityID"/> is defined.</param>
        /// <param name="inID">Unique identifier for the <see cref="InteractionModel"/>.  Cannot be null.</param>
        /// <param name="inName">Player-friendly name of the <see cref="InteractionModel"/>.  Cannot be null or empty.</param>
        /// <param name="inDescription">Player-friendly description of the <see cref="InteractionModel"/>.</param>
        /// <param name="inComment">Comment of, on, or by the <see cref="InteractionModel"/>.</param>
        /// <param name="inStartCriteria">Describes the criteria for completing this <see cref="InteractionModel"/>.</param>
        /// <param name="inSteps">Describes the criteria for completing this <see cref="InteractionModel"/>.</param>
        /// <param name="inStatus">The current status of this <see cref="InteractionModel"/>.</param>
        protected InteractionModel(Range<EntityID> inBounds, EntityID inID, string inName, string inDescription, string inComment,
                                   IEnumerable<EntityTag> inStartCriteria, IEnumerable<EntityTag> inSteps, string inOutcome)
            : base(inBounds, inID, inName, inDescription, inComment)
        {
            StartCriteria = (inStartCriteria ?? Enumerable.Empty<EntityTag>()).ToList();
            Steps = (inSteps ?? Enumerable.Empty<EntityTag>()).ToList();
            Outcome = inOutcome ?? "";
        }
        #endregion
    }
}
