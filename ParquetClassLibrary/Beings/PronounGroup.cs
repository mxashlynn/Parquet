using System;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Beings
{
    /// <summary>
    /// A group of personal pronouns used together to indicate an individual, potentially communicating both their plurality and their gender.
    /// </summary>
    public sealed class PronounGroup : IPronounGroupEdit, ITypeConverter
    {
        #region Class Defaults
        /// <summary>A pronoun to use when none is specified.</summary>
        public const string Default = "they/them";
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

        #region Pronouns
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
        /// <param name="inDeterminer">Personal pronoun used to modify a noun attributing possession.  Cannot be null or empty.</param>
        /// <param name="inPossessive">Personal pronoun used to indicate a relationship in a broad sense.  Cannot be null or empty.</param>
        /// <param name="inReflexive">Personal pronoun used as a coreferential to indicate the user.  Cannot be null or empty.</param>
        public PronounGroup(string inSubjective, string inObjective, string inDeterminer,
                            string inPossessive, string inReflexive)
        {
            Precondition.IsNotNullOrEmpty(inSubjective, nameof(inSubjective));
            Precondition.IsNotNullOrEmpty(inSubjective, nameof(inSubjective));
            Precondition.IsNotNullOrEmpty(inSubjective, nameof(inSubjective));
            Precondition.IsNotNullOrEmpty(inSubjective, nameof(inSubjective));
            Precondition.IsNotNullOrEmpty(inSubjective, nameof(inSubjective));

            Subjective = inSubjective;
            Objective = inObjective;
            Determiner = inDeterminer;
            Possessive = inPossessive;
            Reflexive = inReflexive;
        }
        #endregion

        #region ITypeConverter Implementation
        /// <summary>Allows the converter to construct itself without exposing a public parameterless constructor.</summary>
        internal static readonly PronounGroup ConverterFactory =
            new PronounGroup(nameof(Subjective), nameof(Objective), nameof(Determiner), nameof(Possessive), nameof(Reflexive));

        /// <summary>
        /// Converts the given <see cref="object"/> to a <see cref="string"/> for serialization.
        /// </summary>
        /// <param name="value">The instance to convert.</param>
        /// <param name="row">The current context and configuration.</param>
        /// <param name="memberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance serialized.</returns>
        public string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
        {
        }

        /// <summary>
        /// Converts the given <see cref="string"/> to an <see cref="object"/> as deserialization.
        /// </summary>
        /// <param name="text">The text to convert.</param>
        /// <param name="row">The current context and configuration.</param>
        /// <param name="memberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance deserialized.</returns>
        public object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
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
