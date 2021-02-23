using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;

namespace Parquet.Beings
{
    /// <summary>
    /// Tracks the status of a <see cref="BeingModel"/>.
    /// Instances of this class are mutable during play.
    /// </summary>
    public class BeingStatus : Status<BeingModel>
    {
        #region Class Defaults
        /// <summary>Provides a throwaway instance of the <see cref="ParquetPackStatus"/> class with default values.</summary>
        public static BeingStatus Unused { get; } = new BeingStatus();
        #endregion

        #region Status
        /// <summary>The <see cref="Location"/> the tracked <see cref="BeingModel"/> occupies.</summary>
        public Location Position { get; set; }

        /// <summary>The <see cref="Location"/> the tracked <see cref="BeingModel"/> will next spawn at.</summary>
        /// <remarks>For example, for <see cref="CharacterModel"/>s, this might be the spot the where when the game was last saved.</remarks>
        public Location SpawnAt { get; set; }

        /// <summary>The <see cref="Location"/> the <see cref="Rooms.Room"/> assigned to this <see cref="BeingModel"/>.</summary>
        public Location RoomAssignment { get; set; }

        /// <summary>The <see cref="ModelID"/> for the <see cref="Scripts.ScriptModel"/> currently governing the tracked <see cref="BeingModel"/>.</summary>
        public ModelID CurrentBehaviorID { get; set; }

        /// <summary>The time remaining that the tracked <see cref="BeingModel"/> can safely remain in the current <see cref="Biomes.BiomeRecipe"/>.</summary>
        /// <remarks>It is likely that this will only be used by <see cref="CharacterModel"/> but may be useful for other beings as well.</remarks>
        public int BiomeTimeRemaining { get; set; }

        /// <summary>The time it takes the tracked <see cref="BeingModel"/> to place new parquets.</summary>
        public float BuildingSpeed { get; set; }

        /// <summary>The time it takes the tracked <see cref="BeingModel"/> to modify existing parquets.</summary>
        public float ModificationSpeed { get; set; }

        /// <summary>The time it takes the tracked <see cref="BeingModel"/> to gather existing parquets.</summary>
        public float GatheringSpeed { get; set; }

        /// <summary>The time it takes the tracked <see cref="BeingModel"/> to walk from one <see cref="Location"/> to another.</summary>
        public float MovementSpeed { get; set; }
        #endregion

