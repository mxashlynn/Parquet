using System.Diagnostics.CodeAnalysis;
using CsvHelper.Configuration.Attributes;
using Parquet.EditorSupport;

namespace Parquet.Parquets
{
    [SuppressMessage("Design", "CA1033:Interface methods should be callable by subtypes",
                     Justification = "By design, subtypes of Model should never themselves use IMutableModel or derived interfaces to access their own members.  The IMutableModel family of interfaces is for external types that require read/write access.")]
    public partial class FurnishingModel : IMutableFurnishingModel
    {
        #region IFurnishingModelEdit Implementation
        /// <summary>Indicates whether this <see cref="FurnishingModel"/> may be walked on.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IMutableModel"/>.
        /// IModelEdit is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        bool IMutableFurnishingModel.IsWalkable
        {
            get => IsWalkable;
            set => IsWalkable = LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(IsWalkable), IsWalkable)
                : value;
        }

        /// <summary>Indicates if and how this <see cref="FurnishingModel"/> serves as an entry to a <see cref="Rooms.Room"/> or <see cref="Maps.MapRegionModel"/>.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IMutableModel"/>.
        /// IModelEdit is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        EntryType IMutableFurnishingModel.Entry
        {
            get => Entry;
            set => Entry = LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(Entry), Entry)
                : value;
        }

        /// <summary>Indicates whether this <see cref="FurnishingModel"/> serves as part of a perimeter of a <see cref="Rooms.Room"/>.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IMutableModel"/>.
        /// IModelEdit is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        bool IMutableFurnishingModel.IsEnclosing
        {
            get => IsEnclosing;
            set => IsEnclosing = LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(IsEnclosing), IsEnclosing)
                : value;
        }

        /// <summary>Whether or not the <see cref="FurnishingModel"/> is flammable.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IMutableModel"/>.
        /// IModelEdit is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        bool IMutableFurnishingModel.IsFlammable
        {
            get => IsFlammable;
            set => IsFlammable = LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(IsFlammable), IsFlammable)
                : value;
        }

        /// <summary>The <see cref="FurnishingModel"/> to swap with this Furnishing on an open/close action.</summary>
        /// <remarks>
        /// By design, subtypes of <see cref="Model"/> should never themselves use <see cref="IMutableModel"/>.
        /// IModelEdit is for external types that require read/write access.
        /// </remarks>
        [Ignore]
        ModelID IMutableFurnishingModel.SwapID
        {
            get => SwapID;
            set => SwapID = LibraryState.IsPlayMode
                ? Logger.DefaultWithImmutableInPlayLog(nameof(SwapID), SwapID)
                : value;
        }
        #endregion
    }
}
