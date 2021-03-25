using System;

namespace Parquet
{
    /// <summary>
    /// Indicates an external view onto associated data should be updated.
    /// </summary>
    /// <param name="inSender">The instance that raised the event.</param>
    /// <param name="inEventData">Additional event data.</param>
    /// <returns><c>true</c> if the operation succeeded; otherwise, <c>false</c>.</returns>
    public delegate bool DataChangedEventHandler(object inSender, EventArgs inEventData);

    /// <summary>
    /// Raises events when an external view onto associated data should be updated.
    /// </summary>
    public interface IVisibleData
    {
        /// <summary>
        /// Raised when an external view onto associated data should be updated.
        /// </summary>
        public event DataChangedEventHandler VisibleDataChanged;
    }
}
