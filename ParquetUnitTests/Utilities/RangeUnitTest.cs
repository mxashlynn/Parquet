using Xunit;
using System;
using ParquetClassLibrary.Utilities;

namespace ParquetUnitTests.Utilities
{
    public class RangeUnitTest
    {
        #region Values for Tests
        private const int lowerBound = 0;
        private const int upperBound = 10;
        #endregion

        [Fact]
        public void RangeMustBeWillDefinedTest()
        {
            Assert.Throws<ArgumentException>(() => { var range = new Range<int>(upperBound, lowerBound); });
        }

        [Fact]
        public void WellDefinedRangeIsValidTest()
        {
            var range = new Range<int>(lowerBound, upperBound);

            Assert.True(range.IsValid());
        }

        [Fact]
        public void AverageIsWithinRangeTest()
        {
            var range = new Range<int>(lowerBound, upperBound);
            var average = (lowerBound + upperBound) / 2;

            Assert.True(range.ContainsValue(average));
        }

        [Fact]
        public void MinimumIsWithinRangeTest()
        {
            var range = new Range<int>(lowerBound, upperBound);

            Assert.True(range.ContainsValue(lowerBound));
        }

        [Fact]
        public void MaximumIsWithinRangeTest()
        {
            var range = new Range<int>(lowerBound, upperBound);

            Assert.True(range.ContainsValue(upperBound));
        }

        [Fact]
        public void GreaterThanMaximumIsNotWithinRangeTest()
        {
            var range = new Range<int>(lowerBound, upperBound);
            var greater = upperBound + 1;

            Assert.False(range.ContainsValue(greater));
        }

        [Fact]
        public void LessThanMinimumIsNotWithinRangeTest()
        {
            var range = new Range<int>(lowerBound, upperBound);
            var lesser = lowerBound - 1;

            Assert.False(range.ContainsValue(lesser));
        }
    }
}
