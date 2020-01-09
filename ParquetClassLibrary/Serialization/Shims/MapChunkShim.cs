using ParquetClassLibrary.Maps;

namespace ParquetClassLibrary.Serialization.Shims
{
    /// <summary>
    /// Provides a default public parameterless constructor for a
    /// <see cref="MapChunk"/>-like class that CSVHelper can instantiate.
    /// 
    /// Provides the ability to generate a <see cref="MapChunk"/> from this class.
    /// </summary>
    public class MapChunkShim : MapParentShim
    {
        /// <summary>
        /// Converts a shim into the class it corresponds to.
        /// </summary>
        /// <typeparam name="T">The type to convert this shim to.</typeparam>
        /// <returns>An instance of a child class of <see cref="Enity"/>.</returns>
        public override T ToEntity<T>()
        {
            return null;

            /* TODO Update this once map serialization format has been decided.
            Precondition.IsOfType<TargetType, MapChunk>(typeof(TargetType).ToString());
            if (!DataVersion.Equals(AssemblyInfo.SupportedMapDataVersion))
            {
                throw new System.NotSupportedException(
                    $"Parquet supports map chunk data version {AssemblyInfo.SupportedMapDataVersion}; cannot deserialize version {DataVersion}.");
            }

            return (TargetType)(EntityModel)new MapChunk(ID, Name, Description, Comment, Revision,
                                                         ExitPoints, ParquetStatuses, ParquetDefintion);
            */
        }
    }
}
