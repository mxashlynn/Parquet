using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using CsvHelper.Configuration.Attributes;
using Parquet.Items;

namespace Parquet.Beings
{
    /// <summary>
    /// Models the definitions of in-game actors that take part in the narrative.
    /// </summary>
    [SuppressMessage("Design", "CA1033:Interface methods should be callable by subtypes",
                     Justification = "By design, subtypes of Model should never themselves use IMutableModel or derived interfaces to access their own members.  The IMutableModel family of interfaces is for external types that require read/write access.")]
    public class CharacterModel : BeingModel, IMutableCharacterModel
    {
        #region Class Defaults
        /// <summary>Indicates an uninitialized character.</summary>
        public static CharacterModel Unused { get; } = new CharacterModel(ModelID.None, nameof(Unused), "", "");
        #endregion

        #region Characteristics
        /// <summary>Player-facing personal name.</summary>
        [Ignore]
        public string PersonalName => Name?.Split(Delimiters.NameDelimiter)[0] ?? "";

        /// <summary>Player-facing family name.</summary>
        [Ignore]
        public string FamilyName
        {
            get
            {
                var names = Name?.Split(Delimiters.NameDelimiter) ?? new string[] { "" };
                return names.Length > 1
                    ? names[1]
                    : "";
            }
        }

        /// <summary>
        /// A key for the <see cref="PronounGroup"/> the <see cref="CharacterModel"/> uses,
        /// stored as "<see cref="PronounGroup.Objective"/>/<see cref="PronounGroup.Subjective"/>.
        /// </summary>
        [Index(9)]
        public string PronounKey { get; private set; }

        /// <summary>The story character that this <see cref="CharacterModel"/> represents.</summary>
        /// <remarks>
        /// This identifier provides a link between software character classes
        /// and the characters written of in a game's narrative that they represent.  The goal
        /// is that these identifiers be able to span any number of shipped titles, allowing a
        /// sequel title to import data from prior titles in such a way that one game's NPC
        /// can become another game's protagonist.
        /// </remarks>
        [Index(10)]
        public string StoryCharacterID { get; private set; }

        /// <summary>The <see cref="Location"/> the <see cref="CharacterModel"/> begins at.</summary>
        [Index(11)]
        public Location StartingLocation { get; private set; }

        /// <summary>The <see cref="Scripts.InteractionModel"/>s that this <see cref="CharacterModel"/> either offers or has undertaken.</summary>
        /// <remarks>Typically, NPCs offer quests, player characters undertake them.</remarks>
        [Index(12)]
        public IReadOnlyList<ModelID> StartingQuestIDs { get; private set; }

        /// <summary>
        /// The <see cref="ModelID"/> of the <see cref="Scripts.InteractionModel"/>that this <see cref="CharacterModel"/>
        /// can say at the outset.
        /// </summary>
        [Index(13)]
        public ModelID StartingDialogueID { get; private set; }

        /// <summary>The set of belongings that this <see cref="CharacterModel"/> begins with.</summary>
        /// <remarks>
        /// Note that, unlike other members, for technical reasons this property is mutable.
        /// Care should be taken not to alter it during play.
        /// </remarks>
        [Index(14)]
        public InventoryCollection StartingInventory { get; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="CharacterModel"/> class.
        /// </summary>
        /// <param name="id">Unique identifier for the <see cref="CharacterModel"/>.  Cannot be null.</param>
        /// <param name="name">Personal and family names of the <see cref="CharacterModel"/>, separated by a space.  Cannot be null or empty.</param>
        /// <param name="description">Player-friendly description of the <see cref="CharacterModel"/>.</param>
        /// <param name="comment">Comment of, on, or by the <see cref="CharacterModel"/>.</param>
        /// <param name="tags">Any additional information about the <see cref="CharacterModel"/>.</param>
        /// <param name="nativeBiomeID">The <see cref="ModelID"/> for the <see cref="Biomes.BiomeRecipe"/> in which this <see cref="CharacterModel"/> is most comfortable.</param>
        /// <param name="primaryBehaviorID">The rules that govern how this <see cref="CharacterModel"/> acts.  Cannot be null.</param>
        /// <param name="avoidsIDs">Any parquets this <see cref="CharacterModel"/> avoids.</param>
        /// <param name="seeksIDs">Any parquets this <see cref="CharacterModel"/> seeks.</param>
        /// <param name="pronounKey">How to refer to this <see cref="CharacterModel"/>.</param>
        /// <param name="storyCharacterID">A means of identifying this <see cref="CharacterModel"/> across multiple shipped game titles.</param>
        /// <param name="startingLocation">The <see cref="Location"/> where this <see cref="CharacterModel"/> begins.</param>
        /// <param name="startingQuestIDs">Any quests this <see cref="CharacterModel"/> has to offer or has undertaken.</param>
        /// <param name="startingDialogueID">All dialogue this <see cref="CharacterModel"/> may say.</param>
        /// <param name="startingInventory">Any items this <see cref="CharacterModel"/> possesses at the outset.</param>
        public CharacterModel(ModelID id, string name, string description, string comment,
                              IEnumerable<ModelTag> tags = null, ModelID? nativeBiomeID = null,
                              ModelID? primaryBehaviorID = null, IEnumerable<ModelID> avoidsIDs = null,
                              IEnumerable<ModelID> seeksIDs = null, string pronounKey = PronounGroup.DefaultKey,
                              string storyCharacterID = "", Location? startingLocation = null,
                              IEnumerable<ModelID> startingQuestIDs = null, ModelID? startingDialogueID = null,
                              InventoryCollection startingInventory = null)
            : base(All.CharacterIDs, id, name, description, comment, tags,
                   nativeBiomeID, primaryBehaviorID, avoidsIDs, seeksIDs)
        {
            var nonNullStartingLocation = startingLocation ?? Location.Nowhere;
            var nonNullQuestIDs = startingQuestIDs ?? Enumerable.Empty<ModelID>();
            var nonNullDialogueID = startingDialogueID ?? ModelID.None;
            var nonNullInventory = startingInventory ?? InventoryCollection.Empty;

            Precondition.AreInRange(nonNullQuestIDs, All.InteractionIDs, nameof(startingQuestIDs));
            Precondition.IsInRange(nonNullDialogueID, All.InteractionIDs, nameof(startingDialogueID));

            PronounKey = pronounKey;
            StoryCharacterID = storyCharacterID;
            StartingLocation = nonNullStartingLocation;
            StartingQuestIDs = nonNullQuestIDs.ToList();
            StartingDialogueID = nonNullDialogueID;
            StartingInventory = nonNullInventory;
        }
        #endregion

        #region IMutableCharacterModel Implementation
        /// <summary>Player-facing personal name.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="CharacterModel"/> should never themselves use <see cref="IMutableCharacterModel"/>.
        /// IMutableCharacterModel is for external types that require read-write access.
        /// </remarks>
        [Ignore]
        string IMutableCharacterModel.PersonalName
        {
            get => PersonalName;
            set => ((IMutableModel)this).Name = ((IMutableModel)this).Name = LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(PersonalName), Name)
                : $"{value}{Delimiters.NameDelimiter}{FamilyName}";
        }

