using System.Diagnostics.CodeAnalysis;
using CsvHelper.Configuration.Attributes;

namespace Parquet.Regions
{
    [SuppressMessage("Design", "CA1033:Interface methods should be callable by subtypes",
                     Justification = "By design, subtypes of Model should never themselves use IMutableModel or derived interfaces to access their own members.  The IMutableModel family of interfaces is for external types that require read/write access.")]
    public partial class MapRegionSketch : IMutableRegionModel
    {
        #region IMapRegionEdit Implementation
        /// <summary>What the region is called in-game.</summary>
        [Ignore]
        string IMutableModel.Name
        {
            get => Name;
            set
            {
                IMutableModel editableThis = this;
                editableThis.Name = value;
            }
        }

        /// <summary>A color to display in any empty areas of the region.</summary>
        [Ignore]
        string IMutableRegionModel.BackgroundColor { get => BackgroundColor; set => BackgroundColor = value; }

        /// <summary>The <see cref="ModelID"/> of the region to the north of this one.</summary>
        [Ignore]
        ModelID IMutableRegionModel.RegionToTheNorthID { get => RegionToTheNorth; set => RegionToTheNorth = value; }

        /// <summary>The <see cref="ModelID"/> of the region to the east of this one.</summary>
        [Ignore]
        ModelID IMutableRegionModel.RegionToTheEastID { get => RegionToTheEast; set => RegionToTheEast = value; }

        /// <summary>The <see cref="ModelID"/> of the region to the south of this one.</summary>
        [Ignore]
        ModelID IMutableRegionModel.RegionToTheSouthID { get => RegionToTheSouth; set => RegionToTheSouth = value; }

        /// <summary>The <see cref="ModelID"/> of the region to the west of this one.</summary>
        [Ignore]
        ModelID IMutableRegionModel.RegionToTheWestID { get => RegionToTheWest; set => RegionToTheWest = value; }

        /// <summary>The <see cref="ModelID"/> of the region above this one.</summary>
        [Ignore]
        ModelID IMutableRegionModel.RegionAboveID { get => RegionAbove; set => RegionAbove = value; }

        /// <summary>The <see cref="ModelID"/> of the <see cref="RegionModel"/> below this one.</summary>
        [Ignore]
        ModelID IMutableRegionModel.RegionBelowID { get => RegionBelow; set => RegionBelow = value; }
        #endregion
    }
}
