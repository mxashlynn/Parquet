using CsvHelper.Configuration.Attributes;
using ParquetClassLibrary.EditorSupport;

namespace ParquetClassLibrary.Games
{
    /// <summary>
    /// Collects data about a Parquet-based game generally.
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1033:Interface methods should be callable by subtypes",
        Justification = "By design, subtypes of Model should never themselves use IModelEdit or derived interfaces to access their own members.  The IModelEdit family of interfaces is for external types that require read/write access.")]
    public class GameModel : Model, IGameModelEdit
    {
        #region Characteristics
        /// <summary>If <c>true</c> this game is part of a sequence of games.</summary>
        [Index(4)]
        public bool IsEpisode { get; private set; }

        /// <summary>If <c>true</c> this game is part of a sequence of games.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="GameModel"/> should never themselves use <see cref="IGameModelEdit"/>.
        /// IGameModelEdit is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        bool IGameModelEdit.IsEpisode { get => IsEpisode; set => IsEpisode = value; }

        /// <summary>Subtitle, if any.  This will be used as the title of the episode if <see cref="IsEpisode"/> is <c>true</c>.</summary>
        [Index(5)]
        public string EpisodeTitle { get; private set; }

        /// <summary>Subtitle, if any.  This will be used as the title of the episode if <see cref="IsEpisode"/> is <c>true</c>.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="GameModel"/> should never themselves use <see cref="IGameModelEdit"/>.
        /// IGameModelEdit is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        string IGameModelEdit.EpisodeTitle { get => EpisodeTitle; set => EpisodeTitle = value; }

        /// <summary>Number of this episode in its sequence, if any.</summary>
        [Index(6)]
        public int EpisodeNumber { get; private set; }

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
        [Index(8)]
        public ModelID FirstScriptID { get; private set; }

        /// <summary>The <see cref="ModelID"/> of the <see cref="Scripts.ScriptModel"/> to run when play begins.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="GameModel"/> should never themselves use <see cref="IGameModelEdit"/>.
        /// IGameModelEdit is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        ModelID IGameModelEdit.FirstScriptID { get => FirstScriptID; set => FirstScriptID = value; }
        #endregion

        #region Initialization
        /// <summary>
        /// Represents a game or game-episode created with the Parquet system.
        /// Primarily cointains metadata and gameplay rules information.
        /// </summary>
        /// <param name="inID">Unique identifier for the <see cref="GameModel"/>.  Cannot be null.</param>
        /// <param name="inName">Player-facing title of the <see cref="GameModel"/>.  Cannot be null or empty.</param>
        /// <param name="inDescription">Player-facing description of the <see cref="GameModel"/>.</param>
        /// <param name="inComment">A private comment on the nature of the game or episode.</param>
        /// <param name="inIsEpisode">If <c>true</c> this game is part of a longer sequence of games.</param>
        /// <param name="inEpisodeTitle">Title of this episode, if any.</param>
        /// <param name="inEpisodeNumber">Number of this episode in its sequence, if any.</param>
        /// <param name="inPlayerCharacterID">The <see cref="ModelID"/> of the <see cref="Beings.CharacterModel"/> that the player controls at the outset.</param>
        /// <param name="inFirstScriptID">The <see cref="ModelID"/> of the <see cref="Scripts.ScriptModel"/> to run when play begins.</param>
        public GameModel(ModelID inID, string inName, string inDescription, string inComment,
                         bool inIsEpisode = false, string inEpisodeTitle = "", int inEpisodeNumber = 0,
                         ModelID? inPlayerCharacterID = null, ModelID? inFirstScriptID = null)
            : base(All.GameIDs, inID, inName, inDescription, inComment)
        {
            var nonNullPlayerCharacterID = inPlayerCharacterID ?? ModelID.None;
            var nonNullFirstScriptID = inFirstScriptID ?? ModelID.None;

            Precondition.IsInRange(nonNullPlayerCharacterID, All.CharacterIDs, nameof(inPlayerCharacterID));
            Precondition.IsInRange(nonNullFirstScriptID, All.ScriptIDs, nameof(inFirstScriptID));

            IsEpisode = inIsEpisode;
            EpisodeTitle = IsEpisode ? inEpisodeTitle : "";
            EpisodeNumber = IsEpisode ? inEpisodeNumber : 0;
            PlayerCharacterID = nonNullPlayerCharacterID;
            FirstScriptID = nonNullFirstScriptID;
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
