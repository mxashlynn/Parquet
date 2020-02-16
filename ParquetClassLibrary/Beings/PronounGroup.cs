using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
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
        public const string DefaultKey = "they/them";

        /// <summary>A pronoun to use when none is specified.</summary>
        public static readonly PronounGroup DefaultGroup = new PronounGroup("they", "them", "their", "theirs", "themself");
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

        #region Self Serialization
        /// <summary>
        /// Reads all <see cref="PronounGroup"/> records from the appropriate file.
        /// </summary>
        /// <returns>The instances read.</returns>
        public static HashSet<PronounGroup> GetRecords()
        {
            using var reader = new StreamReader($"{All.WorkingDirectory}/{nameof(PronounGroup)}s.csv");
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            csv.Configuration.TypeConverterOptionsCache.AddOptions(typeof(EntityID), All.IdentifierOptions);
            csv.Configuration.PrepareHeaderForMatch = (string header, int index) => header.StartsWith("in", StringComparison.InvariantCulture)
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

            using var writer = new StreamWriter($"{All.WorkingDirectory}/{nameof(PronounGroup)}s.csv");
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.Configuration.TypeConverterOptionsCache.AddOptions(typeof(EntityID), All.IdentifierOptions);
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
        /// Returns a <see langword="string"/> that represents the <see cref="PronounGroup"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override string ToString()
            => $"{Subjective}/{Objective}/{Determiner}/{Possessive}/{Reflexive}";
        #endregion
    }
}
