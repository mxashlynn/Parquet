namespace ParquetClassLibrary.Dialogues
{
    /// <summary>
    /// Models dialogue that an <see cref="Beings.NPC"/> may communicate.
    /// </summary>
    public sealed class DialogueModel : EntityModel
    {
        // TODO: This is a stub.
        #region Characteristics

        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="DialogueModel"/> class.
        /// </summary>
        /// <param name="inID">Unique identifier for the <see cref="DialogueModel"/>.  Cannot be null.</param>
        /// <param name="inName">Player-friendly name of the <see cref="DialogueModel"/>.  Cannot be null or empty.</param>
        /// <param name="inDescription">Player-friendly description of the <see cref="DialogueModel"/>.</param>
        /// <param name="inComment">Comment of, on, or by the <see cref="DialogueModel"/>.</param>
        public DialogueModel(EntityID inID, string inName, string inDescription, string inComment)
            : base(All.DialogueIDs, inID, inName, inDescription, inComment)
        { }
        #endregion
    }
}
