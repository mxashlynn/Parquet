using System.Collections.Generic;
using System.Linq;
using CsvHelper.Configuration.Attributes;

namespace ParquetClassLibrary.Beings
{
    /// <summary>
    /// Models the definitions of in-game actors that take part in the narrative.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1033:Interface methods should be callable by child types",
        Justification = "By design, children of Model should never themselves use IModelEdit or its decendent interfaces to access their own members.  The IModelEdit family of interfaces is for external types that require read/write access.")]
    public class CharacterModel : BeingModel, ICharacterModelEdit
    {
        #region Characteristics
        /// <summary>Player-facing personal name.</summary>
        [Ignore]
        public string PersonalName { get; private set; }

        /// <summary>Player-facing personal name.</summary>
        /// <remarks>
        /// By design, children of <see cref="Model"/> should never themselves use <see cref="IModelEdit"/>.
        /// IModelEdit is for external types that require readwrite access.
        /// </remarks>
        [Ignore]
        string ICharacterModelEdit.PersonalName { get => PersonalName; set => PersonalName = value; }

        /// <summary>Player-facing family name.</summary>
        [Ignore]
        public string FamilyName { get; private set; }

        /// <summary>Player-facing family name.</summary>
        /// <remarks>
        /// By design, children of <see cref="Model"/> should never themselves use <see cref="IModelEdit"/>.
        /// IModelEdit is for external types that require readwrite access.
        /// </remarks>
        [Ignore]
        string ICharacterModelEdit.FamilyName { get => FamilyName; set => FamilyName = value; }

        /// <summary>
        /// A key for the <see cref="PronounGroup"/> the <see cref="CharacterModel"/> uses,
        /// stored as "<see cref="PronounGroup.Objective"/>/<see cref="PronounGroup.Subjective"/>.
        /// </summary>
        [Index(8)]
        public string Pronouns { get; private set; }

        /// <summary>
        /// A key for the <see cref="PronounGroup"/> the <see cref="CharacterModel"/> uses,
        /// stored as "<see cref="PronounGroup.Objective"/>/<see cref="PronounGroup.Subjective"/>.
        /// </summary>
        /// <remarks>
        /// By design, children of <see cref="Model"/> should never themselves use <see cref="IModelEdit"/>.
        /// IModelEdit is for external types that require readwrite access.
        /// </remarks>
        [Ignore]
        string ICharacterModelEdit.Pronouns { get => Pronouns; set => Pronouns = value; }

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

        /// <summary>The story character that this <see cref="CharacterModel"/> represents.</summary>
        /// <remarks>
        /// By design, children of <see cref="Model"/> should never themselves use <see cref="IModelEdit"/>.
        /// IModelEdit is for external types that require readwrite access.
        /// </remarks>
        [Ignore]
        string ICharacterModelEdit.StoryCharacterID { get => StoryCharacterID; set => StoryCharacterID = value; }

        /// <summary>The <see cref="Scripts.InteractionModel"/>s that this <see cref="CharacterModel"/> either offers or has undertaken.</summary>
        /// <remarks>Typically, NPCs offer quests, player characters undertake them.</remarks>
        [Index(10)]
        public IReadOnlyList<ModelID> StartingQuests { get; }

        /// <summary>The <see cref="Scripts.InteractionModel"/>s that this <see cref="CharacterModel"/> either offers or has undertaken.</summary>
        /// <remarks>
        /// By design, children of <see cref="Model"/> should never themselves use <see cref="IModelEdit"/>.
        /// IModelEdit is for external types that require readwrite access.
        /// </remarks>
        [Ignore]
        IList<ModelID> ICharacterModelEdit.StartingQuests => (IList<ModelID>)StartingQuests;

        /// <summary>Dialogue lines this <see cref="CharacterModel"/> can say.</summary>
        [Index(11)]
        public IReadOnlyList<ModelID> StartingDialogue { get; }

        /// <summary>Dialogue lines this <see cref="CharacterModel"/> can say.</summary>
        /// <remarks>
        /// By design, children of <see cref="Model"/> should never themselves use <see cref="IModelEdit"/>.
        /// IModelEdit is for external types that require readwrite access.
        /// </remarks>
        [Ignore]
        IList<ModelID> ICharacterModelEdit.StartingDialogue => (IList<ModelID>)StartingDialogue;

        /// <summary>The set of belongings that this <see cref="CharacterModel"/> begins with.</summary>
        /// <remarks>This is not the full <see cref="Items.Inventory"/> but a list of item IDs to populate it with.</remarks>
        [Index(12)]
        public IReadOnlyList<ModelID> StartingInventory { get; }

        /// <summary>The set of belongings that this <see cref="CharacterModel"/> begins with.</summary>
        /// <remarks>
        /// By design, children of <see cref="Model"/> should never themselves use <see cref="IModelEdit"/>.
        /// IModelEdit is for external types that require readwrite access.
        /// </remarks>
        [Ignore]
        IList<ModelID> ICharacterModelEdit.StartingInventory => (IList<ModelID>)StartingInventory;
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="CharacterModel"/> class.
        /// </summary>
        /// <param name="inID">Unique identifier for the <see cref="CharacterModel"/>.  Cannot be null.</param>
        /// <param name="inName">Personal and family names of the <see cref="CharacterModel"/>, separated by a space.  Cannot be null or empty.</param>
        /// <param name="inDescription">Player-friendly description of the <see cref="CharacterModel"/>.</param>
        /// <param name="inComment">Comment of, on, or by the <see cref="CharacterModel"/>.</param>
        /// <param name="inNativeBiome">The <see cref="ModelID"/> for the <see cref="Biomes.BiomeRecipe"/> in which this <see cref="BeingModel"/> is most comfortable.</param>
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

            Precondition.AreInRange(nonNullQuests, All.InteractionIDs, nameof(inStartingQuests));
            Precondition.AreInRange(inStartingDialogue, All.InteractionIDs, nameof(inStartingDialogue));
            Precondition.AreInRange(nonNullInventory, All.ItemIDs, nameof(inStartingInventory));
            Precondition.IsNotNullOrEmpty(inName, nameof(inName));

            var names = inName.Split(Delimiters.NameDelimiter);
            PersonalName = names[0];
            FamilyName = names.Length > 1
                ? names[1]
                : "";
            Pronouns = inPronouns;
            StoryCharacterID = inStoryCharacterID;
            StartingQuests = nonNullQuests.ToList();
            StartingDialogue = nonNullDialogue.ToList();
            StartingInventory = nonNullInventory.ToList();
        }
        #endregion
    }
}
