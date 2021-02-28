using System;
using System.Collections.Generic;
using Parquet;
using Xunit;

namespace ParquetUnitTests
{
    /// <summary>
    /// Unit tests <see cref="Range{TElement}"/>.
    /// </summary>
    public class RangeUnitTest
    {
        #region Values for Tests
        private const int lowerBound = 0;
        private const int upperBound = 10;
        #endregion

        [Fact]
        internal void RangeMustBeWillDefinedTest()
        {
            Assert.Throws<InvalidOperationException>(() => { var _ = new Range<int>(upperBound, lowerBound); });
        }

        [Fact]
        internal void WellDefinedRangeIsValidTest()
        {
            var range = new Range<int>(lowerBound, upperBound);

            Assert.True(range.IsValid());
        }

        [Fact]
        internal void WellDefinedRangeContainsItselfTest()
        {
            var range = new Range<int>(lowerBound, upperBound);

            Assert.True(range.ContainsRange(range));
        }

        [Fact]
        internal void RangeContainsStrictlySmallerRangeTest()
        {
            var range = new Range<int>(lowerBound, upperBound);
            var smallerRange = new Range<int>(lowerBound + 1, upperBound - 1);

            Assert.True(range.ContainsRange(smallerRange));
        }

        [Fact]
        internal void AverageIsWithinRangeTest()
        {
            var range = new Range<int>(lowerBound, upperBound);
            var average = (lowerBound + upperBound) / 2;

            Assert.True(range.ContainsValue(average));
        }

        [Fact]
        internal void MinimumIsWithinRangeTest()
        {
            var range = new Range<int>(lowerBound, upperBound);

            Assert.True(range.ContainsValue(lowerBound));
        }

        [Fact]
        internal void MaximumIsWithinRangeTest()
        {
            var range = new Range<int>(lowerBound, upperBound);

            Assert.True(range.ContainsValue(upperBound));
        }

        [Fact]
        internal void GreaterThanMaximumIsNotWithinRangeTest()
        {
            var range = new Range<int>(lowerBound, upperBound);
            var greater = upperBound + 1;

            Assert.False(range.ContainsValue(greater));
        }

        [Fact]
        internal void LessThanMinimumIsNotWithinRangeTest()
        {
            var range = new Range<int>(lowerBound, upperBound);
            var lesser = lowerBound - 1;

            Assert.False(range.ContainsValue(lesser));
        }

        [Fact]
        internal void EmptyRangeCollectionContainsNothingTest()
        {
            var range = new Range<int>(lowerBound, upperBound);
            var emptyCollection = new List<Range<int>>();

            Assert.False(emptyCollection.ContainsRange(range));
            Assert.False(emptyCollection.ContainsValue(lowerBound));
        }

        [Fact]
        internal void KnownRangeCanBeFoundInRangeCollectionTest()
        {
            var range = new Range<int>(lowerBound, upperBound);
            var collection = new List<Range<int>> { range };

            Assert.True(collection.ContainsRange(range));
        }

        [Fact]
        internal void KnownValueCanBeFoundInRangeCollectionTest()
        {
            var range = new Range<int>(lowerBound, upperBound);
            var collection = new List<Range<int>> { range };

            Assert.True(collection.ContainsValue(lowerBound));
        }
    }
}
