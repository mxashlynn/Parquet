using System;
using CsvHelper;
using CsvHelper.Configuration;

namespace Parquet.Games
{
    /// <summary>
    /// Tracks the status of a <see cref="GameModel"/>.
    /// Instances of this class are mutable during play.
    /// </summary>
    public sealed class GameStatus : Status<GameModel>
    {
        #region Class Defaults
        /// <summary>Provides an instance of the <see cref="GameStatus"/> class with default values.</summary>
        public static GameStatus Default { get; } = new GameStatus();
        #endregion

        #region Status
        /// <summary>The <see cref="ModelID"/> of the <see cref="Beings.CharacterModel"/> that the player controls.</summary>
        public ModelID PlayerCharacterID { get; set; }

        /// <summary>The <see cref="ModelID"/> of the <see cref="Scripts.ScriptModel"/> that is running.</summary>
        public ModelID CurrentScriptID { get; set; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new default instance of the <see cref="GameStatus"/> class.
        /// </summary>
        /// <remarks>This is primarily useful for serialization.</remarks>
        public GameStatus()
            : this(null, null)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="GameStatus"/> class.
        /// </summary>
        /// <param name="inPlayerCharacterID">The <see cref="ModelID"/> of the <see cref="Beings.CharacterModel"/> that the player controls at the outset.</param>
        /// <param name="inCurrentScriptID">The <see cref="ModelID"/> of the <see cref="Scripts.ScriptModel"/> to run when play begins.</param>
        public GameStatus(ModelID? inPlayerCharacterID, ModelID? inCurrentScriptID)
        {
            PlayerCharacterID = inPlayerCharacterID ?? ModelID.None;
            CurrentScriptID = inCurrentScriptID ?? ModelID.None;
        }

        /// <summary>
        /// Initializes an instance of the <see cref="GameStatus"/> class
        /// based on a given <see cref="GameModel"/> instance.
        /// </summary>
        /// <param name="inGameModel">The definitions being tracked.</param>
        public GameStatus(GameModel inGameModel)
        {
            Precondition.IsNotNull(inGameModel);
            var nonNullGameModel = inGameModel is null
                ? GameModel.Empty
                : inGameModel;

            PlayerCharacterID = nonNullGameModel.PlayerCharacterID;
            CurrentScriptID = nonNullGameModel.FirstScriptID;
        }
        #endregion

        #region IEquatable Implementation
        /// <summary>
        /// Serves as a hash function for a <see cref="GameStatus"/>.
        /// </summary>
        /// <returns>A hash code for this instance that is suitable for use in hashing algorithms and data structures.</returns>
        public override int GetHashCode()
            => (PlayerCharacterID, CurrentScriptID).GetHashCode();

        /// <summary>
        /// Determines whether the specified <see cref="GameStatus"/> is equal to the current <see cref="GameStatus"/>.
        /// </summary>
        /// <param name="inStatus">The <see cref="GameStatus"/> to compare with the current.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public override bool Equals<T>(T inStatus)
            => inStatus is GameStatus status
            && PlayerCharacterID == status.PlayerCharacterID
            && CurrentScriptID == status.CurrentScriptID;

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="GameStatus"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="GameStatus"/>.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
            => obj is GameStatus status
            && Equals(status);

        /// <summary>
        /// Determines whether a specified instance of <see cref="GameStatus"/> is equal to another specified instance of <see cref="GameStatus"/>.
        /// </summary>
        /// <param name="inStatus1">The first <see cref="GameStatus"/> to compare.</param>
        /// <param name="inStatus2">The second <see cref="GameStatus"/> to compare.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(GameStatus inStatus1, GameStatus inStatus2)
            => inStatus1?.Equals(inStatus2) ?? inStatus2?.Equals(inStatus1) ?? true;

        /// <summary>
        /// Determines whether a specified instance of <see cref="GameStatus"/> is not equal to another specified instance of <see cref="GameStatus"/>.
        /// </summary>
        /// <param name="inStatus1">The first <see cref="GameStatus"/> to compare.</param>
        /// <param name="inStatus2">The second <see cref="GameStatus"/> to compare.</param>
        /// <returns><c>true</c> if they are NOT equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(GameStatus inStatus1, GameStatus inStatus2)
            => !(inStatus1 == inStatus2);
        #endregion

        #region ITypeConverter Implementation
        /// <summary>Allows the converter to construct itself statically.</summary>
        internal static GameStatus ConverterFactory { get; } = Default;

        /// <summary>
        /// Converts the given <see cref="object"/> to a <see cref="string"/> for serialization.
        /// </summary>
        /// <param name="inValue">The instance to convert.</param>
        /// <param name="inRow">The current context and configuration.</param>
        /// <param name="inMemberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance serialized.</returns>
        public override string ConvertToString(object inValue, IWriterRow inRow, MemberMapData inMemberMapData)
            => inValue is GameStatus status
                ? $"{ModelID.ConverterFactory.ConvertToString(status.PlayerCharacterID, inRow, inMemberMapData)}{Delimiters.InternalDelimiter}" +
                  $"{ModelID.ConverterFactory.ConvertToString(status.CurrentScriptID, inRow, inMemberMapData)}"
                : Logger.DefaultWithConvertLog(inValue?.ToString() ?? "null", nameof(GameStatus), nameof(Default));

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
                || string.Compare(nameof(Default), inText, StringComparison.OrdinalIgnoreCase) == 0)
            {
                return Default.DeepClone();
            }

            var parameterText = inText.Split(Delimiters.InternalDelimiter);

            var parsedPlayerCharacterID = (ModelID)ModelID.ConverterFactory.ConvertFromString(parameterText[0], inRow, inMemberMapData);
            var parsedCurrentScriptID = (ModelID)ModelID.ConverterFactory.ConvertFromString(parameterText[1], inRow, inMemberMapData);

            return new GameStatus(parsedPlayerCharacterID, parsedCurrentScriptID);
        }
        #endregion

        #region IDeeplyCloneable Implementation
        /// <summary>
        /// Creates a new instance that is a deep copy of the current instance.
        /// </summary>
        /// <returns>A new instance with the same status as the current instance.</returns>
        public override T DeepClone<T>()
            => new GameStatus(PlayerCharacterID, CurrentScriptID) as T;
        #endregion

        #region Utilities
        /// <summary>
        /// Returns a <see cref="string"/> that represents the current <see cref="GameStatus"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override string ToString()
            => $"[{nameof(PlayerCharacterID)} {PlayerCharacterID}, {nameof(CurrentScriptID)} {CurrentScriptID}]";
        #endregion
    }
}
