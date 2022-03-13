using System;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using Parquet.Parquets;

namespace Parquet.Regions
{
    /// <summary>
    /// Models details of a portion of a <see cref="RegionModel"/>,
    /// either directly composed of parquets or generated from <see cref="ChunkDetail"/>s.
    /// Instances of this class are mutable during play.
    /// </summary>
    public class MapChunk : IEquatable<MapChunk>, ITypeConverter, IDeeplyCloneable<MapChunk>
    {
        #region Class Defaults
        /// <summary>Used to indicate an uninitialized chunk.</summary>
        public static MapChunk Empty { get; } = new MapChunk(false);

        /// <summary>The length of each <see cref="MapChunk"/> dimension in parquets.</summary>
        public const int ParquetsPerChunkDimension = 16;

        /// <summary>The chunk's dimensions in parquets.</summary>
        public Point2D DimensionsInParquets { get; } = new Point2D(ParquetsPerChunkDimension,
                                                                     ParquetsPerChunkDimension);
        #endregion

        #region Characteristics
        /// <summary>If <c>true</c>, the <see cref="MapChunk"/> is created at design time instead of procedurally generated.</summary>
        public bool IsFilledOut { get; private set; }

        /// <summary>A description of the type and arrangement of parquets to generate at runtime.</summary>
        public ChunkDetail Details { get; set; }

        /// <summary>Floors and walkable terrain in the chunk.</summary>
        public IReadOnlyGrid<ParquetModelPack> ParquetDefinitions { get; set; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new default instance of the <see cref="ParquetModelPack"/> class.
        /// </summary>
        /// <remarks>This is primarily useful for serialization.</remarks>
        public MapChunk()
            : this(false)
        { }

        /// <summary>
        /// Initializes an instance of the <see cref="MapChunk"/> class.
        /// </summary>
        /// <param name="isFilledOut">
        /// If <c>true</c>, the <see cref="MapChunk"/> was either created at design time or
        /// has already been procedurally generated on load in-game.
        /// </param>
        /// <param name="details">Cues to the generation routines if generated at runtime.</param>
        /// <param name="parquetDefinitions">The definitions of the collected parquets if designed by hand.</param>        
        public MapChunk(bool isFilledOut, ChunkDetail details = null, IReadOnlyGrid<ParquetModelPack> parquetDefinitions = null)
        {
            IsFilledOut = isFilledOut;

            if (IsFilledOut)
            {
                Details = ChunkDetail.None;
                ParquetDefinitions = parquetDefinitions ?? new ParquetModelPackGrid(ParquetsPerChunkDimension, ParquetsPerChunkDimension);
            }
            else
            {
                Details = details ?? ChunkDetail.None;
                ParquetDefinitions = ParquetModelPackGrid.Empty;
            }
        }
        #endregion

        #region Procedural Generation
        /// <summary>
        /// Transforms the current <see cref="MapChunk"/> so that it is ready to be stitched together
        /// with others in its <see cref="MapChunkGrid"/> into a playable <see cref="RegionModel"/>.
        /// </summary>
        /// <remarks>
        /// If a chunk <see cref="IsFilledOut"/>, it is ready to go.
        /// Chunks that are not handmade at design time need to undergo procedural generation based on their <see cref="ChunkDetail"/>s.
        /// </remarks>
        /// <returns>The generated <see cref="MapChunk"/>.</returns>
        // TODO [PROC GEN] Review and update this entire routine.
        public MapChunk Generate()
        {
            // If this chunk has already been generated, no work is needed.
            if (IsFilledOut)
            {
                return this;
            }

            // Create a grid to hold the generated parquets.
            var newParquetDefinitions = new ParquetModelPackGrid(ParquetsPerChunkDimension, ParquetsPerChunkDimension);

            // Generates the map for this chunk.
            // TODO [PROC GEN] Replace this pass-through implementation.
            #region Pass-Through Implementation
            Details = ChunkDetail.None;
            for (var x = 0; x < ParquetsPerChunkDimension; x++)
            {
                for (var y = 0; y < ParquetsPerChunkDimension; y++)
                {
                    newParquetDefinitions[y, x].FloorID = All.FloorIDs.Minimum;
                }
                newParquetDefinitions[0, x].BlockID = All.BlockIDs.Minimum;
                newParquetDefinitions[ParquetsPerChunkDimension - 1, 1].BlockID = All.BlockIDs.Minimum;
            }
            for (var y = 0; y < ParquetsPerChunkDimension; y++)
            {
                newParquetDefinitions[y, 0].BlockID = All.BlockIDs.Minimum;
                newParquetDefinitions[y, ParquetsPerChunkDimension - 1].BlockID = All.BlockIDs.Minimum;
            }
            newParquetDefinitions[2, 1].FurnishingID = All.FurnishingIDs.Minimum;
            newParquetDefinitions[3, 3].CollectibleID = All.CollectibleIDs.Minimum;
            #endregion

            // Return a new MapChunk with the new contents generated from the current one.
            return new MapChunk(true, null, newParquetDefinitions);
        }
        #endregion

        #region IEquatable Implementation
        /// <summary>
        /// Serves as a hash function for a <see cref="MapChunk"/>.
        /// </summary>
        /// <returns>
        /// A hash code for this instance that is suitable for use in hashing algorithms and data structures.
        /// </returns>
        public override int GetHashCode()
            => (IsFilledOut, Details, ParquetDefinitions).GetHashCode();

        /// <summary>
        /// Determines whether the specified <see cref="MapChunk"/> is equal to the current <see cref="MapChunk"/>.
        /// </summary>
        /// <param name="other">The <see cref="MapChunk"/> to compare with the current.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public bool Equals(MapChunk other)
            => other is MapChunk chunk
            && IsFilledOut == chunk.IsFilledOut
            && Details == chunk.Details
            && ParquetDefinitions == chunk.ParquetDefinitions;

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="MapChunk"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="MapChunk"/>.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
            => obj is MapChunk chunk
            && Equals(chunk);

        /// <summary>
        /// Determines whether a specified instance of <see cref="MapChunk"/> is equal to another specified instance of <see cref="MapChunk"/>.
        /// </summary>
        /// <param name="chunk1">The first <see cref="MapChunk"/> to compare.</param>
        /// <param name="chunk2">The second <see cref="MapChunk"/> to compare.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(MapChunk chunk1, MapChunk chunk2)
            => chunk1?.Equals(chunk2) ?? chunk2?.Equals(chunk1) ?? true;

        /// <summary>
        /// Determines whether a specified instance of <see cref="MapChunk"/> is not equal to another specified instance of <see cref="MapChunk"/>.
        /// </summary>
        /// <param name="chunk1">The first <see cref="MapChunk"/> to compare.</param>
        /// <param name="chunk2">The second <see cref="MapChunk"/> to compare.</param>
        /// <returns><c>true</c> if they are NOT equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(MapChunk chunk1, MapChunk chunk2)
            => !(chunk1 == chunk2);
        #endregion

        #region ITypeConverter Implementation
        /// <summary>Allows the converter to construct itself statically.</summary>
        internal static MapChunk ConverterFactory { get; } = Empty;

        /// <summary>
        /// Converts the given <see cref="object"/> to a <see cref="string"/> for serialization.
        /// </summary>
        /// <param name="value">The instance to convert.</param>
        /// <param name="row">The current context and configuration.</param>
        /// <param name="memberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance serialized.</returns>
        public string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
            => value is MapChunk chunk
                ? $"{IsFilledOut}{Delimiters.MapChunkDelimiter}" +
                  $"{chunk.Details.ConvertToString(Details, row, memberMapData)}{Delimiters.MapChunkDelimiter}" +
                  $"{GridConverter<ParquetModelPack, ParquetModelPackGrid>.ConverterFactory.ConvertToString(ParquetDefinitions, row, memberMapData)}"
                : Logger.DefaultWithConvertLog(value?.ToString() ?? "null", nameof(MapChunk), nameof(Empty));

        /// <summary>
        /// Converts the given <see cref="string"/> to an <see cref="object"/> as deserialization.
        /// </summary>
        /// <param name="text">The text to convert.</param>
        /// <param name="row">The current context and configuration.</param>
        /// <param name="memberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance deserialized.</returns>
        public object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            if (string.IsNullOrEmpty(text)
                || string.Equals(nameof(Empty), text, StringComparison.OrdinalIgnoreCase))
            {
                return Empty;
            }

            var parameterText = text.Split(Delimiters.MapChunkDelimiter);
            var parsedIsFilledOut = bool.TryParse(parameterText[0], out var tempIsFilledOut)
                ? tempIsFilledOut
                : Logger.DefaultWithParseLog(parameterText[0], nameof(IsFilledOut), false);
            var parsedDetails = (ChunkDetail)ChunkDetail.ConverterFactory.ConvertFromString(parameterText[1], row, memberMapData);
            var parsedParquetDefinitions = (ParquetModelPackGrid)GridConverter<ParquetModelPack, ParquetModelPackGrid>
                .ConverterFactory
                .ConvertFromString(parameterText[2], row, memberMapData);

            return new MapChunk(parsedIsFilledOut, parsedDetails, parsedParquetDefinitions);
        }
        #endregion

