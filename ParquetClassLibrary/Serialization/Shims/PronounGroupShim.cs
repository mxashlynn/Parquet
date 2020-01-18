using ParquetClassLibrary.Beings;

namespace ParquetClassLibrary.Serialization.Shims
{
    /// <summary>
    /// Provides a default public parameterless constructor for a
    /// <see cref="PronounGroup"/>-like class that CSVHelper can instantiate.
    /// 
    /// Provides the ability to generate a <see cref="PronounGroup"/> from this class.
    /// </summary>
    public class PronounGroupShim
    {
        /// <summary>Personal pronoun used as the subject of a verb.</summary>
        public string Subjective;

        /// <summary>Personal pronoun used as the indirect object of a preposition or verb.</summary>
        public string Objective;

        /// <summary>Personal pronoun used to attribute possession.</summary>
        public string Determiner;

        /// <summary>Personal pronoun used to indicate a relationship.</summary>
        public string Possessive;

        /// <summary>Personal pronoun used to indicate the user.</summary>
        public string Reflexive;

        /// <summary>
        /// Converts a shim into the class it corresponds to.
        /// </summary>
        /// <returns>An instance corresponding to this shim.</returns>
        public PronounGroup ToPronounGroup()
            => new PronounGroup(Subjective, Objective, Determiner, Possessive, Reflexive);
    }
}
