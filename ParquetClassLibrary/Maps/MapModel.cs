using System;
using System.Collections.Generic;
using System.Linq;
using CsvHelper.Configuration.Attributes;
using ParquetClassLibrary.Parquets;

namespace ParquetClassLibrary.Maps
{
    /// <summary>
    /// Provides methods that are used by all parquet-based map models (for example <see cref="MapRegion"/> and <see cref="MapChunk"/>,
    /// but contrast <see cref="ChunkTypeGrid"/> which is not parquet-based).
    /// </summary>
    public abstract class MapModel : Model
    {
        #region Class Defaults
        /// <summary>Dimensions in parquets.  Defined by child classes.</summary>
        [Ignore]
        public abstract Vector2D DimensionsInParquets { get; }

        /// <summary>Describes the version of serialized data, to support versioning.</summary>
        [Index(4)]
        public string DataVersion { get; } = AssemblyInfo.SupportedMapDataVersion;
        #endregion

        #region Characteristics
        #region Whole-Map Characteristics
        /// <summary>Tracks how many times the data structure has been serialized.</summary>
        [Index(5)]
        public int Revision { get; protected set; }
        #endregion

        #region Map Contents
        /// <summary>Locations on the map at which a something happens that cannot be determined from parquets alone.</summary>
        [Index(6)]
        public List<ExitPoint> Exits { get; }

        /// <summary>Floors and walkable terrain on the map.</summary>
        [Index(10)]
        public abstract ParquetStatusGrid ParquetStatuses { get; }

        /// <summary>
        /// Definitions for every <see cref="FloorModel"/>, <see cref="BlockModel"/>, <see cref="FurnishingModel"/>,
        /// and <see cref="CollectibleModel"/> that makes up this part of the game world.
        /// </summary>
        [Index(11)]
        public abstract ParquetStackGrid ParquetDefinitions { get; }
        #endregion
        #endregion

        #region Initialization
        /// <summary>
        /// Used by children of the <see cref="MapModel"/> class.
        /// </summary>
        /// <param name="inBounds">The bounds within which the derived map type's <see cref="ModelID"/> is defined.</param>
        /// <param name="inID">Unique identifier for the map.  Cannot be null.</param>
        /// <param name="inName">Player-friendly name of the map.  Cannot be null or empty.</param>
        /// <param name="inDescription">Player-friendly description of the map.</param>
        /// <param name="inComment">Comment of, on, or by the map.</param>
        /// <param name="inDataVersion">Describes the version of serialized data, to support versioning.</param>
        /// <param name="inRevision">How many times this map has been serialized.</param>
        /// <param name="inExits">Locations on the map at which a something happens that cannot be determined from parquets alone.</param>
        protected MapModel(Range<ModelID> inBounds, ModelID inID, string inName, string inDescription, string inComment,
                           string inDataVersion, int inRevision, IEnumerable<ExitPoint> inExits = null)
            : base(inBounds, inID, inName, inDescription, inComment)
        {
            if (!DataVersion.Equals(inDataVersion, StringComparison.InvariantCultureIgnoreCase))
            {
                throw new FormatException($"Unsupported {nameof(MapModel)} data version {inDataVersion}.");
            }

            Revision = inRevision;
            Exits = inExits?.ToList() ?? new List<ExitPoint>();
        }
        #endregion

        #region Utilities
        /// <summary>The total number of parquets in the entire map.</summary>
        [Ignore]
        protected int ParquetsCount => ParquetDefinitions?.Count ?? 0;

        /// <summary>
        /// Determines if the given position corresponds to a point in the region.
        /// </summary>
        /// <param name="inPosition">The position to validate.</param>
        /// <returns><c>true</c>, if the position is valid, <c>false</c> otherwise.</returns>
        public bool IsValidPosition(Vector2D inPosition)
            => ParquetDefinitions.IsValidPosition(inPosition);

        /// <summary>
        /// Provides all parquet definitions within the current map.
        /// </summary>
        /// <returns>The entire map as a subregion.</returns>
        public ParquetStackGrid GetSubregion()
            => GetSubregion(Vector2D.Zero, new Vector2D(DimensionsInParquets.X - 1, DimensionsInParquets.Y - 1));

        /// <summary>
        /// Provides all parquet definitions within the specified rectangular subsection of the current map.
        /// </summary>
        /// <param name="inUpperLeft">The position of the upper-leftmost corner of the subregion.</param>
        /// <param name="inLowerRight">The position of the lower-rightmost corner of the subregion.</param>
        /// <returns>A portion of the map as a subregion.</returns>
        public ParquetStackGrid GetSubregion(Vector2D inUpperLeft, Vector2D inLowerRight)
        {
            if (!ParquetDefinitions.IsValidPosition(inUpperLeft))
            {
                throw new ArgumentOutOfRangeException(nameof(inUpperLeft));
            }
            else if (!ParquetDefinitions.IsValidPosition(inLowerRight))
            {
                throw new ArgumentOutOfRangeException(nameof(inLowerRight));
            }
            else if (inLowerRight.X < inUpperLeft.X && inLowerRight.Y < inUpperLeft.Y)
            {
                throw new ArgumentException("Improper vector order.", nameof(inLowerRight));
            }
            else
            {
                var subregion = new ParquetStack[inLowerRight.X - inUpperLeft.X + 1,
                                                 inLowerRight.Y - inUpperLeft.Y + 1];

                for (var x = inUpperLeft.X; x <= inLowerRight.X; x++)
                {
                    for (var y = inUpperLeft.Y; y <= inLowerRight.Y; y++)
                    {
                        subregion[y - inUpperLeft.Y, x - inUpperLeft.X] = ParquetDefinitions[y, x];
                    }
                }

                return new ParquetStackGrid(subregion);
            }
        }

        /// <summary>
        /// Describes the map through general characteristics.
        /// </summary>
        /// <returns>A <see langword="string"/> that represents the current map.</returns>
        public override string ToString()
            => $"({DimensionsInParquets.X }, {DimensionsInParquets.Y}) contains {ParquetsCount} parquets and {Exits.Count} exits.";
        #endregion
    }
}
