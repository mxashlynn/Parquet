using System;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using ParquetClassLibrary.Biomes;
using ParquetClassLibrary.Items;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Parquets
{
    /// <summary>
    /// Configurations for a sandbox parquet walking surface.
    /// </summary>
    public sealed class FloorModel : ParquetModel, ITypeConverter
    {
        #region Class Defaults
        /// <summary>A name to employ for parquets when IsTrench is set, if none is provided.</summary>
        private const string defaultTrenchName = "dark hole";

        /// <summary>The set of values that are allowed for Floor IDs.</summary>
        public static Range<EntityID> Bounds => All.FloorIDs;
        #endregion

        #region Characteristics
        /// <summary>The tool used to dig out or fill in the floor.</summary>
        public ModificationTool ModTool { get; }

        /// <summary>Player-facing name of the parquet, used when it has been dug out.</summary>
        public string TrenchName { get; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="FloorModel"/> class.
        /// </summary>
        /// <param name="inID">Unique identifier for the parquet.  Cannot be null.</param>
        /// <param name="inName">Player-friendly name of the parquet.  Cannot be null.</param>
        /// <param name="inDescription">Player-friendly description of the parquet.</param>
        /// <param name="inComment">Comment of, on, or by the parquet.</param>
        /// <param name="inItemID">The <see cref="EntityID"/> of the <see cref="Items.ItemModel"/> awarded to the player when a character gathers this parquet.</param>
        /// <param name="inAddsToBiome">Which, if any, <see cref="BiomeModel"/> this parquet helps to generate.</param>
        /// <param name="inAddsToRoom">Describes which, if any, <see cref="Rooms.RoomRecipe"/>(s) this parquet helps form.</param>
        /// <param name="inModTool">The tool used to modify this floor.</param>
        /// <param name="inTrenchName">The name to use for this floor when it has been dug out.</param>
        public FloorModel(EntityID inID, string inName, string inDescription, string inComment,
                     EntityID? inItemID = null, EntityTag inAddsToBiome = null,
                     EntityTag inAddsToRoom = null, ModificationTool inModTool = ModificationTool.None,
                     string inTrenchName = defaultTrenchName)
            : base(Bounds, inID, inName, inDescription, inComment, inItemID ?? EntityID.None,
                   inAddsToBiome ?? EntityTag.None, inAddsToRoom ?? EntityTag.None)
        {
            ModTool = inModTool;
            TrenchName = inTrenchName;
        }
        #endregion

        #region ITypeConverter Implementation
        /// <summary>Allows the converter to construct itself statically.</summary>
        internal static readonly FloorModel ConverterFactory = new FloorModel(EntityID.None, nameof(ConverterFactory), "", "");

        /// <summary>
        /// Converts the given <see cref="object"/> to a <see cref="string"/> for serialization.
        /// </summary>
        /// <param name="inValue">The instance to convert.</param>
        /// <param name="inRow">The current context and configuration.</param>
        /// <param name="inMemberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance serialized.</returns>
        public string ConvertToString(object inValue, IWriterRow inRow, MemberMapData inMemberMapData)
            => null != inValue
            && inValue is FloorModel model
            && model.ID != EntityID.None
                ? $"{model.ID}{Rules.Delimiters.InternalDelimiter}" +
                  $"{model.Name}{Rules.Delimiters.InternalDelimiter}" +
                  $"{model.Description}{Rules.Delimiters.InternalDelimiter}" +
                  $"{model.Comment}{Rules.Delimiters.InternalDelimiter}" +
                  $"{model.ItemID}{Rules.Delimiters.InternalDelimiter}" +
                  $"{model.AddsToBiome}{Rules.Delimiters.InternalDelimiter}" +
                  $"{model.AddsToRoom}{Rules.Delimiters.InternalDelimiter}" +
                  $"{model.ModTool}{Rules.Delimiters.InternalDelimiter}" +
                  $"{model.TrenchName}"
            : throw new ArgumentException($"Could not serialize {inValue} as {nameof(FloorModel)}.");

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
                throw new ArgumentException($"Could not convert '{inText}' to {nameof(FloorModel)}.");
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
                var mod = Enum.Parse<ModificationTool>(parameterText[7], true);
                var trenchName = parameterText[8];

                return new FloorModel(id, name, description, comment, itemID, biome, room, mod, trenchName);
            }
            catch (Exception e)
            {
                throw new FormatException($"Could not parse '{inText}' as {nameof(FloorModel)}: {e}");
            }
        }
        #endregion
    }
}
