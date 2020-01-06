namespace ParquetClassLibrary.Serialization.Shims
{
    /// <summary>
    /// Parent class for all shims.
    /// </summary>
    public abstract class EntityShim
    {
        /// <summary>Unique identifier of the parquet.</summary>
        public EntityID ID;

        /// <summary>Player-facing name of the parquet.</summary>
        public string Name;

        /// <summary>Player-facing description.</summary>
        public string Description;

        /// <summary>Optional comment.</summary>
        public string Comment;

        /// <summary>
        /// Converts a shim into the class it corresponds to.
        /// </summary>
        /// <typeparam name="T">The type to convert this shim to.</typeparam>
        /// <returns>An instance of a child class of <see cref="Entity"/>.</returns>
        public abstract T To<T>() where T : Entity;
    }
}
