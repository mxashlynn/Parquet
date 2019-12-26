using ParquetClassLibrary;
using ParquetClassLibrary.Parquets;
using Xunit;

namespace ParquetUnitTests.Parquets
{
    public class ParquetStatusUnitTest
    {
        #region Test Values
        private static readonly int TestMaxToughness = TestEntities.TestBlock.MaxToughness;
        #endregion

        [Fact]
        public void ToughnessCannotBeSetBelowZeroTest()
        {
            var testStatus = new ParquetStatus();

            testStatus.Toughness = int.MinValue;

            Assert.Equal(Block.LowestPossibleToughness, testStatus.Toughness);
        }

        [Fact]
        public void ToughnessCannotBeAboveMaxToughnessTest()
        {
            var testStatus = new ParquetStatus(false, TestMaxToughness, TestMaxToughness);

            testStatus.Toughness = int.MaxValue;

            Assert.Equal(TestMaxToughness, testStatus.Toughness);
        }
    }
}
