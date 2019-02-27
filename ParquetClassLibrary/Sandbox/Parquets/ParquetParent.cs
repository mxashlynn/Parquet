namespace ParquetClassLibrary.Sandbox.Parquets
{
    /// <summary>
    /// Parent for a all sandbox-mode parquets.
    /// </summary>
    public abstract class ParquetParent
    {

        /// <summary>
        /// If a <see cref="T:ParquetClassLibrary.Sandbox.BiomeMask"/> flag is set,
        /// this parquet helps generate the corresponding <see cref="T:ParquetClassLibrary.Sandbox.Biome"/>.
        /// </summary>
        internal BiomeMask AddsToBiome { get; private protected set; }







    }
}
