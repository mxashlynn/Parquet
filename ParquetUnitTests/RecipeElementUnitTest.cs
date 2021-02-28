using System;
using Parquet;
using Xunit;

namespace ParquetUnitTests
{
    /// <summary>
    /// Unit tests <see cref="RecipeElement"/>.
    /// </summary>
    public class RecipeElementUnitTest
    {
        [Fact]
        internal void ZeroAmountsFailTest()
        {
            static void TestCodeZero()
            {
                var _ = new RecipeElement(0, "test");
            }

            Assert.Throws<ArgumentOutOfRangeException>(TestCodeZero);
        }

        [Fact]
        internal void NegativeeAountsFailTest()
        {
            static void TestCodeNegative()
            {
                var _ = new RecipeElement(-1, "test");
            }

            Assert.Throws<ArgumentOutOfRangeException>(TestCodeNegative);
        }
    }
}
