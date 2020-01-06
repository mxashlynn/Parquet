using System.Collections.Generic;
using ParquetClassLibrary;
using ParquetClassLibrary.Beings;

namespace ParquetCLITool.Shims
{
    /// <summary>
    /// Provides a default public parameterless constructor for a
    /// <see cref="Being"/>-like class that CSVHelper can instantiate.
    /// 
    /// Provides the ability to generate a <see cref="Being"/> from this class.
    /// </summary>
    public abstract class CharacterShim : BeingShim
    {
        /// <summary>Player-facing personal name.</summary>
        public string PersonalName;

        /// <summary>Player-facing family name.</summary>
        public string FamilyName;

        /// <summary>Player-facing full name.</summary>
        public string FullName => Name;

        /// <summary>The pronouns the <see cref="Character"/> uses.</summary>
        public string Pronoun;

        /// <summary>The story character that this <see cref="Character"/> represents.</summary>
        public string StoryCharacterID;

        /// <summary>The <see cref="Quests.Quest"/>s that this <see cref="Character"/> either offers or has undertaken.</summary>
        public List<EntityID> StartingQuests;

        /// <summary>Dialogue lines this <see cref="Character"/> can say.</summary>
        public List<string> Dialogue;

        /// <summary>The set of belongings that this <see cref="Character"/> begins with.</summary>
        public List<EntityID> StartingInventory;
    }
}
