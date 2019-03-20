using ParquetClassLibrary;
using ParquetClassLibrary.Sandbox.Parquets;
using Xunit;

namespace ParquetUnitTests.Sandbox.Parquets
{
    public class BlockUnitTest
    {
        [Fact]
        public void ToughnessCannotBeSetBelowZeroTest()
        {
            var testBlock = TestParquets.TestBlock;
            var priorToughness = testBlock.Toughness;

            testBlock.Toughness = int.MinValue;

            Assert.Equal(priorToughness, testBlock.Toughness);
        }

        [Fact]
        public void ToughnessCannotBeAboveMaxToughnessTest()
        {
            var testBlock = TestParquets.TestBlock;
            var priorToughness = testBlock.Toughness;

            testBlock.Toughness = int.MaxValue;

            Assert.Equal(priorToughness, testBlock.Toughness);
        }
    }
}
