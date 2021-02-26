using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using Parquet.Items;

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
        /// <param name="inPosition">The <see cref="Location"/> the tracked <see cref="CritterModel"/> occupies.</param>
        /// <param name="inCurrentBehavior">The behavior currently governing the tracked <see cref="CritterModel"/>.</param>
        public CritterStatus(Location? inPosition = null, ModelID? inCurrentBehavior = null)
        {
            var nonNullPosition = inPosition ?? Location.Nowhere;
            var nonNullCurrentBehavior = inCurrentBehavior ?? ModelID.None;
            Precondition.IsInRange(nonNullCurrentBehavior, All.ScriptIDs, nameof(inCurrentBehavior));

            Position = nonNullPosition;
            CurrentBehaviorID = nonNullCurrentBehavior;
        }


        /// <summary>
        /// Initializes an instance of the <see cref="CritterStatus"/> class
        /// based on a given <see cref="CritterModel"/> instance.
        /// </summary>
        /// <param name="inCritterModel">The definitions being tracked.</param>
        public CritterStatus(CritterModel inCritterModel)
        {
            Precondition.IsNotNull(inCritterModel);
            var nonNullCritterModel = inCritterModel ?? CritterModel.Unused;

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
        /// <param name="inStatus">The <see cref="CritterStatus"/> to compare with the current.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public override bool Equals<T>(T inStatus)
            => inStatus is CritterStatus critterStatus
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
        /// <param name="inStatus1">The first <see cref="CritterStatus"/> to compare.</param>
        /// <param name="inStatus2">The second <see cref="CritterStatus"/> to compare.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(CritterStatus inStatus1, CritterStatus inStatus2)
            => inStatus1?.Equals(inStatus2) ?? inStatus2?.Equals(inStatus1) ?? true;

        /// <summary>
        /// Determines whether a specified instance of <see cref="CritterStatus"/> is not equal to another specified instance of <see cref="CritterStatus"/>.
        /// </summary>
        /// <param name="inStatus1">The first <see cref="CritterStatus"/> to compare.</param>
        /// <param name="inStatus2">The second <see cref="CritterStatus"/> to compare.</param>
        /// <returns><c>true</c> if they are NOT equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(CritterStatus inStatus1, CritterStatus inStatus2)
            => !(inStatus1 == inStatus2);
        #endregion

        #region ITypeConverter Implementation
        /// <summary>Allows the converter to construct itself statically.</summary>
        internal static CritterStatus ConverterFactory { get; } = Unused;

        /// <summary>
        /// Converts the given <see cref="object"/> to a <see cref="string"/> for serialization.
        /// </summary>
        /// <param name="inValue">The instance to convert.</param>
        /// <param name="inRow">The current context and configuration.</param>
        /// <param name="inMemberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance serialized.</returns>
        public override string ConvertToString(object inValue, IWriterRow inRow, MemberMapData inMemberMapData)
            => inValue is CritterStatus status
                ? $"{status.Position.ConvertToString(status.Position, inRow, inMemberMapData)}{Delimiters.SecondaryDelimiter}" +
                  $"{status.CurrentBehaviorID.ConvertToString(status.CurrentBehaviorID, inRow, inMemberMapData)}"
                : Logger.DefaultWithConvertLog(inValue?.ToString() ?? "null", nameof(CritterStatus), nameof(Unused));

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
                || string.Compare(nameof(Unused), inText, StringComparison.OrdinalIgnoreCase) == 0)
            {
                return Logger.DefaultWithConvertLog(inText, nameof(CritterStatus), Unused);
            }

            var parameterText = inText.Split(Delimiters.SecondaryDelimiter);

            var parsedPosition = (Location)Location.ConverterFactory.ConvertFromString(parameterText[0],
                                                                                       inRow, inMemberMapData);
            var parsedCurrentBehaviorID = (ModelID)ModelID.ConverterFactory.ConvertFromString(parameterText[3],
                                                                                              inRow, inMemberMapData);

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
