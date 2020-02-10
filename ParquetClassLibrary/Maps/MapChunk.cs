using System;
using System.Collections.Generic;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using ParquetClassLibrary.Parquets;

namespace ParquetClassLibrary.Maps
{
    /// <summary>
    /// Models details of a playable chunk in sandbox.
    /// <see cref="MapChunk"/>s are composed of parquets and <see cref="SpecialPoints.SpecialPoint"/>s.
    /// </summary>
    public sealed class MapChunk : MapModel, ITypeConverter
    {
        #region Class Defaults
        /// <summary>Used to indicate an empty grid.</summary>
        public static readonly MapChunk Empty = new MapChunk(EntityID.None, "Empty MapChunk", "", "");

        /// <summary>The chunk's dimensions in parquets.</summary>
        public override Vector2D DimensionsInParquets { get; } = new Vector2D(Rules.Dimensions.ParquetsPerChunk,
                                                                              Rules.Dimensions.ParquetsPerChunk);

        /// <summary>The set of values that are allowed for <see cref="MapChunk"/> <see cref="EntityID"/>s.</summary>
        public static Range<EntityID> Bounds => All.MapChunkIDs;
        #endregion

        #region Characteristics
        /// <summary>The statuses of parquets in the chunk.</summary>
        protected override ParquetStatusGrid ParquetStatuses { get; }

        /// <summary>Floors and walkable terrain in the chunk.</summary>
        protected override ParquetStackGrid ParquetDefintion { get; }
        #endregion

        #region Initialization
        /// <summary>
        /// Used by children of the <see cref="MapModel"/> class.
        /// </summary>
        /// <param name="inID">Unique identifier for the map.  Cannot be null.</param>
        /// <param name="inName">Player-friendly name of the map.  Cannot be null or empty.</param>
        /// <param name="inDescription">Player-friendly description of the map.</param>
        /// <param name="inComment">Comment of, on, or by the map.</param>
        /// <param name="inRevision">An option revision count.</param>
        /// <param name="inExits">Locations on the map at which a something happens that cannot be determined from parquets alone.</param>
        /// <param name="inStatuses">The statuses of the collected parquets.</param>
        /// <param name="inDefintions">The definitions of the collected parquets.</param>
        public MapChunk(EntityID inID, string inName, string inDescription, string inComment, int inRevision = 0,
                        IEnumerable<ExitPoint> inExits = null, ParquetStatusGrid inStatuses = null, ParquetStackGrid inDefintions = null)
            : base(Bounds, inID, inName, inDescription, inComment, inRevision, inExits)
        {
            ParquetStatuses = inStatuses ?? new ParquetStatusGrid(Rules.Dimensions.ParquetsPerChunk, Rules.Dimensions.ParquetsPerChunk);
            ParquetDefintion = inDefintions ?? new ParquetStackGrid(Rules.Dimensions.ParquetsPerChunk, Rules.Dimensions.ParquetsPerChunk);
        }
        #endregion

        #region ITypeConverter Implementation
        /// <summary>Allows the converter to construct itself statically.</summary>
        internal static MapChunk ConverterFactory { get; } = Empty;

        /// <summary>
        /// Converts the given <see cref="object"/> to a <see cref="string"/> for serialization.
        /// </summary>
        /// <param name="inValue">The instance to convert.</param>
        /// <param name="inRow">The current context and configuration.</param>
        /// <param name="inMemberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance serialized.</returns>
        public string ConvertToString(object inValue, IWriterRow inRow, MemberMapData inMemberMapData)
            => null != inValue
            && inValue is MapChunk map
                ? $"{map.ID}{Rules.Delimiters.InternalDelimiter}" +
                  $"{map.Name}{Rules.Delimiters.InternalDelimiter}" +
                  $"{map.Description}{Rules.Delimiters.InternalDelimiter}" +
                  $"{map.Comment}{Rules.Delimiters.InternalDelimiter}" +
                  $"{map.DataVersion}{Rules.Delimiters.InternalDelimiter}" +
                  $"{map.Revision++}{Rules.Delimiters.InternalDelimiter}" +
                  $"{SeriesConverter<ExitPoint, List<ExitPoint>>.ConverterFactory.ConvertToString(map.ExitPoints, inRow, inMemberMapData)}" +
                  $"{Rules.Delimiters.InternalDelimiter}" +
                  $"{GridConverter<ParquetStatus, ParquetStatusGrid>.ConverterFactory.ConvertToString(map.ParquetStatuses, inRow, inMemberMapData)}" +
                  $"{Rules.Delimiters.InternalDelimiter}" +
                  $"{GridConverter<ParquetStack, ParquetStackGrid>.ConverterFactory.ConvertToString(map.ParquetDefintion, inRow, inMemberMapData)}"
                : throw new ArgumentException($"Could not serialize {inValue} as {nameof(MapChunk)}.");

        /// <summary>
        /// Converts the given <see cref="string"/> to an <see cref="object"/> as deserialization.
        /// </summary>
        /// <param name="inText">The text to convert.</param>
        /// <param name="inRow">The current context and configuration.</param>
        /// <param name="inMemberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance deserialized.</returns>
        public object ConvertFromString(string inText, IReaderRow inRow, MemberMapData inMemberMapData)
        {
            if (string.IsNullOrEmpty(inText))
            {
                throw new ArgumentException($"Could not convert '{inText}' to {nameof(MapChunk)}.");
            }

            try
            {
                var numberStyle = inMemberMapData?.TypeConverterOptions?.NumberStyle ?? All.SerializedNumberStyle;
                var cultureInfo = inMemberMapData?.TypeConverterOptions?.CultureInfo ?? All.SerializedCultureInfo;
                var parameterText = inText.Split(Rules.Delimiters.InternalDelimiter);

                var dataVersion = parameterText[4];
                if (dataVersion != DataVersion)
                {
                    throw new FormatException($"Unsupported saved data version: ${dataVersion}.");
                }

                var id = (EntityID)EntityID.ConverterFactory.ConvertFromString(parameterText[0], inRow, inMemberMapData);
                var name = parameterText[1];
                var description = parameterText[2];
                var comment = parameterText[3];
                var revision = int.Parse(parameterText[5], numberStyle, cultureInfo);
                var exits = (IReadOnlyList<ExitPoint>)SeriesConverter<ExitPoint, List<ExitPoint>>.ConverterFactory
                    .ConvertFromString(parameterText[6], inRow, inMemberMapData);
                var statuses = (ParquetStatusGrid)GridConverter<ParquetStatus, ParquetStatusGrid>.ConverterFactory
                    .ConvertFromString(parameterText[7], inRow, inMemberMapData);
                var stacks = (ParquetStackGrid)GridConverter<ParquetStack, ParquetStackGrid>.ConverterFactory
                    .ConvertFromString(parameterText[8], inRow, inMemberMapData);

                return new MapChunk(id, name, description, comment, revision, exits, statuses, stacks);
            }
            catch (Exception e)
            {
                throw new FormatException($"Could not parse '{inText}' as {nameof(MapChunk)}: {e}");
            }
        }
        #endregion

        #region Utilities
        /// <summary>
        /// Describes the <see cref="MapChunk"/> as a <see langword="string"/> containing basic information.
        /// </summary>
        /// <returns>A <see langword="string"/> that represents the current <see cref="MapChunk"/>.</returns>
        public override string ToString()
            => $"Chunk {base.ToString()}";
        #endregion
    }
}
