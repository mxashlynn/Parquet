using Parquet.Parquets;
using Xunit;

namespace ParquetUnitTests.Parquets
{
    public class ParquetPackUnitTest
    {
        [Fact]
        internal void ParquetPackIsEmptyWhenAllFieldsAreNullTest()
        {
            var pack = new ParquetPack();

            Assert.True(pack.IsEmpty);
        }

        [Fact]
        internal void ParquetPackDotEmptyIsEmpty()
        {
            Assert.True(ParquetPack.Empty.IsEmpty);
        }

        [Fact]
        internal void IdenticalStacksAreEqualTest()
        {
            var pack1 = new ParquetPack(TestModels.TestFloor.ID,
                                        TestModels.TestBlock.ID,
                                        TestModels.TestFurnishing.ID,
                                        TestModels.TestCollectible.ID);
            var pack2 = new ParquetPack(TestModels.TestFloor.ID,
                                        TestModels.TestBlock.ID,
                                        TestModels.TestFurnishing.ID,
                                        TestModels.TestCollectible.ID);

            Assert.Equal(pack1, pack2);
        }

        [Fact]
        internal void DifferingStacksAreUnequalTest()
        {
            var pack1 = new ParquetPack(TestModels.TestFloor.ID,
                                        TestModels.TestBlock.ID,
                                        TestModels.TestFurnishing.ID,
                                        TestModels.TestCollectible.ID);
            var pack2 = new ParquetPack(TestModels.TestFloor.ID - 1,
                                        TestModels.TestBlock.ID - 1,
                                        TestModels.TestFurnishing.ID - 1,
                                        TestModels.TestCollectible.ID - 1);

            Assert.NotEqual(pack1, pack2);
        }
    }
}
