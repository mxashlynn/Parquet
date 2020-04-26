using System.Collections.Generic;
using ParquetClassLibrary;
using Xunit;

namespace ParquetUnitTests
{
    public class ModelIDUnitTest
    {
        #region Values for Tests
        private static readonly ModelID firstLowerBound = 10;
        private static readonly ModelID firstUpperBound = 20;

        private static readonly ModelID secondLowerBound = 30;
        private static readonly ModelID secondUpperBound = 40;

        private static readonly ModelID overlapLowerBound = 15;
        private static readonly ModelID overlapUpperBound = 25;
        #endregion

        [Fact]
        public void NoneIsValidTest()
        {
            var range = new Range<ModelID>(firstLowerBound, firstUpperBound);

            var result = ModelID.None.IsValidForRange(range);

            Assert.True(result);
        }

        [Fact]
        public void MinimumIsValidTest()
        {
            var range = new Range<ModelID>(firstLowerBound, firstUpperBound);
            var id = range.Minimum;
            var result = id.IsValidForRange(range);

            Assert.True(result);
        }

        [Fact]
        public void AverageIsValidTest()
        {
            var range = new Range<ModelID>(firstLowerBound, firstUpperBound);
            var id = range.Minimum;
            var result = id.IsValidForRange(range);

            Assert.True(result);
        }

        [Fact]
        public void MaximumIsValidTest()
        {
            var range = new Range<ModelID>(firstLowerBound, firstUpperBound);
            var id = range.Minimum;
            var result = id.IsValidForRange(range);

            Assert.True(result);
        }

        [Fact]
        public void ValidSubrangeValuesAreValidInDiscreteRangeCollectionTest()
        {
            var firstRange = new Range<ModelID>(firstLowerBound, firstUpperBound);
            var secondRange = new Range<ModelID>(secondLowerBound, secondUpperBound);
            var discreteRanges = new List<Range<ModelID>> { firstRange, secondRange };

            var firstLower = firstRange.Minimum;
            ModelID firstAverage = (firstRange.Minimum + firstRange.Maximum) / 2;
            var firstUpper = firstRange.Maximum;
            var secondLower = secondRange.Minimum;
            ModelID secondAverage = (secondRange.Minimum + secondRange.Maximum) / 2;
            var secondUpper = secondRange.Maximum;

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
            var firstRange = new Range<ModelID>(firstLowerBound, firstUpperBound);
            var overlappingRange = new Range<ModelID>(overlapLowerBound, overlapUpperBound);
            var overlappingRanges = new List<Range<ModelID>> { firstRange, overlappingRange };

            var firstLower = firstRange.Minimum;
            ModelID firstAverage = (firstRange.Minimum + firstRange.Maximum) / 2;
            var firstUpper = firstRange.Maximum;
            var secondLower = overlappingRange.Minimum;
            ModelID secondAverage = (overlappingRange.Minimum + overlappingRange.Maximum) / 2;
            var secondUpper = overlappingRange.Maximum;

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
            var firstRange = new Range<ModelID>(firstLowerBound, firstUpperBound);
            var secondRange = new Range<ModelID>(secondLowerBound, secondUpperBound);
            var discreteRanges = new List<Range<ModelID>> { firstRange, secondRange };

            ModelID firstLesser = firstRange.Minimum - 1;
            ModelID firstGreater = firstRange.Maximum + 1;
            ModelID secondLesser = secondRange.Minimum - 1;
            ModelID secondGreater = secondRange.Maximum + 1;

            Assert.False(firstLesser.IsValidForRange(discreteRanges));
            Assert.False(firstGreater.IsValidForRange(discreteRanges));
            Assert.False(secondLesser.IsValidForRange(discreteRanges));
            Assert.False(secondGreater.IsValidForRange(discreteRanges));
        }

        [Fact]
        public void OnlySubrangeValuesOutsideOverlappedRangesAreInvalidInOverlappingRangeCollectionTest()
        {
            var firstRange = new Range<ModelID>(firstLowerBound, firstUpperBound);
            var overlappingRange = new Range<ModelID>(overlapLowerBound, overlapUpperBound);
            var overlappingRanges = new List<Range<ModelID>> { firstRange, overlappingRange };

            ModelID firstLesser = firstRange.Minimum - 1;
            ModelID firstGreater = firstRange.Maximum + 1;
            ModelID secondLesser = overlappingRange.Minimum - 1;
            ModelID secondGreater = overlappingRange.Maximum + 1;

            Assert.True(firstGreater.IsValidForRange(overlappingRanges));
            Assert.True(secondLesser.IsValidForRange(overlappingRanges));

            Assert.False(firstLesser.IsValidForRange(overlappingRanges));
            Assert.False(secondGreater.IsValidForRange(overlappingRanges));
        }
    }
}
