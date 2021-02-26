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
    /// Tracks the status of a <see cref="CharacterModel"/>.
    /// Instances of this class are mutable during play.
    /// </summary>
    /// <remarks>
    /// Most of the game interaction is mediated through instances of this class.
    /// </remarks>
    public class CharacterStatus : BeingStatus<CharacterModel>
    {
        #region Class Defaults
        /// <summary>Provides a throwaway instance of the <see cref="CharacterStatus"/> class with default values.</summary>
        public static CharacterStatus Unused { get; } = new CharacterStatus();
        #endregion

        #region Status
        /// <summary>The <see cref="Location"/> the tracked <see cref="CharacterModel"/> occupies.</summary>
        public Location Position { get; set; }

        /// <summary>The <see cref="Location"/> the tracked <see cref="CharacterModel"/> will next spawn at.</summary>
        /// <remarks>For example, this might be the spot the where when the game was last saved.</remarks>
        public Location SpawnAt { get; set; }

        /// <summary>The <see cref="Location"/> the <see cref="Rooms.Room"/> assigned to this <see cref="CharacterModel"/>.</summary>
        public Location RoomAssignment { get; set; }

        /// <summary>The <see cref="ModelID"/> for the <see cref="Scripts.ScriptModel"/> currently governing the tracked <see cref="CharacterModel"/>.</summary>
        public ModelID CurrentBehaviorID { get; set; }

        /// <summary>The time remaining that the tracked <see cref="CharacterModel"/> can safely remain in the current <see cref="Biomes.BiomeRecipe"/>.</summary>
        public int BiomeTimeRemaining { get; set; }
        #endregion

        #region Collections
        /// <summary>The <see cref="CharacterModel"/>s that this <see cref="CharacterModel"/> has encountered.</summary>
        public ICollection<ModelID> KnownBeings { get; }

        /// <summary>The parquets that this <see cref="CharacterModel"/> has encountered.</summary>
        public ICollection<ModelID> KnownParquets { get; }

        /// <summary>The <see cref="Rooms.RoomRecipe"/>s that this <see cref="CharacterModel"/> knows.</summary>
        public ICollection<ModelID> KnownRoomRecipes { get; }

        /// <summary>The <see cref="Crafts.CraftingRecipe"/>s that this <see cref="CharacterModel"/> knows.</summary>
        public ICollection<ModelID> KnownCraftingRecipes { get; }

        /// <summary>The <see cref="Scripts.InteractionModel"/>s that this <see cref="CharacterModel"/> offers or has undertaken.</summary>
        public ICollection<ModelID> Quests { get; }

        /// <summary>This <see cref="CharacterModel"/>'s set of belongings.</summary>
        public InventoryCollection Inventory { get; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="CharacterStatus"/> class.
        /// </summary>
        /// <param name="inPosition">The <see cref="Location"/> the tracked <see cref="CharacterModel"/> occupies.</param>
        /// <param name="inSpawnAt">The <see cref="Location"/> the tracked <see cref="CharacterModel"/> will next spawn at.</param>
        /// <param name="inRoomAssignment">The <see cref="Location"/> of the <see cref="Rooms.Room"/> to which the tracked <see cref="CharacterModel"/> is assigned.</param>
        /// <param name="inCurrentBehavior">The behavior currently governing the tracked <see cref="CharacterModel"/>.</param>
        /// <param name="inBiomeTimeRemaining">How long [TODO in what units?] before the <see cref="CharacterModel"/> must leave the <see cref="Biomes.BiomeRecipe"/>.</param>
        /// <param name="inKnownBeings">The <see cref="CritterModel"/>s that this <see cref="CharacterModel"/> has encountered.</param>
        /// <param name="inKnownParquets">The parquets that this <see cref="CharacterModel"/> has encountered.</param>
        /// <param name="inKnownRoomRecipes">The <see cref="Rooms.RoomRecipe"/>s that this <see cref="CharacterModel"/> knows.</param>
        /// <param name="inKnownCraftingRecipes">The <see cref="Crafts.CraftingRecipe"/>s that this <see cref="CharacterModel"/> knows.</param>
        /// <param name="inQuests">The <see cref="Scripts.InteractionModel"/>s that this <see cref="CharacterModel"/> offers or has undertaken.</param>
        /// <param name="inInventory">This <see cref="CharacterModel"/>'s set of belongings.</param>
        public CharacterStatus(Location? inPosition = null, Location? inSpawnAt = null, Location? inRoomAssignment = null,
                               ModelID? inCurrentBehavior = null, int inBiomeTimeRemaining = int.MaxValue,
                               ICollection<ModelID> inKnownBeings = null, ICollection<ModelID> inKnownParquets = null,
                               ICollection<ModelID> inKnownRoomRecipes = null, ICollection<ModelID> inKnownCraftingRecipes = null,
                               ICollection<ModelID> inQuests = null, InventoryCollection inInventory = null)
        {
            var nonNullPosition = inPosition ?? Location.Nowhere;
            var nonNullSpawnAt = inSpawnAt ?? Location.Nowhere;
            var nonNullRoomAssignment = inRoomAssignment ?? Location.Nowhere;
            var nonNullCurrentBehavior = inCurrentBehavior ?? ModelID.None;
            Precondition.IsInRange(nonNullCurrentBehavior, All.ScriptIDs, nameof(inCurrentBehavior));
            var nonNullBeings = inKnownBeings ?? Enumerable.Empty<ModelID>().ToList();
            var nonNullParquets = inKnownParquets ?? Enumerable.Empty<ModelID>().ToList();
            var nonNullRoomRecipes = inKnownRoomRecipes ?? Enumerable.Empty<ModelID>().ToList();
            var nonNullCraftingRecipes = inKnownCraftingRecipes ?? Enumerable.Empty<ModelID>().ToList();
            var nonNullQuests = inQuests ?? Enumerable.Empty<ModelID>().ToList();
            var nonNullInventory = inInventory ?? InventoryCollection.Empty;
            Precondition.AreInRange(nonNullBeings, All.CritterIDs, nameof(inKnownBeings));
            Precondition.AreInRange(nonNullParquets, All.ParquetIDs, nameof(inKnownParquets));
            Precondition.AreInRange(nonNullRoomRecipes, All.RoomRecipeIDs, nameof(inKnownRoomRecipes));
            Precondition.AreInRange(nonNullCraftingRecipes, All.CraftingRecipeIDs, nameof(inKnownCraftingRecipes));
            Precondition.AreInRange(nonNullQuests, All.InteractionIDs, nameof(inQuests));

            Position = nonNullPosition;
            SpawnAt = nonNullSpawnAt;
            RoomAssignment = nonNullRoomAssignment;
            CurrentBehaviorID = nonNullCurrentBehavior;
            BiomeTimeRemaining = inBiomeTimeRemaining;
            KnownBeings = nonNullBeings;
            KnownParquets = nonNullParquets;
            KnownRoomRecipes = nonNullRoomRecipes;
            KnownCraftingRecipes = nonNullCraftingRecipes;
            Quests = nonNullQuests;
            Inventory = nonNullInventory;
        }


        /// <summary>
        /// Initializes an instance of the <see cref="CharacterStatus"/> class
        /// based on a given <see cref="CharacterModel"/> instance.
        /// </summary>
        /// <param name="inCharacterModel">The definitions being tracked.</param>
        public CharacterStatus(CharacterModel inCharacterModel)
        {
            Precondition.IsNotNull(inCharacterModel);
            var nonNullCharacterModel = inCharacterModel ?? CharacterModel.Unused;

            Position = Location.Nowhere;
            SpawnAt = nonNullCharacterModel.StartingLocation;
            RoomAssignment = Location.Nowhere;
            CurrentBehaviorID = nonNullCharacterModel.PrimaryBehaviorID;
            BiomeTimeRemaining = int.MaxValue;
            KnownBeings = Enumerable.Empty<ModelID>().ToList();
            KnownParquets = Enumerable.Empty<ModelID>().ToList();
            KnownRoomRecipes = Enumerable.Empty<ModelID>().ToList();
            KnownCraftingRecipes = Enumerable.Empty<ModelID>().ToList();
            Quests = nonNullCharacterModel.StartingQuestIDs.ToList();
            Inventory = nonNullCharacterModel.StartingInventory.DeepClone();
        }
        #endregion

        #region IEquatable Implementation
        /// <summary>
        /// Serves as a hash function for a <see cref="CharacterStatus"/>.
        /// </summary>
        /// <returns>
        /// A hash code for this instance that is suitable for use in hashing algorithms and data structures.
        /// </returns>
        public override int GetHashCode()
            => (CurrentBehaviorID,
                Position,
                SpawnAt,
                RoomAssignment,
                BiomeTimeRemaining,
                KnownBeings,
                KnownParquets,
                KnownRoomRecipes,
                KnownCraftingRecipes,
                Quests,
                Inventory).GetHashCode();

        /// <summary>
        /// Determines whether the specified <see cref="CharacterStatus"/> is equal to the current <see cref="CharacterStatus"/>.
        /// </summary>
        /// <param name="inStatus">The <see cref="CharacterStatus"/> to compare with the current.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public override bool Equals<T>(T inStatus)
            => inStatus is CharacterStatus characterStatus
            && CurrentBehaviorID == characterStatus.CurrentBehaviorID
            && Position == characterStatus.Position
            && SpawnAt == characterStatus.SpawnAt
            && RoomAssignment == characterStatus.RoomAssignment
            && BiomeTimeRemaining == characterStatus.BiomeTimeRemaining
            && KnownBeings == characterStatus.KnownBeings
            && KnownParquets == characterStatus.KnownParquets
            && KnownRoomRecipes == characterStatus.KnownRoomRecipes
            && KnownCraftingRecipes == characterStatus.KnownCraftingRecipes
            && Quests == characterStatus.Quests
            && Inventory == characterStatus.Inventory;

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="CharacterStatus"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="CharacterStatus"/>.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
            => obj is CharacterStatus status
            && Equals(status);

        /// <summary>
        /// Determines whether a specified instance of <see cref="CharacterStatus"/> is equal to another specified instance of <see cref="CharacterStatus"/>.
        /// </summary>
        /// <param name="inStatus1">The first <see cref="CharacterStatus"/> to compare.</param>
        /// <param name="inStatus2">The second <see cref="CharacterStatus"/> to compare.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(CharacterStatus inStatus1, CharacterStatus inStatus2)
            => inStatus1?.Equals(inStatus2) ?? inStatus2?.Equals(inStatus1) ?? true;

        /// <summary>
        /// Determines whether a specified instance of <see cref="CharacterStatus"/> is not equal to another specified instance of <see cref="CharacterStatus"/>.
        /// </summary>
        /// <param name="inStatus1">The first <see cref="CharacterStatus"/> to compare.</param>
        /// <param name="inStatus2">The second <see cref="CharacterStatus"/> to compare.</param>
        /// <returns><c>true</c> if they are NOT equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(CharacterStatus inStatus1, CharacterStatus inStatus2)
            => !(inStatus1 == inStatus2);
        #endregion

        #region ITypeConverter Implementation
        /// <summary>Allows the converter to construct itself statically.</summary>
        internal static CharacterStatus ConverterFactory { get; } = Unused;

        /// <summary>
        /// Converts the given <see cref="object"/> to a <see cref="string"/> for serialization.
        /// </summary>
        /// <param name="inValue">The instance to convert.</param>
        /// <param name="inRow">The current context and configuration.</param>
        /// <param name="inMemberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance serialized.</returns>
        public override string ConvertToString(object inValue, IWriterRow inRow, MemberMapData inMemberMapData)
            => inValue is CharacterStatus status
                ? $"{status.CurrentBehaviorID.ConvertToString(status.CurrentBehaviorID, inRow, inMemberMapData)}{Delimiters.SecondaryDelimiter}" +
                  $"{status.Position.ConvertToString(status.Position, inRow, inMemberMapData)}{Delimiters.SecondaryDelimiter}" +
                  $"{status.SpawnAt.ConvertToString(status.SpawnAt, inRow, inMemberMapData)}{Delimiters.SecondaryDelimiter}" +
                  $"{status.RoomAssignment.ConvertToString(status.RoomAssignment, inRow, inMemberMapData)}{Delimiters.SecondaryDelimiter}" +
                  $"{status.BiomeTimeRemaining}{Delimiters.SecondaryDelimiter}" +
                  $"{SeriesConverter<ModelID, List<ModelID>>.ConverterFactory.ConvertToString(status.KnownBeings, inRow, inMemberMapData)}{Delimiters.SecondaryDelimiter}" +
                  $"{SeriesConverter<ModelID, List<ModelID>>.ConverterFactory.ConvertToString(status.KnownParquets, inRow, inMemberMapData)}{Delimiters.SecondaryDelimiter}" +
                  $"{SeriesConverter<ModelID, List<ModelID>>.ConverterFactory.ConvertToString(status.KnownRoomRecipes, inRow, inMemberMapData)}{Delimiters.SecondaryDelimiter}" +
                  $"{SeriesConverter<ModelID, List<ModelID>>.ConverterFactory.ConvertToString(status.KnownCraftingRecipes, inRow, inMemberMapData)}{Delimiters.SecondaryDelimiter}" +
                  $"{SeriesConverter<ModelID, List<ModelID>>.ConverterFactory.ConvertToString(status.Quests, inRow, inMemberMapData)}{Delimiters.SecondaryDelimiter}" +
                  $"{SeriesConverter<ModelID, List<ModelID>>.ConverterFactory.ConvertToString(status.Inventory, inRow, inMemberMapData)}"
                : Logger.DefaultWithConvertLog(inValue?.ToString() ?? "null", nameof(CharacterStatus), nameof(Unused));

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
                return Logger.DefaultWithConvertLog(inText, nameof(CharacterStatus), Unused);
            }

            var parameterText = inText.Split(Delimiters.SecondaryDelimiter);

            var parsedPosition = (Location)Location.ConverterFactory.ConvertFromString(parameterText[0],
                                                                                       inRow, inMemberMapData);
            var parsedSpawnAt = (Location)Location.ConverterFactory.ConvertFromString(parameterText[1],
                                                                                      inRow, inMemberMapData);
            var parsedRoomAssignment = (Location)Location.ConverterFactory.ConvertFromString(parameterText[2],
                                                                                             inRow, inMemberMapData);
            var parsedCurrentBehaviorID = (ModelID)ModelID.ConverterFactory.ConvertFromString(parameterText[3],
                                                                                              inRow, inMemberMapData);
            var parsedBiomeTimeRemaining = int.TryParse(parameterText[4], All.SerializedNumberStyle,
                                                        CultureInfo.InvariantCulture, out var temp4)
                ? temp4
                : Logger.DefaultWithParseLog(parameterText[4], nameof(BiomeTimeRemaining), int.MaxValue);
            var parsedKnownBeings = (ICollection<ModelID>)
                SeriesConverter<ModelID, List<ModelID>>.ConverterFactory.ConvertFromString(parameterText[9], inRow,
                                                                                           inMemberMapData);
            var parsedKnownParquets = (ICollection<ModelID>)
                SeriesConverter<ModelID, List<ModelID>>.ConverterFactory
                                                       .ConvertFromString(parameterText[10], inRow, inMemberMapData);
            var parsedKnownRoomRecipes = (ICollection<ModelID>)
                SeriesConverter<ModelID, List<ModelID>>.ConverterFactory.ConvertFromString(parameterText[11], inRow,
                                                                                           inMemberMapData);
            var parsedKnownCraftingRecipes = (ICollection<ModelID>)
                SeriesConverter<ModelID, List<ModelID>>.ConverterFactory.ConvertFromString(parameterText[12], inRow,
                                                                                           inMemberMapData);
            var parsedQuests = (ICollection<ModelID>)
                SeriesConverter<ModelID, List<ModelID>>.ConverterFactory.ConvertFromString(parameterText[13], inRow,
                                                                                           inMemberMapData);
            var parsedInventory = (InventoryCollection)
                SeriesConverter<InventorySlot, InventoryCollection>.ConverterFactory.ConvertFromString(parameterText[14], inRow,
                                                                                             inMemberMapData);

            return new CharacterStatus(parsedPosition,
                                       parsedSpawnAt,
                                       parsedRoomAssignment,
                                       parsedCurrentBehaviorID,
                                       parsedBiomeTimeRemaining,
                                       parsedKnownBeings,
                                       parsedKnownParquets,
                                       parsedKnownRoomRecipes,
                                       parsedKnownCraftingRecipes,
                                       parsedQuests,
                                       parsedInventory);
        }
        #endregion

        #region IDeeplyCloneable Implementation
        /// <summary>
        /// Creates a new instance that is a deep copy of the current instance.
        /// </summary>
        /// <returns>A new instance with the same status as the current instance.</returns>
        public override T DeepClone<T>()
            => new CharacterStatus(Position,
                                   SpawnAt,
                                   RoomAssignment,
                                   CurrentBehaviorID,
                                   BiomeTimeRemaining,
                                   // Note: The following .ToList() perform shallow copies, but this is acceptable as ModelID has value semantics
                                   KnownBeings.ToList(),
                                   KnownParquets.ToList(),
                                   KnownRoomRecipes.ToList(),
                                   KnownCraftingRecipes.ToList(),
                                   Quests.ToList(),
                                   Inventory) as T;
        #endregion

        #region Utilities
        /// <summary>
        /// Returns a <see cref="string"/> that represents the current <see cref="CharacterStatus"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override string ToString()
            => $"[{nameof(CurrentBehaviorID)} {CurrentBehaviorID} @ {nameof(Position)} {Position}]";
        #endregion
    }
}
