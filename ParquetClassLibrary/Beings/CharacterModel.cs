using System.Collections.Generic;
using System.Linq;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Beings
{
    /// <summary>
    /// Models the definitions shared by in-game actors that take part in the narrative.
    /// </summary>
    public abstract class CharacterModel : BeingModel
    {
        #region Characteristics
        /// <summary>Player-facing personal name.</summary>
        public string PersonalName { get; }

        /// <summary>Player-facing family name.</summary>
        public string FamilyName { get; }

        /// <summary>Player-facing full name.</summary>
        public string FullName => Name;

        /// <summary>
        /// A key for the <see cref="PronounGroup"/> the <see cref="CharacterModel"/> uses,
        /// stored as "<see cref="PronounGroup.Objective"/>/<see cref="PronounGroup.Subjective"/>.
        /// </summary>
        public string Pronouns { get; }

        /// <summary>The story character that this <see cref="CharacterModel"/> represents.</summary>
        /// <remarks>
        /// This identifier provides a link between software character <see langword="class"/>es
        /// and the characters written of in a game's narrative that they represent.  The goal
        /// is that these identifiers be able to span any number of shipped titles, allowing a
        /// sequel title to import data from prior titles in such a way that one game's <see cref="NPCModel"/>
        /// can become another game's <see cref="PlayerCharacterModel"/>.
        /// </remarks>
        public string StoryCharacterID { get; }

        /// <summary>The <see cref="Quests.QuestModel"/>s that this <see cref="CharacterModel"/> either offers or has undertaken.</summary>
        /// <remarks><see cref="NPCModel"/>s offer quests, <see cref="PlayerCharacterModel"/>s undertake them.</remarks>
        public IReadOnlyList<EntityID> StartingQuests { get; }

        /// <summary>Dialogue lines this <see cref="CharacterModel"/> can say.</summary>
        public IReadOnlyList<string> Dialogue { get; }

        /// <summary>The set of belongings that this <see cref="CharacterModel"/> begins with.</summary>
        /// <remarks>This is not the full <see cref="Items.Inventory"/> but a list of item IDs to populate it with.</remarks>
        public IReadOnlyList<EntityID> StartingInventory { get; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="CharacterModel"/> class.
        /// </summary>
        /// <param name="inBounds">
        /// The bounds within which the <see cref="CharacterModel"/>'s <see cref="EntityID"/> is defined.
        /// Must be one of <see cref="All.BeingIDs"/>.
        /// </param>
        /// <param name="inID">Unique identifier for the <see cref="CharacterModel"/>.  Cannot be null.</param>
        /// <param name="inPersonalName">Personal name of the <see cref="CharacterModel"/>.  Cannot be null or empty.</param>
        /// <param name="inFamilyName">Family name of the <see cref="CharacterModel"/>.  Cannot be null or empty.</param>
        /// <param name="inDescription">Player-friendly description of the <see cref="CharacterModel"/>.</param>
        /// <param name="inComment">Comment of, on, or by the <see cref="CharacterModel"/>.</param>
        /// <param name="inNativeBiome">The <see cref="EntityID"/> for the <see cref="Biomes.BiomeModel"/> in which this <see cref="BeingModel"/> is most comfortable.</param>
        /// <param name="inPrimaryBehavior">The rules that govern how this <see cref="CharacterModel"/> acts.  Cannot be null.</param>
        /// <param name="inAvoids">Any parquets this <see cref="CharacterModel"/> avoids.</param>
        /// <param name="inSeeks">Any parquets this <see cref="CharacterModel"/> seeks.</param>
        /// <param name="inPronouns">How to refer to this <see cref="CharacterModel"/>.</param>
        /// <param name="inStoryCharacterID">A means of identifying this <see cref="CharacterModel"/> across multiple shipped game titles.</param>
        /// <param name="inStartingQuests">Any quests this <see cref="CharacterModel"/> has to offer or has undertaken.</param>
        /// <param name="inDialogue">All dialogue this <see cref="CharacterModel"/> may say.</param>
        /// <param name="inStartingInventory">Any items this <see cref="CharacterModel"/> possesses at the outset.</param>
        protected CharacterModel(Range<EntityID> inBounds, EntityID inID,
                                 string inPersonalName, string inFamilyName,
                                 string inDescription, string inComment, EntityID inNativeBiome,
                                 Behavior inPrimaryBehavior, List<EntityID> inAvoids = null,
                                 List<EntityID> inSeeks = null, string inPronouns = null,
                                 string inStoryCharacterID = "", List<EntityID> inStartingQuests = null,
                                 List<string> inDialogue = null, List<EntityID> inStartingInventory = null)
            : base(inBounds, inID, $"{inPersonalName} {inFamilyName}", inDescription, inComment,
                   inNativeBiome, inPrimaryBehavior, inAvoids, inSeeks)
        {
            var nonNullQuests = inStartingQuests ?? Enumerable.Empty<EntityID>();
            var nonNullInventory = inStartingInventory ?? Enumerable.Empty<EntityID>();

            Precondition.AreInRange(nonNullQuests, All.QuestIDs, nameof(inStartingQuests));
            Precondition.AreInRange(nonNullInventory, All.ItemIDs, nameof(inStartingInventory));
            Precondition.IsNotNullOrEmpty(inPersonalName, nameof(inPersonalName));
            Precondition.IsNotNullOrEmpty(inFamilyName, nameof(inFamilyName));

            PersonalName = inPersonalName;
            FamilyName = inFamilyName;
            Pronouns = inPronouns ?? PronounGroup.Default;
            StoryCharacterID = inStoryCharacterID;
            StartingQuests = nonNullQuests.ToList();
            Dialogue = (inDialogue ?? Enumerable.Empty<string>()).ToList();
            StartingInventory = nonNullInventory.ToList();
        }
        #endregion
    }
}
