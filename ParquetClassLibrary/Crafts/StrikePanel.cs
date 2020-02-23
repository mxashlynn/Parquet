using System;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Crafts
{
    /// <summary>
    /// Models the panels that the player must strike during item crafting.
    /// </summary>
    public class StrikePanel : IEquatable<StrikePanel>, ITypeConverter
    {
        #region Class Defaults
        /// <summary>Part of the definition for an <see cref="Unused"/> panel.</summary>
        private static readonly Range<int> defaultWorkingRange = new Range<int>(0, 3);

        /// <summary>Part of the definition for an <see cref="Unused"/> panel.</summary>
        private static readonly Range<int> defaultIdealRange = new Range<int>(0, 3);

        /// <summary>Indicates an space in a <see cref="StrikePanelGrid"/>.</summary>
        public static readonly StrikePanel Unused = new StrikePanel(defaultWorkingRange, defaultIdealRange);
        #endregion

        #region Characteristics
        /// <summary>Backing value for <see cref="WorkingRange"/>.</summary>
        private Range<int> workingRangeBackingStruct;

        /// <summary>Backing value for <see cref="IdealRange"/>.</summary>
        private Range<int> idealRangeBackingStruct;

        /// <summary>
        /// The range of values this panel can take on while being worked.  <see cref="Range{int}.Minimum"/> is normally 0.
        /// This range constricts that given by <see cref="IdealRange"/>.
        /// </summary>
        public Range<int> WorkingRange
        {
            get => workingRangeBackingStruct;
            set
            {
                workingRangeBackingStruct = value;

                if (IdealRange.Maximum > value.Maximum)
                {
                    idealRangeBackingStruct = new Range<int>(idealRangeBackingStruct.Minimum, value.Maximum);
                }
                if (IdealRange.Minimum < value.Minimum)
                {
                    idealRangeBackingStruct = new Range<int>(value.Minimum, idealRangeBackingStruct.Maximum);
                }
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
                if (value.Maximum > WorkingRange.Maximum)
                {
                    value = new Range<int>(value.Minimum, WorkingRange.Maximum);
                }
                if (value.Minimum < WorkingRange.Minimum)
                {
                    value = new Range<int>(WorkingRange.Minimum, value.Maximum);
                }

                idealRangeBackingStruct = value;
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
            // Note the use of the backing struct to avoid preinitialized range-checking.
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
        public override int GetHashCode()
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
        internal static StrikePanel ConverterFactory { get; } = new StrikePanel();

        /// <summary>
        /// Converts the given <see langword="string"/> to a <see cref="StrikePanel"/>.
        /// </summary>
        /// <param name="inText">The <see langword="string"/> to convert to an object.</param>
        /// <param name="inRow">The <see cref="IReaderRow"/> for the current record.</param>
        /// <param name="inMemberMapData">The <see cref="MemberMapData"/> for the member being created.</param>
        /// <returns>The <see cref="StrikePanel"/> created from the <see langword="string"/>.</returns>
        public object ConvertFromString(string inText, IReaderRow inRow, MemberMapData inMemberMapData)
        {
            if (string.IsNullOrEmpty(inText)
                || string.Compare(nameof(Unused), inText, StringComparison.InvariantCultureIgnoreCase) == 0)
            {
                return Unused;
            }

            try
            {
                var panelSplitText = inText.Split(Rules.Delimiters.InternalDelimiter);
                var workingRangeDeserialized = (Range<int>)Range<int>.ConverterFactory.ConvertFromString(panelSplitText[0], inRow, inMemberMapData);
                var idealRangeDeserialized = (Range<int>)Range<int>.ConverterFactory.ConvertFromString(panelSplitText[1], inRow, inMemberMapData);

                return new StrikePanel(workingRangeDeserialized, idealRangeDeserialized);
            }
            catch (Exception e)
            {
                throw new FormatException($"Could not parse {nameof(StrikePanel)} '{inText}': {e}", e);
            }
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
                ? null == panel
                || Unused == panel
                    ? nameof(Unused)
                    : $"{panel.WorkingRange.Minimum}{Rules.Delimiters.ElementDelimiter}" +
                      $"{panel.WorkingRange.Maximum}{Rules.Delimiters.InternalDelimiter}" +
                      $"{panel.IdealRange.Minimum}{Rules.Delimiters.ElementDelimiter}" +
                      $"{panel.IdealRange.Maximum}"
                : throw new ArgumentException($"Could not convert {inValue} to {nameof(StrikePanel)}.");
        #endregion

        #region Utilities
        /// <summary>
        /// Returns a <see langword="string"/> that represents the current <see cref="StrikePanel"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override string ToString()
            => this == Unused
                ? nameof(Unused)
                : $"{WorkingRange.ToString()}{Rules.Delimiters.ElementDelimiter}{IdealRange.ToString()}";
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
        /// <param name="inPosition">The position to validate.</param>
        /// <returns><c>true</c>, if the position is valid, <c>false</c> otherwise.</returns>
        public static bool IsValidPosition(this StrikePanel[,] inStrikePanels, Vector2D inPosition)
        {
            Precondition.IsNotNull(inStrikePanels, nameof(inStrikePanels));

            return inPosition.X > -1
                && inPosition.Y > -1
                && inPosition.X < inStrikePanels.GetLength(1)
                && inPosition.Y < inStrikePanels.GetLength(0);
        }
    }
}
