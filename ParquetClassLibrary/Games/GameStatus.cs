using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
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
        /// <param name="playerCharacterID">The <see cref="ModelID"/> of the <see cref="Beings.CharacterModel"/> that the player controls at the outset.</param>
        /// <param name="currentScriptID">The <see cref="ModelID"/> of the <see cref="Scripts.ScriptModel"/> to run when play begins.</param>
        public GameStatus(ModelID? playerCharacterID, ModelID? currentScriptID)
        {
            PlayerCharacterID = playerCharacterID ?? ModelID.None;
            CurrentScriptID = currentScriptID ?? ModelID.None;
        }

        /// <summary>
        /// Initializes an instance of the <see cref="GameStatus"/> class
        /// based on a given <see cref="GameModel"/> instance.
        /// </summary>
        /// <param name="gameModel">The definitions being tracked.</param>
        public GameStatus(GameModel gameModel)
        {
            Precondition.IsNotNull(gameModel);
            var nonNullGameModel = gameModel is null
                ? GameModel.Empty
                : gameModel;

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
        /// <param name="status">The <see cref="GameStatus"/> to compare with the current.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public override bool Equals<T>(T status)
            => status is GameStatus gameStatus
            && PlayerCharacterID == gameStatus.PlayerCharacterID
            && CurrentScriptID == gameStatus.CurrentScriptID;

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
        /// <param name="status1">The first <see cref="GameStatus"/> to compare.</param>
        /// <param name="status2">The second <see cref="GameStatus"/> to compare.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(GameStatus status1, GameStatus status2)
            => status1?.Equals(status2) ?? status2?.Equals(status1) ?? true;

        /// <summary>
        /// Determines whether a specified instance of <see cref="GameStatus"/> is not equal to another specified instance of <see cref="GameStatus"/>.
        /// </summary>
        /// <param name="status1">The first <see cref="GameStatus"/> to compare.</param>
        /// <param name="status2">The second <see cref="GameStatus"/> to compare.</param>
        /// <returns><c>true</c> if they are NOT equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(GameStatus status1, GameStatus status2)
            => !(status1 == status2);
        #endregion

        #region ITypeConverter Implementation
        /// <summary>Allows the converter to construct itself statically.</summary>
        internal static GameStatus ConverterFactory { get; } = Default;

        /// <summary>
        /// Converts the given <see cref="object"/> to a <see cref="string"/> for serialization.
        /// </summary>
        /// <param name="value">The instance to convert.</param>
        /// <param name="row">The current context and configuration.</param>
        /// <param name="memberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance serialized.</returns>
        public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
            => value is GameStatus status
                ? $"{ModelID.ConverterFactory.ConvertToString(status.PlayerCharacterID, row, memberMapData)}{Delimiters.InternalDelimiter}" +
                  $"{ModelID.ConverterFactory.ConvertToString(status.CurrentScriptID, row, memberMapData)}"
                : Logger.DefaultWithConvertLog(value?.ToString() ?? "null", nameof(GameStatus), nameof(Default));

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
                || string.Equals(nameof(Default), text, StringComparison.OrdinalIgnoreCase))
            {
                return Default.DeepClone();
            }

            var parameterText = text.Split(Delimiters.InternalDelimiter);

            var parsedPlayerCharacterID = (ModelID)ModelID.ConverterFactory.ConvertFromString(parameterText[0], row, memberMapData);
            var parsedCurrentScriptID = (ModelID)ModelID.ConverterFactory.ConvertFromString(parameterText[1], row, memberMapData);

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

        #region Self Serialization
        /// <summary>
        /// Reads all <see cref="GameStatus"/> records from the appropriate file.
        /// </summary>
        /// <returns>The instances read.</returns>
        public static Dictionary<ModelID, GameStatus> GetRecords()
        {
            using var reader = new StreamReader(FilePath);
            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            csv.Configuration.TypeConverterOptionsCache.AddOptions(typeof(ModelID), All.IdentifierOptions);
            csv.Configuration.PrepareHeaderForMatch = (string header, int index) => header.ToUpperInvariant();
            foreach (var kvp in All.ConversionConverters)
            {
                csv.Configuration.TypeConverterCache.AddConverter(kvp.Key, kvp.Value);
            }

            return new Dictionary<ModelID, GameStatus>(csv.GetRecords<KeyValuePair<ModelID, GameStatus>>());
        }

        /// <summary>
        /// Writes the given <see cref="GameStatus"/> records to the appropriate file.
        /// </summary>
        public static void PutRecords(IEnumerable<KeyValuePair<ModelID, GameStatus>> gameStatuses)
        {
            if (gameStatuses is null)
            {
                gameStatuses = Enumerable.Empty<KeyValuePair<ModelID, GameStatus>>();
            }

            using var writer = new StreamWriter(FilePath, false, new UTF8Encoding(true, true));
            using var csv = new CsvWriter(writer, CultureInfo.InvariantCulture);
            csv.Configuration.NewLine = NewLine.LF;
            csv.Configuration.TypeConverterOptionsCache.AddOptions(typeof(ModelID), All.IdentifierOptions);
            foreach (var kvp in All.ConversionConverters)
            {
                csv.Configuration.TypeConverterCache.AddConverter(kvp.Key, kvp.Value);
            }

            csv.WriteHeader<KeyValuePair<ModelID, GameStatus>>();
            csv.NextRecord();
            csv.WriteRecords(gameStatuses);
        }
        #endregion

        #region Utilities
        /// <summary>
        /// Returns the filename and path associated with <see cref="GameStatus"/>'s definition file.
        /// </summary>
        /// <returns>A full path to the associated file.</returns>
        public static string FilePath
            => $"{All.ProjectDirectory}/{nameof(GameStatus)}es.csv";

        /// <summary>
        /// Returns a <see cref="string"/> that represents the current <see cref="GameStatus"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override string ToString()
            => $"[{nameof(PlayerCharacterID)} {PlayerCharacterID}, {nameof(CurrentScriptID)} {CurrentScriptID}]";
        #endregion
    }
}
