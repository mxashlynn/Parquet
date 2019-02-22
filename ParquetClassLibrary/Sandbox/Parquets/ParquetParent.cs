namespace ParquetClassLibrary.Sandbox.Parquets
{
    /// <summary>
    /// Parent for a all sandbox-mode parquets.
    /// </summary>
    public abstract class ParquetParent
    {
        /// <summary>If <c>true</c>, this parquet helps generate a Desert <see cref="T:ParquetClassLibrary.Sandbox.Biome"/>.</summary>
        internal bool ContributesToDesert;

        /// <summary>If <c>true</c>, this parquet helps generate a Forest <see cref="T:ParquetClassLibrary.Sandbox.Biome"/>.</summary>
        internal bool ContributesToForest;

        /// <summary>If <c>true</c>, this parquet helps generate a Heavens <see cref="T:ParquetClassLibrary.Sandbox.Biome"/>.</summary>
        internal bool ContributesToHeavens;

        /// <summary>If <c>true</c>, this parquet helps generate a Volcanic <see cref="T:ParquetClassLibrary.Sandbox.Biome"/>.</summary>
        internal bool ContributesToVolcanic;

        /// <summary>If <c>true</c>, this parquet helps generate a Seaside <see cref="T:ParquetClassLibrary.Sandbox.Biome"/>.</summary>
        internal bool ContributesToSeaside;

        /// <summary>If <c>true</c>, this parquet helps generate a Swamp <see cref="T:ParquetClassLibrary.Sandbox.Biome"/>.</summary>
        internal bool ContributesToSwamp;

        /// <summary>If <c>true</c>, this parquet helps generate a Tundra <see cref="T:ParquetClassLibrary.Sandbox.Biome"/>.</summary>
        internal bool ContributesToTundra;
    }
}
