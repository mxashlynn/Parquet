#if DESIGN
using CsvHelper.Configuration.Attributes;
using ParquetClassLibrary.EditorSupport;

namespace ParquetClassLibrary.Games
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1033:Interface methods should be callable by subtypes",
        Justification = "By design, subtypes of Model should never themselves use IModelEdit or derived interfaces to access their own members.  The IModelEdit family of interfaces is for external types that require read/write access.")]
    public partial class GameModel : IGameModelEdit
    {
        #region IGameModelEdit Implementation
        /// <summary>If <c>true</c> this game is part of a sequence of games.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="GameModel"/> should never themselves use <see cref="IGameModelEdit"/>.
        /// IGameModelEdit is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        bool IGameModelEdit.IsEpisode { get => IsEpisode; set => IsEpisode = value; }

        /// <summary>Subtitle, if any.  This will be used as the title of the episode if <see cref="IsEpisode"/> is <c>true</c>.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="GameModel"/> should never themselves use <see cref="IGameModelEdit"/>.
        /// IGameModelEdit is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        string IGameModelEdit.EpisodeTitle { get => EpisodeTitle; set => EpisodeTitle = value; }

        /// <summary>Number of this episode in its sequence, if any.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="GameModel"/> should never themselves use <see cref="IGameModelEdit"/>.
        /// IGameModelEdit is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        int IGameModelEdit.EpisodeNumber { get => EpisodeNumber; set => EpisodeNumber = value; }

        /// <summary>The <see cref="ModelID"/> of the <see cref="Beings.CharacterModel"/> that the player controls at the outset.</summary>
        [Index(7)]
        public ModelID PlayerCharacterID { get; private set; }

        /// <summary>The <see cref="ModelID"/> of the <see cref="Beings.CharacterModel"/> that the player controls at the outset.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="GameModel"/> should never themselves use <see cref="IGameModelEdit"/>.
        /// IGameModelEdit is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        ModelID IGameModelEdit.PlayerCharacterID { get => PlayerCharacterID; set => PlayerCharacterID = value; }

        /// <summary>The <see cref="ModelID"/> of the <see cref="Scripts.ScriptModel"/> to run when play begins.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="GameModel"/> should never themselves use <see cref="IGameModelEdit"/>.
        /// IGameModelEdit is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        ModelID IGameModelEdit.FirstScriptID { get => FirstScriptID; set => FirstScriptID = value; }
        #endregion
    }
}
#endif
