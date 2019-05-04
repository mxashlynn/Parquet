using System;
using System.Collections.Generic;
using ParquetClassLibrary;
using ParquetClassLibrary.Utilities;
using Xunit;

namespace ParquetUnitTests.Utilities
{
    public class PreconditionUnitTest
    {
        #region Test Values
        public class BaseType { };
        public class DerivedType : BaseType { };
        #endregion

        [Fact]
        public void EntityIsInRangeTest()
        {
            var testID = (EntityID)6;
            var testRange = new Range<EntityID>(0, 10);

            var exception = Record.Exception(() => Precondition.IsInRange(testID, testRange));

            Assert.Null(exception);
        }

        [Fact]
        public void RangeIsInRangeTest()
        {
            var innerRange = new Range<EntityID>(1, 9);
            var outterRange = new Range<EntityID>(0, 10);

            var exception = Record.Exception(() => Precondition.IsInRange(innerRange, outterRange));

            Assert.Null(exception);
        }

        [Fact]
        public void EntityIsInRangeCollectionTest()
        {
            var testID = (EntityID)7;
            var testCollection = new List<Range<EntityID>> { new Range<EntityID>(0, 5), new Range<EntityID>(6, 10) };

            var exception = Record.Exception(() => Precondition.IsInRange(testID, testCollection));

            Assert.Null(exception);
        }

        [Fact]
        public void RangeIsInRangeCollectionTest()
        {
            var innerRange = new Range<EntityID>(1, 4);
            var testCollection = new List<Range<EntityID>> { new Range<EntityID>(0, 5), new Range<EntityID>(6, 10) };

            var exception = Record.Exception(() => Precondition.IsInRange(innerRange, testCollection));

            Assert.Null(exception);
        }

        [Fact]
        public void EntityIsInRangeThrowsOnOutOfRangeTest()
        {
            var testID = (EntityID)12;
            var testRange = new Range<EntityID>(0, 10);

            Assert.Throws<ArgumentOutOfRangeException>(() => { Precondition.IsInRange(testID, testRange); });
        }

        [Fact]
        public void RangeIsInRangeThrowsOnOutOfRangeTest()
        {
            var innerRange = new Range<EntityID>(0, 10);
            var outterRange = new Range<EntityID>(1, 9);

            Assert.Throws<ArgumentOutOfRangeException>(() => { Precondition.IsInRange(innerRange, outterRange); });
        }

        [Fact]
        public void EntityIsInRangeCollectionThrowsOnOutOfRangeTest()
        {
            var testID = (EntityID)12;
            var testCollection = new List<Range<EntityID>> { new Range<EntityID>(0, 5), new Range<EntityID>(6, 10) };

            Assert.Throws<ArgumentOutOfRangeException>(() => { Precondition.IsInRange(testID, testCollection); });
        }

        [Fact]
        public void RangeIsInRangeCollectionThrowsOnOutOfRangeTest()
        {
            var innerRange = new Range<EntityID>(0, 10);
            var testCollection = new List<Range<EntityID>> { new Range<EntityID>(1, 5), new Range<EntityID>(6, 9) };

            Assert.Throws<ArgumentOutOfRangeException>(() => { Precondition.IsInRange(innerRange, testCollection); });
        }

        [Fact]
        public void IsOfTypeTest()
        {
            var exception = Record.Exception(() => Precondition.IsOfType<DerivedType, BaseType>());

            Assert.Null(exception);
        }

        [Fact]
        public void IsOfTypeThrowsOnNotSubtypeTest()
        {
            Assert.Throws<InvalidCastException>(() => Precondition.IsOfType<BaseType, DerivedType>());
        }

        [Fact]
        public void IsOfTypeSystemTest()
        {
            var exception = Record.Exception(() => Precondition.IsOfType<string, object>());

            Assert.Null(exception);
        }

        [Fact]
        public void IsOfTypeThrowsOnNotSubtypeSystemTest()
        {
            Assert.Throws<InvalidCastException>(() => Precondition.IsOfType<object, string>());
        }

