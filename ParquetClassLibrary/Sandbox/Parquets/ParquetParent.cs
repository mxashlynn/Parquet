namespace ParquetClassLibrary.Sandbox.Parquets
{
    /// <summary>
    /// Parent for a all sandbox-mode parquets.
    /// </summary>
    public abstract class ParquetParent
    {
        /// <summary>If <c>true</c>, this parquet helps generate a Desert <see cref="T:ParquetClassLibrary.Sandbox.Biome"/>.</summary>
        internal bool ContributesToDesert { get; private protected set; }

        /// <summary>If <c>true</c>, this parquet helps generate a Forest <see cref="T:ParquetClassLibrary.Sandbox.Biome"/>.</summary>
        internal bool ContributesToForest { get; private protected set; }

        /// <summary>If <c>true</c>, this parquet helps generate a Heavens <see cref="T:ParquetClassLibrary.Sandbox.Biome"/>.</summary>
        internal bool ContributesToHeavens { get; private protected set; }

        /// <summary>If <c>true</c>, this parquet helps generate a Volcanic <see cref="T:ParquetClassLibrary.Sandbox.Biome"/>.</summary>
        internal bool ContributesToVolcanic { get; private protected set; }

        /// <summary>If <c>true</c>, this parquet helps generate a Seaside <see cref="T:ParquetClassLibrary.Sandbox.Biome"/>.</summary>
        internal bool ContributesToSeaside { get; private protected set; }

        /// <summary>If <c>true</c>, this parquet helps generate a Swamp <see cref="T:ParquetClassLibrary.Sandbox.Biome"/>.</summary>
        internal bool ContributesToSwamp { get; private protected set; }

        /// <summary>If <c>true</c>, this parquet helps generate a Tundra <see cref="T:ParquetClassLibrary.Sandbox.Biome"/>.</summary>
        internal bool ContributesToTundra { get; private protected set; }
    }
}
