using Xunit;
using System;
using ParquetClassLibrary.Utilities;

namespace ParquetUnitTests.Utilities
{
    public class RangeUnitTest
    {
        #region Values for Tests
        private const int LowerBound = 0;
        private const int UpperBound = 10;
        #endregion

        [Fact]
        public void RangeMustBeWillDefinedTest()
        {
            Assert.Throws<ArgumentException>(() => { var range = new Range<int>(UpperBound, LowerBound); });
        }

        [Fact]
        public void WellDefinedRangeIsValidTest()
        {
            var range = new Range<int>(LowerBound, UpperBound);

            Assert.True(range.IsValid());
        }

        [Fact]
        public void AverageIsWithinRangeTest()
        {
            var range = new Range<int>(LowerBound, UpperBound);
            var average = (LowerBound + UpperBound) / 2;

            Assert.True(range.ContainsValue(average));
        }
    }
}
