#if DESIGN
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CsvHelper.Configuration.Attributes;
using ParquetClassLibrary.EditorSupport;
using ParquetClassLibrary.Items;

namespace ParquetClassLibrary.Beings
{
    [SuppressMessage("Design", "CA1033:Interface methods should be callable by subtypes",
                     Justification = "By design, subtypes of Model should never themselves use IMutableModel or derived interfaces to access their own members.  The IMutableModel family of interfaces is for external types that require read/write access.")]
    public partial class CharacterModel : IMutableCharacterModel
    {
        #region ICharacterModelEdit Implementation
        /// <summary>Player-facing personal name.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IMutableModel"/>.
        /// IModelEdit is for external types that require read-write access.
        /// </remarks>
        [Ignore]
        string IMutableCharacterModel.PersonalName
        {
            get => PersonalName;
            set => ((IMutableModel)this).Name = $"{value}{Delimiters.NameDelimiter}{FamilyName}";
        }

        /// <summary>Player-facing family name.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IMutableModel"/>.
        /// IModelEdit is for external types that require read-write access.
        /// </remarks>
        [Ignore]
        string IMutableCharacterModel.FamilyName
        {
            get => FamilyName;
            set => ((IMutableModel)this).Name = $"{PersonalName}{Delimiters.NameDelimiter}{value}";
        }

        /// <summary>
        /// A key for the <see cref="PronounGroup"/> the <see cref="CharacterModel"/> uses,
        /// stored as "<see cref="PronounGroup.Objective"/>/<see cref="PronounGroup.Subjective"/>.
        /// </summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IMutableModel"/>.
        /// IModelEdit is for external types that require read-write access.
        /// </remarks>
        [Ignore]
        string IMutableCharacterModel.PronounKey { get => PronounKey; set => PronounKey = value; }

        /// <summary>The story character that this <see cref="CharacterModel"/> represents.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IMutableModel"/>.
        /// IModelEdit is for external types that require read-write access.
        /// </remarks>
        [Ignore]
        string IMutableCharacterModel.StoryCharacterID { get => StoryCharacterID; set => StoryCharacterID = value; }

        /// <summary>The <see cref="Scripts.InteractionModel"/>s that this <see cref="CharacterModel"/> either offers or has undertaken.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IMutableModel"/>.
        /// IModelEdit is for external types that require read-write access.
        /// </remarks>
        [Ignore]
        IList<ModelID> IMutableCharacterModel.StartingQuestIDs => (IList<ModelID>)StartingQuestIDs;

        /// <summary>Dialogue lines this <see cref="CharacterModel"/> can say.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IMutableModel"/>.
        /// IModelEdit is for external types that require read-write access.
        /// </remarks>
        [Ignore]
        ModelID IMutableCharacterModel.StartingDialogueID { get => StartingDialogueID; set => StartingDialogueID = value; }


        /// <summary>The <see cref="Scripts.InteractionModel"/>s that this <see cref="CharacterModel"/> either offers or has undertaken.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IMutableModel"/>.
        /// IModelEdit is for external types that require read-write access.
        /// </remarks>
        [Ignore]
        Inventory IMutableCharacterModel.StartingInventory => StartingInventory;
        #endregion
    }
}
#endif
