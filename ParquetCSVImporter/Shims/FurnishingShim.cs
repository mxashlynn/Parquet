using System;
using ParquetClassLibrary;
using ParquetClassLibrary.Sandbox.Parquets;

namespace ParquetCSVImporter.Shims
{
    /// <summary>
    /// Provides a default public parameterless constructor for a <see cref="Furnishing"/>-like
    /// class that CSVHelper can instantiate.
    /// 
    /// Provides the ability to generate a <see cref="Furnishing"/> from this class.
    /// </summary>
    public class FurnishingShim : ParquetParentShim
    {
        /// <summary>The furnishing may be walked on.</summary>
        public bool IsWalkable;

        /// <summary>The furnishing may be entered through.</summary>
        public bool IsEntry;

        /// <summary>The furnishing may be a wall.</summary>
        public bool IsEnclosing;

        /// <summary>The item that represents this furnishing in the inventory.</summary>
        public EntityID ItemID;

        /// <summary>The furnishing to swap with this furnishing on an open/close action.</summary>
        public EntityID SwapID;

        /// <summary>
        /// Converts a shim into the class is corresponds to.
        /// </summary>
        /// <typeparam name="T">The type to convert this shim to.</typeparam>
        /// <returns>An instance of a child class of <see cref="ParquetParent"/>.</returns>
        /// <exception cref="System.ArgumentException">
        /// Thrown when the current shim does not correspond to the specified type.
        /// </exception>
        public override T To<T>()
        {
            T result;

            if (typeof(T) == typeof(Furnishing))
            {
                result = (T)(ParquetParent)new Furnishing(ID, Name, AddsToBiome, IsWalkable,
                                                          IsEntry, IsEnclosing, SwapID);
            }
            else
            {
                throw new ArgumentException(nameof(T));
            }

            return result;
        }
    }
}
