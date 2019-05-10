using System.Collections.Generic;
using System.Linq;
using ParquetClassLibrary.Biomes;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Characters
{
    public abstract class Character : Being
    {
        #region Class Defaults
        /// <summary>A pronoun to use when none is specified.</summary>
        // TODO This is just a place-holder, I am not sure yet how we will handle pronouns.
        public const string DefaultPronoun = "they";
        #endregion

        #region Characteristics
        /// <summary>Player-facing personal name.</summary>
        public string PersonalName { get; }

        /// <summary>Player-facing family name.</summary>
        public string FamilyName { get; }

        /// <summary>Player-facing full name.</summary>
        public string FullName => Name;

        /// <summary>The pronouns the <see cref="Character"/> uses.</summary>
        // TODO This is just a place-holder, I am not sure yet how we will handle pronouns.
        public string Pronoun { get; }

        /// <summary>The story character that this <see cref="Character"/> represents.</summary>
        /// <remarks>
        /// This identifier provides a link between software character <see langword="class"/>es
        /// and the characters written of in a game's narrative that they represent.  The goal
        /// is that these identifiers be able to span any number of shipped titles, allowing a
        /// sequel title to import data from prior titles in such a way that an one game's <see cref="NPC"/>
        /// can become another game's <see cref="PlayerCharacter"/>.
        /// </remarks>
        public string StoryCharacterID { get; }

        /// <summary>The <see cref="Quests.Quest"/>s that this <see cref="Character"/> either offers or has undertaken.</summary>
        /// <remarks><see cref="NPC"/>s offer quests, <see cref="PlayerCharacter"/>s undertake them.</remarks>
        public IReadOnlyList<EntityID> StartingQuests { get; }

        /// <summary>Dialogue lines this <see cref="Character"/> can say.</summary>
        // TODO This is just a place-holder, I am not at all sure how we will handle this.
        public IReadOnlyList<string> Dialogue { get; }

        /// <summary>The set of belongings that this <see cref="Character"/> begins with.</summary>
        /// <remarks>This is not the full <see cref="Items.Inventory"/> but a list of item IDs to populate it with.</remarks>
        public IReadOnlyList<EntityID> StartingInventory { get; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="Character"/> class.
        /// </summary>
        /// <param name="in_bounds">
        /// The bounds within which the <see cref="Character"/>'s <see cref="EntityID"/> is defined.
        /// Must be one of <see cref="All.BeingIDs"/>.
        /// </param>
        /// <param name="in_id">Unique identifier for the <see cref="Character"/>.  Cannot be null.</param>
        /// <param name="in_description">Player-friendly description of the <see cref="Character"/>.</param>
        /// <param name="in_comment">Comment of, on, or by the <see cref="Character"/>.</param>
        /// <param name="in_personalName">Personal name of the <see cref="Character"/>.  Cannot be null or empty.</param>
        /// <param name="in_familyName">Family name of the <see cref="Character"/>.  Cannot be null or empty.</param>
        /// <param name="in_primaryBehavior">The rules that govern how this <see cref="Character"/> acts.  Cannot be null.</param>
        /// <param name="in_avoids">Any parquets this <see cref="Character"/> avoids.</param>
        /// <param name="in_seeks">Any parquets this <see cref="Character"/> seeks.</param>
        /// <param name="in_pronoun">How to refer to this <see cref="Character"/>.</param>
        /// <param name="in_storyCharacterID">A means of identifying this <see cref="Character"/> across multiple shipped game titles.</param>
        /// <param name="in_startingQuests">Any quests this <see cref="Character"/> has to offer or has undertaken.</param>
        /// <param name="in_dialogue">All dialogue this <see cref="Character"/> may say.</param>
        /// <param name="in_startingInventory">Any items this <see cref="Character"/> owns at the outset.</param>
        protected Character(Range<EntityID> in_bounds, EntityID in_id,
                            string in_personalName, string in_familyName,
                            string in_description, string in_comment, EntityID in_nativeBiome,
                            Behavior in_primaryBehavior, List<EntityID> in_avoids = null,
                            List<EntityID> in_seeks = null, string in_pronoun = DefaultPronoun,
                            string in_storyCharacterID = "", List<EntityID> in_startingQuests = null,
                            List<string> in_dialogue = null, List<EntityID> in_startingInventory = null)
            : base(in_bounds, in_id, $"{in_personalName} {in_familyName}", in_description, in_comment,
                   in_nativeBiome, in_primaryBehavior, in_avoids, in_seeks)
        {
            var nonNullPronoun = string.IsNullOrEmpty(in_pronoun) ? DefaultPronoun : in_pronoun;
            var nonNullQuests = in_startingQuests ?? Enumerable.Empty<EntityID>();
            var nonNullInventory = in_startingInventory ?? Enumerable.Empty<EntityID>();

            Precondition.AreInRange(nonNullQuests, All.QuestIDs, nameof(in_startingQuests));
            Precondition.AreInRange(nonNullInventory, All.ItemIDs, nameof(in_startingInventory));
            Precondition.IsNotEmpty(in_personalName, nameof(in_personalName));
            Precondition.IsNotEmpty(in_familyName, nameof(in_familyName));

            PersonalName = in_personalName;
            FamilyName = in_familyName;
            Pronoun = nonNullPronoun;
            StoryCharacterID = in_storyCharacterID;
            StartingQuests = nonNullQuests.ToList();
            Dialogue = (in_dialogue ?? Enumerable.Empty<string>()).ToList();
            StartingInventory = nonNullInventory.ToList();
        }
        #endregion
    }
}