        #region IDeeplyCloneable Implementation
        /// <summary>
        /// Creates a new instance that is a deep copy of the current instance.
        /// </summary>
        /// <returns>A new instance with the same characteristics as the current instance.</returns>
        public MapChunk DeepClone()
            => new(IsFilledOut, Details, ParquetDefinitions);
        #endregion

        #region Utilities
        /// <summary>
        /// The number of parquets within the <see cref="MapChunk"/> whose identity has been determined.
        /// If <see cref="IsFilledOut"/> is <c>false</c>, this will always be <c>0</c>.</summary>
        /// <returns>The total number of parquets collected.</returns>
        public int Count
            => IsFilledOut
                ? ParquetDefinitions.Count
                : 0;

        /// <summary>
        /// Describes the <see cref="MapChunk"/> as a <see cref="string"/> containing basic information.
        /// </summary>
        /// <returns>A <see cref="string"/> that represents the current <see cref="MapChunk"/>.</returns>
        public override string ToString()
            => IsFilledOut
                ? $"{nameof(MapChunk)}: {ParquetDefinitions.Count}"
                : $"{nameof(MapChunk)}: {Details}";
        #endregion
    }

    /// <summary>
    /// Provides extension methods useful when dealing with 2D arrays of <see cref="MapChunk"/>s.
    /// </summary>
    public static class MapChunkArrayExtensions
    {
        /// <summary>
        /// Determines if the given position corresponds to a point within the current array.
        /// </summary>
        /// <param name="array">The <see cref="Pack{T}"/> array to validate against.</param>
        /// <param name="position">The position to validate.</param>
        /// <returns><c>true</c>, if the position is valid, <c>false</c> otherwise.</returns>
        public static bool IsValidPosition(this MapChunk[,] array, Point2D position)
            => array is not null
            && position.X > -1
            && position.Y > -1
            && position.X < array.GetLength(1)
            && position.Y < array.GetLength(0);
    }
}
