using System.Collections.Generic;
using ParquetClassLibrary;
using ParquetClassLibrary.Utilities;
using Xunit;

namespace ParquetUnitTests
{
    public class EntityIDTest
    {
        #region Values for Tests
        private static readonly EntityID firstLowerBound = 10;
        private static readonly EntityID firstUpperBound = 20;

        private static readonly EntityID secondLowerBound = 30;
        private static readonly EntityID secondUpperBound = 40;

        private static readonly EntityID overlapLowerBound = 15;
        private static readonly EntityID overlapUpperBound = 25;
        #endregion

        [Fact]
        public void NoneIsValidTest()
        {
            var range = new Range<EntityID>(firstLowerBound, firstUpperBound);

            var result = EntityID.None.IsValidForRange(range);

            Assert.True(result);
        }

        [Fact]
        public void MinimumIsValidTest()
        {
            var range = new Range<EntityID>(firstLowerBound, firstUpperBound); ;
            var entity = range.Minimum;
            var result = entity.IsValidForRange(range);

            Assert.True(result);
        }

        [Fact]
        public void AverageIsValidTest()
        {
            var range = new Range<EntityID>(firstLowerBound, firstUpperBound); ;
            var entity = range.Minimum;
            var result = entity.IsValidForRange(range);

            Assert.True(result);
        }

        [Fact]
        public void MaximumIsValidTest()
        {
            var range = new Range<EntityID>(firstLowerBound, firstUpperBound); ;
            var entity = range.Minimum;
            var result = entity.IsValidForRange(range);

            Assert.True(result);
        }

        [Fact]
        public void ValidSubrangeValuesAreValidInDiscreteRangeCollectionTest()
        {
            var firstRange = new Range<EntityID>(firstLowerBound, firstUpperBound);
            var secondRange = new Range<EntityID>(secondLowerBound, secondUpperBound);
            var discreteRanges = new List<Range<EntityID>> { firstRange, secondRange };

            EntityID firstLower = firstRange.Minimum;
            EntityID firstAverage = (firstRange.Minimum + firstRange.Maximum) / 2;
            EntityID firstUpper = firstRange.Maximum;
            EntityID secondLower = secondRange.Minimum;
            EntityID secondAverage = (secondRange.Minimum + secondRange.Maximum) / 2;
            EntityID secondUpper = secondRange.Maximum;

            Assert.True(firstLower.IsValidForRange(discreteRanges));
            Assert.True(firstAverage.IsValidForRange(discreteRanges));
            Assert.True(firstUpper.IsValidForRange(discreteRanges));
            Assert.True(secondLower.IsValidForRange(discreteRanges));
            Assert.True(secondAverage.IsValidForRange(discreteRanges));
            Assert.True(secondUpper.IsValidForRange(discreteRanges));
        }

        [Fact]
        public void ValidSubrangeValuesAreValidInOverlappingRangeCollectionTest()
        {
            var firstRange = new Range<EntityID>(firstLowerBound, firstUpperBound);
            var overlappingRange = new Range<EntityID>(overlapLowerBound, overlapUpperBound);
            var overlappingRanges = new List<Range<EntityID>> { firstRange, overlappingRange };

            EntityID firstLower = firstRange.Minimum;
            EntityID firstAverage = (firstRange.Minimum + firstRange.Maximum) / 2;
            EntityID firstUpper = firstRange.Maximum;
            EntityID secondLower = overlappingRange.Minimum;
            EntityID secondAverage = (overlappingRange.Minimum + overlappingRange.Maximum) / 2;
            EntityID secondUpper = overlappingRange.Maximum;

            Assert.True(firstLower.IsValidForRange(overlappingRanges));
            Assert.True(firstAverage.IsValidForRange(overlappingRanges));
            Assert.True(firstUpper.IsValidForRange(overlappingRanges));
            Assert.True(secondLower.IsValidForRange(overlappingRanges));
            Assert.True(secondAverage.IsValidForRange(overlappingRanges));
            Assert.True(secondUpper.IsValidForRange(overlappingRanges));
        }

        [Fact]
        public void InvalidSubrangeValuesAreInvalidInDiscreteRangeCollectionTest()
        {
            var firstRange = new Range<EntityID>(firstLowerBound, firstUpperBound);
            var secondRange = new Range<EntityID>(secondLowerBound, secondUpperBound);
            var discreteRanges = new List<Range<EntityID>> { firstRange, secondRange };

            EntityID firstLesser = firstRange.Minimum - 1;
            EntityID firstGreater = firstRange.Maximum + 1;
            EntityID secondLesser = secondRange.Minimum - 1;
            EntityID secondGreater = secondRange.Maximum + 1;

            Assert.False(firstLesser.IsValidForRange(discreteRanges));
            Assert.False(firstGreater.IsValidForRange(discreteRanges));
            Assert.False(secondLesser.IsValidForRange(discreteRanges));
            Assert.False(secondGreater.IsValidForRange(discreteRanges));
        }

        [Fact]
        public void OnlySubrangeValuesOutsideOverlappedRangesAreInvalidInOverlappingRangeCollectionTest()
        {
            var firstRange = new Range<EntityID>(firstLowerBound, firstUpperBound);
            var overlappingRange = new Range<EntityID>(overlapLowerBound, overlapUpperBound);
            var overlappingRanges = new List<Range<EntityID>> { firstRange, overlappingRange };

            EntityID firstLesser = firstRange.Minimum - 1;
            EntityID firstGreater = firstRange.Maximum + 1;
            EntityID secondLesser = overlappingRange.Minimum - 1;
            EntityID secondGreater = overlappingRange.Maximum + 1;

            Assert.True(firstGreater.IsValidForRange(overlappingRanges));
            Assert.True(secondLesser.IsValidForRange(overlappingRanges));

            Assert.False(firstLesser.IsValidForRange(overlappingRanges));
            Assert.False(secondGreater.IsValidForRange(overlappingRanges));
        }
    }
}