        /// <summary>Player-facing family name.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="CharacterModel"/> should never themselves use <see cref="IMutableCharacterModel"/>.
        /// IMutableCharacterModel is for external types that require read-write access.
        /// </remarks>
        [Ignore]
        string IMutableCharacterModel.FamilyName
        {
            get => FamilyName;
            set => ((IMutableModel)this).Name = LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(FamilyName), Name)
                : $"{PersonalName}{Delimiters.NameDelimiter}{value}";
        }

        /// <summary>
        /// A key for the <see cref="PronounGroup"/> the <see cref="CharacterModel"/> uses,
        /// stored as "<see cref="PronounGroup.Objective"/>/<see cref="PronounGroup.Subjective"/>.
        /// </summary>
        /// <remarks>
        /// By design, subtypes of <see cref="CharacterModel"/> should never themselves use <see cref="IMutableCharacterModel"/>.
        /// IMutableCharacterModel is for external types that require read-write access.
        /// </remarks>
        [Ignore]
        string IMutableCharacterModel.PronounKey
        {
            get => PronounKey;
            set => PronounKey = LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(PronounKey), PronounKey)
                : value;
        }

        /// <summary>The story character that this <see cref="CharacterModel"/> represents.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="CharacterModel"/> should never themselves use <see cref="IMutableCharacterModel"/>.
        /// IMutableCharacterModel is for external types that require read-write access.
        /// </remarks>
        [Ignore]
        string IMutableCharacterModel.StoryCharacterID
        {
            get => StoryCharacterID;
            set => StoryCharacterID = LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(StoryCharacterID), StoryCharacterID)
                : value;
        }

        /// <summary>The <see cref="Location"/> the <see cref="CharacterModel"/> begins at.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="CharacterModel"/> should never themselves use <see cref="IMutableCharacterModel"/>.
        /// IMutableCharacterModel is for external types that require read-write access.
        /// </remarks>
        [Ignore]
        Location IMutableCharacterModel.StartingLocation
        {
            get => StartingLocation;
            set => StartingLocation = LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(StartingLocation), StartingLocation)
                : value;
        }

        /// <summary>The <see cref="Scripts.InteractionModel"/>s that this <see cref="CharacterModel"/> either offers or has undertaken.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="CharacterModel"/> should never themselves use <see cref="IMutableCharacterModel"/>.
        /// IMutableCharacterModel is for external types that require read-write access.
        /// </remarks>
        [Ignore]
        ICollection<ModelID> IMutableCharacterModel.StartingQuestIDs
            => LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(StartingQuestIDs), new Collection<ModelID>())
                : (ICollection<ModelID>)StartingQuestIDs;

        /// <summary>Dialogue lines this <see cref="CharacterModel"/> can say.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="CharacterModel"/> should never themselves use <see cref="IMutableCharacterModel"/>.
        /// IMutableCharacterModel is for external types that require read-write access.
        /// </remarks>
        [Ignore]
        ModelID IMutableCharacterModel.StartingDialogueID
        {
            get => StartingDialogueID;
            set => StartingDialogueID = LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(StartingDialogueID), StartingDialogueID)
                : value;
        }


        /// <summary>The <see cref="Scripts.InteractionModel"/>s that this <see cref="CharacterModel"/> either offers or has undertaken.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="CharacterModel"/> should never themselves use <see cref="IMutableCharacterModel"/>.
        /// IMutableCharacterModel is for external types that require read-write access.
        /// </remarks>
        [Ignore]
        InventoryCollection IMutableCharacterModel.StartingInventory
            => LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(StartingInventory), InventoryCollection.Empty)
                : StartingInventory;
        #endregion
    }
}
