using System;
using System.Collections.Generic;
using CsvHelper.Configuration;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Interactions
{
    /// <summary>
    /// Models dialogue that an <see cref="Beings.NPCModel"/> may communicate.
    /// </summary>
    public sealed class DialogueModel : InteractionModel
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

        #region Serialization
        #region Serializer Shim
        /// <summary>
        /// Provides a default public parameterless constructor for a
        /// <see cref="DialogueModel"/>-like class that CSVHelper can instantiate.
        /// 
        /// Provides the ability to generate a <see cref="DialogueModel"/> from this class.
        /// </summary>
        internal class DialogueShim : EntityShim
        {
            // TODO Derive this from InteractionStub
            // TODO This is a stub.

            /// <summary>
            /// Converts a shim into the class it corresponds to.
            /// </summary>
            /// <typeparam name="T">The type to convert this shim to.</typeparam>
            /// <returns>An instance of a child class of <see cref="InteractionModel"/>.</returns>
            public override TModel ToInstance<TModel>()
            {
                Precondition.IsOfType<TModel, DialogueModel>(typeof(TModel).ToString());

                // TODO fill in these nulls.
                return (TModel)(ShimProvider)new DialogueModel(ID, Name, Description, Comment, null, null, null);
            }
        }
        #endregion

        #region Class Map
        /// <summary>
        /// Maps the values in a <see cref="DialogueShim"/> to records that CSVHelper recognizes.
        /// </summary>
        internal sealed class DialogueClassMap : ClassMap<DialogueShim>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="DialogueClassMap"/> class.
            /// </summary>
            public DialogueClassMap()
            {
                // TODO This is a stub.

                // Properties are ordered by index to facilitate a logical layout in spreadsheet apps.
                Map(m => m.ID).Index(0);
                Map(m => m.Name).Index(1);
                Map(m => m.Description).Index(2);
                Map(m => m.Comment).Index(3);
            }
        }
        #endregion

        /// <summary>Caches a class mapper.</summary>
        private static DialogueClassMap classMapCache;

        /// <summary>
        /// Provides the means to map all members of this class to a CSV file.
        /// </summary>
        /// <returns>The member mapping.</returns>
        internal static ClassMap GetClassMap()
            => classMapCache
            ?? (classMapCache = new DialogueClassMap());

        /// <summary>
        /// Provides the means to map all members of this class to a CSV file.
        /// </summary>
        /// <returns>The member mapping.</returns>
        internal new static Type GetShimType()
            => typeof(DialogueShim);
        #endregion
    }
}
