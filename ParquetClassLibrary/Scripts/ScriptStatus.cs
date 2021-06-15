using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;

namespace Parquet.Scripts
{
    /// <summary>
    /// Tracks the status of a <see cref="ScriptModel"/>.
    /// Instances of this class are mutable during play.
    /// </summary>
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
        /// Initializes an instance of the <see cref="ScriptStatus"/> with default values.
        /// </summary>
        public ScriptStatus()
            : this(RunState.Unstarted, 0)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ScriptStatus"/> class.
        /// </summary>
        /// <param name="state">The <see cref="RunState"/> of the tracked <see cref="ScriptModel"/>.</param>
        /// <param name="programCounter">Index to the current <see cref="ScriptNode"/> in the tracked <see cref="ScriptModel.Nodes"/>.</param>
        public ScriptStatus(RunState state, int programCounter)
        {
            State = state;
            ProgramCounter = programCounter;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ScriptStatus"/> class
        /// based on a given <see cref="ScriptModel"/> instance.
        /// </summary>
        /// <param name="script">The script definition whose status is being tracked.</param>
        [SuppressMessage("Usage", "CA1801:Review unused parameters",
            Justification = "This constructor is provided for consistency.  The parameter is currently ignored, but may not be in the future.")]
        [SuppressMessage("Style", "IDE0060:Remove unused parameter",
            Justification = "This constructor is provided for consistency.  The parameter is currently ignored, but may not be in the future.")]
        public ScriptStatus(ScriptModel script)
            : this(RunState.Unstarted, 0)
        { }
        #endregion

        #region IEquatable Implementation
        /// <summary>
        /// Serves as a hash function for a <see cref="ScriptStatus"/>.
        /// </summary>
        /// <returns>
        /// A hash code for this instance that is suitable for use in hashing algorithms and data structures.
        /// </returns>
        public override int GetHashCode()
            => (State, ProgramCounter).GetHashCode();

        /// <summary>
        /// Determines whether the specified <see cref="ScriptStatus"/> is equal to the current <see cref="ScriptStatus"/>.
        /// </summary>
        /// <param name="status">The <see cref="ScriptStatus"/> to compare with the current.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public override bool Equals<T>(T status)
            => status is ScriptStatus ScriptStatus
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
        /// <param name="status1">The first <see cref="ScriptStatus"/> to compare.</param>
        /// <param name="status2">The second <see cref="ScriptStatus"/> to compare.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(ScriptStatus status1, ScriptStatus status2)
            => status1?.Equals(status2) ?? status2?.Equals(status1) ?? true;

        /// <summary>
        /// Determines whether a specified instance of <see cref="ScriptStatus"/> is not equal to another specified instance of <see cref="ScriptStatus"/>.
        /// </summary>
        /// <param name="status1">The first <see cref="ScriptStatus"/> to compare.</param>
        /// <param name="status2">The second <see cref="ScriptStatus"/> to compare.</param>
        /// <returns><c>true</c> if they are NOT equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(ScriptStatus status1, ScriptStatus status2)
            => !(status1 == status2);
        #endregion

        #region ITypeConverter Implementation
        /// <summary>Allows the converter to construct itself statically.</summary>
        internal static ScriptStatus ConverterFactory { get; } = Unstarted;

        /// <summary>
        /// Converts the given <see cref="object"/> to a <see cref="string"/> for serialization.
        /// </summary>
        /// <param name="value">The instance to convert.</param>
        /// <param name="row">The current context and configuration.</param>
        /// <param name="memberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance serialized.</returns>
        public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
            => value is ScriptStatus status
                ? $"{status.State}{Delimiters.InternalDelimiter}" +
                  $"{status.ProgramCounter}"
                : Logger.DefaultWithConvertLog(value?.ToString() ?? "null", nameof(ScriptStatus), nameof(Unstarted));

        /// <summary>
        /// Converts the given <see cref="string"/> to an <see cref="object"/> as deserialization.
        /// </summary>
        /// <param name="text">The text to convert.</param>
        /// <param name="row">The current context and configuration.</param>
        /// <param name="memberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance deserialized.</returns>
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            if (string.IsNullOrEmpty(text)
                || string.Compare(nameof(Unstarted), text, StringComparison.OrdinalIgnoreCase) == 0)
            {
                return Unstarted;
            }

            var parameterText = text.Split(Delimiters.SecondaryDelimiter);

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

        #region IDeeplyCloneable Implementation
        /// <summary>
        /// Creates a new instance that is a deep copy of the current instance.
        /// </summary>
        /// <returns>A new instance with the same characteristics as the current instance.</returns>
        public override T DeepClone<T>()
            => new ScriptStatus(State, ProgramCounter) as T;
        #endregion

        #region Utilities
        /// <summary>
        /// Returns a <see cref="string"/> that represents the current <see cref="ScriptStatus"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override string ToString()
            => $"{nameof(ScriptStatus)}: {State}@ {ProgramCounter}";
        #endregion
    }
}
