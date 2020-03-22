using System.Collections.Generic;
using System.Linq;
using CsvHelper.Configuration.Attributes;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Beings
{
    /// <summary>
    /// Models the definitions of in-game actors that take part in the narrative.
    /// </summary>
    public class CharacterModel : BeingModel
    {
        #region Characteristics
        /// <summary>Player-facing personal name.</summary>
        [Ignore]
        public string PersonalName { get; }

        /// <summary>Player-facing family name.</summary>
        [Ignore]
        public string FamilyName { get; }

        /// <summary>
        /// A key for the <see cref="PronounGroup"/> the <see cref="CharacterModel"/> uses,
        /// stored as "<see cref="PronounGroup.Objective"/>/<see cref="PronounGroup.Subjective"/>.
        /// </summary>
        [Index(8)]
        public string Pronouns { get; }

        /// <summary>The story character that this <see cref="CharacterModel"/> represents.</summary>
        /// <remarks>
        /// This identifier provides a link between software character <see langword="class"/>es
        /// and the characters written of in a game's narrative that they represent.  The goal
        /// is that these identifiers be able to span any number of shipped titles, allowing a
        /// sequel title to import data from prior titles in such a way that one game's NPC
        /// can become another game's protagonist.
        /// </remarks>
        [Index(9)]
        public string StoryCharacterID { get; }

        /// <summary>The <see cref="Quests.QuestModel"/>s that this <see cref="CharacterModel"/> either offers or has undertaken.</summary>
        /// <remarks>Typically, NPCs offer quests, player characters undertake them.</remarks>
        [Index(10)]
        public IReadOnlyList<ModelID> StartingQuests { get; }

        /// <summary>Dialogue lines this <see cref="CharacterModel"/> can say.</summary>
        [Index(11)]
        public IReadOnlyList<ModelID> StartingDialogue { get; }

        /// <summary>The set of belongings that this <see cref="CharacterModel"/> begins with.</summary>
        /// <remarks>This is not the full <see cref="Items.Inventory"/> but a list of item IDs to populate it with.</remarks>
        [Index(12)]
        public IReadOnlyList<ModelID> StartingInventory { get; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="CharacterModel"/> class.
        /// </summary>
        /// <param name="inID">Unique identifier for the <see cref="CharacterModel"/>.  Cannot be null.</param>
        /// <param name="inName">Personal and family names of the <see cref="CharacterModel"/>, separated by a space.  Cannot be null or empty.</param>
        /// <param name="inDescription">Player-friendly description of the <see cref="CharacterModel"/>.</param>
        /// <param name="inComment">Comment of, on, or by the <see cref="CharacterModel"/>.</param>
        /// <param name="inNativeBiome">The <see cref="ModelID"/> for the <see cref="Biomes.BiomeModel"/> in which this <see cref="BeingModel"/> is most comfortable.</param>
        /// <param name="inPrimaryBehavior">The rules that govern how this <see cref="CharacterModel"/> acts.  Cannot be null.</param>
        /// <param name="inAvoids">Any parquets this <see cref="CharacterModel"/> avoids.</param>
        /// <param name="inSeeks">Any parquets this <see cref="CharacterModel"/> seeks.</param>
        /// <param name="inPronouns">How to refer to this <see cref="CharacterModel"/>.</param>
        /// <param name="inStoryCharacterID">A means of identifying this <see cref="CharacterModel"/> across multiple shipped game titles.</param>
        /// <param name="inStartingQuests">Any quests this <see cref="CharacterModel"/> has to offer or has undertaken.</param>
        /// <param name="inStartingDialogue">All dialogue this <see cref="CharacterModel"/> may say.</param>
        /// <param name="inStartingInventory">Any items this <see cref="CharacterModel"/> possesses at the outset.</param>
        public CharacterModel(ModelID inID, string inName, string inDescription, string inComment, ModelID inNativeBiome,
                              ModelID inPrimaryBehavior, IEnumerable<ModelID> inAvoids = null,
                              IEnumerable<ModelID> inSeeks = null, string inPronouns = PronounGroup.DefaultKey,
                              string inStoryCharacterID = "", IEnumerable<ModelID> inStartingQuests = null,
                              IEnumerable<ModelID> inStartingDialogue = null, IEnumerable<ModelID> inStartingInventory = null)
            : base(All.CharacterIDs, inID, inName, inDescription, inComment,
                   inNativeBiome, inPrimaryBehavior, inAvoids, inSeeks)
        {
            var nonNullQuests = inStartingQuests ?? Enumerable.Empty<ModelID>();
            var nonNullDialogue = inStartingDialogue ?? Enumerable.Empty<ModelID>();
            var nonNullInventory = inStartingInventory ?? Enumerable.Empty<ModelID>();

            Precondition.AreInRange(nonNullQuests, All.QuestIDs, nameof(inStartingQuests));
            Precondition.AreInRange(nonNullInventory, All.ItemIDs, nameof(inStartingInventory));
            Precondition.IsNotNullOrEmpty(inName, nameof(inName));

            var names = inName.Split(Rules.Delimiters.NameDelimiter);
            PersonalName = names[0];
            FamilyName = names.Length > 1
                ? names[1]
                : string.Empty;
            Pronouns = inPronouns;
            StoryCharacterID = inStoryCharacterID;
            StartingQuests = nonNullQuests.ToList();
            StartingDialogue = nonNullDialogue.ToList();
            StartingInventory = nonNullInventory.ToList();
        }
        #endregion
    }
}
