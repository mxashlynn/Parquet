namespace ParquetClassLibrary.Scripts
{
    /// <summary>
    /// IDs for commands used in <see cref="ScriptNodes"/>.
    /// </summary>
    public static class Commands
    {
        /// <summary>Indicates non-command.  NOP.</summary>
        public const string None = "";

        /// <summary>Display the given text as an alert by the user interface.</summary>
        public const string Alert = "ALERT";

        /// <summary>Allot the given number and type of <see cref="Items.ItemModel"/> to the given <see cref="Beings.CharacterModel"/>.</summary>
        public const string CharGiveItem = "CHARGIVEITEM";

        /// <summary>Allot the given <see cref="Interactions.QuestModel"/> to the given <see cref="Beings.CharacterModel"/>.</summary>
        public const string CharGiveQuest = "CHARGIVEQUEST";

        /// <summary>Allot the given <see cref="Interactions.DialogueModel"/> to the given <see cref="Beings.CharacterModel"/>.</summary>
        public const string CharSetDialogue = "CHARSETDIALOGUE";

        /// <summary>Allot the given <see cref="Beings.Behavior"/> to the given <see cref="Beings.CharacterModel"/>.</summary>
        public const string CharSetBehavior = "CHARSETBEHAVIOR";

        /// <summary>Allot the given <see cref="Beings.PronounGroup"/> to the given <see cref="Beings.CharacterModel"/>.</summary>
        public const string CharSetPronoun = "CHARSETPRONOUN";

        /// <summary>Immediately load and begin processing the given <see cref="ScriptModel"/>.</summary>
        public const string Jump = "JUMP";

        /// <summary>If the given variable is set, load and begin processing the given <see cref="ScriptModel"/>.</summary>
        public const string JumpIf = "JUMPIF";

        /// <summary>Place the given <see cref="Parquets.ParquetStack"/> at the given <see cref="Location"/>.</summary>
        public const string Put = "PUT";

        /// <summary>Display the given text as dialogue spoken by the given <see cref="Beings.CharacterModel"/>.</summary>
        public const string Say = "SAY";

        /// <summary>Allot the given value to the given variable.</summary>
        public const string Set = "SET";

        /// <summary>Highlight the given <see cref="Location"/> via the UI, perhaps by camera movement or particle effect.</summary>
        public const string ShowLocation = "SHOWLOCATION";
    }
}
