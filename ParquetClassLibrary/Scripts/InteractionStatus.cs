using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Scripts
{
    /// <summary>
    /// Models the status of an <see cref="InteractionModel"/>.
    /// </summary>
    public class InteractionStatus
    {
        #region Metadata
        /// <summary>
        /// Describes the version of serialized data.
        /// Allows selecting data files that can be successfully deserialized.
        /// </summary>
        public string DataVersion { get; } = AssemblyInfo.SupportedScriptDataVersion;

        /// <summary>Tracks how many times the data structure has been serialized.</summary>
        public int Revision { get; private set; }
        #endregion

        #region Identity
        /// <summary>The <see cref="BeingModel"/> whose status is being tracked.</summary>
        public InteractionModel InteractionDefinition { get; }
        #endregion

        #region Stats
        /// <summary>The <see cref="Location"/> the tracked <see cref="BeingModel"/> occupies.</summary>
        public RunState State { get; set; }

        /// <summary>The index the tracked <see cref="BeingModel"/> occupies.</summary>
        public int ProgramCounter { get; set; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="BeingStatus"/> class.
        /// </summary>
        /// <param name="inInteractionDefinition">The <see cref="InteractionModel"/> whose status is being tracked.</param>
        /// <param name="inState">The <see cref="RunState"/> of the tracked <see cref="InteractionModel"/>.</param>
        /// <param name="inProgramCounter">Index to the current <see cref="Scripts.ScriptNode"/> in the tracked <see cref="InteractionModel.Steps"/>.</param>
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
        /// Returns a <see langword="string"/> that represents the current <see cref="BeingStatus"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override string ToString()
            => $"{InteractionDefinition.Name}";
        #endregion
    }
}
