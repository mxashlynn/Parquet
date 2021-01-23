#if DESIGN
using Parquet.EditorSupport;
using CsvHelper.Configuration.Attributes;
using System.Diagnostics.CodeAnalysis;

namespace Parquet.Beings
{
    [SuppressMessage("Design", "CA1033:Interface methods should be callable by subtypes",
                     Justification = "By design, PronounGroup should never use IPronounGroupEdit to access its own members.  The IPronounGroupEdit interface is for external types that require read/write access.")]
    public partial class PronounGroup : IMutablePronounGroup
    {
        #region IPronounGroupEdit Implementation
        /// <summary>Personal pronoun used as the subject of a verb.</summary>
        [Ignore]
        string IMutablePronounGroup.Subjective { get => Subjective; set => Subjective = value; }

        /// <summary>Personal pronoun used as the indirect object of a preposition or verb.</summary>
        [Ignore]
        string IMutablePronounGroup.Objective { get => Objective; set => Objective = value; }

        /// <summary>Personal pronoun used to attribute possession.</summary>
        [Ignore]
        string IMutablePronounGroup.Determiner { get => Determiner; set => Determiner = value; }

        /// <summary>Personal pronoun used to indicate a relationship.</summary>
        [Ignore]
        string IMutablePronounGroup.Possessive { get => Possessive; set => Possessive = value; }

        /// <summary>Personal pronoun used to indicate the user.</summary>
        [Ignore]
        string IMutablePronounGroup.Reflexive { get => Reflexive; set => Reflexive = value; }
        #endregion
    }
}
#endif
