namespace Parquet
{
    /// <summary>
    /// Classes implementing this interface provide the means to duplicate an instance of that class via a deep copy.
    /// </summary>
    /// <typeparam name="T">The class to be deeply cloned.</typeparam>
    public interface IDeeplyCloneable<T>
    {
        /// <summary>
        /// Creates a new instance that is a deep copy of the current instance.
        /// </summary>
        /// <returns>A new instance with the same characteristics as the current instance.</returns>
        T DeepClone();
    }
}
