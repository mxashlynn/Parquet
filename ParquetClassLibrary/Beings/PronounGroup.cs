using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;

namespace Parquet.Beings
{
    /// <summary>
    /// A group of personal pronouns used together to indicate a <see cref="BeingModel"/>,
    /// potentially communicating both their plurality and their gender.
    /// Instances of this class are mutable during play.
    /// </summary>
    [SuppressMessage("Design", "CA1033:Interface methods should be callable by subtypes",
                     Justification = "By design, subtypes of Model should never themselves use IMutableModel or derived interfaces to access their own members.  The IMutableModel family of interfaces is for external types that require read/write access.")]
    public class PronounGroup : IMutablePronounGroup
    {
        #region Class Defaults
        /// <summary>A pronoun to use when none is specified.</summary>
        public const string DefaultKey = "they/them";

        /// <summary>A pronoun to use when none is specified.</summary>
        public static readonly PronounGroup DefaultGroup = new("they", "them", "their", "theirs", "themself");
        #endregion

        #region Textual Tags
        /// <summary>Indicates the <see cref="Subjective"/> should be used.</summary>
        public const string SubjectiveTag = Delimiters.PronounDelimiter + "they" + Delimiters.PronounDelimiter;

        /// <summary>Indicates the <see cref="Objective"/> should be used.</summary>
        public const string ObjectiveTag = Delimiters.PronounDelimiter + "them" + Delimiters.PronounDelimiter;

        /// <summary>Indicates the <see cref="Determiner"/> should be used.</summary>
        public const string DeterminerTag = Delimiters.PronounDelimiter + "their" + Delimiters.PronounDelimiter;

        /// <summary>Indicates the <see cref="Possessive"/> should be used.</summary>
        public const string PossessiveTag = Delimiters.PronounDelimiter + "theirs" + Delimiters.PronounDelimiter;

        /// <summary>Indicates the <see cref="Reflexive"/> should be used.</summary>
        public const string ReflexiveTag = Delimiters.PronounDelimiter + "themselves" + Delimiters.PronounDelimiter;
        #endregion

        #region Characteristics
        /// <summary>Personal pronoun used as the subject of a verb.</summary>
        [Index(0)]
        public string Subjective { get; private set; }

        /// <summary>Personal pronoun used as the indirect object of a preposition or verb.</summary>
        [Index(1)]
        public string Objective { get; private set; }

        /// <summary>Personal pronoun used to attribute possession.</summary>
        [Index(2)]
        public string Determiner { get; private set; }

        /// <summary>Personal pronoun used to indicate a relationship.</summary>
        [Index(3)]
        public string Possessive { get; private set; }

        /// <summary>Personal pronoun used to indicate the user.</summary>
        [Index(4)]
        public string Reflexive { get; private set; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="PronounGroup"/> class.
        /// </summary>
        /// <param name="subjective">Personal pronoun used as the subject of a verb.  Cannot be null or empty.</param>
        /// <param name="objective">Personal pronoun used as the indirect object of a preposition or verb.  Cannot be null or empty.</param>
        /// <param name="determiner">Personal pronoun used to modify a noun attributing possession.  Cannot be null or empty.</param>
        /// <param name="possessive">Personal pronoun used to indicate a relationship in a broad sense.  Cannot be null or empty.</param>
        /// <param name="reflexive">Personal pronoun used as a coreferential to indicate the user.  Cannot be null or empty.</param>
        public PronounGroup(string subjective, string objective, string determiner,
                            string possessive, string reflexive)
        {
            Precondition.IsNotNullOrEmpty(subjective, nameof(subjective));
            Precondition.IsNotNullOrEmpty(subjective, nameof(subjective));
            Precondition.IsNotNullOrEmpty(subjective, nameof(subjective));
            Precondition.IsNotNullOrEmpty(subjective, nameof(subjective));
            Precondition.IsNotNullOrEmpty(subjective, nameof(subjective));

            Subjective = subjective;
            Objective = objective;
            Determiner = determiner;
            Possessive = possessive;
            Reflexive = reflexive;
        }
        #endregion

        #region IMutablePronounGroup Implementation
        /// <summary>Personal pronoun used as the subject of a verb.</summary>
        [Ignore]
        string IMutablePronounGroup.Subjective
        {
            get => Subjective;
            set => Subjective = LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(Subjective), Subjective)
                : value;
        }

