namespace Parquet.Parquets
{
    /// <summary>
    /// Tracks the status of a <see cref="ParquetModel"/> during play.
    /// Instances of this class are mutable during play.
    /// </summary>
    public abstract class ParquetStatus<T> : Status<T>
        where T : ParquetModel
    {
        // Currently, everything needed for tracking ParquetModels is provided by Status<T>.
    }
}
