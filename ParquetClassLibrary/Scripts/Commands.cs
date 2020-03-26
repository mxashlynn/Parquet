using System;

namespace ParquetClassLibrary.Scripts
{
    /// <summary>
    /// IDs for commands used in <see cref="ScriptNodes"/>.
    /// </summary>
    public static class Commands
    {
        /// <summary>Indicates non-command.  NOP.</summary>
        public const string None = "";

        /// <summary>
        /// IDs for commands used in <see cref="ScriptNodes"/> in longer notation.
        /// </summary>
        public static class LongForm
        {
            /// <summary>Display the given text as an alert by the user interface.</summary>
            public const string Alert = "ALERT";

            /// <summary>Allot the given number and type of <see cref="Items.ItemModel"/> to the given <see cref="Beings.CharacterModel"/>.</summary>
            public const string GiveItem = "GIVEITEM";

            /// <summary>Allot the given <see cref="Interactions.QuestModel"/> to the given <see cref="Beings.CharacterModel"/>.</summary>
            public const string GiveQuest = "GIVEQUEST";

            /// <summary>Immediately load and begin processing the given <see cref="ScriptModel"/>.</summary>
            public const string Jump = "JUMP";

            /// <summary>If the given variable is set, load and begin processing the given <see cref="ScriptModel"/>.</summary>
            public const string JumpIf = "JUMPIF";

            /// <summary>Place the given <see cref="Parquets.ParquetStack"/> at the given <see cref="Location"/>.</summary>
            public const string Put = "PUT";

            /// <summary>Display the given text as dialogue spoken by the given <see cref="Beings.CharacterModel"/>.</summary>
            public const string Say = "SAY";

            /// <summary>Allot the given <see cref="Beings.Behavior"/> to the given <see cref="Beings.CharacterModel"/>.</summary>
            public const string SetBehavior = "SETBEHAVIOR";

            /// <summary>Allot the given <see cref="Interactions.DialogueModel"/> to the given <see cref="Beings.CharacterModel"/>.</summary>
            public const string SetDialogue = "SETDIALOGUE";

            /// <summary>Allot the given <see cref="Beings.PronounGroup"/> to the given <see cref="Beings.CharacterModel"/>.</summary>
            public const string SetPronoun = "SETPRONOUN";

            /// <summary>Allot the given value to the given variable.</summary>
            public const string SetVar = "SETVAR";

            /// <summary>Highlight the given <see cref="Location"/> via the UI, perhaps by camera movement or particle effect.</summary>
            public const string ShowLocation = "SHOWLOCATION";
        }

        /// <summary>
        /// IDs for commands used in <see cref="ScriptNodes"/> in concise notation.
        /// </summary>
        public static class ShortForm
        {
            /// <summary>Display the given text as an alert by the user interface.</summary>
            public const string Alert = "A";

            /// <summary>Allot the given number and type of <see cref="Items.ItemModel"/> to the given <see cref="Beings.CharacterModel"/>.</summary>
            public const string GiveItem = "I";

            /// <summary>Allot the given <see cref="Interactions.QuestModel"/> to the given <see cref="Beings.CharacterModel"/>.</summary>
            public const string GiveQuest = "Q";

            /// <summary>Immediately load and begin processing the given <see cref="ScriptModel"/>.</summary>
            public const string Jump = "J";

            /// <summary>If the given variable is set, load and begin processing the given <see cref="ScriptModel"/>.</summary>
            public const string JumpIf = "F";

            /// <summary>Place the given <see cref="Parquets.ParquetStack"/> at the given <see cref="Location"/>.</summary>
            public const string Put = "P";

            /// <summary>Display the given text as dialogue spoken by the given <see cref="Beings.CharacterModel"/>.</summary>
            public const string Say = "S";

            /// <summary>Allot the given <see cref="Beings.Behavior"/> to the given <see cref="Beings.CharacterModel"/>.</summary>
            public const string SetBehavior = "B";

            /// <summary>Allot the given <see cref="Interactions.DialogueModel"/> to the given <see cref="Beings.CharacterModel"/>.</summary>
            public const string SetDialogue = "D";

            /// <summary>Allot the given <see cref="Beings.PronounGroup"/> to the given <see cref="Beings.CharacterModel"/>.</summary>
            public const string SetPronoun = "R";

            /// <summary>Allot the given value to the given variable.</summary>
            public const string SetVar = "V";

            /// <summary>Highlight the given <see cref="Location"/> via the UI, perhaps by camera movement or particle effect.</summary>
            public const string ShowLocation = "L";
        }

        /// <summary>
        /// Provides an alternative concise syntax.
        /// </summary>
        /// <param name="inCommandText">The long name of the command.</param>
        /// <returns>The short name of the command.  A <see langword="string"/> of length 1 corresponding to the given command text.</returns>
        public static string ToShortForm(string inCommandText)
            => inCommandText switch
            {
                None => "",
                LongForm.Alert => ShortForm.Alert,
                LongForm.GiveItem => ShortForm.GiveItem,
                LongForm.GiveQuest => ShortForm.GiveQuest,
                LongForm.Jump => ShortForm.Jump,
                LongForm.JumpIf => ShortForm.JumpIf,
                LongForm.Put => ShortForm.Put,
                LongForm.Say => ShortForm.Say,
                LongForm.SetBehavior => ShortForm.SetBehavior,
                LongForm.SetDialogue => ShortForm.SetDialogue,
                LongForm.SetPronoun => ShortForm.SetPronoun,
                LongForm.SetVar => ShortForm.SetVar,
                LongForm.ShowLocation => ShortForm.ShowLocation,
                _ => throw new InvalidOperationException($"Unknown {nameof(ScriptNode)} long form '{inCommandText}'."),
            };

        /// <summary>
        /// Provides an standard syntax when given short form syntax.
        /// </summary>
        /// <param name="inCommandText">The short name of the command.</param>
        /// <returns>The long name of the command.  A <see langword="string"/> of length > 1 corresponding to the given command text.</returns>
        public static string ToLongForm(string inCommandText)
            => inCommandText switch
            {
                None => "",
                ShortForm.Alert => LongForm.Alert,
                ShortForm.GiveItem => LongForm.GiveItem,
                ShortForm.GiveQuest => LongForm.GiveQuest,
                ShortForm.Jump => LongForm.Jump,
                ShortForm.JumpIf => LongForm.JumpIf,
                ShortForm.Put => LongForm.Put,
                ShortForm.Say => LongForm.Say,
                ShortForm.SetBehavior => LongForm.SetBehavior,
                ShortForm.SetDialogue => LongForm.SetDialogue,
                ShortForm.SetPronoun => LongForm.SetPronoun,
                ShortForm.SetVar => LongForm.SetVar,
                ShortForm.ShowLocation => LongForm.ShowLocation,
                _ => throw new InvalidOperationException($"Unknown {nameof(ScriptNode)} short form '{inCommandText}'."),
            };
    }
}
