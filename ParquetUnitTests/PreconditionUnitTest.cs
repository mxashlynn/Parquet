using System;
using System.Collections.Generic;
using ParquetClassLibrary;
using Xunit;

namespace ParquetUnitTests
{
    public class PreconditionUnitTest
    {
        #region Test Values
        public class BaseType { };
        public class DerivedType : BaseType { };
        #endregion

        [Fact]
        public void ModelIsInRangeTest()
        {
            var testID = (ModelID)6;
            var testRange = new Range<ModelID>(0, 10);

            var exception = Record.Exception(() => Precondition.IsInRange(testID, testRange, nameof(testID)));

            Assert.Null(exception);
        }

        [Fact]
        public void RangeIsInRangeTest()
        {
            var innerRange = new Range<ModelID>(1, 9);
            var outterRange = new Range<ModelID>(0, 10);

            var exception = Record.Exception(() => Precondition.IsInRange(innerRange, outterRange, nameof(innerRange)));

            Assert.Null(exception);
        }

        [Fact]
        public void ModelIsInRangeCollectionTest()
        {
            var testID = (ModelID)7;
            var testCollection = new List<Range<ModelID>> { new Range<ModelID>(0, 5), new Range<ModelID>(6, 10) };

            var exception = Record.Exception(() => Precondition.IsInRange(testID, testCollection, nameof(testID)));

            Assert.Null(exception);
        }

        [Fact]
        public void RangeIsInRangeCollectionTest()
        {
            var innerRange = new Range<ModelID>(1, 4);
            var testCollection = new List<Range<ModelID>> { new Range<ModelID>(0, 5), new Range<ModelID>(6, 10) };

            var exception = Record.Exception(() => Precondition.IsInRange(innerRange, testCollection, nameof(innerRange)));

            Assert.Null(exception);
        }

        [Fact]
        public void ModelIsInRangeThrowsOnOutOfRangeTest()
        {
            var testID = (ModelID)12;
            var testRange = new Range<ModelID>(0, 10);

            Assert.Throws<ArgumentOutOfRangeException>(() => { Precondition.IsInRange(testID, testRange, nameof(testID)); });
        }

        [Fact]
        public void RangeIsInRangeThrowsOnOutOfRangeTest()
        {
            var innerRange = new Range<ModelID>(0, 10);
            var outterRange = new Range<ModelID>(1, 9);

            Assert.Throws<ArgumentOutOfRangeException>(() => { Precondition.IsInRange(innerRange, outterRange, nameof(innerRange)); });
        }

        [Fact]
        public void ModelIsInRangeCollectionThrowsOnOutOfRangeTest()
        {
            var testID = (ModelID)12;
            var testCollection = new List<Range<ModelID>> { new Range<ModelID>(0, 5), new Range<ModelID>(6, 10) };

            Assert.Throws<ArgumentOutOfRangeException>(() => { Precondition.IsInRange(testID, testCollection, nameof(testID)); });
        }

        [Fact]
        public void RangeIsInRangeCollectionThrowsOnOutOfRangeTest()
        {
            var innerRange = new Range<ModelID>(0, 10);
            var testCollection = new List<Range<ModelID>> { new Range<ModelID>(1, 5), new Range<ModelID>(6, 9) };

            Assert.Throws<ArgumentOutOfRangeException>(() => { Precondition.IsInRange(innerRange, testCollection, nameof(innerRange)); });
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
            var testIDCollection = new List<ModelID> { 0, 1, 5, 6, 9, 10 };
            var testRange = new Range<ModelID>(0, 10);

            var exception = Record.Exception(() => Precondition.AreInRange(testIDCollection, testRange, nameof(testIDCollection)));

            Assert.Null(exception);
        }

        [Fact]
        public void AreInRangeCollectionTest()
        {
            var testIDCollection = new List<ModelID> { 0, 1, 2, 7, 8, 10 };
            var testCollection = new List<Range<ModelID>> { new Range<ModelID>(0, 5), new Range<ModelID>(6, 10) };

            var exception = Record.Exception(() => Precondition.AreInRange(testIDCollection, testCollection, nameof(testIDCollection)));

            Assert.Null(exception);
        }

        [Fact]
        public void AreInRangeThrowsOnSingleOutOfRangeTest()
        {
            var testIDCollection = new List<ModelID> { 0, 1, 5, 9, 10, 20 };
            var testRange = new Range<ModelID>(0, 10);

            Assert.Throws<ArgumentOutOfRangeException>(() => Precondition.AreInRange(testIDCollection, testRange, nameof(testIDCollection)));
        }

        [Fact]
        public void AreInRangeThrowsOnSingleOutOfRangeCollectionTest()
        {
            var testIDCollection = new List<ModelID> { 0, 1, 3, 8, 10, 20 };
            var testCollection = new List<Range<ModelID>> { new Range<ModelID>(0, 5), new Range<ModelID>(6, 10) };

            Assert.Throws<ArgumentOutOfRangeException>(() => Precondition.AreInRange(testIDCollection, testCollection, nameof(testIDCollection)));
        }

        [Fact]
        public void IsNotNoneTest()
        {
            var testValue0 = int.MaxValue;
            var testValue1 = int.MinValue;
            var testValue2 = 1;

            var exception0 = Record.Exception(() => Precondition.IsNotNone(testValue0));
            var exception1 = Record.Exception(() => Precondition.IsNotNone(testValue1));
            var exception2 = Record.Exception(() => Precondition.IsNotNone(testValue2));

            Assert.Null(exception0);
            Assert.Null(exception1);
            Assert.Null(exception2);
        }

        [Fact]
        public void IsNotNoneThrowsOnNoneTest()
        {
            var testValue = ModelID.None;

            Assert.Throws<ArgumentOutOfRangeException>(() => Precondition.IsNotNone(testValue));
        }

        [Fact]
        public void MustBeNonNegativeTest()
        {
            var testValue0 = 0;
            var testValue1 = 1;

            var exception0 = Record.Exception(() => Precondition.MustBeNonNegative(testValue0));
            var exception1 = Record.Exception(() => Precondition.MustBeNonNegative(testValue1));

            Assert.Null(exception0);
            Assert.Null(exception1);
        }

        [Fact]
        public void MustBeNonNegativeThrowsOnNegativeTest()
        {
            var testValue = -1;

            Assert.Throws<ArgumentOutOfRangeException>(() => Precondition.MustBeNonNegative(testValue));
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
            var testValue = new List<ModelID> { 0, 1, 2 };

            var exception = Record.Exception(() => Precondition.IsNotNullOrEmpty(testValue, nameof(testValue)));

            Assert.Null(exception);
        }


        [Fact]
        public void IsNotEmptyStringTest()
        {
            var testValue = "will pass";

            var exception = Record.Exception(() => Precondition.IsNotNullOrEmpty(testValue, nameof(testValue)));

            Assert.Null(exception);
        }

        [Fact]
        public void IsNotEmptyThrowsOnEmptyTest()
        {
            var testValue = new List<ModelID>();

            Assert.Throws<IndexOutOfRangeException>(() => Precondition.IsNotNullOrEmpty(testValue, nameof(testValue)));
        }

        [Fact]
        public void IsNotEmptyStringThrowsOnEmptyStringTest()
        {
            var testValue = "";

            Assert.Throws<IndexOutOfRangeException>(() => Precondition.IsNotNullOrEmpty(testValue, nameof(testValue)));
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
