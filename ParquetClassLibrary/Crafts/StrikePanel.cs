using System;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using ParquetClassLibrary.Utilities;
using Range = ParquetClassLibrary.Utilities.Range<int>;

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

        /// <summary>Separates the two <see cref="Range"/>s when serializing.</summary>
        private const string rangeDelimiter = "|";

        /// <summary>Separates values within a <see cref="Range"/> when serializing.</summary>
        private const string intDelimiter = "-";
        #endregion

        #region Characteristics
        /// <summary>Backing value for <see cref="WorkingRange"/>.</summary>
        private Range<int> workingRangeBackingStruct;

        /// <summary>Backing value for <see cref="IdealRange"/>.</summary>
        private Range<int> idealRangeBackingStruct;

        /// <summary>
        /// The range of values this panel can take on while being worked.  <see cref="Range{int}.Minimum"/> is normally 0.
        /// This range constricts that given by <c see="IdealRange"/>.
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
        /// This range expands that given by <c see="WorkingRange"/> if necessary.
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
        /// <param name="inWorkingRange"></param>
        /// <param name="inIdealRange"></param>
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
        {
            Precondition.IsNotNull(inStrikePanel, nameof(inStrikePanel));

            return workingRangeBackingStruct == inStrikePanel.workingRangeBackingStruct
                && idealRangeBackingStruct == inStrikePanel.idealRangeBackingStruct;
        }

        /// <summary>
        /// Determines whether the specified <see cref="object"/> is equal to the current <see cref="StrikePanel"/>.
        /// </summary>
        /// <param name="obj">The <see cref="object"/> to compare with the current <see cref="StrikePanel"/>.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
            => obj is StrikePanel strikePanel && Equals(strikePanel);

        /// <summary>
        /// Determines whether a specified instance of <see cref="StrikePanel"/> is equal to another specified instance of <see cref="StrikePanel"/>.
        /// </summary>
        /// <param name="inStrikePanel1">The first <see cref="StrikePanel"/> to compare.</param>
        /// <param name="inStrikePanel2">The second <see cref="StrikePanel"/> to compare.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(StrikePanel inStrikePanel1, StrikePanel inStrikePanel2)
        {
            Precondition.IsNotNull(inStrikePanel1, nameof(inStrikePanel1));
            Precondition.IsNotNull(inStrikePanel2, nameof(inStrikePanel2));

            return inStrikePanel1.workingRangeBackingStruct == inStrikePanel2.workingRangeBackingStruct
                && inStrikePanel1.idealRangeBackingStruct == inStrikePanel2.idealRangeBackingStruct;
        }

        /// <summary>
        /// Determines whether a specified instance of <see cref="StrikePanel"/> is not equal to another specified instance of <see cref="StrikePanel"/>.
        /// </summary>
        /// <param name="inStrikePanel1">The first <see cref="StrikePanel"/> to compare.</param>
        /// <param name="inStrikePanel2">The second <see cref="StrikePanel"/> to compare.</param>
        /// <returns><c>true</c> if they are NOT equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(StrikePanel inStrikePanel1, StrikePanel inStrikePanel2)
        {
            Precondition.IsNotNull(inStrikePanel1, nameof(inStrikePanel1));
            Precondition.IsNotNull(inStrikePanel2, nameof(inStrikePanel2));

            return inStrikePanel1.workingRangeBackingStruct != inStrikePanel2.workingRangeBackingStruct
                || inStrikePanel1.idealRangeBackingStruct != inStrikePanel2.idealRangeBackingStruct;
        }
        #endregion

        #region ITypeConverter Implementation
        /// <summary>Allows the converter to construct itself statically.</summary>
        internal static readonly StrikePanel ConverterFactory =
            new NotImplementedException();

        /// <summary>
        /// Converts the given <see langword="string"/> to a <see cref="StrikePanel"/>.
        /// </summary>
        /// <param name="inText">The <see langword="string"/> to convert to an object.</param>
        /// <param name="inRow">The <see cref="IReaderRow"/> for the current record.</param>
        /// <param name="inMemberMapData">The <see cref="MemberMapData"/> for the member being created.</param>
        /// <returns>The <see cref="StrikePanel"/> created from the <see langword="string"/>.</returns>
        public object ConvertFromString(string inText, IReaderRow inRow, MemberMapData inMemberMapData)
        {
            Precondition.IsNotNull(inMemberMapData, nameof(inMemberMapData));

            if (string.IsNullOrEmpty(inText)
                || string.Compare(nameof(Unused), inText, StringComparison.InvariantCultureIgnoreCase) == 0)
            {
                return Unused;
            }

            try
            {
                var numberStyle = inMemberMapData.TypeConverterOptions.NumberStyle ?? NumberStyles.Integer;

                var panelSplitText = inText.Split(rangeDelimiter);

                var workingSplitText = panelSplitText[0].Split(intDelimiter);
                var workingMinText = workingSplitText[0];
                var workingMaxText = workingSplitText[1];

                var idealSplitText = panelSplitText[1].Split(intDelimiter);
                var idealMinText = idealSplitText[0];
                var idealMaxText = idealSplitText[1];

                if (int.TryParse(workingMinText, numberStyle, inMemberMapData.TypeConverterOptions.CultureInfo, out var workingMin)
                    && int.TryParse(workingMaxText, numberStyle, inMemberMapData.TypeConverterOptions.CultureInfo, out var workingMax)
                    && int.TryParse(idealMinText, numberStyle, inMemberMapData.TypeConverterOptions.CultureInfo, out var idealMin)
                    && int.TryParse(idealMaxText, numberStyle, inMemberMapData.TypeConverterOptions.CultureInfo, out var idealMax))
                {
                    return new StrikePanel(new Range<int>(workingMin, workingMax), new Range<int>(idealMin, idealMax));
                }
                else
                {
                    throw new FormatException($"Could not parse {nameof(StrikePanel)} '{inText}' into {nameof(Range<int>)}s.");
                }
            }
            catch (Exception e)
            {
                throw new FormatException($"Could not parse {nameof(StrikePanel)} '{inText}': {e}", e);
            }
        }

        /// <summary>
        /// Converts the given <see cref="StrikePanel"/> to a record column.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="inRow">The <see cref="IReaderRow"/> for the current record.</param>
        /// <param name="inMemberMapData">The <see cref="MemberMapData"/> for the member being serialized.</param>
        /// <returns>The <see cref="StrikePanel"/> as a CSV record.</returns>
        public string ConvertToString(object inValue, IWriterRow inRow, MemberMapData inMemberMapData)
            => inValue is StrikePanel panel
                ? null == panel || panel == Unused
                    ? nameof(Unused)
                    : $"{panel.WorkingRange.Minimum}{intDelimiter}{panel.WorkingRange.Maximum}{rangeDelimiter}{panel.IdealRange.Minimum}{intDelimiter}{panel.IdealRange.Maximum}"
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
                : $"{WorkingRange.ToString()}{rangeDelimiter}{IdealRange.ToString()}";
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
