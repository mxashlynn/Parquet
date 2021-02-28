namespace Parquet.Parquets
{
    /// <summary>
    /// Facilitates editing of a <see cref="FurnishingModel"/> from design tools while maintaining a read-only face for use during play.
    /// </summary>
    /// <remarks>
    /// By design, subtypes of <see cref="FurnishingModel"/> should never themselves use <see cref="IMutableFurnishingModel"/>.
    /// IMutableFurnishingModel is for use only by external types that require read/write access to model properties.
    /// </remarks>
    public interface IMutableFurnishingModel : IMutableParquetModel
    {
        /// <summary>If <c>true</c> this <see cref="FurnishingModel"/> may be walked on.</summary>
        public bool IsWalkable { get; set; }

        /// <summary>Indicates if and how this <see cref="FurnishingModel"/> serves as an entry to a <see cref="Rooms.Room"/> or <see cref="Regions.RegionModel"/>.</summary>
        public EntryType Entry { get; set; }

        /// <summary>If <c>true</c> this <see cref="FurnishingModel"/> serves as part of a perimeter of a <see cref="Rooms.Room"/>.</summary>
        public bool IsEnclosing { get; set; }

        /// <summary>If <c>true</c> the <see cref="FurnishingModel"/> may catch fire.</summary>
        public bool IsFlammable { get; set; }

        /// <summary>If <c>true</c> this <see cref="FurnishingModel"/> may be opened and closed.</summary>
        public bool IsOpenable { get; set; }
    }
}
