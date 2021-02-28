using System;
using Parquet;
using Parquet.Beings;
using Xunit;

namespace ParquetUnitTests.Beings
{
    /// <summary>
    /// Unit tests <see cref="CritterModel"/>.
    /// </summary>
    public class CritterModelUnitTest
    {
        #region Test Values
        /// <summary>Identifier used when creating a new block.</summary>
        private static readonly ModelID newCritterID = TestModels.TestCritter.ID - 1;
        #endregion

        [Fact]
        internal void ValidCritterIDsArePermittedTest()
        {
            var newCritter = new CritterModel(newCritterID, "will be created", "", "", null,
                                         All.BiomeRecipeIDs.Minimum, All.ScriptIDs.Minimum);

            Assert.NotNull(newCritter);
        }

        [Fact]
        internal void InvalidCritterIDsRaiseExceptionTest()
        {
            var badCritterID = TestModels.TestBlock.ID - 1;

            void TestCode()
            {
                var _ = new CritterModel(badCritterID, "will fail", "", "", null,
                                    All.BiomeRecipeIDs.Minimum, All.ScriptIDs.Minimum);
            }

            Assert.Throws<ArgumentOutOfRangeException>(TestCode);
        }
    }
}
