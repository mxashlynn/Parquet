#if DESIGN
using CsvHelper.Configuration.Attributes;
using ParquetClassLibrary.EditorSupport;

namespace ParquetClassLibrary.Maps
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1033:Interface methods should be callable by subtypes",
        Justification = "By design, subtypes of Model should never themselves use IModelEdit or derived interfaces to access their own members.  The IModelEdit family of interfaces is for external types that require read/write access.")]
    public partial class MapRegionModel : IMapRegionEdit
    {
        #region IMapRegionEdit Implementation
        /// <summary>A color to display in any empty areas of the region.</summary>
        [Ignore]
        string IMapRegionEdit.BackgroundColor { get => BackgroundColor; set => BackgroundColor = value; }

        /// <summary>The <see cref="ModelID"/> of the region to the north of this one.</summary>
        [Ignore]
        ModelID IMapRegionEdit.RegionToTheNorthID { get => RegionToTheNorth; set => RegionToTheNorth = value; }

        /// <summary>The <see cref="ModelID"/> of the region to the east of this one.</summary>
        [Ignore]
        ModelID IMapRegionEdit.RegionToTheEastID { get => RegionToTheEast; set => RegionToTheEast = value; }

        /// <summary>The <see cref="ModelID"/> of the region to the south of this one.</summary>
        [Ignore]
        ModelID IMapRegionEdit.RegionToTheSouthID { get => RegionToTheSouth; set => RegionToTheSouth = value; }

        /// <summary>The <see cref="ModelID"/> of the region to the west of this one.</summary>
        [Ignore]
        ModelID IMapRegionEdit.RegionToTheWestID { get => RegionToTheWest; set => RegionToTheWest = value; }

        /// <summary>The <see cref="ModelID"/> of the region above this one.</summary>
        [Ignore]
        ModelID IMapRegionEdit.RegionAboveID { get => RegionAbove; set => RegionAbove = value; }

        /// <summary>The <see cref="ModelID"/> of the region below this one.</summary>
        [Ignore]
        ModelID IMapRegionEdit.RegionBelowID { get => RegionBelow; set => RegionBelow = value; }
        #endregion
    }
}
#endif
