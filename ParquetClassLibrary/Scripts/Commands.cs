namespace Parquet.Scripts
{
    /// <summary>
    /// IDs for commands used in <see cref="ScriptNode"/>s.
    /// </summary>
    /// <remarks>Note that these commands are encoded in upper case, but the library ignores case when reading or comparing them.</remarks>
    public static class Commands
    {
        /// <summary>Indicates non-command.  NOP.</summary>
        public const string None = "";

        /// <summary>Display the given text as an alert by the user interface.</summary>
        public const string Alert = "A";

        /// <summary>Calls the given <see cref="Beings.CharacterModel"/> to stand near another given <see cref="Beings.CharacterModel"/>.</summary>
        public const string CallCharacter = "C";

        /// <summary>Lower the given flag.</summary>
        public const string ClearFlag = "!";

        /// <summary>Allot the given number and type of <see cref="Items.ItemModel"/> to the given <see cref="Beings.CharacterModel"/>.</summary>
        public const string GiveItem = "I";

        /// <summary>Allot the given <see cref="InteractionModel"/> to the given <see cref="Beings.CharacterModel"/>.</summary>
        public const string GiveQuest = "Q";

        /// <summary>Immediately load and begin processing the given <see cref="ScriptModel"/>.</summary>
        public const string Jump = "J";

        /// <summary>If the given variable is set, load and begin processing the given <see cref="ScriptModel"/>.</summary>
        public const string JumpIf = "F";

        /// <summary>Place the given <see cref="Parquets.ParquetModelPack"/> at the given <see cref="Location"/>.</summary>
        public const string Put = "P";

        /// <summary>Display the given text as dialogue spoken by the given <see cref="Beings.CharacterModel"/>.</summary>
        public const string Say = "S";

        /// <summary>Allot the given <see cref="InteractionModel"/> to the given <see cref="Beings.CharacterModel"/>.</summary>
        public const string SetBehavior = "B";

        /// <summary>Allot the given <see cref="InteractionModel"/> to the given <see cref="Beings.CharacterModel"/>.</summary>
        public const string SetDialogue = "D";

        /// <summary>Allot the given <see cref="Beings.PronounGroup"/> to the given <see cref="Beings.CharacterModel"/>.</summary>
        public const string SetPronoun = "R";

        /// <summary>Raise the given flag.</summary>
        public const string SetFlag = "=";

        /// <summary>Highlight the given <see cref="Location"/> via the UI, perhaps by camera movement or particle effect.</summary>
        public const string ShowLocation = "L";
    }
}
