namespace Parquet.Beings
{
    /// <summary>
    /// Tracks the status of a <see cref="BeingModel"/> during play.
    /// Instances of this class are mutable during play.
    /// </summary>
    public abstract class BeingStatus<T> : Status<T>
        where T : BeingModel
    {
        // Currently, everything needed for tracking BeingModels is provided by Status<T>.
    }
}
