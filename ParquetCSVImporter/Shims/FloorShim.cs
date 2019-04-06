using System;
using ParquetClassLibrary.Items;
using ParquetClassLibrary.Sandbox.Parquets;

namespace ParquetCSVImporter.ClassMaps
{
    /// <summary>
    /// Provides a default public parameterless constructor for a
    /// <see cref="T:ParquetClassLibrary.Sandbox.Parquets.Floor"/>-like
    /// class that CSVHelper can instantiate.
    /// 
    /// Provides the ability to generate a <see cref="T:ParquetClassLibrary.Sandbox.Parquets.Floor"/>
    /// from this class.
    /// </summary>
    public class FloorShim : ParquetParentShim
    {
        /// <summary>The tool used to dig out or fill in the floor.</summary>
        public ModificationTools ModTool;

        /// <summary>Player-facing name of the parquet, used when it has been dug out.</summary>
        public string TrenchName;

        /// <summary>The floor may be walked on.</summary>
        public bool IsWalkable;

        /// <summary>
        /// Converts a shim into the class is corresponds to.
        /// </summary>
        /// <typeparam name="T">The type to convert this shim to.</typeparam>
        /// <returns>An instance of a child class of <see cref="T:ParquetClassLibrary.Sandbox.Parquets.ParquetParent"/>.</returns>
        /// <exception cref="System.ArgumentException">
        /// Thrown when the current shim does not correspond to the specified type.
        /// </exception>
        public override T To<T>()
        {
            T result;

            if (typeof(T) == typeof(Floor))
            {
                result = (T)(ParquetParent)new Floor(ID, Name, AddsToBiome, ModTool, TrenchName, IsWalkable);
            }
            else
            {
                throw new ArgumentException(nameof(T));
            }

            return result;
        }
    }
}
