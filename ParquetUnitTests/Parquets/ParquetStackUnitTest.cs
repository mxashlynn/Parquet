using ParquetClassLibrary.Parquets;
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
            var stack1 = new ParquetStack(TestEntities.TestFloor.ID,
                                          TestEntities.TestBlock.ID,
                                          TestEntities.TestFurnishing.ID,
                                          TestEntities.TestCollectible.ID);
            var stack2 = new ParquetStack(TestEntities.TestFloor.ID,
                                          TestEntities.TestBlock.ID,
                                          TestEntities.TestFurnishing.ID,
                                          TestEntities.TestCollectible.ID);

            Assert.Equal(stack1, stack2);
        }

        [Fact]
        internal void DifferingStacksAreUnequalTest()
        {
            var stack1 = new ParquetStack(TestEntities.TestFloor.ID,
                                          TestEntities.TestBlock.ID,
                                          TestEntities.TestFurnishing.ID,
                                          TestEntities.TestCollectible.ID);
            var stack2 = new ParquetStack(TestEntities.TestFloor.ID - 1,
                                          TestEntities.TestBlock.ID - 1,
                                          TestEntities.TestFurnishing.ID - 1,
                                          TestEntities.TestCollectible.ID - 1);

            Assert.NotEqual(stack1, stack2);
        }
    }
}
