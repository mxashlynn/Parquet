using System.Collections.Generic;
using CsvHelper.TypeConversion;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Beings
{
    /// <summary>
    /// Models the definition for a player character, the game object that represents the player during play.
    /// </summary>
    public sealed class PlayerCharacterModel : CharacterModel, ITypeConverter
    {
        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="PlayerCharacterModel"/> class.
        /// </summary>
        /// <param name="inID">
        /// Unique identifier for the <see cref="PlayerCharacterModel"/>.  Cannot be null.
        /// Must be a valid <see cref="All.NpcIDs"/>.
        /// </param>
        /// <param name="inPersonalName">Personal name of the <see cref="PlayerCharacterModel"/>.  Cannot be null or empty.</param>
        /// <param name="inFamilyName">Family name of the <see cref="PlayerCharacterModel"/>.  Cannot be null or empty.</param>
        /// <param name="inDescription">Player-friendly description of the <see cref="PlayerCharacterModel"/>.</param>
        /// <param name="inComment">Comment of, on, or by the <see cref="PlayerCharacterModel"/>.</param>
        /// <param name="inNativeBiome">The <see cref="EntityID"/> of the <see cref="Biome"/> in which this <see cref="PlayerCharacterModel"/> is most comfortable.</param>
        /// <param name="inPrimaryBehavior">The rules that govern how this <see cref="PlayerCharacterModel"/> acts.  Cannot be null.</param>
        /// <param name="inAvoids">Any parquets this <see cref="PlayerCharacterModel"/> avoids.</param>
        /// <param name="inSeeks">Any parquets this <see cref="PlayerCharacterModel"/> seeks.</param>
        /// <param name="inPronouns">How to refer to this <see cref="PlayerCharacterModel"/>.</param>
        /// <param name="inStoryCharacterID">A means of identifying this <see cref="PlayerCharacterModel"/> across multiple shipped game titles.</param>
        /// <param name="inStartingQuests">Any quests this <see cref="PlayerCharacterModel"/> has to offer.</param>
        /// <param name="inDialogue">All dialogue this <see cref="PlayerCharacterModel"/> may say.</param>
        /// <param name="inStartingInventory">Any items this <see cref="PlayerCharacterModel"/> owns.</param>
        public PlayerCharacterModel(EntityID inID, string inPersonalName, string inFamilyName,
                                    string inDescription, string inComment,
                                    EntityID inNativeBiome, Behavior inPrimaryBehavior,
                                    IEnumerable<EntityID> inAvoids = null, IEnumerable<EntityID> inSeeks = null,
                                    string inPronouns = null, string inStoryCharacterID = "",
                                    IEnumerable<EntityID> inStartingQuests = null, IEnumerable<EntityID> inDialogue = null,
                                    IEnumerable<EntityID> inStartingInventory = null)
            : base(All.PlayerCharacterIDs, inID, inPersonalName, inFamilyName, inDescription,
                   inComment, inNativeBiome, inPrimaryBehavior, inAvoids, inSeeks,
                   inPronouns, inStoryCharacterID, inStartingQuests, inDialogue, inStartingInventory)
        {
            Precondition.IsInRange(inID, All.PlayerCharacterIDs, nameof(inID));
        }
        #endregion

        #region ITypeConverter Implementation
        /// <summary>Allows the converter to construct itself without exposing a public parameterless constructor.</summary>
        internal static readonly PlayerCharacterModel ConverterFactory =
            new PlayerCharacterModel(EntityID.None, nameof(ConverterFactory), "", "", "", EntityID.None, Behavior.Still);

        /// <summary>
        /// Converts the given <see cref="object"/> to a <see cref="string"/> for serialization.
        /// </summary>
        /// <param name="value">The instance to convert.</param>
        /// <param name="row">The current context and configuration.</param>
        /// <param name="memberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance serialized.</returns>
        public string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
        {
        }

        /// <summary>
        /// Converts the given <see cref="string"/> to an <see cref="object"/> as deserialization.
        /// </summary>
        /// <param name="text">The text to convert.</param>
        /// <param name="row">The current context and configuration.</param>
        /// <param name="memberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance deserialized.</returns>
        public object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
        }
        #endregion
    }
}
