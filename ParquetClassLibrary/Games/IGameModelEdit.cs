namespace ParquetClassLibrary.Games
{
    /// <summary>
    /// Facilitates editing of a <see cref="GameModel"/> from design tools while maintaining a read-only face for use during play.
    /// </summary>
    /// <remarks>
    /// By design, children of <see cref="GameModel"/> should never themselves use <see cref="IGameModelEdit"/>.
    /// IGameModelEdit is for use only by external types that require readwrite access to model properties.
    /// </remarks>
    public interface IGameModelEdit : IModelEdit
    {
        /// <summary>If <c>true</c> this game is part of a longer sequence of games.</summary>
        public bool IsEpisode { get; set;  }

        /// <summary>Title of this episode, if any.</summary>
        public string EpisodeTitle { get; set;  }

        /// <summary>Number of this episode in its sequence, if any.</summary>
        public int EpisodeNumber { get; set; }

        /// <summary>The <see cref="ModelID"/> of the <see cref="Beings.CharacterModel"/> that the player controls at the outset.</summary>
        public ModelID PlayerCharacterID { get; set; }

        /// <summary>The <see cref="ModelID"/> of the <see cref="Scripts.ScriptModel"/> to run when play begins.</summary>
        public ModelID FirstScriptID { get; set; }
    }
}
