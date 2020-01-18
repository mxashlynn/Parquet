using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Beings
{
    /// <summary>
    /// Facilitates editing of an <see cref="PronounGroup"/> from design tools while maintaining a read-only face for use during play.
    /// </summary>
    public interface IPronounGroupEdit
    {
        /// <summary>Personal pronoun used as the subject of a verb.</summary>
        public string Subjective { get; set; }

        /// <summary>Personal pronoun used as the indirect object of a preposition or verb.</summary>
        public string Objective { get; set; }

        /// <summary>Personal pronoun used to attribute possession.</summary>
        public string Determiner { get; set; }

        /// <summary>Personal pronoun used to indicate a relationship.</summary>
        public string Possessive { get; set; }

        /// <summary>Personal pronoun used to indicate the user.</summary>
        public string Reflexive { get; set; }
    }
}
