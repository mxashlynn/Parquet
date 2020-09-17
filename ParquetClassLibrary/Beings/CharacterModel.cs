using System;
using System.Collections.Generic;
using System.Linq;
using CsvHelper.Configuration.Attributes;
using ParquetClassLibrary.Items;

namespace ParquetClassLibrary.Beings
{
    /// <summary>
    /// Models the definitions of in-game actors that take part in the narrative.
    /// </summary>
    public partial class CharacterModel : BeingModel
    {
        #region Characteristics
        /// <summary>Player-facing personal name.</summary>
        [Ignore]
        public string PersonalName { get; private set; }

        /// <summary>Player-facing family name.</summary>
        [Ignore]
        public string FamilyName { get; private set; }

        /// <summary>
        /// A key for the <see cref="PronounGroup"/> the <see cref="CharacterModel"/> uses,
        /// stored as "<see cref="PronounGroup.Objective"/>/<see cref="PronounGroup.Subjective"/>.
        /// </summary>
        [Index(8)]
        public string Pronouns { get; private set; }

        /// <summary>The story character that this <see cref="CharacterModel"/> represents.</summary>
        /// <remarks>
        /// This identifier provides a link between software character classes
        /// and the characters written of in a game's narrative that they represent.  The goal
        /// is that these identifiers be able to span any number of shipped titles, allowing a
        /// sequel title to import data from prior titles in such a way that one game's NPC
        /// can become another game's protagonist.
        /// </remarks>
        [Index(9)]
        public string StoryCharacterID { get; private set; }

        /// <summary>The <see cref="Scripts.InteractionModel"/>s that this <see cref="CharacterModel"/> either offers or has undertaken.</summary>
        /// <remarks>Typically, NPCs offer quests, player characters undertake them.</remarks>
        [Index(10)]
        public IReadOnlyList<ModelID> StartingQuestIDs { get; }

        /// <summary>Dialogue lines this <see cref="CharacterModel"/> can say at the outset.</summary>
        [Index(11)]
        public ModelID StartingDialogueID { get; private set; }

        /// <summary>The set of belongings that this <see cref="CharacterModel"/> begins with.</summary>
        /// <remarks>
        /// Note that, unlike other members, for technical reasons this property is mutable.
        /// Care should be taken not to alter it during play.
        /// </remarks>
        [Index(12)]
        public Inventory StartingInventory { get; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="CharacterModel"/> class.
        /// </summary>
        /// <param name="inID">Unique identifier for the <see cref="CharacterModel"/>.  Cannot be null.</param>
        /// <param name="inName">Personal and family names of the <see cref="CharacterModel"/>, separated by a space.  Cannot be null or empty.</param>
        /// <param name="inDescription">Player-friendly description of the <see cref="CharacterModel"/>.</param>
        /// <param name="inComment">Comment of, on, or by the <see cref="CharacterModel"/>.</param>
        /// <param name="inNativeBiomeID">The <see cref="ModelID"/> for the <see cref="Biomes.BiomeRecipe"/> in which this <see cref="BeingModel"/> is most comfortable.</param>
        /// <param name="inPrimaryBehaviorID">The rules that govern how this <see cref="CharacterModel"/> acts.  Cannot be null.</param>
        /// <param name="inAvoidsIDs">Any parquets this <see cref="CharacterModel"/> avoids.</param>
        /// <param name="inSeeksIDs">Any parquets this <see cref="CharacterModel"/> seeks.</param>
        /// <param name="inPronouns">How to refer to this <see cref="CharacterModel"/>.</param>
        /// <param name="inStoryCharacterID">A means of identifying this <see cref="CharacterModel"/> across multiple shipped game titles.</param>
        /// <param name="inStartingQuestIDs">Any quests this <see cref="CharacterModel"/> has to offer or has undertaken.</param>
        /// <param name="inStartingDialogueID">All dialogue this <see cref="CharacterModel"/> may say.</param>
        /// <param name="inStartingInventory">Any items this <see cref="CharacterModel"/> possesses at the outset.</param>
        public CharacterModel(ModelID inID, string inName, string inDescription, string inComment, ModelID? inNativeBiomeID = null,
                              ModelID? inPrimaryBehaviorID = null, IEnumerable<ModelID> inAvoidsIDs = null,
                              IEnumerable<ModelID> inSeeksIDs = null, string inPronouns = PronounGroup.DefaultKey,
                              string inStoryCharacterID = "", IEnumerable<ModelID> inStartingQuestIDs = null,
                              ModelID? inStartingDialogueID = null, Inventory inStartingInventory = null)
            : base(All.CharacterIDs, inID, inName, inDescription, inComment,
                   inNativeBiomeID, inPrimaryBehaviorID, inAvoidsIDs, inSeeksIDs)
        {
            var nonNullQuestIDs = inStartingQuestIDs ?? Enumerable.Empty<ModelID>();
            var nonNullDialogueID = inStartingDialogueID ?? ModelID.None;
            var nonNullInventory = inStartingInventory ?? Inventory.Empty;

            Precondition.AreInRange(nonNullQuestIDs, All.InteractionIDs, nameof(inStartingQuestIDs));
            Precondition.IsInRange(nonNullDialogueID, All.InteractionIDs, nameof(inStartingDialogueID));

            var names = inName?.Split(Delimiters.NameDelimiter) ?? new string[] { "" };
            PersonalName = names[0];
            FamilyName = names.Length > 1
                ? names[1]
                : "";
            Pronouns = inPronouns;
            StoryCharacterID = inStoryCharacterID;
            StartingQuestIDs = nonNullQuestIDs.ToList();
            StartingDialogueID = nonNullDialogueID;
            StartingInventory = nonNullInventory;
        }
        #endregion
    }
}
