using ParquetClassLibrary.Sandbox.Parquets;
using Xunit;

namespace ParquetUnitTests.Sandbox.Parquets
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
    }
}
