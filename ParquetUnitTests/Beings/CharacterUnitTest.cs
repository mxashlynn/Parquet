using System;
using Parquet;
using Parquet.Beings;
using Xunit;

namespace ParquetUnitTests.Beings
{
    public class CharacterUnitTest
    {
        #region Test Values
        /// <summary>Identifier used when creating a new block.</summary>
        private static readonly ModelID newCharacterID = TestModels.TestCharacter.ID - 1;
        #endregion

        [Fact]
        public void ValidCharacterIDsArePermittedTest()
        {
            var newCharacter = new CharacterModel(newCharacterID, "Character", "will be created", "", All.BiomeRecipeIDs.Minimum, All.ScriptIDs.Minimum);

            Assert.NotNull(newCharacter);
        }

        [Fact]
        public void InvalidCharacterIDsRaiseExceptionTest()
        {
            var badCharacterID = TestModels.TestBlock.ID - 1;

            void TestCode()
            {
                var _ = new CharacterModel(badCharacterID, "Character", "will fail", "", All.BiomeRecipeIDs.Minimum, All.ScriptIDs.Minimum);
            }

            Assert.Throws<ArgumentOutOfRangeException>(TestCode);
        }
    }
}
