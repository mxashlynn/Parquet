using ParquetClassLibrary.Sandbox.Parquets;
using Xunit;

namespace ParquetUnitTests.Sandbox.Parquets
{
    /// <summary>
    /// Simple container for one of each layer of parquet that can occupy the same position.
    /// </summary>
    public class ParquetStackUnitTest
    {
        [Fact]
        internal void ParquetStackIsEmptyWhenAllFieldsAreNullTest()
        {
            var stack = new ParquetStack();

            Assert.True(stack.IsEmpty);
        }
    }
}
