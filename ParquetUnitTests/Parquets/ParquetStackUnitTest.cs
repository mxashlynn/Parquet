using Parquet.Parquets;
using Xunit;

namespace ParquetUnitTests.Parquets
{
    public class ParquetStackUnitTest
    {
        [Fact]
        internal void ParquetStackIsEmptyWhenAllFieldsAreNullTest()
        {
            var stack = new ParquetStack();

            Assert.True(stack.IsEmpty);
        }

        [Fact]
        internal void ParquetStackDotEmptyIsEmpty()
        {
            Assert.True(ParquetStack.Empty.IsEmpty);
        }

        [Fact]
        internal void IdenticalStacksAreEqualTest()
        {
            var stack1 = new ParquetStack(TestModels.TestFloor.ID,
                                          TestModels.TestBlock.ID,
                                          TestModels.TestFurnishing.ID,
                                          TestModels.TestCollectible.ID);
            var stack2 = new ParquetStack(TestModels.TestFloor.ID,
                                          TestModels.TestBlock.ID,
                                          TestModels.TestFurnishing.ID,
                                          TestModels.TestCollectible.ID);

            Assert.Equal(stack1, stack2);
        }

        [Fact]
        internal void DifferingStacksAreUnequalTest()
        {
            var stack1 = new ParquetStack(TestModels.TestFloor.ID,
                                          TestModels.TestBlock.ID,
                                          TestModels.TestFurnishing.ID,
                                          TestModels.TestCollectible.ID);
            var stack2 = new ParquetStack(TestModels.TestFloor.ID - 1,
                                          TestModels.TestBlock.ID - 1,
                                          TestModels.TestFurnishing.ID - 1,
                                          TestModels.TestCollectible.ID - 1);

            Assert.NotEqual(stack1, stack2);
        }
    }
}
