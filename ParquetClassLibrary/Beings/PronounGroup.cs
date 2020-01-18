using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Beings
{
    /// <summary>
    /// A group of personal pronouns used together to indicate an individual, potentially communicating both their plurality and their gender.
    /// </summary>
    public sealed class PronounGroup : IPronounGroupEdit
    {
        #region Class Defaults
        /// <summary>A pronoun to use when none is specified.</summary>
        public static readonly PronounGroup Default = new PronounGroup("they", "them", "their", "theirs", "themselves");
        #endregion

        #region Textual Tags
        /// <summary>Indicates the <see cref="Subjective"/> should be used.</summary>
        public const string SubjectiveTag = "%they%";

        /// <summary>Indicates the <see cref="Objective"/> should be used.</summary>
        public const string ObjectiveTag = "%them%";

        /// <summary>Indicates the <see cref="Determiner"/> should be used.</summary>
        public const string DeterminerTag = "%their%";

        /// <summary>Indicates the <see cref="Possessive"/> should be used.</summary>
        public const string PossessiveTag = "%theirs%";

        /// <summary>Indicates the <see cref="Reflexive"/> should be used.</summary>
        public const string ReflexiveTag = "%themselves%";
        #endregion

        #region Pronoun Properties
        /// <summary>Personal pronoun used as the subject of a verb.</summary>
        public string Subjective { get; private set; }

        /// <summary>Personal pronoun used as the subject of a verb.</summary>
        string IPronounGroupEdit.Subjective { get => Subjective; set => Subjective = value; }

        /// <summary>Personal pronoun used as the indirect object of a preposition or verb.</summary>
        public string Objective { get; private set; }

        /// <summary>Personal pronoun used as the indirect object of a preposition or verb.</summary>
        string IPronounGroupEdit.Objective { get => Objective; set => Objective = value; }

        /// <summary>Personal pronoun used to attribute possession.</summary>
        public string Determiner { get; private set; }

        /// <summary>Personal pronoun used to attribute possession.</summary>
        string IPronounGroupEdit.Determiner { get => Determiner; set => Determiner = value; }

        /// <summary>Personal pronoun used to indicate a relationship.</summary>
        public string Possessive { get; private set; }

        /// <summary>Personal pronoun used to indicate a relationship.</summary>
        string IPronounGroupEdit.Possessive { get => Possessive; set => Possessive = value; }

        /// <summary>Personal pronoun used to indicate the user.</summary>
        public string Reflexive { get; private set; }

        /// <summary>Personal pronoun used to indicate the user.</summary>
        string IPronounGroupEdit.Reflexive { get => Reflexive; set => Reflexive = value; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="PronounGroup"/> class.
        /// </summary>
        /// <param name="inSubjective">Personal pronoun used as the subject of a verb.  Cannot be null or empty.</param>
        /// <param name="inObjective">Personal pronoun used as the indirect object of a preposition or verb.  Cannot be null or empty.</param>
        /// <param name="inPossessiveDeterminer">Personal pronoun used to modify a noun attributing possession.  Cannot be null or empty.</param>
        /// <param name="inPossessivePronoun">Personal pronoun used to indicate a relationship in a broad sense.  Cannot be null or empty.</param>
        /// <param name="inReflexive">Personal pronoun used as a coreferential to indicate the user.  Cannot be null or empty.</param>
        public PronounGroup(string inSubjective, string inObjective, string inPossessiveDeterminer,
                        string inPossessivePronoun, string inReflexive)
        {
            Precondition.IsNotNullOrEmpty(inSubjective, nameof(inSubjective));
            Precondition.IsNotNullOrEmpty(inSubjective, nameof(inSubjective));
            Precondition.IsNotNullOrEmpty(inSubjective, nameof(inSubjective));
            Precondition.IsNotNullOrEmpty(inSubjective, nameof(inSubjective));
            Precondition.IsNotNullOrEmpty(inSubjective, nameof(inSubjective));

            Subjective = inSubjective;
            Objective = inObjective;
            Determiner = inPossessiveDeterminer;
            Possessive = inPossessivePronoun;
            Reflexive = inReflexive;
        }
        #endregion

        #region Utilities
        /// <summary>
        /// Returns a <see langword="string"/> that represents the <see cref="PronounGroup"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override string ToString()
            => $"{Subjective}/{Objective}/{Determiner}/{Possessive}/{Reflexive}";
        #endregion
    }
}