        [Fact]
        public void IsOfTypeThrowsOnNotSubtypeValueTypeTest()
        {
            Assert.Throws<InvalidCastException>(() => Precondition.IsOfType<float, int>());
        }

        [Fact]
        public void AreInRangeTest()
        {
            var testIDCollection = new List<EntityID> { 0, 1, 5, 6, 9, 10 };
            var testRange = new Range<EntityID>(0, 10);

            var exception = Record.Exception(() => Precondition.AreInRange(testIDCollection, testRange));

            Assert.Null(exception);
        }

        [Fact]
        public void AreInRangeCollectionTest()
        {
            var testIDCollection = new List<EntityID> { 0, 1, 2, 7, 8, 10 };
            var testCollection = new List<Range<EntityID>> { new Range<EntityID>(0, 5), new Range<EntityID>(6, 10) };

            var exception = Record.Exception(() => Precondition.AreInRange(testIDCollection, testCollection));

            Assert.Null(exception);
        }

        [Fact]
        public void AreInRangeThrowsOnSingleOutOfRangeTest()
        {
            var testIDCollection = new List<EntityID> { 0, 1, 5, 9, 10, 20 };
            var testRange = new Range<EntityID>(0, 10);

            Assert.Throws<ArgumentOutOfRangeException>(() => Precondition.AreInRange(testIDCollection, testRange));
        }

        [Fact]
        public void AreInRangeThrowsOnSingleOutOfRangeCollectionTest()
        {
            var testIDCollection = new List<EntityID> { 0, 1, 3, 8, 10, 20 };
            var testCollection = new List<Range<EntityID>> { new Range<EntityID>(0, 5), new Range<EntityID>(6, 10) };

            Assert.Throws<ArgumentOutOfRangeException>(() => Precondition.AreInRange(testIDCollection, testCollection));
        }

        [Fact]
        public void MustBePositiveTest()
        {
            var testValue = 1;

            var exception = Record.Exception(() => Precondition.MustBePositive(testValue));

            Assert.Null(exception);
        }

        [Fact]
        public void MustBePositiveThrowsOnZeroTest()
        {
            var testValue = 0;

            Assert.Throws<ArgumentOutOfRangeException>(() => Precondition.MustBePositive(testValue));
        }

        [Fact]
        public void MustBePositiveThrowsOnNegativeTest()
        {
            var testValue = -1;

            Assert.Throws<ArgumentOutOfRangeException>(() => Precondition.MustBePositive(testValue));
        }


        [Fact]
        public void IsNotEmptyTest()
        {
            var testValue = new List<EntityID> { 0, 1, 2 };

            var exception = Record.Exception(() => Precondition.IsNotEmpty(testValue));

            Assert.Null(exception);
        }


        [Fact]
        public void IsNotEmptyStringTest()
        {
            var testValue = "will pass";

            var exception = Record.Exception(() => Precondition.IsNotEmpty(testValue));

            Assert.Null(exception);
        }

        [Fact]
        public void IsNotEmptyThrowsOnEmptyTest()
        {
            var testValue = new List<EntityID>();

            Assert.Throws<IndexOutOfRangeException>(() => Precondition.IsNotEmpty(testValue));
        }

        [Fact]
        public void IsNotEmptyStringThrowsOnEmptyStringTest()
        {
            var testValue = "";

            Assert.Throws<IndexOutOfRangeException>(() => Precondition.IsNotEmpty(testValue));
        }

        [Fact]
        public void IsNullTest()
        {
            var testValue = "will pass";

            var exception = Record.Exception(() => Precondition.IsNotNull(testValue));

            Assert.Null(exception);
        }

        [Fact]
        public void IsNullThrowsOnNullTest()
        {
            object testValue = null;

            Assert.Throws<ArgumentNullException>(() => Precondition.IsNotNull(testValue));
        }
    }
}
