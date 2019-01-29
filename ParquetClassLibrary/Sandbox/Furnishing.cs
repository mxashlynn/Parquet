namespace Queertet.Sandbox
{
    /// <summary>
    /// Configurations for a sandbox-mode Furniture and similar items.
    /// </summary>
    public class Furnishing
    {
        #region Identity
        /// <summary>The type of Furnishing this instance represents.</summary>
        // IDEA: We might be able to remove this if we move to a Scriptable Object or other Unity-derived class.
        public ID.Furnishings furnishingType;
        #endregion
    }
}
