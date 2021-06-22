using System;
using System.Collections.Generic;
using Parquet;
using Parquet.Crafts;
using Xunit;

namespace ParquetUnitTests.Crafts
{
    /// <summary>
    /// Unit tests <see cref="CraftingRecipe"/>.
    /// </summary>
    public class CraftingRecipeUnitTest
    {
        #region Test Values
        /// <summary>Identifier used when creating a new block.</summary>
        private static readonly ModelID newCraftingRecipeID = TestModels.TestCraftingRecipe.ID - 1;

        /// <summary>A valid minimal list of test ingredients.</summary>
        private static readonly IReadOnlyList<RecipeElement> ingredientList = new List<RecipeElement>
        {
            new RecipeElement(1, "ingredient"),
        };

        /// <summary>A valid minimal list of test products.</summary>
        private static readonly IReadOnlyList<RecipeElement> productList = new List<RecipeElement>
        {
            new RecipeElement(1, "product"),
        };
        #endregion

        [Fact]
        internal void ValidCraftingRecipeIDsArePermittedTest()
        {
            var newCraftingRecipe = new CraftingRecipe(newCraftingRecipeID, "will be created", "", "", null,
                                                       productList, ingredientList);

            Assert.NotNull(newCraftingRecipe);
        }

        [Fact]
        internal void InvalidCraftingRecipeIDsThrowTest()
        {
            var badCraftingRecipeID = TestModels.TestBlock.ID - 1;

            void TestCode()
            {
                var _ = new CraftingRecipe(badCraftingRecipeID, "will fail", "", "", null,
                                           productList, ingredientList);
            }

            Assert.Throws<ArgumentOutOfRangeException>(TestCode);
        }
    }
}
