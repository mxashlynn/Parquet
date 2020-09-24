using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;

namespace ParquetClassLibrary.Beings
{
    /// <summary>
    /// A group of personal pronouns used together to indicate an individual, potentially communicating both their plurality and their gender.
    /// </summary>
    public partial class PronounGroup
    {
        #region Class Defaults
        /// <summary>A pronoun to use when none is specified.</summary>
        public const string DefaultKey = "they/them";

        /// <summary>A pronoun to use when none is specified.</summary>
        public static readonly PronounGroup DefaultGroup = new PronounGroup("they", "them", "their", "theirs", "themself");
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

        #region Self Serialization
        /// <summary>
        /// Reads all <see cref="PronounGroup"/> records from the appropriate file.
        /// </summary>
        /// <returns>The instances read.</returns>
        public static HashSet<PronounGroup> GetRecords()
        {
            using var reader = new StreamReader(GetFilePath());
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            csv.Configuration.TypeConverterOptionsCache.AddOptions(typeof(ModelID), All.IdentifierOptions);
            csv.Configuration.PrepareHeaderForMatch =
                (string header, int index)
                    => header.StartsWith("in", StringComparison.InvariantCulture)
                        ? header.Substring(2).ToUpperInvariant()
                        : header.ToUpperInvariant();
            foreach (var kvp in All.ConversionConverters)
            {
                csv.Configuration.TypeConverterCache.AddConverter(kvp.Key, kvp.Value);
            }

            return new HashSet<PronounGroup>(csv.GetRecords<PronounGroup>());
        }

        /// <summary>
        /// Writes all <see cref="PronounGroup"/> records to the appropriate file.
        /// </summary>
        public static void PutRecords(IEnumerable<PronounGroup> inGroups)
        {
            Precondition.IsNotNull(inGroups);

            using var writer = new StreamWriter(GetFilePath(), false, new UTF8Encoding(true, true));
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.Configuration.NewLine = NewLine.LF;
            csv.Configuration.TypeConverterOptionsCache.AddOptions(typeof(ModelID), All.IdentifierOptions);
            foreach (var kvp in All.ConversionConverters)
            {
                csv.Configuration.TypeConverterCache.AddConverter(kvp.Key, kvp.Value);
            }

            csv.WriteHeader<PronounGroup>();
            csv.NextRecord();
            csv.WriteRecords(inGroups);
        }
        #endregion

        #region Utilities
        /// <summary>
        /// Returns the filename and path associated with <see cref="PronounGroup"/>'s definition file.
        /// </summary>
        /// <returns>A full path to the associated file.</returns>
        public static string GetFilePath()
            => $"{All.ProjectDirectory}/{nameof(PronounGroup)}s.csv";

        /// <summary>
        /// Replaces pronoun tags with the appropriate pronoung from the given <see cref="PronounGroup"/>.
        /// </summary>
        /// <param name="inText">The text to transform.</param>
        /// <returns>The updated text.</returns>
        public StringBuilder FillInPronouns(StringBuilder inText)
            => inText?
                .Replace(SubjectiveTag, Subjective)
                .Replace(ObjectiveTag, Objective)
                .Replace(DeterminerTag, Determiner)
                .Replace(PossessiveTag, Possessive)
                .Replace(ReflexiveTag, Reflexive);

        /// <summary>
        /// Replaces pronoun tags with the appropriate pronoung from the given <see cref="PronounGroup"/>.
        /// </summary>
        /// <param name="inText">The text to transform.</param>
        /// <returns>The updated text.</returns>
        public StringBuilder FillInPronouns(string inText)
            => new StringBuilder(inText)
                .Replace(SubjectiveTag, Subjective)
                .Replace(ObjectiveTag, Objective)
                .Replace(DeterminerTag, Determiner)
                .Replace(PossessiveTag, Possessive)
                .Replace(ReflexiveTag, Reflexive);

        /// <summary>
        /// Returns a <see cref="string"/> to use as shorthand for the <see cref="PronounGroup"/>.
        /// </summary>
        /// <returns>The shorthand.</returns>
        public string GetKey()
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
