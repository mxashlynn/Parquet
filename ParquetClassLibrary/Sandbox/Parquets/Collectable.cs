namespace ParquetClassLibrary.Sandbox.Parquets
{
    /// <summary>
    /// Configurations for a sandbox-mode Characters, Furnishings, Crafting Materils, etc.
    /// </summary>
    public class Collectable : ParquetParent
    {
        #region Identity
        /// <summary>The type of collectable material this instance represents.</summary>
        // IDEA: We might be able to remove this if we move to a Scriptable Object or other Unity-derived class.
        public ID.Collectables collectableType;
        #endregion

        #region Utility Methods
        public override string ToString()
        {
            return collectableType.ToString("g").Substring(0, 1);
        }
        #endregion
    }
}
