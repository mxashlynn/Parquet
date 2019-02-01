using ParquetClassLibrary.Sandbox.Parquets;
using Xunit;

namespace ParquetUnitTests.Sandbox.Parquets
{
    public class BlockUnitTest
    {
        [Fact]
        public void ToughnessCannotBeSetBelowZeroTest()
        {
            var testBlock = new Block();

            testBlock.MaxToughness = 10;
            testBlock.Toughness = 30;

            Assert.Equal(testBlock.MaxToughness, testBlock.Toughness);
        }

        [Fact]
        public void ToughnessCannotBeAboveMaxToughnessTest()
        {
            var testBlock = new Block();

            testBlock.MaxToughness = 10;
            testBlock.Toughness = -10;

            Assert.Equal(0, testBlock.Toughness);
        }
    }
}
