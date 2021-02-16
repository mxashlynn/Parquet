namespace Parquet.Scripts
{
    /// <summary>
    /// Tracks the status of an <see cref="InteractionModel"/>.
    /// </summary>
    public class InteractionStatus
    {
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
        /// <param name="inState">The <see cref="RunState"/> of the tracked <see cref="InteractionModel"/>.</param>
        /// <param name="inProgramCounter">Index to the current <see cref="ScriptNode"/> in the tracked <see cref="InteractionModel.StepsIDs"/>.</param>
        public InteractionStatus(RunState inState = RunState.Unstarted, int inProgramCounter = 0)
        {
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
            => $"{nameof(InteractionStatus)}: {State}";
        #endregion
    }
}
