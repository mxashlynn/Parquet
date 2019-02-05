namespace ParquetClassLibrary.Sandbox.Parquets
{
    /// <summary>
    /// Configurations for a sandbox-mode parquet block.
    /// </summary>
    public class Block : ParquetParent
    {
        #region Identity
        /// <summary>The type of Block this instance represents.</summary>
        // IDEA: We might be able to remove this if we move to a Scriptable Object or other Unity-derived class.
        public ID.Blocks blockType;
        #endregion

        #region Constructor
        public Block(ID.Blocks in_id = ID.Blocks.Tree)
        {
            blockType = in_id;
        }
        #endregion

        #region Block Physics
        /// <summary>The block is flammable.</summary>
        public bool IsFlammable { get; set; }

        /// <summary>The block is a liquid.</summary>
        public bool IsLiquid { get; set; }

        /// <summary>The tool used to remove the block.</summary>
        public ID.GatheringTools ToolType { get; set; }

        /// <summary>The block's native toughness.</summary>
        public int MaxToughness { get; set; }

        /// <summary>The block's current toughness.</summary>
        private int _toughness;

        /// <summary>The block's current toughness, from 0 to <see cref="MaxToughness"/>.</summary>
        public int Toughness
        {
            get => _toughness;
            set
            {
                _toughness = value;
                if (_toughness < 0)
                {
                    _toughness = 0;
                }
                else if (_toughness > MaxToughness)
                {
                    _toughness = MaxToughness;
                }
            }
        }
        #endregion

        #region Utility Methods
        public override string ToString()
        {
            return blockType.ToString("g").Substring(0, 1);
        }
        #endregion
    }
}
