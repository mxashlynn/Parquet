using CsvHelper.Configuration.Attributes;

namespace ParquetClassLibrary.Beings
{
    /// <summary>
    /// Collects data about a Parquet-based game generally.
    /// </summary>
    public class GameModel : Model
    {
        #region Characteristics
        /// <summary>If <c>true</c> this game is part of a longer sequence of games.</summary>
        [Index(4)]
        public bool IsEpisode { get; }

        /// <summary>Title of this episode, if any.</summary>
        [Index(5)]
        public string EpisodeTitle { get; }

        /// <summary>Number of this episode in its sequence, if any.</summary>
        [Index(6)]
        public int EpisodeNumber { get; }

        /// <summary>The <see cref="ModelID"/> of the <see cref="Beings.CharacterModel"/> that the player controls at the outset.</summary>
        [Index(7)]
        public ModelID PlayerCharacterID { get; }

        /// <summary>The <see cref="ModelID"/> of the <see cref="Scripts.ScriptModel"/> to run when play begins.</summary>
        [Index(8)]
        public ModelID FirstScriptID { get; }
        #endregion

        #region Initialization
        /// <summary>
        /// Used by <see cref="BeingModel"/> subtypes.
        /// </summary>
        /// <param name="inID">Unique identifier for the <see cref="GameModel"/>.  Cannot be null.</param>
        /// <param name="inName">Player-facing title of the <see cref="GameModel"/>.  Cannot be null or empty.</param>
        /// <param name="inDescription">Player-facing description of the <see cref="GameModel"/>.</param>
        /// <param name="inComment">Comment of, on, or by the <see cref="BeingModel"/>.</param>
        /// <param name="inIsEpisode">If <c>true</c> this game is part of a longer sequence of games.</param>
        /// <param name="inEpisodeTitle">Title of this episode, if any.</param>
        /// <param name="inEpisodeNumber">Number of this episode in its sequence, if any.</param>
        /// <param name="inPlayerCharacterID">The <see cref="ModelID"/> of the <see cref="Beings.CharacterModel"/> that the player controls at the outset.</param>
        /// <param name="inFirstScriptID">The <see cref="ModelID"/> of the <see cref="Scripts.ScriptModel"/> to run when play begins.</param>
        public GameModel(ModelID inID, string inName, string inDescription, string inComment,
                            bool inIsEpisode, string inEpisodeTitle, int inEpisodeNumber,
                            ModelID inPlayerCharacterID, ModelID inFirstScriptID)
            : base(All.GameIDs, inID, inName, inDescription, inComment)
        {
            Precondition.IsInRange(inPlayerCharacterID, All.CharacterIDs, nameof(inPlayerCharacterID));
            Precondition.IsInRange(inFirstScriptID, All.ScriptIDs, nameof(inFirstScriptID));

            IsEpisode = inIsEpisode;
            EpisodeTitle = IsEpisode ? inEpisodeTitle : "";
            EpisodeNumber = IsEpisode ? inEpisodeNumber : 0;
            PlayerCharacterID = inPlayerCharacterID;
            FirstScriptID = inFirstScriptID;
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
