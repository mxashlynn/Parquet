using System;

namespace Parquet
{
    /// <summary>
    /// Raises events when an external view onto associated data should be updated.
    /// </summary>
    public interface IVisibleData
    {
        /// <summary>
        /// Raised  when an external view onto associated data should be updated.
        /// </summary>
        public event EventHandler<EventArgs> VisibleDataChanged;
    }
}
