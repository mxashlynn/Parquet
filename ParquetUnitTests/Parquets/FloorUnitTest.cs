using System;
using Parquet;
using Parquet.Parquets;
using Xunit;

namespace ParquetUnitTests.Parquets
{
    public class FloorUnitTest
    {
        #region Test Values
        /// <summary>Identifier used when creating a new floor.</summary>
        private static readonly ModelID newFloorID = TestModels.TestFloor.ID - 1;
        #endregion

        [Fact]
        public void ValidFloorIDsArePermittedTest()
        {
            var testFloor = new FloorModel(newFloorID, "will be created", "", "");

            Assert.NotNull(testFloor);
        }

        [Fact]
        public void InvalidFloorIDsRaiseExceptionTest()
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
