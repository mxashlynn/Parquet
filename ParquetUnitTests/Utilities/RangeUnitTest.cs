using System;
using System.Collections.Generic;
using ParquetClassLibrary.Utilities;
using Xunit;

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
            Assert.Throws<ArgumentException>(() => { var _ = new Range<int>(upperBound, lowerBound); });
        }

        [Fact]
        public void WellDefinedRangeIsValidTest()
        {
            var range = new Range<int>(lowerBound, upperBound);

            Assert.True(range.IsValid());
        }

        [Fact]
        public void WellDefinedRangeContainsItselfTest()
        {
            var range = new Range<int>(lowerBound, upperBound);

            Assert.True(range.ContainsRange(range));
        }

        [Fact]
        public void RangeContainsStrictlySmallerRangeTest()
        {
            var range = new Range<int>(lowerBound, upperBound);
            var smallerRange = new Range<int>(lowerBound + 1, upperBound - 1);

            Assert.True(range.ContainsRange(smallerRange));
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

        [Fact]
        public void EmptyRangeCollectionContainsNothingTest()
        {
            var range = new Range<int>(lowerBound, upperBound);
            var emptyCollection = new List<Range<int>>();

            Assert.False(emptyCollection.ContainsRange(range));
            Assert.False(emptyCollection.ContainsValue(lowerBound));
        }

        [Fact]
        public void KnownRangeCanBeFoundInRangeCollectionTest()
        {
            var range = new Range<int>(lowerBound, upperBound);
            var collection = new List<Range<int>> { range };

            Assert.True(collection.ContainsRange(range));
        }

        [Fact]
        public void KnownValueCanBeFoundInRangeCollectionTest()
        {
            var range = new Range<int>(lowerBound, upperBound);
            var collection = new List<Range<int>> { range };

            Assert.True(collection.ContainsValue(lowerBound));
        }
    }
}
