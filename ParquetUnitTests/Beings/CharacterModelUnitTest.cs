using System;
using Parquet;
using Parquet.Beings;
using Xunit;

namespace ParquetUnitTests.Beings
{
    /// <summary>
    /// Unit tests <see cref="CharacterModel"/>.
    /// </summary>
    public class CharacterModelUnitTest
    {
        #region Test Values
        /// <summary>Identifier used when creating a new block.</summary>
        private static readonly ModelID newCharacterID = TestModels.TestCharacter.ID - 1;
        #endregion

        [Fact]
        internal void ValidCharacterIDsArePermittedTest()
        {
            var newCharacter = new CharacterModel(newCharacterID, "Character", "will be created", "", null, All.BiomeRecipeIDs.Minimum, All.ScriptIDs.Minimum);

            Assert.NotNull(newCharacter);
        }

        [Fact]
        internal void InvalidCharacterIDsRaiseExceptionTest()
        {
            var badCharacterID = TestModels.TestBlock.ID - 1;

            void TestCode()
            {
                var _ = new CharacterModel(badCharacterID, "Character", "will fail", "", null, All.BiomeRecipeIDs.Minimum, All.ScriptIDs.Minimum);
            }

            Assert.Throws<ArgumentOutOfRangeException>(TestCode);
        }
    }
}
