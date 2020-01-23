using System;
using CsvHelper.Configuration;
using ParquetClassLibrary.Utilities;
using Range = ParquetClassLibrary.Utilities.Range<int>;

namespace ParquetClassLibrary.Crafts
{
    /// <summary>
    /// Models the panels that the player must strike during item crafting.
    /// </summary>
    public class StrikePanel : IEquatable<StrikePanel>
    {
        #region Characteristics
        /// <summary><c>true</c> if this panel is not used in the current crafting recipe; otherwise, <c>false</c>.</summary>
        public bool IsVoid { get; set; }

        /// <summary>Backing value for <see cref="WorkingRange"/>.</summary>
        private Range<int> workingRange;

        /// <summary>Backing value for <see cref="IdealRange"/>.</summary>
        private Range<int> idealRange;

        /// <summary>
        /// The range of values this panel can take on while being worked.  <see cref="Range{int}.Minimum"/> is normally 0.
        /// This range constricts that given by <c see="IdealRange"/>.
        /// </summary>
        public Range<int> WorkingRange
        {
            get => workingRange;
            set
            {
                workingRange = value;

                if (IdealRange.Maximum > value.Maximum)
                {
                    idealRange = new Range<int>(idealRange.Minimum, value.Maximum);
                }
                if (IdealRange.Minimum < value.Minimum)
                {
                    idealRange = new Range<int>(value.Minimum, idealRange.Maximum);
                }
            }
        }

        /// <summary>
        /// The range of values this panel targets for a completed craft.
        /// This range expands that given by <c see="WorkingRange"/> if necessary.
        /// </summary>
        public Range<int> IdealRange
        {
            get => idealRange;
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

                idealRange = value;
            }
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
            => (IsVoid, workingRange, idealRange).GetHashCode();

        /// <summary>
        /// Determines whether the specified <see cref="StrikePanel"/> is equal to the current <see cref="StrikePanel"/>.
        /// </summary>
        /// <param name="inStrikePanel">The <see cref="StrikePanel"/> to compare with the current.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public bool Equals(StrikePanel inStrikePanel)
        {
            Precondition.IsNotNull(inStrikePanel, nameof(inStrikePanel));

            return IsVoid == inStrikePanel.IsVoid
                && workingRange == inStrikePanel.workingRange
                && idealRange == inStrikePanel.idealRange;
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

            return inStrikePanel1.IsVoid == inStrikePanel2.IsVoid
                && inStrikePanel1.workingRange == inStrikePanel2.workingRange
                && inStrikePanel1.idealRange == inStrikePanel2.idealRange;
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

            return inStrikePanel1.IsVoid != inStrikePanel2.IsVoid
                || inStrikePanel1.workingRange != inStrikePanel2.workingRange
                || inStrikePanel1.idealRange != inStrikePanel2.idealRange;
        }
        #endregion

        #region Serialization
        /// <summary>
        /// Maps the values in a <see cref="StrikePanelClassMap"/> to records that CSVHelper recognizes.
        /// </summary>
        internal sealed class StrikePanelClassMap : ClassMap<StrikePanel>
        {
            /// <summary>
            /// Initializes a new instance of the <see cref="StrikePanelClassMap"/> class.
            /// </summary>
            public StrikePanelClassMap()
            {
                Map(m => m.IsVoid);
                References<Range.RangeClassMap<int>>(m => m.WorkingRange);
                References<Range.RangeClassMap<int>>(m => m.IdealRange);
            }
        }
        #endregion

        #region Utilities
        /// <summary>
        /// Returns a <see langword="string"/> that represents the current <see cref="StrikePanel"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override string ToString()
            => IsVoid
                ? "[Void - Void]"
                : WorkingRange.ToString();
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
