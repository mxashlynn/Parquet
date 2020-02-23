namespace ParquetClassLibrary
{
    /// <summary>
    /// Facilitates editing of an <see cref="EntityModel"/> from design tools while maintaining a read-only face for use during play.
    /// </summary>
    internal interface IEntityModelEdit
    {
        /// <summary>Player-facing name.</summary>
        public string Name { get; set; }

        /// <summary>Player-facing description.</summary>
        public string Description { get; set; }

        /// <summary>Optional comment.</summary>
        /// <remarks>
        /// Could be used for designer notes or to implement an in-game dialogue
        /// with or on the <see cref="EntityModel"/>.
        /// </remarks>
        public string Comment { get; set; }
    }
}
