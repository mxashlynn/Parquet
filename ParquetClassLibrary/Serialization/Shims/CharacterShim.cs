using System.Collections.Generic;
using ParquetClassLibrary.Beings;

namespace ParquetClassLibrary.Serialization.Shims
{
    /// <summary>
    /// Provides a default public parameterless constructor for a
    /// <see cref="CharacterModel"/>-like class that CSVHelper can instantiate.
    /// 
    /// Provides the ability to generate a <see cref="CharacterModel"/> from this class.
    /// </summary>
    public abstract class CharacterShim : BeingShim
    {
        /// <summary>Player-facing personal name.</summary>
        public string PersonalName;

        /// <summary>Player-facing family name.</summary>
        public string FamilyName;

        /// <summary>Player-facing full name.</summary>
        public string FullName => Name;

        /// <summary>
        /// A key for the <see cref="PronounGroup"/> the <see cref="CharacterModel"/> uses,
        /// stored as "<see cref="PronounGroup.Objective"/>/<see cref="PronounGroup.Subjective"/>.
        /// </summary>
        public string Pronouns;

        /// <summary>The story character that this <see cref="CharacterModel"/> represents.</summary>
        public string StoryCharacterID;

        /// <summary>The <see cref="Quests.QuestModel"/>s that this <see cref="CharacterModel"/> either offers or has undertaken.</summary>
        public EntityID StartingQuests;
        // TODO public List<EntityID> StartingQuests;

        /// <summary>Dialogue lines this <see cref="CharacterModel"/> can say.</summary>
        public string Dialogue;
        // TODO public List<string> Dialogue;

        /// <summary>The set of belongings that this <see cref="CharacterModel"/> begins with.</summary>
        public EntityID StartingInventory;
        // TODO public List<EntityID> StartingInventory;
    }
}
