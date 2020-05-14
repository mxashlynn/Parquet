namespace ParquetClassLibrary
{
    /// <summary>
    /// Facilitates editing of a <see cref="Model"/> from design tools while maintaining a read-only face for use during play.
    /// </summary>
    internal interface IModelEdit
    {
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
