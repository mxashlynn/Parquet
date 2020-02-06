using System;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using ParquetClassLibrary.Biomes;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Parquets
{
    /// <summary>
    /// Configurations for a sandbox collectible object, such as crafting materials.
    /// </summary>
    public sealed class CollectibleModel : ParquetModel, ITypeConverter
    {
        #region Class Defaults
        /// <summary>The set of values that are allowed for Collectible IDs.</summary>
        public static Range<EntityID> Bounds => All.CollectibleIDs;
        #endregion

        #region Characteristics
        /// <summary>The effect generated when a character encounters this Collectible.</summary>
        public CollectingEffect CollectionEffect { get; }

        /// <summary>
        /// The scale in points of the effect.
        /// For example, how much to alter a stat if the <see cref="CollectingEffect"/> is set to alter a stat.
        /// </summary>
        public int EffectAmount { get; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="CollectibleModel"/> class.
        /// </summary>
        /// <param name="inID">Unique identifier for the parquet.  Cannot be null.</param>
        /// <param name="inName">Player-friendly name of the parquet.  Cannot be null.</param>
        /// <param name="inDescription">Player-friendly description of the parquet.</param>
        /// <param name="inComment">Comment of, on, or by the parquet.</param>
        /// <param name="inItemID">The <see cref="EntityID"/> of the <see cref="Item"/> that this <see cref="CollectibleModel"/> corresponds to, if any.</param>
        /// <param name="inAddsToBiome">A set of flags indicating which, if any, <see cref="BiomeModel"/> this parquet helps to generate.</param>
        /// <param name="inEffect">Effect of this collectible.</param>
        /// <param name="inEffectAmount">
        /// The scale in points of the effect.
        /// For example, how much to alter a stat if inEffect is set to alter a stat.
        /// </param>
        public CollectibleModel(EntityID inID, string inName, string inDescription, string inComment,
                           EntityID? inItemID = null, EntityTag inAddsToBiome = null,
                           EntityTag inAddsToRoom = null, CollectingEffect inEffect = CollectingEffect.None,
                           int inEffectAmount = 0)
            : base(Bounds, inID, inName, inDescription, inComment, inItemID ?? EntityID.None,
                   inAddsToBiome ?? EntityTag.None, inAddsToRoom ?? EntityTag.None)
        {
            var nonNullItemID = inItemID ?? EntityID.None;
            Precondition.IsInRange(nonNullItemID, All.ItemIDs, nameof(inItemID));

            CollectionEffect = inEffect;
            EffectAmount = inEffectAmount;
        }
        #endregion

        #region ITypeConverter Implementation
        /// <summary>Allows the converter to construct itself statically.</summary>
        internal static readonly CollectibleModel ConverterFactory = new CollectibleModel(EntityID.None, nameof(ConverterFactory), "", "");

        /// <summary>
        /// Converts the given <see cref="object"/> to a <see cref="string"/> for serialization.
        /// </summary>
        /// <param name="inValue">The instance to convert.</param>
        /// <param name="inRow">The current context and configuration.</param>
        /// <param name="inMemberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance serialized.</returns>
        public string ConvertToString(object inValue, IWriterRow inRow, MemberMapData inMemberMapData)
            => null != inValue
            && inValue is CollectibleModel model
            && model.ID != EntityID.None
                ? $"{model.ID}{Rules.Delimiters.InternalDelimiter}" +
                  $"{model.Name}{Rules.Delimiters.InternalDelimiter}" +
                  $"{model.Description}{Rules.Delimiters.InternalDelimiter}" +
                  $"{model.Comment}{Rules.Delimiters.InternalDelimiter}" +
                  $"{model.ItemID}{Rules.Delimiters.InternalDelimiter}" +
                  $"{model.AddsToBiome}{Rules.Delimiters.InternalDelimiter}" +
                  $"{model.AddsToRoom}{Rules.Delimiters.InternalDelimiter}" +
                  $"{model.CollectionEffect}{Rules.Delimiters.InternalDelimiter}" +
                  $"{model.EffectAmount}"
            : throw new ArgumentException($"Could not serialize {inValue} as {nameof(CollectibleModel)}.");

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
                throw new ArgumentException($"Could not convert '{inText}' to {nameof(CollectibleModel)}.");
            }

            try
            {
                var numberStyle = inMemberMapData.TypeConverterOptions.NumberStyle ?? NumberStyles.Integer;
                var parameterText = inText.Split(Rules.Delimiters.InternalDelimiter);

                var id = (EntityID)EntityID.ConverterFactory.ConvertFromString(parameterText[0], inRow, inMemberMapData);
                var name = parameterText[1];
                var description = parameterText[2];
                var comment = parameterText[3];
                var itemID = (EntityID)EntityID.ConverterFactory.ConvertFromString(parameterText[4], inRow, inMemberMapData);
                var biome = (EntityTag)EntityTag.ConverterFactory.ConvertFromString(parameterText[5], inRow, inMemberMapData);
                var room = (EntityTag)EntityTag.ConverterFactory.ConvertFromString(parameterText[6], inRow, inMemberMapData);
                var effect = Enum.Parse<CollectingEffect>(parameterText[7], true);
                var amount = int.Parse(parameterText[8], numberStyle, inMemberMapData.TypeConverterOptions.CultureInfo);

                return new CollectibleModel(id, name, description, comment, itemID, biome, room, effect, amount);
            }
            catch (Exception e)
            {
                throw new FormatException($"Could not parse '{inText}' as {nameof(CollectibleModel)}: {e}");
            }
        }
        #endregion
    }
}
