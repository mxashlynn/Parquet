using System;
using System.Collections.Generic;
using System.Linq;
using ParquetClassLibrary.Sandbox.IDs;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Characters
{
    public abstract class Character : Being
    {
        #region Class Defaults
        /// <summary>A pronoun to use when none is specified.</summary>
        // TODO This is just a place-holder, I am not sure yet how we will handle pronouns.
        public const string DefaultPronoun = "they";
        #endregion

        #region Characteristics
        /// <summary>The pronouns the <see cref="Character"/> uses.</summary>
        // TODO This is just a place-holder, I am not sure yet how we will handle pronouns.
        public string Pronoun { get; }

        /// <summary>Types of parquets this <see cref="Character"/> avoids.</summary>
        public readonly List<EntityID> Quests = new List<EntityID>();

        /// <summary>Dialogue lines this <see cref="Character"/> can say.</summary>
        // TODO This is just a place-holder, I am not at all sure how we will handle this.
        public readonly List<string> Dialogue = new List<string>();

        /// <summary>This <see cref="Character"/>'s belongings.</summary>
        // TODO This is just a place-holder, inventory may need its own class.
        public readonly List<EntityID> Inventory = new List<EntityID>();
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="Character"/> class.
        /// </summary>
        /// <param name="in_bounds">
        /// The bounds within which the <see cref="Character"/>'s <see cref="EntityID"/> is defined.
        /// Must be one of <see cref="All.BeingIDs"/>.
        /// </param>
        /// <param name="in_id">Unique identifier for the <see cref="Character"/>.  Cannot be null.</param>
        /// <param name="in_name">Player-friendly name of the <see cref="Character"/>.  Cannot be null or empty.</param>
        /// <param name="in_nativeBiome">The <see cref="Biome"/> in which this <see cref="Character"/> is most comfortable.</param>
        /// <param name="in_primaryBehavior">The rules that govern how this <see cref="Character"/> acts.  Cannot be null.</param>
        /// <param name="in_avoids">Any parquets this <see cref="Character"/> avoids.</param>
        /// <param name="in_seeks">Any parquets this <see cref="Character"/> seeks.</param>
        /// <param name="in_quests">Any quests this <see cref="Character"/> has to offer.</param>
        /// <param name="in_dialogue">All dialogue this <see cref="Character"/> may say.</param>
        /// <param name="in_inventory">Any items this <see cref="Character"/> owns.</param>
        /// <param name="in_pronoun">How to refer to this <see cref="Character"/>.</param>
        protected Character(Range<EntityID> in_bounds, EntityID in_id, string in_name, Biome in_nativeBiome,
                            Behavior in_primaryBehavior, List<EntityID> in_avoids = null,
                            List<EntityID> in_seeks = null, List<EntityID> in_quests = null,
                            List<string> in_dialogue = null, List<EntityID> in_inventory = null,
                            string in_pronoun = DefaultPronoun)
            : base(in_bounds, in_id, in_name, in_nativeBiome, in_primaryBehavior, in_avoids, in_seeks)
        {
            foreach (var questID in in_quests ?? Enumerable.Empty<EntityID>())
            {
                if (!questID.IsValidForRange(All.QuestIDs))
                {
                    throw new ArgumentOutOfRangeException(nameof(in_quests));
                }
            }
            foreach (var itemID in in_inventory ?? Enumerable.Empty<EntityID>())
            {
                if (!itemID.IsValidForRange(All.ItemIDs))
                {
                    throw new ArgumentOutOfRangeException(nameof(in_inventory));
                }
            }
            var nonNullPronoun = string.IsNullOrEmpty(in_pronoun) ? DefaultPronoun : in_pronoun;

            Pronoun = nonNullPronoun;
            Quests.AddRange(in_quests ?? Enumerable.Empty<EntityID>());
            Dialogue.AddRange(in_dialogue ?? Enumerable.Empty<string>());
            Inventory.AddRange(in_inventory ?? Enumerable.Empty<EntityID>());
        }
        #endregion
    }
}
