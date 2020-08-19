namespace ParquetClassLibrary.Parquets
{
    /// <summary>
    /// Facilitates editing of a <see cref="CollectibleModel"/> from design tools while maintaining a read-only face for use during play.
    /// </summary>
    public interface ICollectibleModel : IParquetModelEdit
    {
        /// <summary>The effect generated when a character encounters this Collectible.</summary>
        public CollectingEffect CollectionEffect { get; set; }

        /// <summary>
        /// The scale in points of the effect.
        /// For example, how much to alter a stat if the <see cref="CollectingEffect"/> is set to alter a stat.
        /// </summary>
        public int EffectAmount { get; set; }
    }
}
