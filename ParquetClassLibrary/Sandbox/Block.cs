namespace Queertet.Sandbox
{
    /// <summary>
    /// Configurations for a sandbox-mode parquet block.
    /// </summary>
    public class Block
    {
        #region Identity
        /// <summary>The type of Block this instance represents.</summary>
        // IDEA: We might be able to remove this if we move to a Scriptable Object or other Unity-derived class.
        public ID.Blocks blockType;
        #endregion

        #region Block Physics
        /// <summary>The block is flammable.</summary>
        public bool isFlammable;

        /// <summary>The block is a liquid.</summary>
        public bool isLiquid;

        /// <summary>The tool used to remove the block.</summary>
        public ID.GatheringTools toolType;

        /// <summary>The block's native toughness.</summary>
        public int maxToughness;

        /// <summary>The block's current toughness.</summary>
        public int toughness;
        #endregion

        #region Methods for working with Blocks
        #endregion
    }
}
