#if DESIGN
using System.Diagnostics.CodeAnalysis;
using CsvHelper.Configuration.Attributes;
using Parquet.EditorSupport;

namespace Parquet.Games
{
    [SuppressMessage("Design", "CA1033:Interface methods should be callable by subtypes",
                     Justification = "By design, subtypes of Model should never themselves use IMutableModel or derived interfaces to access their own members.  The IMutableModel family of interfaces is for external types that require read/write access.")]
    public partial class GameModel : IMutableGameModel
    {
        #region IGameModelEdit Implementation
        /// <summary>If <c>true</c> this game is part of a sequence of games.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="GameModel"/> should never themselves use <see cref="IMutableGameModel"/>.
        /// IGameModelEdit is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        bool IMutableGameModel.IsEpisode { get => IsEpisode; set => IsEpisode = value; }

        /// <summary>Subtitle, if any.  This will be used as the title of the episode if <see cref="IsEpisode"/> is <c>true</c>.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="GameModel"/> should never themselves use <see cref="IMutableGameModel"/>.
        /// IGameModelEdit is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        string IMutableGameModel.EpisodeTitle { get => EpisodeTitle; set => EpisodeTitle = value; }

        /// <summary>Number of this episode in its sequence, if any.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="GameModel"/> should never themselves use <see cref="IMutableGameModel"/>.
        /// IGameModelEdit is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        int IMutableGameModel.EpisodeNumber { get => EpisodeNumber; set => EpisodeNumber = value; }

        /// <summary>The <see cref="ModelID"/> of the <see cref="Beings.CharacterModel"/> that the player controls at the outset.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="GameModel"/> should never themselves use <see cref="IMutableGameModel"/>.
        /// IGameModelEdit is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        ModelID IMutableGameModel.PlayerCharacterID { get => PlayerCharacterID; set => PlayerCharacterID = value; }

        /// <summary>The <see cref="ModelID"/> of the <see cref="Scripts.ScriptModel"/> to run when play begins.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="GameModel"/> should never themselves use <see cref="IMutableGameModel"/>.
        /// IGameModelEdit is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        ModelID IMutableGameModel.FirstScriptID { get => FirstScriptID; set => FirstScriptID = value; }
        #endregion
    }
}
#endif
