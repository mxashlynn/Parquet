using System;
using CsvHelper;
using CsvHelper.Configuration;

namespace Parquet.Parquets
{
    /// <summary>
    /// Simple container for collocated <see cref="ParquetModel"/>s, one of each subtype.
    /// Instances of this class are mutable during play, although the <see cref="ParquetModel"/>s they contain are not.
    /// </summary>
    public sealed class ParquetModelPack : Pack<ParquetModel>
    {
        #region Class Defaults
        /// <summary>Canonical null <see cref="ParquetModelPack"/>, representing an arbitrary empty pack.</summary>
        public static ParquetModelPack Empty
            => new(ModelID.None, ModelID.None, ModelID.None, ModelID.None);
        #endregion

        #region Characteristics
        /// <summary>The floor contained in this pack.</summary>
        public ModelID FloorID { get; set; }

        /// <summary>The block contained in this pack.</summary>
        public ModelID BlockID { get; set; }

        /// <summary>The furnishing contained in this pack.</summary>
        public ModelID FurnishingID { get; set; }

        /// <summary>The collectible contained in this pack.</summary>
        public ModelID CollectibleID { get; set; }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new default instance of the <see cref="ParquetModelPack"/> class.
        /// </summary>
        /// <remarks>This is primarily useful for serialization.</remarks>
        public ParquetModelPack()
            : this(ModelID.None, ModelID.None, ModelID.None, ModelID.None)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ParquetModelPack"/> class.
        /// </summary>
        /// <param name="floor">The floor-layer parquet.</param>
        /// <param name="block">The block-layer parquet.</param>
        /// <param name="furnishing">The furnishing-layer parquet.</param>
        /// <param name="collectible">The collectible-layer parquet.</param>
        public ParquetModelPack(ModelID floor, ModelID block, ModelID furnishing, ModelID collectible)
        {
            Precondition.IsInRange(floor, All.FloorIDs, nameof(floor));
            Precondition.IsInRange(block, All.BlockIDs, nameof(block));
            Precondition.IsInRange(furnishing, All.FurnishingIDs, nameof(furnishing));
            Precondition.IsInRange(collectible, All.CollectibleIDs, nameof(collectible));

            FloorID = floor;
            BlockID = block;
            FurnishingID = furnishing;
            CollectibleID = collectible;
        }
        #endregion

        #region Queries
        /// <summary>The number of parquets actually present in this pack.</summary>
        public int Count => ModelID.None != FloorID ? 1 : 0
                          + ModelID.None != BlockID ? 1 : 0
                          + ModelID.None != FurnishingID ? 1 : 0
                          + ModelID.None != CollectibleID ? 1 : 0;

        /// <summary>
        /// Indicates whether this <see cref="ParquetModelPack"/> is empty.
        /// </summary>
        /// <value><c>true</c> if the pack contains only null references; otherwise, <c>false</c>.</value>
        public bool IsEmpty => ModelID.None == FloorID
                            && ModelID.None == BlockID
                            && ModelID.None == FurnishingID
                            && ModelID.None == CollectibleID;

        /// <summary>
        /// A <see cref="ParquetModelPack"/> is Enclosing iff:
        /// 1, It has a <see cref="BlockID"/> that is not <see cref="BlockModel.IsLiquid"/>; or,
        /// 2, It has a <see cref="FurnishingID"/> that is <see cref="FurnishingModel.IsEnclosing"/>.
        /// </summary>
        /// <returns><c>true</c>, if this <see cref="ParquetModelPack"/> is Enclosing, <c>false</c> otherwise.</returns>
        public bool IsEnclosing
            => (BlockID != ModelID.None
                && !(All.Blocks.GetOrNull<BlockModel>(BlockID)?.IsLiquid ?? true))
            || (FurnishingID != ModelID.None
                && (All.Furnishings.GetOrNull<FurnishingModel>(FurnishingID)?.IsEnclosing ?? false));

        /// <summary>
        /// A <see cref="ParquetModelPack"/> is Entry iff:
        /// 1, It is either Walkable or Enclosing but not both; and,
        /// 2, It has a <see cref="FurnishingID"/> that is <see cref="FurnishingModel.Entry"/>.
        /// </summary>
        /// <returns><c>true</c>, if this <see cref="ParquetModelPack"/> is Entry, <c>false</c> otherwise.</returns>
        internal bool IsEntry
            => FurnishingID != ModelID.None
            && (All.Furnishings.GetOrNull<FurnishingModel>(FurnishingID)?.Entry ?? EntryType.None) != EntryType.None
            // Inequality standing in for missing conditional XOR here.
            && (IsWalkable != IsEnclosing);

        /// <summary>
        /// A <see cref="ParquetModelPack"/> is considered walkable iff:
        /// 1, It has a <see cref="FloorID"/>;
        /// 2, It does not have a <see cref="BlockID"/>;
        /// 3, It does not have a <see cref="FurnishingID"/> that <see cref="FurnishingModel.IsEnclosing"/>.
        /// </summary>
        /// <returns><c>true</c>, if this <see cref="ParquetModelPack"/> is Walkable, <c>false</c> otherwise.</returns>
        internal bool IsWalkable
            => FloorID != ModelID.None
            && BlockID == ModelID.None
            && (FurnishingID == ModelID.None
                || !(All.Furnishings.GetOrNull<FurnishingModel>(FurnishingID)?.IsEnclosing ?? false));
        #endregion

