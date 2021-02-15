namespace Parquet.Scripts
{
    /// <summary>
    /// Tracks the status of an <see cref="InteractionModel"/>.
    /// </summary>
    public class InteractionStatus
    {
        #region Identity
        /// <summary>The script being tracked.</summary>
        public InteractionModel InteractionDefinition { get; }
        #endregion

        #region Status
        /// <summary>The current execution status of the tracked script.</summary>
        public RunState State { get; set; }

        /// <summary>The index the script node about to be executed.</summary>
        public int ProgramCounter { get; set; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="InteractionStatus"/> class.
        /// </summary>
        /// <param name="inInteractionDefinition">The <see cref="InteractionModel"/> whose status is being tracked.</param>
        /// <param name="inState">The <see cref="RunState"/> of the tracked <see cref="InteractionModel"/>.</param>
        /// <param name="inProgramCounter">Index to the current <see cref="ScriptNode"/> in the tracked <see cref="InteractionModel.StepsIDs"/>.</param>
        public InteractionStatus(InteractionModel inInteractionDefinition, RunState inState, int inProgramCounter)
        {
            Precondition.IsNotNull(inInteractionDefinition, nameof(inInteractionDefinition));

            InteractionDefinition = inInteractionDefinition;
            State = inState;
            ProgramCounter = inProgramCounter;
        }
        #endregion

        #region Utilities
        /// <summary>
        /// Returns a <see cref="string"/> that represents the current <see cref="InteractionStatus"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override string ToString()
            => InteractionDefinition.Name;
        #endregion
    }
}
