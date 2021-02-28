using System;
using Parquet;
using Parquet.Parquets;
using Xunit;

namespace ParquetUnitTests.Parquets
{
    /// <summary>
    /// Unit tests <see cref="FloorModel"/>.
    /// </summary>
    public class FloorModelUnitTest
    {
        #region Test Values
        /// <summary>Identifier used when creating a new floor.</summary>
        private static readonly ModelID newFloorID = TestModels.TestFloor.ID - 1;
        #endregion

        [Fact]
        internal void ValidFloorIDsArePermittedTest()
        {
            var testFloor = new FloorModel(newFloorID, "will be created", "", "");

            Assert.NotNull(testFloor);
        }

        [Fact]
        internal void InvalidFloorIDsRaiseExceptionTest()
        {
            var badFloorID = TestModels.TestBlock.ID;

            void TestCode()
            {
                var _ = new CollectibleModel(badFloorID, "will fail", "", "");
            }

            Assert.Throws<ArgumentOutOfRangeException>(TestCode);
        }
    }
}
