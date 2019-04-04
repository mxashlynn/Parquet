using System;
using ParquetClassLibrary.Utilities;

namespace ParquetClassLibrary.Crafting
{
    /// <summary>
    /// Models the panels that the player must strike during item crafting.
    /// </summary>
    public struct StrikePanel
    {
        /// <summary>
        /// The range of values this panel can take on while being worked.  <see cref="Range{T}.Minimum"/> is normally 0.
        /// </summary>
        public Range<int> WorkingRange { get; set; }

        /// <summary>Backing value for <see cref="IdealRange"/>.</summary>
        private Range<int> _iealRange;

        /// <summary>
        /// The range of values this panel targets for a completed craft.
        /// If the values must fall within the range of <c see="WorkingRange"/>.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException">
        /// Thrown when the either the <see cref="Range{T}.Maximum"/> or <see cref="Range{T}.Minimum"/> are beyond
        /// the range specified in <c see="WorkingRange"/>.
        /// </exception>
        public Range<int> IdealRange
        {
            get
            {
                return _iealRange;
            }
            set
            {
                if (value.Maximum > WorkingRange.Maximum ||
                    value.Minimum < WorkingRange.Minimum)
                {
                    throw new ArgumentOutOfRangeException(nameof(IdealRange));
                }

                _iealRange = value;
            }
        }
    }
}
