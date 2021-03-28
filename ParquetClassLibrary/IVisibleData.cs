using System;

namespace Parquet
{
    /// <summary>
    /// Indicates an external view onto associated data should be updated.
    /// </summary>
    /// <param name="inSender">The instance that raised the event.</param>
    /// <param name="inEventData">Additional event data.</param>
    /// <returns><c>true</c> if the operation succeeded; otherwise, <c>false</c>.</returns>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Naming", "CA1711:Identifiers should not have incorrect suffix",
        Justification = "False positive.")]
    public delegate bool DataChangedEventHandler(object inSender, EventArgs inEventData);

    /// <summary>
    /// Raises events when an external view onto associated data should be updated.
    /// </summary>
    public interface IVisibleData
    {
        /// <summary>
        /// Raised when an external view onto associated data should be updated.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Design", "CA1003:Use generic event handler instances",
            Justification = "False positive.")]
        public event DataChangedEventHandler VisibleDataChanged;
    }
}
