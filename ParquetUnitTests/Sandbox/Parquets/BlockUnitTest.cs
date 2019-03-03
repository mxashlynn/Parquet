using ParquetClassLibrary.Sandbox.Parquets;
using Xunit;

namespace ParquetUnitTests.Sandbox.Parquets
{
    public class BlockUnitTest
    {
        [Fact]
        public void ToughnessCannotBeSetBelowZeroTest()
        {
            var testBlock = AllParquets.TestBlock;

            testBlock.Toughness = int.MaxValue;

            Assert.Equal(testBlock.MaxToughness, testBlock.Toughness);
        }

        [Fact]
        public void ToughnessCannotBeAboveMaxToughnessTest()
        {
            var testBlock = AllParquets.TestBlock;

            testBlock.Toughness = int.MinValue;

            Assert.Equal(0, testBlock.Toughness);
        }
    }
}
