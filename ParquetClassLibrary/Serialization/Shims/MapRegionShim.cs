using ParquetClassLibrary.Biomes;
using ParquetClassLibrary.Maps;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Serialization.Shims
{
    /// <summary>
    /// Provides a default public parameterless constructor for a
    /// <see cref="MapRegion"/>-like class that CSVHelper can instantiate.
    /// 
    /// Provides the ability to generate a <see cref="MapRegion"/> from this class.
    /// </summary>
    public class MapRegionShim : MapParentShim
    {
        /// <summary>A color to display in any empty areas of the region.</summary>
        public PCLColor Background;

        /// <summary>The region's elevation in absolute terms.</summary>
        public Elevation ElevationLocal;

        /// <summary>The region's elevation relative to all other regions.</summary>
        public int ElevationGlobal;

        /// <summary>
        /// Converts a shim into the class it corresponds to.
        /// </summary>
        /// <typeparam name="TargetType">The type to convert this shim to.</typeparam>
        /// <returns>An instance of a child class of <see cref="Enity"/>.</returns>
        public override TargetType To<TargetType>()
        {
            return null;
            /* TODO Update this once map serialization format has been decided.
            Precondition.IsOfType<TargetType, MapRegion>(typeof(TargetType).ToString());
            if (!DataVersion.Equals(AssemblyInfo.SupportedMapDataVersion))
            {
                throw new System.NotSupportedException(
                    $"Parquet supports map chunk data version {AssemblyInfo.SupportedMapDataVersion}; cannot deserialize version {DataVersion}.");
            }

            return (TargetType)(Entity)new MapRegion(ID, Name, Description, Comment, Revision, ExitPoints,
                                                     ParquetStatuses, ParquetDefintion, Background,
                                                     ElevationLocal, ElevationGlobal);
                                                     */
        }
    }
}
