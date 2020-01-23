using System;
using System.Collections.Generic;
using CsvHelper.Configuration;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Beings
{
    /// <summary>
    /// Models the definition for a player character, the game object that represents the player during play.
    /// </summary>
    public sealed class PlayerCharacterModel : CharacterModel
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
                                    IEnumerable<EntityID> inStartingQuests = null, IEnumerable<string> inDialogue = null,
                                    IEnumerable<EntityID> inStartingInventory = null)
            : base(All.PlayerCharacterIDs, inID, inPersonalName, inFamilyName, inDescription,
                   inComment, inNativeBiome, inPrimaryBehavior, inAvoids, inSeeks,
                   inPronouns, inStoryCharacterID, inStartingQuests, inDialogue, inStartingInventory)
        {
            Precondition.IsInRange(inID, All.PlayerCharacterIDs, nameof(inID));
        }
        #endregion

        #region Serialization
        #region Serializer Shim
        /// <summary>
        /// Provides a default public parameterless constructor for a
        /// <see cref="PlayerCharacterModel"/>-like class that CSVHelper can instantiate.
        /// 
        /// Provides the ability to generate a <see cref="PlayerCharacterModel"/> from this class.
        /// </summary>
        internal class PlayerCharacterShim : Serialization.Shims.CharacterShim
        {
            /// <summary>
            /// Converts a shim into the class it corresponds to.
            /// </summary>
            /// <typeparam name="TModel">The type to convert this shim to.</typeparam>
            /// <returns>An instance of a child class of <see cref="CharacterModel"/>.</returns>
            public override TModel ToEntity<TModel>()
            {
                Precondition.IsOfType<TModel, PlayerCharacterModel>(typeof(TModel).ToString());

                return (TModel)(EntityModel)new PlayerCharacterModel(ID, PersonalName, FamilyName, Description, Comment, NativeBiome, PrimaryBehavior,
                                                                     new List<EntityID>() { Avoids }, new List<EntityID>() { Seeks },
                                                                     Pronouns, StoryCharacterID, new List<EntityID>() { StartingQuests },
                                                                     new List<string>() { Dialogue }, new List<EntityID>() { StartingInventory });
            }
        }
        #endregion

        #region Class Map
        /// <summary>
        /// Maps the values in a <see cref="PlayerCharacterShim"/> to records that CSVHelper recognizes.
        /// </summary>
        internal sealed class PlayerCharacterClassMap : ClassMap<PlayerCharacterShim>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="PlayerCharacterClassMap"/> class.
            /// </summary>
            public PlayerCharacterClassMap()
            {
                // Properties are ordered by index to facilitate a logical layout in spreadsheet apps.
                Map(m => m.ID).Index(0);
                Map(m => m.PersonalName).Index(1);
                Map(m => m.FamilyName).Index(2);
                Map(m => m.Description).Index(3);
                Map(m => m.Comment).Index(4);

                Map(m => m.NativeBiome).Index(5);
                Map(m => m.PrimaryBehavior).Index(6);
                Map(m => m.Avoids).Index(7);
                Map(m => m.Seeks).Index(8);

                Map(m => m.Pronouns).Index(9);
                Map(m => m.StoryCharacterID).Index(10);
                Map(m => m.StartingQuests).Index(11);
                Map(m => m.Dialogue).Index(12);
                Map(m => m.StartingInventory).Index(13);
            }
        }
        #endregion

        /// <summary>Caches a class mapper.</summary>
        private static PlayerCharacterClassMap classMapCache;

        /// <summary>
        /// Provides the means to map all members of this class to a CSV file.
        /// </summary>
        /// <returns>The member mapping.</returns>
        internal static ClassMap GetClassMap()
            => classMapCache
            ?? (classMapCache = new PlayerCharacterClassMap());

        /// <summary>
        /// Provides the means to map all members of this class to a CSV file.
        /// </summary>
        /// <returns>The member mapping.</returns>
        internal static Type GetShimType()
            => typeof(PlayerCharacterShim);
        #endregion
    }
}