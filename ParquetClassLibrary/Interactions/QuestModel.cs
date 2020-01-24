using System;
using System.Collections.Generic;
using System.Linq;
using CsvHelper.Configuration;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Interactions
{
    /// <summary>
    /// Models a quest that an <see cref="Beings.NPCModel"/> may give to a <see cref="Beings.PlayerCharacterModel"/> embodies.
    /// </summary>
    public sealed class QuestModel : InteractionModel
    {
        #region Characteristics
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
                          IEnumerable<EntityTag> inStartCriteria, IEnumerable<string> inSteps, string inOutcome,
                          IEnumerable<EntityTag> inCompletionRequirements)
            : base(All.QuestIDs, inID, inName, inDescription, inComment, inStartCriteria, inSteps, inOutcome)
        {
            CompletionRequirements = (inCompletionRequirements ?? Enumerable.Empty<EntityTag>()).ToList();
        }
        #endregion

        #region Serialization
        #region Serializer Shim
        /// <summary>
        /// Provides a default public parameterless constructor for a
        /// <see cref="QuestModel"/>-like class that CSVHelper can instantiate.
        /// 
        /// Provides the ability to generate a <see cref="QuestModel"/> from this class.
        /// </summary>
        internal class QuestShim : EntityShim
        {
            // TODO Derive this from InteractionStub

            /// <summary>Describes the criteria for completing this <see cref="QuestModel"/>.</summary>
            public IReadOnlyList<EntityTag> CompletionRequirements;

            /// <summary>
            /// Converts a shim into the class it corresponds to.
            /// </summary>
            /// <typeparam name="T">The type to convert this shim to.</typeparam>
            /// <returns>An instance of a child class of <see cref="InteractionModel"/>.</returns>
            public override TModel ToEntity<TModel>()
            {
                Precondition.IsOfType<TModel, QuestModel>(typeof(TModel).ToString());

                // TODO Fill in these stubs.
                return (TModel)(EntityModel)new QuestModel(ID, Name, Description, Comment, CompletionRequirements, null, null, null);
            }
        }
        #endregion

        #region Class Map
        /// <summary>
        /// Maps the values in a <see cref="QuestShim"/> to records that CSVHelper recognizes.
        /// </summary>
        internal sealed class QuestClassMap : ClassMap<QuestShim>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="QuestClassMap"/> class.
            /// </summary>
            public QuestClassMap()
            {
                // Properties are ordered by index to facilitate a logical layout in spreadsheet apps.
                Map(m => m.ID).Index(0);
                Map(m => m.Name).Index(1);
                Map(m => m.Description).Index(2);
                Map(m => m.Comment).Index(3);

                Map(m => m.CompletionRequirements).Index(4);
            }
        }
        #endregion

        /// <summary>Caches a class mapper.</summary>
        private static QuestClassMap classMapCache;

        /// <summary>
        /// Provides the means to map all members of this class to a CSV file.
        /// </summary>
        /// <returns>The member mapping.</returns>
        internal static ClassMap GetClassMap()
            => classMapCache
            ?? (classMapCache = new QuestClassMap());

        /// <summary>
        /// Provides the means to map all members of this class to a CSV file.
        /// </summary>
        /// <returns>The member mapping.</returns>
        internal static Type GetShimType()
            => typeof(QuestShim);
        #endregion
    }
}
