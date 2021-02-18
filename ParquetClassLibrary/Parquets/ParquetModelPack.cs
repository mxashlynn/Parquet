using System;
using CsvHelper;
using CsvHelper.Configuration;

namespace Parquet.Parquets
{
    /// <summary>
    /// Simple container for collocated <see cref="ParquetModel"/>s, one of each subtype.
    /// Instances of this class are mutable during play, although the <see cref="ParquetModel"/>s they contain are not.
    /// </summary>
    public sealed class ParquetModelPack : Pack<ParquetModel>, IParquetModelPack
    {
        #region Class Defaults
        /// <summary>Canonical null <see cref="ParquetModelPack"/>, representing an arbitrary empty pack.</summary>
        public static ParquetModelPack Empty
            => new ParquetModelPack(ModelID.None, ModelID.None, ModelID.None, ModelID.None);
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
        public ParquetModelPack() :
            this(ModelID.None, ModelID.None, ModelID.None, ModelID.None)
        { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ParquetModelPack"/> class.
        /// </summary>
        /// <param name="inFloor">The floor-layer parquet.</param>
        /// <param name="inBlock">The block-layer parquet.</param>
        /// <param name="inFurnishing">The furnishing-layer parquet.</param>
        /// <param name="inCollectible">The collectible-layer parquet.</param>
        public ParquetModelPack(ModelID inFloor, ModelID inBlock, ModelID inFurnishing, ModelID inCollectible)
        {
            Precondition.IsInRange(inFloor, All.FloorIDs, nameof(inFloor));
            Precondition.IsInRange(inBlock, All.BlockIDs, nameof(inBlock));
            Precondition.IsInRange(inFurnishing, All.FurnishingIDs, nameof(inFurnishing));
            Precondition.IsInRange(inCollectible, All.CollectibleIDs, nameof(inCollectible));

            FloorID = inFloor;
            BlockID = inBlock;
            FurnishingID = inFurnishing;
            CollectibleID = inCollectible;
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
        /// <param name="inStack">The <see cref="ParquetModelPack"/> to compare with the current.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public override bool Equals<T>(T inPack)
            => inPack is ParquetModelPack parquetModelPack
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
        /// <param name="inStack1">The first <see cref="ParquetModelPack"/> to compare.</param>
        /// <param name="inStack2">The second <see cref="ParquetModelPack"/> to compare.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(ParquetModelPack inStack1, ParquetModelPack inStack2)
            => inStack1?.Equals(inStack2) ?? inStack2?.Equals(inStack1) ?? true;

        /// <summary>
        /// Determines whether a specified instance of <see cref="ParquetModelPack"/> is not equal to another specified instance of <see cref="ParquetModelPack"/>.
        /// </summary>
        /// <param name="inStack1">The first <see cref="ParquetModelPack"/> to compare.</param>
        /// <param name="inStack2">The second <see cref="ParquetModelPack"/> to compare.</param>
        /// <returns><c>true</c> if they are NOT equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(ParquetModelPack inStack1, ParquetModelPack inStack2)
            => !(inStack1 == inStack2);
        #endregion

        #region ITypeConverter
        /// <summary>Allows the converter to construct itself statically.</summary>
        internal static ParquetModelPack ConverterFactory { get; } = Empty;

        /// <summary>
        /// Converts the given <see cref="object"/> to a <see cref="string"/> for serialization.
        /// </summary>
        /// <param name="inValue">The instance to convert.</param>
        /// <param name="inRow">The current context and configuration.</param>
        /// <param name="inMemberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance serialized.</returns>
        public override string ConvertToString(object inValue, IWriterRow inRow, MemberMapData inMemberMapData)
            => inValue is ParquetModelPack pack
                ? $"{pack.FloorID.ConvertToString(pack.FloorID, inRow, inMemberMapData)}{Delimiters.PackDelimiter}" +
                  $"{pack.BlockID.ConvertToString(pack.BlockID, inRow, inMemberMapData)}{Delimiters.PackDelimiter}" +
                  $"{pack.FurnishingID.ConvertToString(pack.FurnishingID, inRow, inMemberMapData)}{Delimiters.PackDelimiter}" +
                  $"{pack.CollectibleID.ConvertToString(pack.CollectibleID, inRow, inMemberMapData)}"
                : Logger.DefaultWithConvertLog(inValue?.ToString() ?? "null", nameof(ParquetModelPack), nameof(Empty));

        /// <summary>
        /// Converts the given <see cref="string"/> to an <see cref="object"/> as deserialization.
        /// </summary>
        /// <param name="inText">The text to convert.</param>
        /// <param name="inRow">The current context and configuration.</param>
        /// <param name="inMemberMapData">Mapping info for a member to a CSV field or property.</param>
        /// <returns>The given instance deserialized.</returns>
        public override object ConvertFromString(string inText, IReaderRow inRow, MemberMapData inMemberMapData)
        {
            if (string.IsNullOrEmpty(inText)
                || string.Compare(nameof(Empty), inText, StringComparison.OrdinalIgnoreCase) == 0)
            {
                return Empty;
            }

            var parameterText = inText.Split(Delimiters.PackDelimiter);

            var parsedFloor = (ModelID)ModelID.ConverterFactory.ConvertFromString(parameterText[0], inRow, inMemberMapData);
            var parsedBlock = (ModelID)ModelID.ConverterFactory.ConvertFromString(parameterText[1], inRow, inMemberMapData);
            var parsedFurnishing = (ModelID)ModelID.ConverterFactory.ConvertFromString(parameterText[2], inRow, inMemberMapData);
            var parsedCollectible = (ModelID)ModelID.ConverterFactory.ConvertFromString(parameterText[3], inRow, inMemberMapData);

            return new ParquetModelPack(parsedFloor, parsedBlock, parsedFurnishing, parsedCollectible);
        }
        #endregion

        #region IDeeplyCloneable Interface
        /// <summary>
        /// Creates a new instance that is a deep copy of the current instance.
        /// </summary>
        /// <returns>A new instance with the same characteristics as the current instance.</returns>
        public override ParquetModelPack DeepClone()
            => new ParquetModelPack(FloorID, BlockID, FurnishingID, CollectibleID);

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
