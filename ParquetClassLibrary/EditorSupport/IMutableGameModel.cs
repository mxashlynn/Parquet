#if DESIGN
using Parquet.Games;

namespace Parquet.EditorSupport
{
    /// <summary>
    /// Facilitates editing of a <see cref="GameModel"/> from design tools while maintaining a read-only face for use during play.
    /// </summary>
    /// <remarks>
    /// By design, subtypes of <see cref="GameModel"/> should never themselves use <see cref="IMutableGameModel"/>.
    /// IGameModelEdit is for use only by external types that require read/write access to model properties.
    /// </remarks>
    public interface IMutableGameModel : IMutableModel
    {
        /// <summary>If <c>true</c> this game is part of a longer sequence of games.</summary>
        public bool IsEpisode { get; set;  }

        /// <summary>Subtitle, if any.  This will be used as the title of the episode if <see cref="IsEpisode"/> is <c>true</c>.</summary>
        public string EpisodeTitle { get; set;  }

        /// <summary>Number of this episode in its sequence, if any.</summary>
        public int EpisodeNumber { get; set; }

        /// <summary>The <see cref="ModelID"/> of the <see cref="Beings.CharacterModel"/> that the player controls at the outset.</summary>
        public ModelID PlayerCharacterID { get; set; }

        /// <summary>The <see cref="ModelID"/> of the <see cref="Scripts.ScriptModel"/> to run when play begins.</summary>
        public ModelID FirstScriptID { get; set; }
    }
}
#endif
