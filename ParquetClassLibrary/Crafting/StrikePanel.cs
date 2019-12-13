using System;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Crafting
{
    /// <summary>
    /// Models the panels that the player must strike during item crafting.
    /// </summary>
    public class StrikePanel : IEquatable<StrikePanel>
    {
        /// <summary><c>true</c> if this panel is not used in the current crafting recipe; otherwise, <c>false</c>.</summary>
        public bool IsVoid { get; set; }

        /// <summary>Backing value for <see cref="WorkingRange"/>.</summary>
        private Range<int> _workingRange;

        /// <summary>Backing value for <see cref="IdealRange"/>.</summary>
        private Range<int> _idealRange;

        /// <summary>
        /// The range of values this panel can take on while being worked.  <see cref="Range{T}.Minimum"/> is normally 0.
        /// This range constricts that given by <c see="IdealRange"/>.
        /// </summary>
        public Range<int> WorkingRange
        {
            get => _workingRange;
            set
            {
                _workingRange = value;

                if (IdealRange.Maximum > value.Maximum)
                {
                    _idealRange = new Range<int>(_idealRange.Minimum, value.Maximum);
                }
                if (IdealRange.Minimum < value.Minimum)
                {
                    _idealRange = new Range<int>(value.Minimum, _idealRange.Maximum);
                }
            }
        }

        /// <summary>
        /// The range of values this panel targets for a completed craft.
        /// This range expands that given by <c see="WorkingRange"/> if necessary.
        /// </summary>
        public Range<int> IdealRange
        {
            get => _idealRange;
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

                _idealRange = value;
            }
        }

        #region IEquatable Implementation
        /// <summary>
        /// Serves as a hash function for a <see cref="StrikePanel"/>.
        /// </summary>
        /// <returns>
        /// A hash code for this instance that is suitable for use in hashing algorithms and data structures.
        /// </returns>
        public override int GetHashCode()
            => (IsVoid, _workingRange, _idealRange).GetHashCode();

        /// <summary>
        /// Determines whether the specified <see cref="StrikePanel"/> is equal to the current <see cref="StrikePanel"/>.
        /// </summary>
        /// <param name="in_strikePanel">The <see cref="StrikePanel"/> to compare with the current.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public bool Equals(StrikePanel in_strikePanel)
        {
            Precondition.IsNotNull(in_strikePanel, nameof(in_strikePanel));

            return IsVoid == in_strikePanel.IsVoid
                && _workingRange == in_strikePanel._workingRange
                && _idealRange == in_strikePanel._idealRange;
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
        /// <param name="in_strikePanel1">The first <see cref="StrikePanel"/> to compare.</param>
        /// <param name="in_strikePanel2">The second <see cref="StrikePanel"/> to compare.</param>
        /// <returns><c>true</c> if they are equal; otherwise, <c>false</c>.</returns>
        public static bool operator ==(StrikePanel in_strikePanel1, StrikePanel in_strikePanel2)
        {
            Precondition.IsNotNull(in_strikePanel1, nameof(in_strikePanel1));
            Precondition.IsNotNull(in_strikePanel2, nameof(in_strikePanel2));

            return in_strikePanel1.IsVoid == in_strikePanel2.IsVoid
                && in_strikePanel1._workingRange == in_strikePanel2._workingRange
                && in_strikePanel1._idealRange == in_strikePanel2._idealRange;
        }

        /// <summary>
        /// Determines whether a specified instance of <see cref="StrikePanel"/> is not equal to another specified instance of <see cref="StrikePanel"/>.
        /// </summary>
        /// <param name="in_strikePanel1">The first <see cref="StrikePanel"/> to compare.</param>
        /// <param name="in_strikePanel2">The second <see cref="StrikePanel"/> to compare.</param>
        /// <returns><c>true</c> if they are NOT equal; otherwise, <c>false</c>.</returns>
        public static bool operator !=(StrikePanel in_strikePanel1, StrikePanel in_strikePanel2)
        {
            Precondition.IsNotNull(in_strikePanel1, nameof(in_strikePanel1));
            Precondition.IsNotNull(in_strikePanel2, nameof(in_strikePanel2));

            return in_strikePanel1.IsVoid != in_strikePanel2.IsVoid
                || in_strikePanel1._workingRange != in_strikePanel2._workingRange
                || in_strikePanel1._idealRange != in_strikePanel2._idealRange;
        }
        #endregion

        #region Utility Methods
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
}
