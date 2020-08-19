using ParquetClassLibrary.Items;

namespace ParquetClassLibrary.Parquets
{
    /// <summary>
    /// Facilitates editing of a <see cref="FloorModel"/> from design tools while maintaining a read-only face for use during play.
    /// </summary>
    public interface IFloorModelEdit : IParquetModelEdit
    {
        /// <summary>The tool used to dig out or fill in the floor.</summary>
        public ModificationTool ModTool { get; set; }

        /// <summary>Player-facing name of the parquet, used when it has been dug out.</summary>
        public string TrenchName { get; set; }
    }
}
