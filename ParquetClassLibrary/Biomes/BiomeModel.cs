using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using ParquetClassLibrary.Items;
using ParquetClassLibrary.Serialization;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Biomes
{
    /// <summary>
    /// Models the biome that a <see cref="Maps.MapRegion"/> embodies.
    /// </summary>
    public sealed class BiomeModel : EntityModel, ITypeConverter
    {
        #region Characteristics
        /// <summary>
        /// A rating indicating where in the progression this <see cref="BiomeModel"/> falls.
        /// Must be non-negative.  Higher values indicate later Biomes.
        /// </summary>
        public int Tier { get; }

        /// <summary>Describes where this <see cref="BiomeModel"/> falls in terms of the game world's overall topography.</summary>
        public Elevation ElevationCategory { get; }

        /// <summary>Determines whether or not this <see cref="BiomeModel"/> is defined in terms of liquid parquets.</summary>
        public bool IsLiquidBased { get; }

        /// <summary>Describes the parquets that make up this <see cref="BiomeModel"/>.</summary>
        public IReadOnlyList<EntityTag> ParquetCriteria { get; }

        /// <summary>Describes the <see cref="ItemModel"/>s a <see cref="Beings.PlayerCharacterModel"/> needs to safely access this <see cref="BiomeModel"/>.</summary>
        public IReadOnlyList<EntityTag> EntryRequirements { get; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="BiomeModel"/> class.
        /// </summary>
        /// <param name="inID">Unique identifier for the <see cref="BiomeModel"/>.  Cannot be null.</param>
        /// <param name="inName">Player-friendly name of the <see cref="BiomeModel"/>.  Cannot be null or empty.</param>
        /// <param name="inDescription">Player-friendly description of the <see cref="BiomeModel"/>.</param>
        /// <param name="inComment">Comment of, on, or by the <see cref="BiomeModel"/>.</param>
        /// <param name="inTier">A rating indicating where in the progression this <see cref="BiomeModel"/> falls.</param>
        /// <param name="inElevationCategory">Describes where this <see cref="BiomeModel"/> falls in terms of the game world's overall topography.</param>
        /// <param name="inIsLiquidBased">Determines whether or not this <see cref="BiomeModel"/> is defined in terms of liquid parquets.</param>
        /// <param name="inParquetCriteria">Describes the parquets that make up this <see cref="BiomeModel"/>.</param>
        /// <param name="inEntryRequirements">Describes the <see cref="ItemModel"/>s needed to access this <see cref="BiomeModel"/>.</param>
        public BiomeModel(EntityID inID, string inName, string inDescription, string inComment,
                     int inTier, Elevation inElevationCategory,
                     bool inIsLiquidBased, IEnumerable<EntityTag> inParquetCriteria,
                     IEnumerable<EntityTag> inEntryRequirements)
            : base(All.BiomeIDs, inID, inName, inDescription, inComment)
        {
            Precondition.MustBeNonNegative(inTier, nameof(inTier));

            Tier = inTier;
            ElevationCategory = inElevationCategory;
            IsLiquidBased = inIsLiquidBased;
            ParquetCriteria = (inParquetCriteria ?? Enumerable.Empty<EntityTag>()).ToList();
            EntryRequirements = (inEntryRequirements ?? Enumerable.Empty<EntityTag>()).ToList();
        }
        #endregion

        #region ITypeConverter Implementation
        /// <summary>Allows the converter to construct itself statically.</summary>
        internal static readonly BiomeModel ConverterFactory =
            new BiomeModel(EntityID.None, nameof(ConverterFactory), "", "", 0, 0, false, null, null);

        /// <summary>
        /// Converts the given <see cref="object"/> to a <see cref="string"/> for serialization.
        /// </summary>
        /// <param name="inValue">The instance to convert.</param>
        /// <param name="inRow">The current context and configuration.</param>
        /// <param name="inMemberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance serialized.</returns>
        public string ConvertToString(object inValue, IWriterRow inRow, MemberMapData inMemberMapData)
            => null != inValue
            && inValue is BiomeModel model
            && model.ID != EntityID.None
                ? $"{model.ID}{Rules.Delimiters.InternalDelimiter}" +
                  $"{model.Name}{Rules.Delimiters.InternalDelimiter}" +
                  $"{model.Description}{Rules.Delimiters.InternalDelimiter}" +
                  $"{model.Comment}{Rules.Delimiters.InternalDelimiter}" +
                  $"{model.Tier}{Rules.Delimiters.InternalDelimiter}" +
                  $"{model.ElevationCategory}{Rules.Delimiters.InternalDelimiter}" +
                  $"{model.IsLiquidBased}{Rules.Delimiters.InternalDelimiter}" +
                  $"{SeriesConverter<EntityTag, List<EntityTag>>.ConverterFactory.ConvertToString(model.ParquetCriteria, Rules.Delimiters.ElementDelimiter)}" +
                  $"{Rules.Delimiters.InternalDelimiter}" +
                  $"{SeriesConverter<EntityTag, List<EntityTag>>.ConverterFactory.ConvertToString(model.EntryRequirements, Rules.Delimiters.ElementDelimiter)}"
                : throw new ArgumentException($"Could not serialize {inValue} as {nameof(BiomeModel)}.");

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
                throw new ArgumentException($"Could not convert '{inText}' to {nameof(BiomeModel)}.");
            }

            try
            {
                var numberStyle = inMemberMapData?.TypeConverterOptions?.NumberStyle ?? Serializer.SerializedNumberStyle;
                var cultureInfo = inMemberMapData?.TypeConverterOptions?.CultureInfo ?? Serializer.SerializedCultureInfo;
                var parameterText = inText.Split(Rules.Delimiters.InternalDelimiter);

                var id = (EntityID)EntityID.ConverterFactory.ConvertFromString(parameterText[0], inRow, inMemberMapData);
                var name = parameterText[1];
                var description = parameterText[2];
                var comment = parameterText[3];
                var tier = int.Parse(parameterText[4], numberStyle, cultureInfo);
                var elevation = (Elevation)Enum.Parse(typeof(Elevation), parameterText[5]);
                var liquid = bool.Parse(parameterText[6]);
                var criteria = (List<EntityTag>)SeriesConverter<EntityTag, List<EntityTag>>
                    .ConverterFactory.ConvertFromString(parameterText[7], inRow, inMemberMapData, Rules.Delimiters.ElementDelimiter);
                var requirements = (List<EntityTag>)SeriesConverter<EntityTag, List<EntityTag>>
                    .ConverterFactory.ConvertFromString(parameterText[8], inRow, inMemberMapData, Rules.Delimiters.ElementDelimiter);

                return new BiomeModel(id, name, description, comment, tier, elevation, liquid, criteria, requirements);
            }
            catch (Exception e)
            {
                throw new FormatException($"Could not parse '{inText}' as {nameof(BiomeModel)}: {e}");
            }
        }
        #endregion
    }
}
