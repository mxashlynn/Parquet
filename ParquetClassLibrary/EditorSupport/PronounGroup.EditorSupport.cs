#if DESIGN
using System;
using ParquetClassLibrary.EditorSupport;
using CsvHelper.Configuration.Attributes;

namespace ParquetClassLibrary.Beings
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1033:Interface methods should be callable by subtypes",
        Justification = "By design, PronounGroup should never use IPronounGroupEdit to access its own members.  The IPronounGroupEdit interface is for external types that require read/write access.")]
    /// </summary>
    public partial class PronounGroup : IPronounGroupEdit
    {
        #region IPronounGroupEdit Implementation
        /// <summary>Personal pronoun used as the subject of a verb.</summary>
        [Ignore]
        string IPronounGroupEdit.Subjective { get => Subjective; set => Subjective = value; }

        /// <summary>Personal pronoun used as the indirect object of a preposition or verb.</summary>
        [Ignore]
        string IPronounGroupEdit.Objective { get => Objective; set => Objective = value; }

        /// <summary>Personal pronoun used to attribute possession.</summary>
        [Ignore]
        string IPronounGroupEdit.Determiner { get => Determiner; set => Determiner = value; }

        /// <summary>Personal pronoun used to indicate a relationship.</summary>
        [Ignore]
        string IPronounGroupEdit.Possessive { get => Possessive; set => Possessive = value; }

        /// <summary>Personal pronoun used to indicate the user.</summary>
        [Ignore]
        string IPronounGroupEdit.Reflexive { get => Reflexive; set => Reflexive = value; }
        #endregion
    }
}
#endif
