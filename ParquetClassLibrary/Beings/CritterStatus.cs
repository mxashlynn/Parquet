using System;
using CsvHelper;
using CsvHelper.Configuration;

namespace Parquet.Beings
{
    /// <summary>
    /// Tracks the status of a <see cref="CritterModel"/>.
    /// Instances of this class are mutable during play.
    /// </summary>
    public class CritterStatus : BeingStatus<CritterModel>
    {
        #region Class Defaults
        /// <summary>Provides a throwaway instance of the <see cref="CritterStatus"/> class with default values.</summary>
        public static CritterStatus Unused { get; } = new CritterStatus();
        #endregion

        #region Status
        /// <summary>The <see cref="Location"/> the tracked <see cref="CritterModel"/> occupies.</summary>
        public Location Position { get; set; }

        /// <summary>The <see cref="ModelID"/> for the <see cref="Scripts.ScriptModel"/> currently governing the tracked <see cref="CritterModel"/>.</summary>
        public ModelID CurrentBehaviorID { get; set; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="CritterStatus"/> class.
        /// </summary>
        /// <param name="position">The <see cref="Location"/> the tracked <see cref="CritterModel"/> occupies.</param>
        /// <param name="currentBehavior">The behavior currently governing the tracked <see cref="CritterModel"/>.</param>
        public CritterStatus(Location? position = null, ModelID? currentBehavior = null)
        {
            var nonNullPosition = position ?? Location.Nowhere;
            var nonNullCurrentBehavior = currentBehavior ?? ModelID.None;
            Precondition.IsInRange(nonNullCurrentBehavior, All.ScriptIDs, nameof(currentBehavior));

            Position = nonNullPosition;
            CurrentBehaviorID = nonNullCurrentBehavior;
        }


        /// <summary>
        /// Initializes an instance of the <see cref="CritterStatus"/> class
        /// based on a given <see cref="CritterModel"/> instance.
        /// </summary>
        /// <param name="critterModel">The definitions being tracked.</param>
        public CritterStatus(CritterModel critterModel)
        {
            Precondition.IsNotNull(critterModel);
            var nonNullCritterModel = critterModel ?? CritterModel.Unused;

            Position = Location.Nowhere;
            CurrentBehaviorID = nonNullCritterModel.PrimaryBehaviorID;
        }
        #endregion

        #region IEquatable Implementation
        /// <summary>
        /// Serves as a hash function for a <see cref="CritterStatus"/>.
        /// </summary>
        /// <returns>
        /// A hash code for this instance that is suitable for use in hashing algorithms and data structures.
        /// </returns>
        public override int GetHashCode()
            => (Position, CurrentBehaviorID).GetHashCode();

        /// <summary>
        /// Determines whether the specified <see cref="CritterStatus"/> is equal to the current <see cref="CritterStatus"/>.
        /// </summary>
        /// <param name="status">The <see cref="CritterStatus"/> to compare with the current.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public override bool Equals<T>(T status)
            => status is CritterStatus critterStatus
            && Position == critterStatus.Position
            && CurrentBehaviorID == critterStatus.CurrentBehaviorID;

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="CritterStatus"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="CritterStatus"/>.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
            => obj is CritterStatus status
            && Equals(status);

        /// <summary>
        /// Determines whether a specified instance of <see cref="CritterStatus"/> is equal to another specified instance of <see cref="CritterStatus"/>.
        /// </summary>
        /// <param name="status1">The first <see cref="CritterStatus"/> to compare.</param>
        /// <param name="status2">The second <see cref="CritterStatus"/> to compare.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(CritterStatus status1, CritterStatus status2)
            => status1?.Equals(status2) ?? status2?.Equals(status1) ?? true;

        /// <summary>
        /// Determines whether a specified instance of <see cref="CritterStatus"/> is not equal to another specified instance of <see cref="CritterStatus"/>.
        /// </summary>
        /// <param name="status1">The first <see cref="CritterStatus"/> to compare.</param>
        /// <param name="status2">The second <see cref="CritterStatus"/> to compare.</param>
        /// <returns><c>true</c> if they are NOT equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(CritterStatus status1, CritterStatus status2)
            => !(status1 == status2);
        #endregion

        #region ITypeConverter Implementation
        /// <summary>Allows the converter to construct itself statically.</summary>
        internal static CritterStatus ConverterFactory { get; } = Unused;

        /// <summary>
        /// Converts the given <see cref="object"/> to a <see cref="string"/> for serialization.
        /// </summary>
        /// <param name="value">The instance to convert.</param>
        /// <param name="row">The current context and configuration.</param>
        /// <param name="memberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance serialized.</returns>
        public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
            => value is CritterStatus status
                ? $"{status.Position.ConvertToString(status.Position, row, memberMapData)}{Delimiters.SecondaryDelimiter}" +
                  $"{status.CurrentBehaviorID.ConvertToString(status.CurrentBehaviorID, row, memberMapData)}"
                : Logger.DefaultWithConvertLog(value?.ToString() ?? "null", nameof(CritterStatus), nameof(Unused));

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
                || string.Compare(nameof(Unused), text, StringComparison.OrdinalIgnoreCase) == 0)
            {
                return Logger.DefaultWithConvertLog(text, nameof(CritterStatus), Unused);
            }

            var parameterText = text.Split(Delimiters.SecondaryDelimiter);

            var parsedPosition = (Location)Location.ConverterFactory.ConvertFromString(parameterText[0],
                                                                                       row, memberMapData);
            var parsedCurrentBehaviorID = (ModelID)ModelID.ConverterFactory.ConvertFromString(parameterText[3],
                                                                                              row, memberMapData);

            return new CritterStatus(parsedPosition, parsedCurrentBehaviorID);
        }
        #endregion

        #region IDeeplyCloneable Implementation
        /// <summary>
        /// Creates a new instance that is a deep copy of the current instance.
        /// </summary>
        /// <returns>A new instance with the same status as the current instance.</returns>
        public override T DeepClone<T>()
            => new CritterStatus(Position, CurrentBehaviorID) as T;
        #endregion

        #region Utilities
        /// <summary>
        /// Returns a <see cref="string"/> that represents the current <see cref="CritterStatus"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override string ToString()
            => $"[{nameof(CurrentBehaviorID)} {CurrentBehaviorID} @ {nameof(Position)} {Position}]";
        #endregion
    }
}
