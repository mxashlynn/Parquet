using ParquetClassLibrary.Sandbox;
using ParquetClassLibrary.Sandbox.Parquets;
using ParquetClassLibrary.Stubs;
using Xunit;

namespace ParquetUnitTests.Sandbox
{
    public class RegionMapUnitTest
    {
        #region Values for Tests
        private readonly Color TestColor = new Color(1f, 0.5f, 0.1f, 0.9f);
        private readonly string TestTitle = "Erdrea";
        #endregion

        #region Initialization
        [Fact]
        public void NewDefaultRegionMapTest()
        {
            var defaultRegion = new RegionMap();

            Assert.Equal(RegionMap.DefaultTitle, defaultRegion.Title);
            Assert.Equal(Color.White, defaultRegion.Background);
        }

        [Fact]
        public void NewNullRegionMapTest()
        {
            var defaultRegion = new RegionMap(null, null);

            Assert.Equal(RegionMap.DefaultTitle, defaultRegion.Title);
            Assert.Equal(Color.White, defaultRegion.Background);
        }

        [Fact]
        public void NewCustomRegionMapTest()
        {
            var defaultRegion = new RegionMap(TestTitle, TestColor);

            Assert.Equal(TestTitle, defaultRegion.Title);
            Assert.Equal(TestColor, defaultRegion.Background);
        }
        #endregion

        #region Parquets Replacement Methods
        [Fact]
        public void TrySetFloorFailsWithNullParquetTest()
        {
            var region = new RegionMap();

            bool result = region.TrySetFloor(null, Vector2Int.ZeroVector);

            Assert.False(result);
        }

        [Fact]
        public void TrySetFloorFailsWithOutOfBoundsPositionTest()
        {
            var region = new RegionMap();
            var position = new Vector2Int(-1, -1);
            var parquet = new Floor();

            bool result = region.TrySetFloor(parquet, position);

            Assert.False(result);
        }

        [Fact]
        public void TrySetFloorSucceedsWithDefaultParquetAndPositionTest()
        {
            var region = new RegionMap();
            var parquet = new Floor();

            bool result = region.TrySetFloor(parquet, Vector2Int.ZeroVector);

            Assert.True(result);
        }

        [Fact]
        public void TrySetBlockFailsWithNullParquetTest()
        {
            var region = new RegionMap();

            bool result = region.TrySetBlock(null, Vector2Int.ZeroVector);

            Assert.False(result);
        }

        [Fact]
        public void TrySetBlockFailsWithOutOfBoundsPositionTest()
        {
            var region = new RegionMap();
            var position = new Vector2Int(-1, -1);
            var parquet = new Block();

            bool result = region.TrySetBlock(parquet, position);

            Assert.False(result);
        }

        [Fact]
        public void TrySetBlockSucceedsWithDefaultParquetAndPositionTest()
        {
            var region = new RegionMap();
            var parquet = new Block();

            bool result = region.TrySetBlock(parquet, Vector2Int.ZeroVector);

            Assert.True(result);
        }

        [Fact]
        public void TrySetFurnishingFailsWithNullParquetTest()
        {
            var region = new RegionMap();

            bool result = region.TrySetFurnishing(null, Vector2Int.ZeroVector);

            Assert.False(result);
        }

        [Fact]
        public void TrySetFurnishingFailsWithOutOfBoundsPositionTest()
        {
            var region = new RegionMap();
            var position = new Vector2Int(-1, -1);
            var parquet = new Furnishing();

            bool result = region.TrySetFurnishing(parquet, position);

            Assert.False(result);
        }

        [Fact]
        public void TrySetFurnishingSucceedsWithDefaultParquetAndPositionTest()
        {
            var region = new RegionMap();
            var parquet = new Furnishing();

            bool result = region.TrySetFurnishing(parquet, Vector2Int.ZeroVector);

            Assert.True(result);
        }

        [Fact]
        public void TrySetCollectableFailsWithNullParquetTest()
        {
            var region = new RegionMap();

            bool result = region.TrySetCollectable(null, Vector2Int.ZeroVector);

            Assert.False(result);
        }

        [Fact]
        public void TrySetCollectableFailsWithOutOfBoundsPositionTest()
        {
            var region = new RegionMap();
            var position = new Vector2Int(-1, -1);
            var parquet = new Collectable();

            bool result = region.TrySetCollectable(parquet, position);

            Assert.False(result);
        }

