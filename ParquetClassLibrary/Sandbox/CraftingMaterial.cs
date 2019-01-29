namespace Queertet.Sandbox
{
    /// <summary>
    /// Configurations for a sandbox-mode Characters, Furnishings, Crafting Materils, etc.
    /// </summary>
    public class CraftingMaterial
    {
        #region Identity
        /// <summary>The type of collectable material this instance represents.</summary>
        // IDEA: We might be able to remove this if we move to a Scriptable Object or other Unity-derived class.
        public ID.CraftingMaterials craftingMaterialType;
        #endregion
    }
}