        /// <summary>Personal pronoun used as the indirect object of a preposition or verb.</summary>
        [Ignore]
        string IMutablePronounGroup.Objective
        {
            get => Objective;
            set => Objective = LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(Objective), Objective)
                : value;
        }

        /// <summary>Personal pronoun used to attribute possession.</summary>
        [Ignore]
        string IMutablePronounGroup.Determiner
        {
            get => Determiner;
            set => Determiner = LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(Determiner), Determiner)
                : value;
        }

        /// <summary>Personal pronoun used to indicate a relationship.</summary>
        [Ignore]
        string IMutablePronounGroup.Possessive
        {
            get => Possessive;
            set => Possessive = LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(Possessive), Possessive)
                : value;
        }

        /// <summary>Personal pronoun used to indicate the user.</summary>
        [Ignore]
        string IMutablePronounGroup.Reflexive
        {
            get => Reflexive;
            set => Reflexive = LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(Reflexive), Reflexive)
                : value;
        }
        #endregion

        #region Self Serialization
        /// <summary>
        /// Reads all <see cref="PronounGroup"/> records from the appropriate file.
        /// </summary>
        /// <returns>The instances read.</returns>
        public static HashSet<PronounGroup> GetRecords()
        {
            using var reader = new StreamReader(FilePath);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            csv.Configuration.TypeConverterOptionsCache.AddOptions(typeof(ModelID), All.IdentifierOptions);
            csv.Configuration.PrepareHeaderForMatch = (string header, int index) => header.ToUpperInvariant();
            foreach (var kvp in All.ConversionConverters)
            {
                csv.Configuration.TypeConverterCache.AddConverter(kvp.Key, kvp.Value);
            }

            return new HashSet<PronounGroup>(csv.GetRecords<PronounGroup>());
        }

        /// <summary>
        /// Writes the given <see cref="PronounGroup"/> records to the appropriate file.
        /// </summary>
        public static void PutRecords(IEnumerable<PronounGroup> groups)
        {
            Precondition.IsNotNull(groups);

            using var writer = new StreamWriter(FilePath, false, new UTF8Encoding(true, true));
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.Configuration.NewLine = NewLine.LF;
            csv.Configuration.TypeConverterOptionsCache.AddOptions(typeof(ModelID), All.IdentifierOptions);
            foreach (var kvp in All.ConversionConverters)
            {
                csv.Configuration.TypeConverterCache.AddConverter(kvp.Key, kvp.Value);
            }

            csv.WriteHeader<PronounGroup>();
            csv.NextRecord();
            csv.WriteRecords(groups);
        }
        #endregion

        #region Utilities
        /// <summary>
        /// Returns the filename and path associated with <see cref="PronounGroup"/>'s definition file.
        /// </summary>
        /// <returns>A full path to the associated file.</returns>
        public static string FilePath
            => $"{All.ProjectDirectory}/{nameof(PronounGroup)}s.csv";

        /// <summary>
        /// Replaces pronoun tags with the appropriate pronoun from the given <see cref="PronounGroup"/>.
        /// </summary>
        /// <param name="text">The text to transform.</param>
        /// <returns>The updated text.</returns>
        public StringBuilder FillInPronouns(StringBuilder text)
            => text?
                .Replace(SubjectiveTag, Subjective)
                .Replace(ObjectiveTag, Objective)
                .Replace(DeterminerTag, Determiner)
                .Replace(PossessiveTag, Possessive)
                .Replace(ReflexiveTag, Reflexive);

        /// <summary>
        /// Replaces pronoun tags with the appropriate pronoun from the given <see cref="PronounGroup"/>.
        /// </summary>
        /// <param name="text">The text to transform.</param>
        /// <returns>The updated text.</returns>
        public StringBuilder FillInPronouns(string text)
            => new StringBuilder(text)
                .Replace(SubjectiveTag, Subjective)
                .Replace(ObjectiveTag, Objective)
                .Replace(DeterminerTag, Determiner)
                .Replace(PossessiveTag, Possessive)
                .Replace(ReflexiveTag, Reflexive);

        /// <summary>
        /// Returns a <see cref="string"/> to use as shorthand for the <see cref="PronounGroup"/>.
        /// </summary>
        /// <returns>The shorthand.</returns>
        [Ignore]
        public string Key
            => $"{Subjective}/{Objective}";

        /// <summary>
        /// Returns a <see cref="string"/> that represents the <see cref="PronounGroup"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override string ToString()
            => $"{Subjective}/{Objective}/{Determiner}/{Possessive}/{Reflexive}";
        #endregion
    }
}
