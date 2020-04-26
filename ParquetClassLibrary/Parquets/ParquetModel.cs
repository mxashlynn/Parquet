using System.Collections.Generic;
using System.Linq;
using CsvHelper.Configuration.Attributes;
using ParquetClassLibrary.Biomes;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Parquets
{
    /// <summary>
    /// Models a sandbox parquet.
    /// </summary>
    public abstract class ParquetModel : Model
    {
        #region Characteristics
        /// <summary>
        /// The <see cref="ModelID"/> of the <see cref="Items.ItemModel"/> awarded to the player when a character gathers or collects this parquet.
        /// </summary>
        [Index(4)]
        public ModelID ItemID { get; }

        /// <summary>
        /// Describes the <see cref="BiomeModel"/>(s) that this parquet helps form.
        /// Guaranteed to never be <c>null</c>.
        /// </summary>
        [Index(5)]
        public ModelTag AddsToBiome { get; }

        /// <summary>
        /// A property of the parquet that can, for example, be used by <see cref="Rooms.RoomRecipe"/>s.
        /// Guaranteed to never be <c>null</c>.
        /// </summary>
        /// <remarks>
        /// Allows the creation of classes of constructs, for example "wooden", "golden", "rustic", or "fancy" rooms.
        /// </remarks>
        [Index(6)]
        public ModelTag AddsToRoom { get; }
        #endregion

        #region Initialization
        /// <summary>
        /// Used by children of the <see cref="ParquetModel"/> class.
        /// </summary>
        /// <param name="inBounds">The bounds within which the derived parquet type's ModelID is defined.</param>
        /// <param name="inID">Unique identifier for the parquet.  Cannot be null.</param>
        /// <param name="inName">Player-friendly name of the parquet.  Cannot be null or empty.</param>
        /// <param name="inDescription">Player-friendly description of the parquet.</param>
        /// <param name="inComment">Comment of, on, or by the parquet.</param>
        /// <param name="inItemID">The <see cref="ModelID"/> of the <see cref="Items.ItemModel"/> awarded to the player when a character gathers or collects this parquet.</param>
        /// <param name="inAddsToBiome">Describes which, if any, <see cref="BiomeModel"/>(s) this parquet helps form.</param>
        /// <param name="inAddsToRoom">Describes which, if any, <see cref="Rooms.RoomRecipe"/>(s) this parquet helps form.</param>
        protected ParquetModel(Range<ModelID> inBounds, ModelID inID, string inName, string inDescription,
                                string inComment, ModelID inItemID, ModelTag inAddsToBiome, ModelTag inAddsToRoom)
            : base(inBounds, inID, inName, inDescription, inComment)
        {
            Precondition.IsInRange(inItemID, All.ItemIDs, nameof(inItemID));

            ItemID = inItemID;
            AddsToBiome = string.IsNullOrEmpty(inAddsToBiome) ? ModelTag.None : inAddsToBiome;
            AddsToRoom = string.IsNullOrEmpty(inAddsToRoom) ? ModelTag.None : inAddsToRoom;
        }
        #endregion

        #region Utilities
        /// <summary>
        /// Returns a collection of all <see cref="ModelTag"/>s the <see cref="Model"/> has applied to it. Classes inheriting from <see cref="Model"/> that include <see cref="ModelTag"/> should override accordingly.
        /// </summary>
        /// <returns>List of all <see cref="ModelTag"/>s.</returns>
        public override IEnumerable<ModelTag> GetAllTags()
            => base.GetAllTags().Union(new List<ModelTag>() { AddsToBiome, AddsToRoom });
        #endregion
    }
}
