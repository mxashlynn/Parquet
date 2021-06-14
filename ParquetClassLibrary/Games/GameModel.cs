using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using CsvHelper.Configuration.Attributes;

namespace Parquet.Games
{
    /// <summary>
    /// Collects data about a Parquet-based game generally.
    /// </summary>
    [SuppressMessage("Design", "CA1033:Interface methods should be callable by subtypes",
                     Justification = "By design, subtypes of Model should never themselves use IMutableModel or derived interfaces to access their own members.  The IMutableModel family of interfaces is for external types that require read/write access.")]
    public class GameModel : Model, IMutableGameModel
    {
        #region Class Defaults
        /// <summary>Indicates an uninitialized game.</summary>
        public static GameModel Empty { get; } = new GameModel(ModelID.None, nameof(Empty), "", "");
        #endregion

        #region Characteristics
        /// <summary>If <c>true</c> this game is part of a sequence of games.</summary>
        [Index(5)]
        public bool IsEpisode { get; private set; }

        /// <summary>Subtitle, if any.  This will be used as the title of the episode if <see cref="IsEpisode"/> is <c>true</c>.</summary>
        [Index(6)]
        public string EpisodeTitle { get; private set; }

        /// <summary>Number of this episode in its sequence, if any.</summary>
        [Index(7)]
        public int EpisodeNumber { get; private set; }

        /// <summary>The <see cref="ModelID"/> of the <see cref="Beings.CharacterModel"/> that the player controls at the outset.</summary>
        [Index(8)]
        public ModelID PlayerCharacterID { get; private set; }

        /// <summary>The <see cref="ModelID"/> of the <see cref="Scripts.ScriptModel"/> to run when play begins.</summary>
        [Index(9)]
        public ModelID FirstScriptID { get; private set; }
        #endregion

        #region Initialization
        /// <summary>
        /// Models a full game or an episode in a serial game.
        /// Contains metadata and starting conditions.
        /// </summary>
        /// <param name="id">Unique identifier for the <see cref="GameModel"/>.  Cannot be null.</param>
        /// <param name="name">Player-facing title of the <see cref="GameModel"/>.  Cannot be null or empty.</param>
        /// <param name="description">Player-facing description of the <see cref="GameModel"/>.</param>
        /// <param name="comment">A private comment on the nature of the game or episode.</param>
        /// <param name="tags">Any additional information about this <see cref="GameModel"/>.</param>
        /// <param name="isEpisode">If <c>true</c> this game is part of a longer sequence of games.</param>
        /// <param name="episodeTitle">Title of this episode, if any.</param>
        /// <param name="episodeNumber">Number of this episode in its sequence, if any.</param>
        /// <param name="playerCharacterID">The <see cref="ModelID"/> of the <see cref="Beings.CharacterModel"/> that the player controls at the outset.</param>
        /// <param name="firstScriptID">The <see cref="ModelID"/> of the <see cref="Scripts.ScriptModel"/> to run when play begins.</param>
        public GameModel(ModelID id, string name, string description, string comment,
                         IEnumerable<ModelTag> tags = null, bool isEpisode = false, string episodeTitle = "",
                         int episodeNumber = 0, ModelID? playerCharacterID = null, ModelID? firstScriptID = null)
            : base(All.GameIDs, id, name, description, comment, tags)
        {
            var nonNullPlayerCharacterID = playerCharacterID ?? ModelID.None;
            var nonNullFirstScriptID = firstScriptID ?? ModelID.None;

            Precondition.IsInRange(nonNullPlayerCharacterID, All.CharacterIDs, nameof(playerCharacterID));
            Precondition.IsInRange(nonNullFirstScriptID, All.ScriptIDs, nameof(firstScriptID));

            IsEpisode = isEpisode;
            EpisodeTitle = IsEpisode ? episodeTitle : "";
            EpisodeNumber = IsEpisode ? episodeNumber : 0;
            PlayerCharacterID = nonNullPlayerCharacterID;
            FirstScriptID = nonNullFirstScriptID;
        }
        #endregion

        #region IMutableGameModel Implementation
        /// <summary>If <c>true</c> this game is part of a sequence of games.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="GameModel"/> should never themselves use <see cref="IMutableGameModel"/>.
        /// IMutableGameModel is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        bool IMutableGameModel.IsEpisode
        {
            get => IsEpisode;
            set => IsEpisode = LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(IsEpisode), IsEpisode)
                : value;
        }

        /// <summary>Subtitle, if any.  This will be used as the title of the episode if <see cref="IsEpisode"/> is <c>true</c>.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="GameModel"/> should never themselves use <see cref="IMutableGameModel"/>.
        /// IMutableGameModel is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        string IMutableGameModel.EpisodeTitle
        {
            get => EpisodeTitle;
            set => EpisodeTitle = LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(EpisodeTitle), EpisodeTitle)
                : value;
        }

        /// <summary>Number of this episode in its sequence, if any.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="GameModel"/> should never themselves use <see cref="IMutableGameModel"/>.
        /// IMutableGameModel is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        int IMutableGameModel.EpisodeNumber
        {
            get => EpisodeNumber;
            set => EpisodeNumber = LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(EpisodeNumber), EpisodeNumber)
                : value;
        }

        /// <summary>The <see cref="ModelID"/> of the <see cref="Beings.CharacterModel"/> that the player controls at the outset.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="GameModel"/> should never themselves use <see cref="IMutableGameModel"/>.
        /// IMutableGameModel is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        ModelID IMutableGameModel.PlayerCharacterID
        {
            get => PlayerCharacterID;
            set => PlayerCharacterID = LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(PlayerCharacterID), PlayerCharacterID)
                : value;
        }

        /// <summary>The <see cref="ModelID"/> of the <see cref="Scripts.ScriptModel"/> to run when play begins.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="GameModel"/> should never themselves use <see cref="IMutableGameModel"/>.
        /// IMutableGameModel is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        ModelID IMutableGameModel.FirstScriptID
        {
            get => FirstScriptID;
            set => FirstScriptID = LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(FirstScriptID), FirstScriptID)
                : value;
        }
        #endregion

        #region Utilities
        /// <summary>
        /// Returns a <see cref="string"/> that represents the current <see cref="GameModel"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override string ToString()
            => IsEpisode
            ? $"\"{Name}\" #{EpisodeNumber}: '{EpisodeTitle}' ({PlayerCharacterID} @ {FirstScriptID})"
            : $"\"{Name}\" ({PlayerCharacterID} @ {FirstScriptID})";
        #endregion
    }
}
