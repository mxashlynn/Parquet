using System;
using System.Collections.Generic;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using ParquetClassLibrary.Serialization;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Beings
{
    /// <summary>
    /// Models the definition for a simple in-game actor, such as a friendly mob with limited interaction.
    /// </summary>
    public sealed class CritterModel : BeingModel, ITypeConverter
    {
        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="CritterModel"/> class.
        /// </summary>
        /// <param name="inID">
        /// Unique identifier for the <see cref="CritterModel"/>.  Cannot be null.
        /// Must be a <see cref="All.CritterIDs"/>.
        /// </param>
        /// <param name="inName">Player-friendly name of the <see cref="CritterModel"/>.  Cannot be null or empty.</param>
        /// <param name="inDescription">Player-friendly description of the <see cref="CritterModel"/>.</param>
        /// <param name="inComment">Comment of, on, or by the <see cref="CritterModel"/>.</param>
        /// <param name="inNativeBiome">The <see cref="Biomes.BiomeModel"/> in which this <see cref="CritterModel"/> is most comfortable.</param>
        /// <param name="inPrimaryBehavior">The rules that govern how this <see cref="CritterModel"/> acts.  Cannot be null.</param>
        /// <param name="inAvoids">Any parquets this <see cref="CritterModel"/> avoids.</param>
        /// <param name="inSeeks">Any parquets this <see cref="CritterModel"/> seeks.</param>
        public CritterModel(EntityID inID, string inName, string inDescription, string inComment,
                            EntityID inNativeBiome, Behavior inPrimaryBehavior,
                            IEnumerable<EntityID> inAvoids = null, IEnumerable<EntityID> inSeeks = null)
            : base(All.CritterIDs, inID, inName, inDescription, inComment, inNativeBiome, inPrimaryBehavior, inAvoids, inSeeks)
        {
            Precondition.IsInRange(inID, All.CritterIDs, nameof(inID));
        }
        #endregion

        #region ITypeConverter Implementation
        /// <summary>Allows the converter to construct itself statically.</summary>
        internal static readonly CritterModel ConverterFactory =
            new CritterModel(EntityID.None, nameof(ConverterFactory), "", "", EntityID.None, Behavior.Still);

        /// <summary>
        /// Converts the given <see cref="object"/> to a <see cref="string"/> for serialization.
        /// </summary>
        /// <param name="inValue">The instance to convert.</param>
        /// <param name="inRow">The current context and configuration.</param>
        /// <param name="inMemberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance serialized.</returns>
        public string ConvertToString(object inValue, IWriterRow inRow, MemberMapData inMemberMapData)
            => null != inValue
            && inValue is CritterModel model
            && model.ID != EntityID.None
                ? $"{model.ID}{Rules.Delimiters.InternalDelimiter}" +
                  $"{model.Name}{Rules.Delimiters.InternalDelimiter}" +
                  $"{model.Description}{Rules.Delimiters.InternalDelimiter}" +
                  $"{model.Comment}{Rules.Delimiters.InternalDelimiter}" +
                  $"{model.NativeBiome}{Rules.Delimiters.InternalDelimiter}" +
                  $"{model.PrimaryBehavior}{Rules.Delimiters.InternalDelimiter}" +
                  $"{SeriesConverter<EntityID, List<EntityID>>.ConverterFactory.ConvertToString(model.Avoids, inRow, inMemberMapData, Rules.Delimiters.ElementDelimiter)}" +
                  $"{Rules.Delimiters.InternalDelimiter}" +
                  $"{SeriesConverter<EntityID, List<EntityID>>.ConverterFactory.ConvertToString(model.Seeks, inRow, inMemberMapData, Rules.Delimiters.ElementDelimiter)}"
                : throw new ArgumentException($"Could not serialize {inValue} as {nameof(CritterModel)}.");

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
                throw new ArgumentException($"Could not convert '{inText}' to {nameof(CritterModel)}.");
            }

            var numberStyle = inMemberMapData.TypeConverterOptions.NumberStyle ?? NumberStyles.Integer;
            var parameterText = inText.Split(Rules.Delimiters.InternalDelimiter);
            try
            {
                var id = (EntityID)EntityID.ConverterFactory.ConvertFromString(parameterText[0], inRow, inMemberMapData);
                var name = parameterText[1];
                var description = parameterText[2];
                var comment = parameterText[3];
                var biome = (EntityID)EntityID.ConverterFactory.ConvertFromString(parameterText[4], inRow, inMemberMapData);
                var behavior = (Behavior)Enum.Parse(typeof(Behavior), parameterText[5]);
                var avoids = (List<EntityID>)SeriesConverter<EntityID, List<EntityID>>
                    .ConverterFactory.ConvertFromString(parameterText[6], inRow, inMemberMapData);
                var seeks = (List<EntityID>)SeriesConverter<EntityID, List<EntityID>>
                    .ConverterFactory.ConvertFromString(parameterText[7], inRow, inMemberMapData);

                return new CritterModel(id, name, description, comment, biome, behavior, avoids, seeks);
            }
            catch (Exception e)
            {
                throw new FormatException($"Could not parse '{inText}' as {nameof(CritterModel)}: {e}");
            }
        }
        #endregion
    }
}
