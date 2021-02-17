using System;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace Parquet.Scripts
{
    /// <summary>
    /// Tracks the status of a <see cref="ScriptModel"/>.
    /// Instances of this class are mutable during play.
    /// </summary>
    /// <remarks>
    /// This can also be used to tracks the status of an <see cref="InteractionModel"/>
    /// as only <see cref="InteractionModel.StepsIDs"/> is stateful.
    /// </remarks>
    public class ScriptStatus : Status<ScriptModel>
    {
        #region Class Defaults
        /// <summary>Provides an instance of the <see cref="ScriptStatus"/> class with default values.</summary>
        public static ScriptStatus Unstarted { get; } = new ScriptStatus();
        #endregion

        #region Status
        /// <summary>The current execution status of the tracked script.</summary>
        public RunState State { get; set; }

        /// <summary>The index the script node about to be executed.</summary>
        public int ProgramCounter { get; set; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="ScriptStatus"/> class.
        /// </summary>
        /// <param name="inState">The <see cref="RunState"/> of the tracked <see cref="ScriptModel"/>.</param>
        /// <param name="inProgramCounter">Index to the current <see cref="ScriptNode"/> in the tracked <see cref="ScriptModel.StepsIDs"/>.</param>
        public ScriptStatus(RunState inState = RunState.Unstarted, int inProgramCounter = 0)
        {
            State = inState;
            ProgramCounter = inProgramCounter;
        }
        #endregion

        #region IEquatable Implementation
        /// <summary>
        /// Serves as a hash function for a <see cref="BeingStatus"/>.
        /// </summary>
        /// <returns>
        /// A hash code for this instance that is suitable for use in hashing algorithms and data structures.
        /// </returns>
        public override int GetHashCode()
            => (State, ProgramCounter).GetHashCode();

        /// <summary>
        /// Determines whether the specified <see cref="ScriptStatus"/> is equal to the current <see cref="ScriptStatus"/>.
        /// </summary>
        /// <param name="inStatus">The <see cref="ScriptStatus"/> to compare with the current.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public override bool Equals<T>(T inStatus)
            => inStatus is ScriptStatus ScriptStatus
            && State == ScriptStatus.State
            && ProgramCounter == ScriptStatus.ProgramCounter;

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="ScriptStatus"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="ScriptStatus"/>.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
            => obj is ScriptStatus status
            && Equals(status);

        /// <summary>
        /// Determines whether a specified instance of <see cref="ScriptStatus"/> is equal to another specified instance of <see cref="ScriptStatus"/>.
        /// </summary>
        /// <param name="inStatus1">The first <see cref="ScriptStatus"/> to compare.</param>
        /// <param name="inStatus2">The second <see cref="ScriptStatus"/> to compare.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(ScriptStatus inStatus1, ScriptStatus inStatus2)
            => inStatus1?.Equals(inStatus2) ?? inStatus2?.Equals(inStatus1) ?? true;

        /// <summary>
        /// Determines whether a specified instance of <see cref="ScriptStatus"/> is not equal to another specified instance of <see cref="ScriptStatus"/>.
        /// </summary>
        /// <param name="inStatus1">The first <see cref="ScriptStatus"/> to compare.</param>
        /// <param name="inStatus2">The second <see cref="ScriptStatus"/> to compare.</param>
        /// <returns><c>true</c> if they are NOT equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(ScriptStatus inStatus1, ScriptStatus inStatus2)
            => !(inStatus1 == inStatus2);
        #endregion

        #region ITypeConverter Implementation
        /// <summary>Allows the converter to construct itself statically.</summary>
        internal static ScriptStatus ConverterFactory { get; } = Unstarted;

        /// <summary>
        /// Converts the given <see cref="object"/> to a <see cref="string"/> for serialization.
        /// </summary>
        /// <param name="inValue">The instance to convert.</param>
        /// <param name="inRow">The current context and configuration.</param>
        /// <param name="inMemberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance serialized.</returns>
        public override string ConvertToString(object inValue, IWriterRow inRow, MemberMapData inMemberMapData)
            => inValue is ScriptStatus status
                ? $"{status.State}{Delimiters.InternalDelimiter}" +
                  $"{status.ProgramCounter}"
                : Logger.DefaultWithConvertLog(inValue?.ToString() ?? "null", nameof(ScriptStatus), nameof(Unstarted));

        /// <summary>
        /// Converts the given <see cref="string"/> to an <see cref="object"/> as deserialization.
        /// </summary>
        /// <param name="inText">The text to convert.</param>
        /// <param name="inRow">The current context and configuration.</param>
        /// <param name="inMemberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance deserialized.</returns>
        public override object ConvertFromString(string inText, IReaderRow inRow, MemberMapData inMemberMapData)
        {
            if (string.IsNullOrEmpty(inText)
                || string.Compare(nameof(Unstarted), inText, StringComparison.OrdinalIgnoreCase) == 0)
            {
                return Unstarted;
            }

            var numberStyle = inMemberMapData?.TypeConverterOptions?.NumberStyles ?? All.SerializedNumberStyle;
            var parameterText = inText.Split(Delimiters.SecondaryDelimiter);

            var parsedState = Enum.TryParse(typeof(RunState), parameterText[0], out var temp0)
                ? (RunState)temp0
                : Logger.DefaultWithParseLog(parameterText[0], nameof(RunState), RunState.Unstarted);
            var parsedProgramCounter = int.TryParse(parameterText[1], All.SerializedNumberStyle,
                                                    CultureInfo.InvariantCulture, out var temp1)
                ? temp1
                : Logger.DefaultWithParseLog(parameterText[1], nameof(ProgramCounter), 0);

            return new ScriptStatus(parsedState, parsedProgramCounter);
        }
        #endregion

        #region Utilities
        /// <summary>
        /// Returns a <see cref="string"/> that represents the current <see cref="ScriptStatus"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override string ToString()
            => $"{nameof(ScriptStatus)}: {State}";
        #endregion
    }
}
