using ParquetClassLibrary.Parquets;

namespace ParquetClassLibrary.EditorSupport
{
    /// <summary>
    /// Facilitates editing of a <see cref="FurnishingModel"/> from design tools while maintaining a read-only face for use during play.
    /// </summary>
    /// <remarks>
    /// By design, children of <see cref="FurnishingModel"/> should never themselves use <see cref="IFurnishingModelEdit"/>.
    /// IFurnishingModelEdit is for use only by external types that require read/write access to model properties.
    /// </remarks>
    public interface IFurnishingModelEdit : IParquetModelEdit
    {
        /// <summary>Indicates whether this <see cref="FurnishingModel"/> may be walked on.</summary>
        public bool IsWalkable { get; set; }

        /// <summary>Indicates if and how this <see cref="FurnishingModel"/> serves as an entry to a <see cref="Rooms.Room"/> or <see cref="Maps.MapRegionModel"/>.</summary>
        public EntryType Entry { get; set; }

        /// <summary>Indicates whether this <see cref="FurnishingModel"/> serves as part of a perimeter of a <see cref="Rooms.Room"/>.</summary>
        public bool IsEnclosing { get; set; }

        /// <summary>Whether or not the <see cref="FurnishingModel"/> is flammable.</summary>
        public bool IsFlammable { get; set; }

        /// <summary>The <see cref="FurnishingModel"/> to swap with this Furnishing on an open/close action.</summary>
        public ModelID SwapID { get; set; }
    }
}