        #region Collections
        /// <summary>The <see cref="BeingModel"/>s that this <see cref="CharacterModel"/> has encountered.</summary>
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
        public ICollection<ModelID> Inventory { get; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="BeingStatus"/> class.
        /// </summary>
        /// <param name="inPosition">The <see cref="Location"/> the tracked <see cref="BeingModel"/> occupies.</param>
        /// <param name="inSpawnAt">The <see cref="Location"/> the tracked <see cref="BeingModel"/> will next spawn at.</param>
        /// <param name="inRoomAssignment">The <see cref="Location"/> of the <see cref="Rooms.Room"/> to which the tracked <see cref="BeingModel"/> is assigned.</param>
        /// <param name="inCurrentBehavior">The behavior currently governing the tracked <see cref="BeingModel"/>.</param>
        /// <param name="inBiomeTimeRemaining">How long [TODO in what units?] to until being kicked out of the current <see cref="Biomes.BiomeRecipe"/>.</param>
        /// <param name="inBuildingSpeed">The time it takes the tracked <see cref="BeingModel"/> to place new parquets.</param>
        /// <param name="inModificationSpeed">The time it takes the tracked <see cref="BeingModel"/> to modify existing parquets.</param>
        /// <param name="inGatheringSpeed">The time it takes the tracked <see cref="BeingModel"/> to gather existing parquets.</param>
        /// <param name="inMovementSpeed">The time it takes the tracked <see cref="BeingModel"/> to walk from one <see cref="Location"/> to another.</param>
        /// <param name="inKnownBeings">The <see cref="CritterModel"/>s that this <see cref="CharacterModel"/> has encountered.</param>
        /// <param name="inKnownParquets">The parquets that this <see cref="CharacterModel"/> has encountered.</param>
        /// <param name="inKnownRoomRecipes">The <see cref="Rooms.RoomRecipe"/>s that this <see cref="CharacterModel"/> knows.</param>
        /// <param name="inKnownCraftingRecipes">The <see cref="Crafts.CraftingRecipe"/>s that this <see cref="CharacterModel"/> knows.</param>
        /// <param name="inQuests">The <see cref="Scripts.InteractionModel"/>s that this <see cref="CharacterModel"/> offers or has undertaken.</param>
        /// <param name="inInventory">This <see cref="CharacterModel"/>'s set of belongings.</param>
        public BeingStatus(Location inPosition = null, Location inSpawnAt = null, Location inRoomAssignment = null,
                           ModelID? inCurrentBehavior = null, int inBiomeTimeRemaining = 0, float inBuildingSpeed = 0f,
                           float inModificationSpeed = 0f, float inGatheringSpeed = 0f, float inMovementSpeed = 0f,
                           ICollection<ModelID> inKnownBeings = null, ICollection<ModelID> inKnownParquets = null,
                           ICollection<ModelID> inKnownRoomRecipes = null, ICollection<ModelID> inKnownCraftingRecipes = null,
                           ICollection<ModelID> inQuests = null, ICollection<ModelID> inInventory = null)
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
            var nonNullInventory = inInventory ?? Enumerable.Empty<ModelID>().ToList();
            Precondition.AreInRange(nonNullBeings, All.CritterIDs, nameof(inKnownBeings));
            Precondition.AreInRange(nonNullParquets, All.ParquetIDs, nameof(inKnownParquets));
            Precondition.AreInRange(nonNullRoomRecipes, All.RoomRecipeIDs, nameof(inKnownRoomRecipes));
            Precondition.AreInRange(nonNullCraftingRecipes, All.CraftingRecipeIDs, nameof(inKnownCraftingRecipes));
            Precondition.AreInRange(nonNullQuests, All.InteractionIDs, nameof(inQuests));
            Precondition.AreInRange(nonNullInventory, All.ItemIDs, nameof(inInventory));

            Position = nonNullPosition;
            SpawnAt = nonNullSpawnAt;
            RoomAssignment = nonNullRoomAssignment;
            CurrentBehaviorID = nonNullCurrentBehavior;
            BiomeTimeRemaining = inBiomeTimeRemaining;
            BuildingSpeed = inBuildingSpeed;
            ModificationSpeed = inModificationSpeed;
            GatheringSpeed = inGatheringSpeed;
            MovementSpeed = inMovementSpeed;
            KnownBeings = nonNullBeings;
            KnownParquets = nonNullParquets;
            KnownRoomRecipes = nonNullRoomRecipes;
            KnownCraftingRecipes = nonNullCraftingRecipes;
            Quests = nonNullQuests;
            Inventory = nonNullInventory;
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
            => (CurrentBehaviorID,
                Position,
                SpawnAt,
                RoomAssignment,
                BiomeTimeRemaining,
                BuildingSpeed,
                ModificationSpeed,
                GatheringSpeed,
                MovementSpeed,
                KnownBeings,
                KnownParquets,
                KnownRoomRecipes,
                KnownCraftingRecipes,
                Quests,
                Inventory).GetHashCode();

        /// <summary>
        /// Determines whether the specified <see cref="BeingStatus"/> is equal to the current <see cref="BeingStatus"/>.
        /// </summary>
        /// <param name="inStatus">The <see cref="BeingStatus"/> to compare with the current.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public override bool Equals<T>(T inStatus)
            => inStatus is BeingStatus beingStatus
            && CurrentBehaviorID == beingStatus.CurrentBehaviorID
            && Position == beingStatus.Position
            && SpawnAt == beingStatus.SpawnAt
            && RoomAssignment == beingStatus.RoomAssignment
            && BiomeTimeRemaining == beingStatus.BiomeTimeRemaining
            && BuildingSpeed == beingStatus.BuildingSpeed
            && ModificationSpeed == beingStatus.ModificationSpeed
            && GatheringSpeed == beingStatus.GatheringSpeed
            && MovementSpeed == beingStatus.MovementSpeed
            && KnownBeings == beingStatus.KnownBeings
            && KnownParquets == beingStatus.KnownParquets
            && KnownRoomRecipes == beingStatus.KnownRoomRecipes
            && KnownCraftingRecipes == beingStatus.KnownCraftingRecipes
            && Quests == beingStatus.Quests
            && Inventory == beingStatus.Inventory;

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="BeingStatus"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="BeingStatus"/>.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
            => obj is BeingStatus status
            && Equals(status);

        /// <summary>
        /// Determines whether a specified instance of <see cref="BeingStatus"/> is equal to another specified instance of <see cref="BeingStatus"/>.
        /// </summary>
        /// <param name="inStatus1">The first <see cref="BeingStatus"/> to compare.</param>
        /// <param name="inStatus2">The second <see cref="BeingStatus"/> to compare.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(BeingStatus inStatus1, BeingStatus inStatus2)
            => inStatus1?.Equals(inStatus2) ?? inStatus2?.Equals(inStatus1) ?? true;

        /// <summary>
        /// Determines whether a specified instance of <see cref="BeingStatus"/> is not equal to another specified instance of <see cref="BeingStatus"/>.
        /// </summary>
        /// <param name="inStatus1">The first <see cref="BeingStatus"/> to compare.</param>
        /// <param name="inStatus2">The second <see cref="BeingStatus"/> to compare.</param>
        /// <returns><c>true</c> if they are NOT equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(BeingStatus inStatus1, BeingStatus inStatus2)
            => !(inStatus1 == inStatus2);
        #endregion

        #region ITypeConverter Implementation
        /// <summary>Allows the converter to construct itself statically.</summary>
        internal static BeingStatus ConverterFactory { get; } = Unused;

        /// <summary>
        /// Converts the given <see cref="object"/> to a <see cref="string"/> for serialization.
        /// </summary>
        /// <param name="inValue">The instance to convert.</param>
        /// <param name="inRow">The current context and configuration.</param>
        /// <param name="inMemberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance serialized.</returns>
        public override string ConvertToString(object inValue, IWriterRow inRow, MemberMapData inMemberMapData)
            => inValue is BeingStatus status
                ? $"{status.CurrentBehaviorID.ConvertToString(status.CurrentBehaviorID, inRow, inMemberMapData)}{Delimiters.SecondaryDelimiter}" +
                  $"{status.Position.ConvertToString(status.Position, inRow, inMemberMapData)}{Delimiters.SecondaryDelimiter}" +
                  $"{status.SpawnAt.ConvertToString(status.SpawnAt, inRow, inMemberMapData)}{Delimiters.SecondaryDelimiter}" +
                  $"{status.RoomAssignment.ConvertToString(status.RoomAssignment, inRow, inMemberMapData)}{Delimiters.SecondaryDelimiter}" +
                  $"{status.BiomeTimeRemaining}{Delimiters.SecondaryDelimiter}" +
                  $"{status.BuildingSpeed}{Delimiters.SecondaryDelimiter}" +
                  $"{status.ModificationSpeed}{Delimiters.SecondaryDelimiter}" +
                  $"{status.GatheringSpeed}{Delimiters.SecondaryDelimiter}" +
                  $"{status.MovementSpeed}{Delimiters.SecondaryDelimiter}" +
                  $"{SeriesConverter<ModelID, List<ModelID>>.ConverterFactory.ConvertToString(status.KnownBeings, inRow, inMemberMapData)}{Delimiters.SecondaryDelimiter}" +
                  $"{SeriesConverter<ModelID, List<ModelID>>.ConverterFactory.ConvertToString(status.KnownParquets, inRow, inMemberMapData)}{Delimiters.SecondaryDelimiter}" +
                  $"{SeriesConverter<ModelID, List<ModelID>>.ConverterFactory.ConvertToString(status.KnownRoomRecipes, inRow, inMemberMapData)}{Delimiters.SecondaryDelimiter}" +
                  $"{SeriesConverter<ModelID, List<ModelID>>.ConverterFactory.ConvertToString(status.KnownCraftingRecipes, inRow, inMemberMapData)}{Delimiters.SecondaryDelimiter}" +
                  $"{SeriesConverter<ModelID, List<ModelID>>.ConverterFactory.ConvertToString(status.Quests, inRow, inMemberMapData)}{Delimiters.SecondaryDelimiter}" +
                  $"{SeriesConverter<ModelID, List<ModelID>>.ConverterFactory.ConvertToString(status.Inventory, inRow, inMemberMapData)}"
                : Logger.DefaultWithConvertLog(inValue?.ToString() ?? "null", nameof(BeingStatus), nameof(Unused));

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
                return Logger.DefaultWithConvertLog(inText, nameof(BeingStatus), Unused);
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
            var parsedBuildingSpeed = float.TryParse(parameterText[5], All.SerializedNumberStyle,
                                                     CultureInfo.InvariantCulture, out var temp5)
                ? temp5
                : Logger.DefaultWithParseLog(parameterText[5], nameof(BuildingSpeed), 1f);
            var parsedModificationSpeed = float.TryParse(parameterText[6], All.SerializedNumberStyle,
                                                         CultureInfo.InvariantCulture, out var temp6)
                ? temp6
                : Logger.DefaultWithParseLog(parameterText[6], nameof(ModificationSpeed), 1f);
            var parsedGatheringSpeed = float.TryParse(parameterText[7], All.SerializedNumberStyle,
                                                      CultureInfo.InvariantCulture, out var temp7)
                ? temp7
                : Logger.DefaultWithParseLog(parameterText[7], nameof(GatheringSpeed), 1f);
            var parsedMovementSpeed = float.TryParse(parameterText[8], All.SerializedNumberStyle,
                                                     CultureInfo.InvariantCulture, out var temp8)
                ? temp8
                : Logger.DefaultWithParseLog(parameterText[8], nameof(MovementSpeed), 1f);
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
            var parsedInventory = (ICollection<ModelID>)
                SeriesConverter<ModelID, List<ModelID>>.ConverterFactory.ConvertFromString(parameterText[14], inRow,
                                                                                           inMemberMapData);

            return new BeingStatus(parsedPosition,
                                   parsedSpawnAt,
                                   parsedRoomAssignment,
                                   parsedCurrentBehaviorID,
                                   parsedBiomeTimeRemaining,
                                   parsedBuildingSpeed,
                                   parsedModificationSpeed,
                                   parsedGatheringSpeed,
                                   parsedMovementSpeed,
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
        /// <returns>A new instance with the same characteristics as the current instance.</returns>
        public override T DeepClone<T>()
            => new BeingStatus((Location)Position.DeepClone(),
                               (Location)SpawnAt.DeepClone(),
                               (Location)RoomAssignment.DeepClone(),
                               CurrentBehaviorID,
                               BiomeTimeRemaining,
                               BuildingSpeed,
                               ModificationSpeed,
                               GatheringSpeed,
                               MovementSpeed,
                               // Note: the following .ToList() perform shallow copies, but this is acceptable as ModelID has value semantics
                               KnownBeings.ToList(),
                               KnownParquets.ToList(),
                               KnownRoomRecipes.ToList(),
                               KnownCraftingRecipes.ToList(),
                               Quests.ToList(),
                               Inventory.ToList()) as T;
        #endregion
    }
}
