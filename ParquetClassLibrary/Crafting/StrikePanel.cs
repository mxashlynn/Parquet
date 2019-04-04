using System;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Crafting
{
    /// <summary>
    /// Models the panels that the player must strike during item crafting.
    /// </summary>
    public struct StrikePanel
    {
        /// <summary><c>true</c> if this panel is not used in the current crafting recipe; otherwise, <c>false</c>.</summary>
        public bool IsVoid { get; set; }

        /// <summary>Backing value for <see cref="WorkingRange"/>.</summary>
        private Range<int> _workingRange;

        /// <summary>
        /// The range of values this panel can take on while being worked.  <see cref="Range{T}.Minimum"/> is normally 0.
        /// This range constricts that given by <c see="IdealRange"/>.
        /// </summary>
        public Range<int> WorkingRange
        {
            get
            {
                return _workingRange;
            }
            set
            {
                _workingRange = value;

                if (IdealRange.Maximum > value.Maximum)
                {
                    _idealRange.Maximum = value.Maximum;
                }
                if (IdealRange.Minimum < value.Minimum)
                {
                    _idealRange.Minimum = value.Minimum;
                }
            }
        }

        /// <summary>Backing value for <see cref="IdealRange"/>.</summary>
        private Range<int> _idealRange;

        /// <summary>
        /// The range of values this panel targets for a completed craft.
        /// The values must fall within the range of <c see="WorkingRange"/>.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when the either the <see cref="Range{T}.Maximum"/> or <see cref="Range{T}.Minimum"/> are beyond
        /// the range specified in <c see="WorkingRange"/>.
        /// </exception>
        public Range<int> IdealRange
        {
            get
            {
                return _idealRange;
            }
            set
            {
                if (value.Maximum > WorkingRange.Maximum ||
                    value.Minimum < WorkingRange.Minimum)
                {
                    throw new ArgumentOutOfRangeException(nameof(IdealRange));
                }

                _idealRange = value;
            }
        }
    }
}
