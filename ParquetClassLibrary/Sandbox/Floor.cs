namespace Queertet.Sandbox
{
    /// <summary>
    /// Configurations for a sandbox-mode parquet floor.
    /// </summary>
    public class Floor
    {
        #region Identity
        /// <summary>The type of Block this instance represents.</summary>
        // IDEA: We might be able to remove this if we move to a Scriptable Object or other Unity-derived class.
        public ID.Floors floorType;
        #endregion

        #region Parquet Physics
        /// <summary>The floor may be walked on.</summary>
        public bool isWalkable;

        // IDEA: Add isFlyable

        /// <summary>The floor has been dug out.</summary>
        public bool isHole;

        /// <summary>The tool used to dig out or fill in the floor.</summary>
        // TODO I'm not sure this is actually needed -- won't every floor respond to the shovel?
        public ID.ModificationTools tool;
        #endregion

        #region Utility Methods
        public override string ToString()
        {
            return floorType.ToString("g").Substring(0, 1);
        }
        #endregion
    }
}