        [Fact]
        public void TrySetCollectableSucceedsWithDefaultParquetAndPositionTest()
        {
            var region = new RegionMap();
            var parquet = new Collectable();

            bool result = region.TrySetCollectable(parquet, Vector2Int.ZeroVector);

            Assert.True(result);
        }

        [Fact]
        public void TryRemoveFloorFailsWithOutOfBoundsPositionTest()
        {
            var region = new RegionMap();
            var position = new Vector2Int(-1, -1);

            bool result = region.TryRemoveFloor(position);

            Assert.False(result);
        }

        [Fact]
        public void TryRemoveFloorSucceedsWithDefaultPositionTest()
        {
            var region = new RegionMap();

            bool result = region.TryRemoveFloor(Vector2Int.ZeroVector);

            Assert.True(result);
        }

        [Fact]
        public void TryRemoveBlockFailsWithOutOfBoundsPositionTest()
        {
            var region = new RegionMap();
            var position = new Vector2Int(-1, -1);

            bool result = region.TryRemoveBlock(position);

            Assert.False(result);
        }

        [Fact]
        public void TryRemoveBlockSucceedsWithDefaultPositionTest()
        {
            var region = new RegionMap();

            bool result = region.TryRemoveBlock(Vector2Int.ZeroVector);

            Assert.True(result);
        }

        [Fact]
        public void TryRemoveFurnishingFailsWithOutOfBoundsPositionTest()
        {
            var region = new RegionMap();
            var position = new Vector2Int(-1, -1);

            bool result = region.TryRemoveFurnishing(position);

            Assert.False(result);
        }

        [Fact]
        public void TryRemoveFurnishingSucceedsWithDefaultPositionTest()
        {
            var region = new RegionMap();

            bool result = region.TryRemoveFurnishing(Vector2Int.ZeroVector);

            Assert.True(result);
        }

        [Fact]
        public void TryRemoveCollectableFailsWithOutOfBoundsPositionTest()
        {
            var region = new RegionMap();
            var position = new Vector2Int(-1, -1);

            bool result = region.TryRemoveCollectable(position);

            Assert.False(result);
        }

        [Fact]
        public void TryRemoveCollectableSucceedsWithDefaultPositionTest()
        {
            var region = new RegionMap();

            bool result = region.TryRemoveCollectable(Vector2Int.ZeroVector);

            Assert.True(result);
        }
        #endregion

        #region Parquet Adjustment Methods
        [Fact]
        public void TryToDigFailsWithEmptyMapTest()
        {
            var region = new RegionMap();

            bool result = region.TryToDig(Vector2Int.ZeroVector);

            Assert.False(result);
        }

        [Fact]
        public void TryToDigFailsWithInvalidPostionTest()
        {
            var region = new RegionMap();
            region.FillTestPattern();
            var position = new Vector2Int(-1, -1);

            bool result = region.TryToDig(position);

            Assert.False(result);
        }

        [Fact]
        public void TryToDigSucceedsWithInitializedMapAndDefaultPositionTest()
        {
            var region = new RegionMap();
            region.FillTestPattern();

            bool result = region.TryToDig(Vector2Int.ZeroVector);

            Assert.True(result);
        }

        [Fact]
        public void TryToFillFailsWithEmptyMapTest()
        {
            var region = new RegionMap();

            bool result = region.TryToFill(Vector2Int.ZeroVector);

            Assert.False(result);
        }

        [Fact]
        public void TryToFillFailsWithInvalidPostionTest()
        {
            var region = new RegionMap();
            region.FillTestPattern();
            var position = new Vector2Int(-1, -1);

            bool result = region.TryToFill(position);

            Assert.False(result);
        }

        [Fact]
        public void TryToFillSucceedsWithInitializedMapAndDefaultPositionTest()
        {
            var region = new RegionMap();
            region.FillTestPattern();

            bool result = region.TryToFill(Vector2Int.ZeroVector);

            Assert.True(result);
        }

        [Fact]
        public void TryToReduceToughnessFailsWithEmptyMapTest()
        {
            var region = new RegionMap();

            bool result = region.TryToReduceToughness(Vector2Int.ZeroVector, 1);

            Assert.False(result);
        }

        [Fact]
        public void TryToReduceToughnessFailsWithInvalidPostionTest()
        {
            var region = new RegionMap();
            region.FillTestPattern();
            var position = new Vector2Int(-1, -1);

            bool result = region.TryToReduceToughness(position, 1);

            Assert.False(result);
        }

