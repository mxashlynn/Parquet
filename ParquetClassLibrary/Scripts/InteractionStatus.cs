using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;

namespace Parquet.Scripts
{
    /// <summary>
    /// Tracks the status of an <see cref="InteractionModel"/>.
    /// Instances of this class are mutable during play.
    /// </summary>
    /// <remarks>
    /// The narrative gameplay revolves around instances of this class.
    /// </remarks>
    public class InteractionStatus : Status<InteractionModel>
    {
        #region Class Defaults
        /// <summary>Provides an instance of the <see cref="InteractionStatus"/> class with default values.</summary>
        public static InteractionStatus Unstarted { get; } = new InteractionStatus();
        #endregion

        #region Status
        /// <summary>The current execution status of the tracked script.</summary>
        public RunState State { get; set; }

        /// <summary>The index the script node about to be executed.</summary>
        public int StepCounter { get; set; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes an instance of the <see cref="InteractionStatus"/> with default values.
        /// </summary>
        public InteractionStatus()
            : this(RunState.Unstarted, 0)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="InteractionStatus"/> class.
        /// </summary>
        /// <param name="state">The <see cref="RunState"/> of the tracked <see cref="InteractionModel"/>.</param>
        /// <param name="programCounter">Index to the current <see cref="ScriptNode"/> in the tracked <see cref="InteractionModel.StepsIDs"/>.</param>
        public InteractionStatus(RunState state, int programCounter)
        {
            State = state;
            StepCounter = programCounter;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="InteractionStatus"/> class
        /// based on a given <see cref="InteractionModel"/> instance.
        /// </summary>
        /// <param name="script">The script definition whose status is being tracked.</param>
        [SuppressMessage("Usage", "CA1801:Review unused parameters",
            Justification = "This constructor is provided for consistency.  The parameter is currently ignored, but may not be in the future.")]
        [SuppressMessage("Style", "IDE0060:Remove unused parameter",
            Justification = "This constructor is provided for consistency.  The parameter is currently ignored, but may not be in the future.")]
        public InteractionStatus(InteractionModel script)
            : this(RunState.Unstarted, 0)
        { }
        #endregion

        #region IEquatable Implementation
        /// <summary>
        /// Serves as a hash function for a <see cref="InteractionStatus"/>.
        /// </summary>
        /// <returns>
        /// A hash code for this instance that is suitable for use in hashing algorithms and data structures.
        /// </returns>
        public override int GetHashCode()
            => (State, StepCounter).GetHashCode();

        /// <summary>
        /// Determines whether the specified <see cref="InteractionStatus"/> is equal to the current <see cref="InteractionStatus"/>.
        /// </summary>
        /// <param name="status">The <see cref="InteractionStatus"/> to compare with the current.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public override bool Equals<T>(T status)
            => status is InteractionStatus interactionStatus
            && State == interactionStatus.State
            && StepCounter == interactionStatus.StepCounter;

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="InteractionStatus"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="InteractionStatus"/>.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
            => obj is InteractionStatus status
            && Equals(status);

        /// <summary>
        /// Determines whether a specified instance of <see cref="InteractionStatus"/> is equal to another specified instance of <see cref="InteractionStatus"/>.
        /// </summary>
        /// <param name="status1">The first <see cref="InteractionStatus"/> to compare.</param>
        /// <param name="status2">The second <see cref="InteractionStatus"/> to compare.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(InteractionStatus status1, InteractionStatus status2)
            => status1?.Equals(status2) ?? status2?.Equals(status1) ?? true;

        /// <summary>
        /// Determines whether a specified instance of <see cref="InteractionStatus"/> is not equal to another specified instance of <see cref="InteractionStatus"/>.
        /// </summary>
        /// <param name="status1">The first <see cref="InteractionStatus"/> to compare.</param>
        /// <param name="status2">The second <see cref="InteractionStatus"/> to compare.</param>
        /// <returns><c>true</c> if they are NOT equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(InteractionStatus status1, InteractionStatus status2)
            => !(status1 == status2);
        #endregion

        #region ITypeConverter Implementation
        /// <summary>Allows the converter to construct itself statically.</summary>
        internal static InteractionStatus ConverterFactory { get; } = Unstarted;

        /// <summary>
        /// Converts the given <see cref="object"/> to a <see cref="string"/> for serialization.
        /// </summary>
        /// <param name="value">The instance to convert.</param>
        /// <param name="row">The current context and configuration.</param>
        /// <param name="memberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance serialized.</returns>
        public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
            => value is InteractionStatus status
                ? $"{status.State}{Delimiters.InternalDelimiter}" +
                  $"{status.StepCounter}"
                : Logger.DefaultWithConvertLog(value?.ToString() ?? "null", nameof(InteractionStatus), nameof(Unstarted));

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
                : Logger.DefaultWithParseLog(parameterText[1], nameof(StepCounter), 0);

            return new InteractionStatus(parsedState, parsedProgramCounter);
        }
        #endregion

        #region IDeeplyCloneable Implementation
        /// <summary>
        /// Creates a new instance that is a deep copy of the current instance.
        /// </summary>
        /// <returns>A new instance with the same characteristics as the current instance.</returns>
        public override T DeepClone<T>()
            => new InteractionStatus(State, StepCounter) as T;
        #endregion

        #region Self Serialization
        /// <summary>
        /// Reads all <see cref="InteractionStatus"/> records from the appropriate file.
        /// </summary>
        /// <returns>The instances read.</returns>
        public static Dictionary<ModelID, InteractionStatus> GetRecords()
        {
            using var reader = new StreamReader(FilePath);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            csv.Configuration.TypeConverterOptionsCache.AddOptions(typeof(ModelID), All.IdentifierOptions);
            csv.Configuration.PrepareHeaderForMatch = (string header, int index) => header.ToUpperInvariant();
            foreach (var kvp in All.ConversionConverters)
            {
                csv.Configuration.TypeConverterCache.AddConverter(kvp.Key, kvp.Value);
            }

            return new Dictionary<ModelID, InteractionStatus>(csv.GetRecords<KeyValuePair<ModelID, InteractionStatus>>());
        }

        /// <summary>
        /// Writes the given <see cref="InteractionStatus"/> records to the appropriate file.
        /// </summary>
        public static void PutRecords(IEnumerable<KeyValuePair<ModelID, InteractionStatus>> interactionStatuses)
        {
            if (interactionStatuses is null)
            {
                interactionStatuses = Enumerable.Empty<KeyValuePair<ModelID, InteractionStatus>>();
            }

            using var writer = new StreamWriter(FilePath, false, new UTF8Encoding(true, true));
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.Configuration.NewLine = NewLine.LF;
            csv.Configuration.TypeConverterOptionsCache.AddOptions(typeof(ModelID), All.IdentifierOptions);
            foreach (var kvp in All.ConversionConverters)
            {
                csv.Configuration.TypeConverterCache.AddConverter(kvp.Key, kvp.Value);
            }

            csv.WriteHeader<KeyValuePair<ModelID, InteractionStatus>>();
            csv.NextRecord();
            csv.WriteRecords(interactionStatuses);
        }
        #endregion

        #region Utilities
        /// <summary>
        /// Returns the filename and path associated with <see cref="InteractionStatus"/>'s definition file.
        /// </summary>
        /// <returns>A full path to the associated file.</returns>
        // TODO [Save/Load]  This path must be player-specifiable.
        public static string FilePath
            => $"{All.ProjectDirectory}/{nameof(InteractionStatus)}es.csv";

        /// <summary>
        /// Returns a <see cref="string"/> that represents the current <see cref="InteractionStatus"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override string ToString()
            => $"{nameof(InteractionStatus)}: {State} @ {StepCounter}";
        #endregion
    }
}
