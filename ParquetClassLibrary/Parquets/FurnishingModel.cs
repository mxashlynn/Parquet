using System;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using ParquetClassLibrary.Biomes;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Parquets
{
    /// <summary>
    /// Configurations for large sandbox parquet items, such as furniture or plants.
    /// </summary>
    public sealed class FurnishingModel : ParquetModel, ITypeConverter
    {
        #region Class Defaults
        /// <summary>The set of values that are allowed for Furnishing IDs.</summary>
        public static Range<EntityID> Bounds => All.FurnishingIDs;
        #endregion

        #region Characteristics
        /// <summary>Indicates whether this <see cref="FurnishingModel"/> may be walked on.</summary>
        public bool IsWalkable { get; }

        /// <summary>Indicates whether this <see cref="FurnishingModel"/> serves as an entry to a <see cref="Room"/>.</summary>
        public bool IsEntry { get; }

        /// <summary>Indicates whether this <see cref="FurnishingModel"/> serves as part of a perimeter of a <see cref="Room"/>.</summary>
        public bool IsEnclosing { get; }

        /// <summary>Whether or not the <see cref="FurnishingModel"/> is flammable.</summary>
        public bool IsFlammable { get; }

        /// <summary>The <see cref="FurnishingModel"/> to swap with this Furnishing on an open/close action.</summary>
        public EntityID SwapID { get; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="FurnishingModel"/> class.
        /// </summary>
        /// <param name="inID">Unique identifier for the <see cref="FurnishingModel"/>.  Cannot be null.</param>
        /// <param name="inName">Player-friendly name of the <see cref="FurnishingModel"/>.  Cannot be null or empty.</param>
        /// <param name="inDescription">Player-friendly description of the parquet.</param>
        /// <param name="inComment">Comment of, on, or by the parquet.</param>
        /// <param name="inItemID">The <see cref="EntityID"/> that represents this <see cref="FurnishingModel"/> in the <see cref="Inventory"/>.</param>
        /// <param name="inAddsToBiome">Indicates which, if any, <see cref="BiomeModel"/> this parquet helps to generate.</param>
        /// <param name="inAddsToRoom">Describes which, if any, <see cref="Rooms.RoomRecipe"/>(s) this parquet helps form.</param>
        /// <param name="inIsWalkable">If <c>true</c> this <see cref="FurnishingModel"/> may be walked on.</param>
        /// <param name="inIsEntry">If <c>true</c> this <see cref="FurnishingModel"/> serves as an entry to a <see cref="Room"/>.</param>
        /// <param name="inIsEnclosing">If <c>true</c> this <see cref="FurnishingModel"/> serves as part of a perimeter of a <see cref="Room"/>.</param>
        /// <param name="inIsFlammable">If <c>true</c> this <see cref="FurnishingModel"/> may catch fire.</param>
        /// <param name="inSwapID">A <see cref="FurnishingModel"/> to swap with this furnishing on open/close actions.</param>
        public FurnishingModel(EntityID inID, string inName, string inDescription, string inComment,
                          EntityID? inItemID = null, EntityTag inAddsToBiome = null,
                          EntityTag inAddsToRoom = null, bool inIsWalkable = false,
                          bool inIsEntry = false, bool inIsEnclosing = false,
                          bool inIsFlammable = false, EntityID? inSwapID = null)
            : base(Bounds, inID, inName, inDescription, inComment, inItemID ?? EntityID.None,
                   inAddsToBiome ?? EntityTag.None, inAddsToRoom ?? EntityTag.None)
        {
            var nonNullSwapID = inSwapID ?? EntityID.None;
            Precondition.IsInRange(nonNullSwapID, Bounds, nameof(inSwapID));

            IsWalkable = inIsWalkable;
            IsEntry = inIsEntry;
            IsEnclosing = inIsEnclosing;
            IsFlammable = inIsFlammable;
            SwapID = nonNullSwapID;
        }
        #endregion

        #region ITypeConverter Implementation
        /// <summary>Allows the converter to construct itself statically.</summary>
        internal static FurnishingModel ConverterFactory { get; } = new FurnishingModel(EntityID.None, nameof(ConverterFactory), "", "");

        /// <summary>
        /// Converts the given <see cref="object"/> to a <see cref="string"/> for serialization.
        /// </summary>
        /// <param name="inValue">The instance to convert.</param>
        /// <param name="inRow">The current context and configuration.</param>
        /// <param name="inMemberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance serialized.</returns>
        public string ConvertToString(object inValue, IWriterRow inRow, MemberMapData inMemberMapData)
            => null != inValue
            && inValue is FurnishingModel model
            && model.ID != EntityID.None
                ? $"{model.ID}{Rules.Delimiters.InternalDelimiter}" +
                  $"{model.Name}{Rules.Delimiters.InternalDelimiter}" +
                  $"{model.Description}{Rules.Delimiters.InternalDelimiter}" +
                  $"{model.Comment}{Rules.Delimiters.InternalDelimiter}" +
                  $"{model.ItemID}{Rules.Delimiters.InternalDelimiter}" +
                  $"{model.AddsToBiome}{Rules.Delimiters.InternalDelimiter}" +
                  $"{model.AddsToRoom}{Rules.Delimiters.InternalDelimiter}" +
                  $"{model.IsWalkable}{Rules.Delimiters.InternalDelimiter}" +
                  $"{model.IsEntry}{Rules.Delimiters.InternalDelimiter}" +
                  $"{model.IsEnclosing}{Rules.Delimiters.InternalDelimiter}" +
                  $"{model.IsFlammable}{Rules.Delimiters.InternalDelimiter}" +
                  $"{model.SwapID}"
            : throw new ArgumentException($"Could not serialize '{inValue}' as {nameof(FurnishingModel)}.");

        /// <summary>
        /// Converts the given <see cref="string"/> to an <see cref="object"/> as deserialization.
        /// </summary>
        /// <param name="text">The text to convert.</param>
        /// <param name="row">The current context and configuration.</param>
        /// <param name="memberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance deserialized.</returns>
        public object ConvertFromString(string inText, IReaderRow inRow, MemberMapData inMemberMapData)
        {
            if (string.IsNullOrEmpty(inText)
                || string.Compare(nameof(EntityID.None), inText, StringComparison.InvariantCultureIgnoreCase) == 0)
            {
                throw new ArgumentException($"Could not convert '{inText}' to {nameof(FurnishingModel)}.");
            }

            try
            {
                var parameterText = inText.Split(Rules.Delimiters.InternalDelimiter);
                var id = (EntityID)EntityID.ConverterFactory.ConvertFromString(parameterText[0], inRow, inMemberMapData);
                var name = parameterText[1];
                var description = parameterText[2];
                var comment = parameterText[3];
                var itemID = (EntityID)EntityID.ConverterFactory.ConvertFromString(parameterText[4], inRow, inMemberMapData);
                var biome = (EntityTag)EntityTag.ConverterFactory.ConvertFromString(parameterText[5], inRow, inMemberMapData);
                var room = (EntityTag)EntityTag.ConverterFactory.ConvertFromString(parameterText[6], inRow, inMemberMapData);
                var walkable = bool.Parse(parameterText[7]);
                var entry = bool.Parse(parameterText[8]);
                var enclosing = bool.Parse(parameterText[9]);
                var flammable = bool.Parse(parameterText[10]);
                var swapID = (EntityID)EntityID.ConverterFactory.ConvertFromString(parameterText[11], inRow, inMemberMapData);

                return new FurnishingModel(id, name, description, comment, itemID, biome, room, walkable, entry, enclosing, flammable, swapID);
            }
            catch (Exception e)
            {
                throw new FormatException($"Could not parse '{inText}' as {nameof(FurnishingModel)}: {e}");
            }
        }
        #endregion
    }
}
