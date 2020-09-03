namespace ParquetClassLibrary
{
    /// <summary>
    /// Facilitates editing of a <see cref="Model"/> from design tools while maintaining a read-only face for use during play.
    /// </summary>
    /// <remarks>
    /// By design, children of <see cref="Model"/> should never themselves use <see cref="IModelEdit"/>.
    /// IModelEdit is for use only by external types that require read/write access to model properties.
    /// </remarks>
    public interface IModelEdit
    {
        /// <summary>Game-wide unique identifier.</summary>
        /// <remarks>Be cautious editing this.</remarks>
        public ModelID ID { get; set; }

        /// <summary>Player-facing name.</summary>
        public string Name { get; set; }

        /// <summary>Player-facing description.</summary>
        public string Description { get; set; }

        /// <summary>Optional comment.</summary>
        /// <remarks>
        /// Could be used for designer's notes or to implement an in-game dialogue with or on the <see cref="Model"/>.
        /// </remarks>
        public string Comment { get; set; }
    }
}
