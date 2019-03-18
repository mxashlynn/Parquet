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

        [Fact]
        public void MinimumIsWithinRangeTest()
        {
            var range = new Range<int>(LowerBound, UpperBound);

            Assert.True(range.ContainsValue(LowerBound));
        }

        [Fact]
        public void MaximumIsWithinRangeTest()
        {
            var range = new Range<int>(LowerBound, UpperBound);

            Assert.True(range.ContainsValue(UpperBound));
        }

        [Fact]
        public void GreaterThanMaximumIsNotWithinRangeTest()
        {
            var range = new Range<int>(LowerBound, UpperBound);
            var greater = UpperBound + 1;

            Assert.False(range.ContainsValue(greater));
        }

        [Fact]
        public void LessThanMinimumIsNotWithinRangeTest()
        {
            var range = new Range<int>(LowerBound, UpperBound);
            var lesser = LowerBound - 1;

            Assert.False(range.ContainsValue(lesser));
        }
    }
}