        [Fact]
        public void TryToReduceToughnessSucceedsWithInitializedMapAndDefaultPositionTest()
        {
            var region = new RegionMap();
            region.FillTestPattern();

            bool result = region.TryToReduceToughness(Vector2Int.ZeroVector, 1);

            Assert.True(result);
        }

        [Fact]
        public void TryToRestoreToughnessFailsWithEmptyMapTest()
        {
            var region = new RegionMap();

            bool result = region.TryToRestoreToughness(Vector2Int.ZeroVector);

            Assert.False(result);
        }

        [Fact]
        public void TryToRestoreToughnessFailsWithInvalidPostionTest()
        {
            var region = new RegionMap();
            region.FillTestPattern();
            var position = new Vector2Int(-1, -1);

            bool result = region.TryToRestoreToughness(position);

            Assert.False(result);
        }

        [Fact]
        public void TryToRestoreToughnessSucceedsWithInitializedMapAndDefaultPositionTest()
        {
            var region = new RegionMap();
            region.FillTestPattern();

            bool result = region.TryToRestoreToughness(Vector2Int.ZeroVector);

            Assert.True(result);
        }
        #endregion

        #region State Query Methods
        [Fact]
        public void IsFloorWalkableReturnsFalseOnInvalidPositionTest()
        {
            var region = new RegionMap();
            region.FillTestPattern();
            var position = new Vector2Int(-1, -1);

            bool result = region.IsFloorWalkable(position);

            Assert.False(result);
        }

        [Fact]
        public void IsFloorWalkableReturnsFalseOnEmptyMapTest()
        {
            var region = new RegionMap();

            bool result = region.IsFloorWalkable(Vector2Int.ZeroVector);

            Assert.False(result);
        }

        [Fact]
        public void IsFloorAHoleReturnsFalseOnInvalidPositionTest()
        {
            var region = new RegionMap();
            region.FillTestPattern();
            var position = new Vector2Int(-1, -1);

            bool result = region.IsFloorAHole(position);

            Assert.False(result);
        }

        [Fact]
        public void IsFloorAHoleReturnsFalseOnEmptyMapTest()
        {
            var region = new RegionMap();

            bool result = region.IsFloorAHole(Vector2Int.ZeroVector);

            Assert.False(result);
        }

        [Fact]
        public void IsBlockFlammableReturnsFalseOnInvalidPositionTest()
        {
            var region = new RegionMap();
            region.FillTestPattern();
            var position = new Vector2Int(-1, -1);

            bool result = region.IsBlockFlammable(position);

            Assert.False(result);
        }

        [Fact]
        public void IsBlockFlammableReturnsFalseOnEmptyMapTest()
        {
            var region = new RegionMap();

            bool result = region.IsBlockFlammable(Vector2Int.ZeroVector);

            Assert.False(result);
        }

        [Fact]
        public void IsBlockALiquidReturnsFalseOnInvalidPositionTest()
        {
            var region = new RegionMap();
            region.FillTestPattern();
            var position = new Vector2Int(-1, -1);

            bool result = region.IsBlockALiquid(position);

            Assert.False(result);
        }

        [Fact]
        public void IsBlockALiquidReturnsFalseOnEmptyMapTest()
        {
            var region = new RegionMap();

            bool result = region.IsBlockALiquid(Vector2Int.ZeroVector);

            Assert.False(result);
        }


        [Fact]
        public void GetBlockToughnessReturnsZeroOnInvalidPositionTest()
        {
            var region = new RegionMap();
            region.FillTestPattern();
            var position = new Vector2Int(-1, -1);

            var result = region.GetBlockToughnessAtPosition(position);

            Assert.Equal(0, result);
        }

        [Fact]
        public void GetBlockToughnessReturnsZeroOnEmptyMapTest()
        {
            var region = new RegionMap();

            var result = region.GetBlockToughnessAtPosition(Vector2Int.ZeroVector);

            Assert.Equal(0, result);
        }

        [Fact]
        public void GetCollectableReturnsNullOnInvalidPositionTest()
        {
            var region = new RegionMap();
            region.FillTestPattern();
            var position = new Vector2Int(-1, -1);

            var result = region.GetCollectableAtPosition(position);

            Assert.Null(result);
        }

        [Fact]
        public void GetCollectableReturnsNullOnEmptyMapTest()
        {
            var region = new RegionMap();

            var result = region.GetCollectableAtPosition(Vector2Int.ZeroVector);

            Assert.Null(result);
        }
        #endregion
    }
}