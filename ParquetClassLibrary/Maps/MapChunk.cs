using System;
using CsvHelper.Configuration;
using ParquetClassLibrary.Parquets;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Maps
{
    /// <summary>
    /// Models details of a playable chunk in sandbox.
    /// <see cref="MapChunk"/>s are composed of parquets and <see cref="SpecialPoints.SpecialPoint"/>s.
    /// </summary>
    public sealed class MapChunk : MapModel
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
        protected override ParquetStatusGrid ParquetStatuses { get; } = new ParquetStatusGrid(Rules.Dimensions.ParquetsPerChunk, Rules.Dimensions.ParquetsPerChunk);

        /// <summary>Floors and walkable terrain in the chunk.</summary>
        protected override ParquetStackGrid ParquetDefintion { get; } = new ParquetStackGrid(Rules.Dimensions.ParquetsPerChunk, Rules.Dimensions.ParquetsPerChunk);
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
        // TODO We need set the Grid variables from the serializer.
        public MapChunk(EntityID inID, string inName, string inDescription, string inComment, int inRevision = 0)
            : base(Bounds, inID, inName, inDescription, inComment, inRevision) { }
        #endregion

        #region Serialization
        #region Serializer Shim
        /// <summary>
        /// Provides a default public parameterless constructor for a
        /// <see cref="MapChunk"/>-like class that CSVHelper can instantiate.
        /// 
        /// Provides the ability to generate a <see cref="MapChunk"/> from this class.
        /// </summary>
        internal class MapChunkShim : MapModelShim
        {
            /// <summary>
            /// Converts a shim into the class it corresponds to.
            /// </summary>
            /// <typeparam name="TModel">The type to convert this shim to.</typeparam>
            /// <returns>An instance of a child class of <see cref="MapModel"/>.</returns>
            public override TModel ToEntity<TModel>()
            {
                Precondition.IsOfType<TModel, MapChunk>(typeof(TModel).ToString());
                if (!DataVersion.Equals(AssemblyInfo.SupportedMapDataVersion, StringComparison.InvariantCultureIgnoreCase))
                {
                    throw new NotSupportedException(
                        $"Parquet supports map chunk data version {AssemblyInfo.SupportedMapDataVersion}; cannot deserialize version {DataVersion}.");
                }

                return (TModel)(EntityModel)new MapChunk(ID, Name, Description, Comment, Revision
                                                         // TODO ExitPoints, ParquetStatuses, ParquetDefintion
                                                         );
            }
        }
        #endregion

        #region Class Map
        /// <summary>
        /// Maps the values in a <see cref="MapChunkShim"/> to records that CSVHelper recognizes.
        /// </summary>
        internal sealed class MapChunkClassMap : ClassMap<MapChunkShim>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="MapChunkClassMap"/> class.
            /// </summary>
            public MapChunkClassMap()
            {
                // TODO This is a stub.

                // Properties are ordered by index to facilitate a logical layout in spreadsheet apps.
                Map(m => m.ID).Index(0);
                Map(m => m.Name).Index(1);
                Map(m => m.Description).Index(2);
                Map(m => m.Comment).Index(3);
            }
        }
        #endregion

        /// <summary>Caches a class mapper.</summary>
        private static MapChunkClassMap classMapCache;

        /// <summary>
        /// Provides the means to map all members of this class to a CSV file.
        /// </summary>
        /// <returns>The member mapping.</returns>
        internal static ClassMap GetClassMap()
            => classMapCache
            ?? (classMapCache = new MapChunkClassMap());

        /// <summary>
        /// Provides the means to map all members of this class to a CSV file.
        /// </summary>
        /// <returns>The member mapping.</returns>
        internal static Type GetShimType()
            => typeof(MapChunkShim);
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
