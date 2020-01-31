using System;
using System.Collections.Generic;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using ParquetClassLibrary.Biomes;
using ParquetClassLibrary.Items;
using ParquetClassLibrary.Serialization;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Parquets
{
    /// <summary>
    /// Configurations for a sandbox parquet block.
    /// </summary>
    public sealed class BlockModel : ParquetModel, ITypeConverter
    {
        #region Class Defaults
        /// <summary>Minimum toughness value for any Block.</summary>
        public const int LowestPossibleToughness = 0;

        /// <summary>Maximum toughness value to use when none is specified.</summary>
        public const int DefaultMaxToughness = 10;

        /// <summary>The set of values that are allowed for Block IDs.</summary>
        public static Range<EntityID> Bounds => All.BlockIDs;
        #endregion

        #region Characteristics
        /// <summary>The tool used to remove the block.</summary>
        public GatheringTool GatherTool { get; }

        /// <summary>The effect generated when a character gathers this Block.</summary>
        public GatheringEffect GatherEffect { get; }

        /// <summary>The Collectible spawned when a character gathers this Block.</summary>
        public EntityID CollectibleID { get; }

        /// <summary>Whether or not the block is flammable.</summary>
        public bool IsFlammable { get; }

        /// <summary>Whether or not the block is a liquid.</summary>
        public bool IsLiquid { get; }

        /// <summary>The block's native toughness.</summary>
        public int MaxToughness { get; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="BlockModel"/> class.
        /// </summary>
        /// <param name="inID">Unique identifier for the parquet.  Cannot be null.</param>
        /// <param name="inName">Player-friendly name of the parquet.  Cannot be null.</param>
        /// <param name="inDescription">Player-friendly description of the parquet.</param>
        /// <param name="inComment">Comment of, on, or by the parquet.</param>
        /// <param name="inItemID">The item that this collectible corresponds to, if any.</param>
        /// <param name="inAddsToBiome">A set of flags indicating which, if any, <see cref="BiomeModel"/> this parquet helps to generate.</param>
        /// <param name="inGatherTool">The tool used to gather this block.</param>
        /// <param name="inGatherEffect">Effect of this block when gathered.</param>
        /// <param name="inCollectibleID">The Collectible to spawn, if any, when this Block is Gathered.</param>
        /// <param name="inIsFlammable">If <c>true</c> this block may burn.</param>
        /// <param name="inIsLiquid">If <c>true</c> this block will flow.</param>
        /// <param name="inMaxToughness">Representation of the difficulty involved in gathering this block.</param>
        public BlockModel(EntityID inID, string inName, string inDescription, string inComment,
                     EntityID? inItemID = null, EntityTag inAddsToBiome = null,
                     EntityTag inAddsToRoom = null,
                     GatheringTool inGatherTool = GatheringTool.None,
                     GatheringEffect inGatherEffect = GatheringEffect.None,
                     EntityID? inCollectibleID = null, bool inIsFlammable = false,
                     bool inIsLiquid = false, int inMaxToughness = DefaultMaxToughness)
            : base(Bounds, inID, inName, inDescription, inComment, inItemID ?? EntityID.None,
                   inAddsToBiome ?? EntityTag.None, inAddsToRoom ?? EntityTag.None)
        {
            var nonNullCollectibleID = inCollectibleID ?? EntityID.None;

            Precondition.IsInRange(nonNullCollectibleID, All.CollectibleIDs, nameof(inCollectibleID));

            GatherTool = inGatherTool;
            GatherEffect = inGatherEffect;
            CollectibleID = nonNullCollectibleID;
            IsFlammable = inIsFlammable;
            IsLiquid = inIsLiquid;
            MaxToughness = inMaxToughness;
        }
        #endregion

        #region ITypeConverter Implementation
        /// <summary>Allows the converter to construct itself statically.</summary>
        internal static readonly BlockModel ConverterFactory = new BlockModel(EntityID.None, nameof(ConverterFactory), "", "");

        /// <summary>
        /// Converts the given <see cref="object"/> to a <see cref="string"/> for serialization.
        /// </summary>
        /// <param name="inValue">The instance to convert.</param>
        /// <param name="inRow">The current context and configuration.</param>
        /// <param name="inMemberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance serialized.</returns>
        public string ConvertToString(object inValue, IWriterRow inRow, MemberMapData inMemberMapData)
            => null != inValue
            && inValue is BlockModel model
            && model.ID != EntityID.None
                ? $"{model.ID}{modelDelimiter}" +
                  $"{model.Name}{modelDelimiter}" +
                  $"{model.Description}{modelDelimiter}" +
                  $"{model.Comment}{modelDelimiter}" +
                  $"{model.GatherTool}{modelDelimiter}" +
                  $"{model.GatherEffect}{modelDelimiter}" +
                  $"{model.CollectibleID}{modelDelimiter}" +
                  $"{model.IsFlammable}{modelDelimiter}" +
                  $"{model.IsLiquid}{modelDelimiter}" +
                  $"{model.MaxToughness}"
            : throw new ArgumentException($"Could not serialize {inValue} as {nameof(BlockModel)}.");

        /// <summary>
        /// Converts the given <see cref="string"/> to an <see cref="object"/> as deserialization.
        /// </summary>
        /// <param name="text">The text to convert.</param>
        /// <param name="row">The current context and configuration.</param>
        /// <param name="memberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance deserialized.</returns>
        public object ConvertFromString(string inText, IReaderRow inRow, MemberMapData inMemberMapData)
        {
            Precondition.IsNotNull(inMemberMapData, nameof(inMemberMapData));

            if (string.IsNullOrEmpty(inText)
                || string.Compare(nameof(EntityID.None), inText, StringComparison.InvariantCultureIgnoreCase) == 0)
            {
                throw new ArgumentException($"Could not convert '{inText}' to {nameof(BlockModel)}.");
            }

            var numberStyle = inMemberMapData.TypeConverterOptions.NumberStyle ?? NumberStyles.Integer;
            var parameterText = inText.Split(modelDelimiter);
            try
            {
                var id = (EntityID)EntityID.ConverterFactory.ConvertFromString(parameterText[0], inRow, inMemberMapData);
                var name = parameterText[1];
                var description = parameterText[2];
                var comment = parameterText[3];
                var itemID = (EntityID)EntityID.ConverterFactory.ConvertFromString(parameterText[4], inRow, inMemberMapData);
                var biome = (EntityTag)EntityTag.ConverterFactory.ConvertFromString(parameterText[5], inRow, inMemberMapData);
                var room = (EntityTag)EntityTag.ConverterFactory.ConvertFromString(parameterText[6], inRow, inMemberMapData);
                var tool = Enum.Parse<GatheringTool>(parameterText[7], true);
                var effect = Enum.Parse<GatheringEffect>(parameterText[8], true);
                var collectibleID = (EntityID)EntityID.ConverterFactory.ConvertFromString(parameterText[9], inRow, inMemberMapData);
                var flammable = bool.Parse(parameterText[10]);
                var liquid = bool.Parse(parameterText[11]);
                var toughness = int.Parse(parameterText[12], numberStyle, inMemberMapData.TypeConverterOptions.CultureInfo);

                return new BlockModel(id, name, description, comment, ItemID, biome, room, tool, effect, collectibleID, flammable, liquid, toughness);
            }
            catch (Exception e)
            {
                throw new FormatException($"Could not parse '{inText}' as {nameof(BlockModel)}: {e}");
            }
        }
        #endregion
    }
}
