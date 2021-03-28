using System;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace Parquet.Crafts
{
    /// <summary>
    /// Models the panels that the player must strike during item crafting.
    /// </summary>
    /// <remarks>
    /// If a <see cref="StrikePanel"/> is stored in a <see cref="System.Collections.Generic.HashSet{T}"/>,
    /// <see cref="System.Collections.Hashtable"/>, or used as a key in a
    /// <see cref="System.Collections.Generic.Dictionary{K,V}"/> it must not be mutated.
    /// It is safe to mutate it again once it is removed.
    /// </remarks>
    public sealed class StrikePanel : IEquatable<StrikePanel>, ITypeConverter, IDeeplyCloneable<StrikePanel>
    {
        #region Class Defaults
        /// <summary>Part of the definition for an <see cref="Unused"/> panel.</summary>
        private static readonly Range<int> defaultWorkingRange = new(0, 3);

        /// <summary>Part of the definition for an <see cref="Unused"/> panel.</summary>
        private static readonly Range<int> defaultIdealRange = new(0, 3);

        /// <summary>Indicates an open space in a <see cref="StrikePanelGrid"/>.</summary>
        public static readonly StrikePanel Unused = new(defaultWorkingRange, defaultIdealRange);
        #endregion

        #region Characteristics
        /// <summary>Backing field for <see cref="WorkingRange"/>.</summary>
        private Range<int> workingRangeBackingStruct;

        /// <summary>Backing field for <see cref="IdealRange"/>.</summary>
        private Range<int> idealRangeBackingStruct;

        /// <summary>
        /// The range of values this panel can take on while being worked.  <see cref="Range{T}.Minimum"/> is normally 0.
        /// This range constricts that given by <see cref="IdealRange"/>.
        /// </summary>
        public Range<int> WorkingRange
        {
            get => workingRangeBackingStruct;
            set
            {
                workingRangeBackingStruct = value;
                NormalizeRanges();
            }
        }

        /// <summary>
        /// The range of values this panel targets for a completed craft.
        /// This range expands that given by <see cref="WorkingRange"/> if necessary.
        /// </summary>
        public Range<int> IdealRange
        {
            get => idealRangeBackingStruct;
            set
            {
                idealRangeBackingStruct = value;
                NormalizeRanges();
            }
        }

        /// <summary>
        /// Ensures that <see cref="IdealRange"/> always falls within <see cref="WorkingRange"/>.
        /// </summary>
        private void NormalizeRanges()
        {
            // NOTE that these two checks should not be made from within editing tools.
            if (LibraryState.IsPlayMode)
            {
                if (workingRangeBackingStruct.Maximum < idealRangeBackingStruct.Maximum)
                {
                    idealRangeBackingStruct = new Range<int>(idealRangeBackingStruct.Minimum,
                                                             workingRangeBackingStruct.Maximum);
                }
                if (workingRangeBackingStruct.Minimum > idealRangeBackingStruct.Minimum)
                {
                    idealRangeBackingStruct = new Range<int>(workingRangeBackingStruct.Minimum,
                                                             idealRangeBackingStruct.Maximum);
                }
            }
        }
        #endregion

        #region Initialization
        /// <summary>
        /// Initializes a new instance of the <see cref="StrikePanel"/> class with default values.
        /// </summary>
        public StrikePanel()
            : this(defaultWorkingRange, defaultIdealRange) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="StrikePanel"/> class.
        /// </summary>
        /// <param name="inWorkingRange">The range of values this panel can take on while being worked.</param>
        /// <param name="inIdealRange">The range of values this panel targets for a completed craft.</param>
        public StrikePanel(Range<int> inWorkingRange, Range<int> inIdealRange)
        {
            // NOTE the use of the backing struct to avoid preinitialized range-checking.
            workingRangeBackingStruct = inWorkingRange;
            IdealRange = inIdealRange;
        }
        #endregion

        #region IEquatable Implementation
        /// <summary>
        /// Serves as a hash function for a <see cref="StrikePanel"/>.
        /// </summary>
        /// <returns>
        /// A hash code for this instance that is suitable for use in hashing algorithms and data structures.
        /// </returns>
        /// <remarks>
        /// If a <see cref="StrikePanel"/> is stored in a <see cref="System.Collections.Generic.HashSet{T}"/>,
        /// <see cref="System.Collections.Hashtable"/>, or used as a key in a
        /// <see cref="System.Collections.Generic.Dictionary{K,V}"/> it must not be mutated.  It is safe to
        /// mutate it again once it is removed from all such collections.
        /// </remarks>
        public override int GetHashCode()
            // NOTE: This implementation is a potential source of error.  Because this hash code is derived from
            // mutable data, it is unstable.  Until a better way of generating the hash code can be found,
            // do note store StrikePanels in HastSets, HashTables, or use them as keys in Dictionaries. 
            => (workingRangeBackingStruct, idealRangeBackingStruct).GetHashCode();

        /// <summary>
        /// Determines whether the specified <see cref="StrikePanel"/> is equal to the current <see cref="StrikePanel"/>.
        /// </summary>
        /// <param name="inStrikePanel">The <see cref="StrikePanel"/> to compare with the current.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public bool Equals(StrikePanel inStrikePanel)
            => workingRangeBackingStruct == inStrikePanel?.workingRangeBackingStruct
            && idealRangeBackingStruct == inStrikePanel.idealRangeBackingStruct;

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="StrikePanel"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="StrikePanel"/>.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
            => obj is StrikePanel strikePanel
            && Equals(strikePanel);

        /// <summary>
        /// Determines whether a specified instance of <see cref="StrikePanel"/> is equal to another specified instance of <see cref="StrikePanel"/>.
        /// </summary>
        /// <param name="inStrikePanel1">The first <see cref="StrikePanel"/> to compare.</param>
        /// <param name="inStrikePanel2">The second <see cref="StrikePanel"/> to compare.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(StrikePanel inStrikePanel1, StrikePanel inStrikePanel2)
            => inStrikePanel1?.Equals(inStrikePanel2) ?? inStrikePanel2?.Equals(inStrikePanel1) ?? true;

        /// <summary>
        /// Determines whether a specified instance of <see cref="StrikePanel"/> is not equal to another specified instance of <see cref="StrikePanel"/>.
        /// </summary>
        /// <param name="inStrikePanel1">The first <see cref="StrikePanel"/> to compare.</param>
        /// <param name="inStrikePanel2">The second <see cref="StrikePanel"/> to compare.</param>
        /// <returns><c>true</c> if they are NOT equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(StrikePanel inStrikePanel1, StrikePanel inStrikePanel2)
            => !(inStrikePanel1 == inStrikePanel2);
        #endregion

        #region ITypeConverter Implementation
        /// <summary>Allows the converter to construct itself statically.</summary>
        internal static StrikePanel ConverterFactory { get; } = Unused;

        /// <summary>
        /// Converts the given <see cref="string"/> to a <see cref="StrikePanel"/>.
        /// </summary>
        /// <param name="inText">The <see cref="string"/> to convert to an object.</param>
        /// <param name="inRow">The <see cref="IReaderRow"/> for the current record.</param>
        /// <param name="inMemberMapData">The <see cref="MemberMapData"/> for the member being created.</param>
        /// <returns>The <see cref="StrikePanel"/> created from the <see cref="string"/>.</returns>
        public object ConvertFromString(string inText, IReaderRow inRow, MemberMapData inMemberMapData)
        {
            if (string.IsNullOrEmpty(inText)
                || string.Compare(nameof(Unused), inText, StringComparison.OrdinalIgnoreCase) == 0)
            {
                return Unused;
            }

            var panelSplitText = inText.Split(Delimiters.InternalDelimiter);
            var workingRangeDeserialized = (Range<int>)Range<int>.ConverterFactory.ConvertFromString(panelSplitText[0], inRow, inMemberMapData);
            var idealRangeDeserialized = (Range<int>)Range<int>.ConverterFactory.ConvertFromString(panelSplitText[1], inRow, inMemberMapData);

            return new StrikePanel(workingRangeDeserialized, idealRangeDeserialized);
        }

        /// <summary>
        /// Converts the given <see cref="StrikePanel"/> to a record column.
        /// </summary>
        /// <param name="inValue">The instance to convert.</param>
        /// <param name="inRow">The <see cref="IReaderRow"/> for the current record.</param>
        /// <param name="inMemberMapData">The <see cref="MemberMapData"/> for the member being serialized.</param>
        /// <returns>The <see cref="StrikePanel"/> as a CSV record.</returns>
        public string ConvertToString(object inValue, IWriterRow inRow, MemberMapData inMemberMapData)
            => inValue is StrikePanel panel
                ? Unused == panel
                    ? nameof(Unused)
                    : $"{panel.WorkingRange.Minimum}{Delimiters.ElementDelimiter}" +
                      $"{panel.WorkingRange.Maximum}{Delimiters.InternalDelimiter}" +
                      $"{panel.IdealRange.Minimum}{Delimiters.ElementDelimiter}" +
                      $"{panel.IdealRange.Maximum}"
                : Logger.DefaultWithConvertLog(inValue?.ToString() ?? "null", nameof(StrikePanel), nameof(Unused));
        #endregion

        #region IDeeplyCloneable Implementation
        /// <summary>
        /// Creates a new instance that is a deep copy of the current instance.
        /// </summary>
        /// <returns>A new instance with the same characteristics as the current instance.</returns>
        public StrikePanel DeepClone()
            => new(workingRangeBackingStruct, idealRangeBackingStruct);
        #endregion

        #region Utilities
        /// <summary>
        /// Returns a <see cref="string"/> that represents the current <see cref="StrikePanel"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override string ToString()
            => this == Unused
                ? nameof(Unused)
                : WorkingRange.ToString() + Delimiters.ElementDelimiter + IdealRange.ToString();
        #endregion
    }

    /// <summary>
    /// Provides extension methods useful when dealing with 2D arrays of <see cref="StrikePanel"/>s.
    /// </summary>
    public static class StrikePanelArrayExtensions
    {
        /// <summary>
        /// Determines if the given position corresponds to a point within the current array.
        /// </summary>
        /// <param name="inStrikePanels">The <see cref="StrikePanel"/> to check against.</param>
        /// <param name="inPosition">The position to validate.</param>
        /// <returns><c>true</c>, if the position is valid, <c>false</c> otherwise.</returns>
        public static bool IsValidPosition(this StrikePanel[,] inStrikePanels, Point2D inPosition)
            => inStrikePanels is not null
                && inPosition.X > -1
                && inPosition.Y > -1
                && inPosition.X < inStrikePanels.GetLength(1)
                && inPosition.Y < inStrikePanels.GetLength(0);
    }
}
