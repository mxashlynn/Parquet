using Parquet.Parquets;
using Xunit;

namespace ParquetUnitTests.Parquets
{
    public class ParquetStatusUnitTest
    {
        #region Test Values
        private static readonly int TestMaxToughness = TestModels.TestBlock.MaxToughness;
        #endregion

        [Fact]
        public void ToughnessCannotBeSetBelowZeroTest()
        {
            var testStatus = new ParquetPackStatus();

            testStatus.Toughness = int.MinValue;

            Assert.Equal(BlockModel.LowestPossibleToughness, testStatus.Toughness);
        }

        [Fact]
        public void ToughnessCannotBeAboveMaxToughnessTest()
        {
            var testStatus = new ParquetPackStatus(false, TestMaxToughness, TestMaxToughness);

            testStatus.Toughness = int.MaxValue;

            Assert.Equal(TestMaxToughness, testStatus.Toughness);
        }
    }
}
