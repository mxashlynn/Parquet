using Parquet.Parquets;
using Xunit;

namespace ParquetUnitTests.Parquets
{
    /// <summary>
    /// Unit tests <see cref="ParquetModelPack"/>.
    /// </summary>
    public class ParquetPackUnitTest
    {
        [Fact]
        internal void ParquetPackIsEmptyWhenAllFieldsAreNullTest()
        {
            var pack = new ParquetModelPack();

            Assert.True(pack.IsEmpty);
        }

        [Fact]
        internal void ParquetPackDotEmptyIsEmpty()
        {
            Assert.True(ParquetModelPack.Empty.IsEmpty);
        }

        [Fact]
        internal void IdenticalStacksAreEqualTest()
        {
            var pack1 = new ParquetModelPack(TestModels.TestFloor.ID,
                                        TestModels.TestBlock.ID,
                                        TestModels.TestFurnishing.ID,
                                        TestModels.TestCollectible.ID);
            var pack2 = new ParquetModelPack(TestModels.TestFloor.ID,
                                        TestModels.TestBlock.ID,
                                        TestModels.TestFurnishing.ID,
                                        TestModels.TestCollectible.ID);

            Assert.Equal(pack1, pack2);
        }

        [Fact]
        internal void DifferingStacksAreUnequalTest()
        {
            var pack1 = new ParquetModelPack(TestModels.TestFloor.ID,
                                        TestModels.TestBlock.ID,
                                        TestModels.TestFurnishing.ID,
                                        TestModels.TestCollectible.ID);
            var pack2 = new ParquetModelPack(TestModels.TestFloor.ID - 1,
                                        TestModels.TestBlock.ID - 1,
                                        TestModels.TestFurnishing.ID - 1,
                                        TestModels.TestCollectible.ID - 1);

            Assert.NotEqual(pack1, pack2);
        }
    }
}