        #region IEquatable Implementation
        /// <summary>
        /// Serves as a hash function for a <see cref="ParquetModelPack"/>.
        /// </summary>
        /// <returns>
        /// A hash code for this instance that is suitable for use in hashing algorithms and data structures.
        /// </returns>
        public override int GetHashCode()
            => (FloorID, BlockID, FurnishingID, CollectibleID).GetHashCode();

        /// <summary>
        /// Determines whether the specified <see cref="ParquetModelPack"/> is equal to the current <see cref="ParquetModelPack"/>.
        /// </summary>
        /// <param name="pack">The <see cref="ParquetModelPack"/> to compare with the current.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public override bool Equals<T>(T pack)
            => pack is ParquetModelPack parquetModelPack
            && FloorID == parquetModelPack.FloorID
            && BlockID == parquetModelPack.BlockID
            && FurnishingID == parquetModelPack.FurnishingID
            && CollectibleID == parquetModelPack.CollectibleID;

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="ParquetModelPack"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="ParquetModelPack"/>.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
            => obj is ParquetModelPack pack
            && Equals(pack);

        /// <summary>
        /// Determines whether a specified instance of <see cref="ParquetModelPack"/> is equal to another specified instance of <see cref="ParquetModelPack"/>.
        /// </summary>
        /// <param name="pack1">The first <see cref="ParquetModelPack"/> to compare.</param>
        /// <param name="pack2">The second <see cref="ParquetModelPack"/> to compare.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(ParquetModelPack pack1, ParquetModelPack pack2)
            => pack1?.Equals(pack2) ?? pack2?.Equals(pack1) ?? true;

        /// <summary>
        /// Determines whether a specified instance of <see cref="ParquetModelPack"/> is not equal to another specified instance of <see cref="ParquetModelPack"/>.
        /// </summary>
        /// <param name="pack1">The first <see cref="ParquetModelPack"/> to compare.</param>
        /// <param name="pack2">The second <see cref="ParquetModelPack"/> to compare.</param>
        /// <returns><c>true</c> if they are NOT equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(ParquetModelPack pack1, ParquetModelPack pack2)
            => !(pack1 == pack2);
        #endregion

        #region ITypeConverter Implementation
        /// <summary>Allows the converter to construct itself statically.</summary>
        internal static ParquetModelPack ConverterFactory { get; } = Empty;

        /// <summary>
        /// Converts the given <see cref="object"/> to a <see cref="string"/> for serialization.
        /// </summary>
        /// <param name="value">The instance to convert.</param>
        /// <param name="row">The current context and configuration.</param>
        /// <param name="memberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance serialized.</returns>
        public override string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
            => value is ParquetModelPack pack
                ? $"{pack.FloorID.ConvertToString(pack.FloorID, row, memberMapData)}{Delimiters.PackDelimiter}" +
                  $"{pack.BlockID.ConvertToString(pack.BlockID, row, memberMapData)}{Delimiters.PackDelimiter}" +
                  $"{pack.FurnishingID.ConvertToString(pack.FurnishingID, row, memberMapData)}{Delimiters.PackDelimiter}" +
                  $"{pack.CollectibleID.ConvertToString(pack.CollectibleID, row, memberMapData)}"
                : Logger.DefaultWithConvertLog(value?.ToString() ?? "null", nameof(ParquetModelPack), nameof(Empty));

        /// <summary>
        /// Converts the given <see cref="string"/> to an <see cref="object"/> as deserialization.
        /// </summary>
        /// <param name="text">The text to convert.</param>
        /// <param name="row">The current context and configuration.</param>
        /// <param name="memberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance deserialized.</returns>
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            if (string.IsNullOrEmpty(text)
                || string.Compare(nameof(Empty), text, StringComparison.OrdinalIgnoreCase) == 0)
            {
                return Empty;
            }

            var parameterText = text.Split(Delimiters.PackDelimiter);

            var parsedFloor = (ModelID)ModelID.ConverterFactory.ConvertFromString(parameterText[0], row, memberMapData);
            var parsedBlock = (ModelID)ModelID.ConverterFactory.ConvertFromString(parameterText[1], row, memberMapData);
            var parsedFurnishing = (ModelID)ModelID.ConverterFactory.ConvertFromString(parameterText[2], row, memberMapData);
            var parsedCollectible = (ModelID)ModelID.ConverterFactory.ConvertFromString(parameterText[3], row, memberMapData);

            return new ParquetModelPack(parsedFloor, parsedBlock, parsedFurnishing, parsedCollectible);
        }
        #endregion

        #region IDeeplyCloneable Implementation
        /// <summary>
        /// Creates a new instance that is a deep copy of the current instance.
        /// </summary>
        /// <returns>A new instance with the same characteristics as the current instance.</returns>
        public override ParquetModelPack DeepClone()
            => new(FloorID, BlockID, FurnishingID, CollectibleID);

        /// <summary>
        /// Creates a new instance that is a deep copy of the current instance.
        /// </summary>
        /// <returns>A new instance with the same characteristics as the current instance.</returns>
        public override T DeepClone<T>()
            => DeepClone() as T;
        #endregion

        #region Utilities
        /// <summary>
        /// Returns a <see cref="string"/> that represents the current <see cref="ParquetModelPack"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override string ToString()
            => $"[{FloorID} {BlockID} {FurnishingID} {CollectibleID}]";
        #endregion
    }
}
