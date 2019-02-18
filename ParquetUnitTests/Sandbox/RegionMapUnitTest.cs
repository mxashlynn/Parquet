using Xunit;
using ParquetClassLibrary.Sandbox;
using ParquetClassLibrary.Sandbox.SpecialPoints;
using ParquetClassLibrary.Sandbox.Parquets;
using ParquetClassLibrary.Stubs;

namespace ParquetUnitTests.Sandbox
{
    public class RegionMapUnitTest
    {
        #region Values for Tests
        private readonly Vector2Int InvalidPosition = new Vector2Int(-1, -1);
        private readonly Color TestColor = new Color(255, 128, 26, 230);
        private const string TestTitle = "New Region";
        private const string KnownGoodJsonString = "{\"DataVersion\":\"0.1.0\",\"<Title>k__BackingField\":\"New Region\",\"<Background>k__BackingField\":{\"r\":255,\"g\":255,\"b\":255,\"a\":255},\"<Revision>k__BackingField\":1,\"_specialPoints\":[],\"_floorLayer\":[[{\"floorType\":2,\"isWalkable\":false,\"isHole\":false,\"tool\":0},{\"floorType\":2,\"isWalkable\":false,\"isHole\":false,\"tool\":0},{\"floorType\":2,\"isWalkable\":false,\"isHole\":false,\"tool\":0},{\"floorType\":2,\"isWalkable\":false,\"isHole\":false,\"tool\":0},{\"floorType\":2,\"isWalkable\":false,\"isHole\":false,\"tool\":0}],[{\"floorType\":2,\"isWalkable\":false,\"isHole\":false,\"tool\":0},{\"floorType\":2,\"isWalkable\":false,\"isHole\":false,\"tool\":0},{\"floorType\":2,\"isWalkable\":false,\"isHole\":false,\"tool\":0},{\"floorType\":2,\"isWalkable\":false,\"isHole\":false,\"tool\":0},{\"floorType\":2,\"isWalkable\":false,\"isHole\":false,\"tool\":0}],[{\"floorType\":2,\"isWalkable\":false,\"isHole\":false,\"tool\":0},{\"floorType\":2,\"isWalkable\":false,\"isHole\":false,\"tool\":0},{\"floorType\":2,\"isWalkable\":false,\"isHole\":false,\"tool\":0},{\"floorType\":2,\"isWalkable\":false,\"isHole\":false,\"tool\":0},{\"floorType\":2,\"isWalkable\":false,\"isHole\":false,\"tool\":0}],[{\"floorType\":2,\"isWalkable\":false,\"isHole\":false,\"tool\":0},{\"floorType\":2,\"isWalkable\":false,\"isHole\":false,\"tool\":0},{\"floorType\":2,\"isWalkable\":false,\"isHole\":false,\"tool\":0},{\"floorType\":2,\"isWalkable\":false,\"isHole\":false,\"tool\":0},{\"floorType\":2,\"isWalkable\":false,\"isHole\":false,\"tool\":0}],[{\"floorType\":2,\"isWalkable\":false,\"isHole\":false,\"tool\":0},{\"floorType\":2,\"isWalkable\":false,\"isHole\":false,\"tool\":0},{\"floorType\":2,\"isWalkable\":false,\"isHole\":false,\"tool\":0},{\"floorType\":2,\"isWalkable\":false,\"isHole\":false,\"tool\":0},{\"floorType\":2,\"isWalkable\":false,\"isHole\":false,\"tool\":0}]],\"_blockLayer\":[[{\"blockType\":5,\"IsFlammable\":false,\"IsLiquid\":false,\"ToolType\":0,\"MaxToughness\":0,\"Toughness\":0},{\"blockType\":5,\"IsFlammable\":false,\"IsLiquid\":false,\"ToolType\":0,\"MaxToughness\":0,\"Toughness\":0},{\"blockType\":5,\"IsFlammable\":false,\"IsLiquid\":false,\"ToolType\":0,\"MaxToughness\":0,\"Toughness\":0},{\"blockType\":5,\"IsFlammable\":false,\"IsLiquid\":false,\"ToolType\":0,\"MaxToughness\":0,\"Toughness\":0},{\"blockType\":5,\"IsFlammable\":false,\"IsLiquid\":false,\"ToolType\":0,\"MaxToughness\":0,\"Toughness\":0}],[{\"blockType\":5,\"IsFlammable\":false,\"IsLiquid\":false,\"ToolType\":0,\"MaxToughness\":0,\"Toughness\":0},null,null,null,{\"blockType\":5,\"IsFlammable\":false,\"IsLiquid\":false,\"ToolType\":0,\"MaxToughness\":0,\"Toughness\":0}],[{\"blockType\":5,\"IsFlammable\":false,\"IsLiquid\":false,\"ToolType\":0,\"MaxToughness\":0,\"Toughness\":0},null,null,null,{\"blockType\":5,\"IsFlammable\":false,\"IsLiquid\":false,\"ToolType\":0,\"MaxToughness\":0,\"Toughness\":0}],[{\"blockType\":5,\"IsFlammable\":false,\"IsLiquid\":false,\"ToolType\":0,\"MaxToughness\":0,\"Toughness\":0},null,null,null,{\"blockType\":5,\"IsFlammable\":false,\"IsLiquid\":false,\"ToolType\":0,\"MaxToughness\":0,\"Toughness\":0}],[{\"blockType\":5,\"IsFlammable\":false,\"IsLiquid\":false,\"ToolType\":0,\"MaxToughness\":0,\"Toughness\":0},{\"blockType\":5,\"IsFlammable\":false,\"IsLiquid\":false,\"ToolType\":0,\"MaxToughness\":0,\"Toughness\":0},{\"blockType\":5,\"IsFlammable\":false,\"IsLiquid\":false,\"ToolType\":0,\"MaxToughness\":0,\"Toughness\":0},{\"blockType\":5,\"IsFlammable\":false,\"IsLiquid\":false,\"ToolType\":0,\"MaxToughness\":0,\"Toughness\":0},{\"blockType\":5,\"IsFlammable\":false,\"IsLiquid\":false,\"ToolType\":0,\"MaxToughness\":0,\"Toughness\":0}]],\"_furnishingLayer\":[[null,null,null,null,null],[null,null,{\"furnishingType\":0},null,null],[null,null,null,null,null],[null,null,null,null,null],[null,null,null,null,null]],\"_collectableLayer\":[[null,null,null,null,null],[null,null,null,null,null],[null,null,null,null,null],[null,null,null,{\"collectableType\":0},null],[null,null,null,null,null]]}";
        private const string UnsupportedVersionJsonString = "{\"DataVersion\":\"0.0.1\",\"<Title>k__BackingField\":\"New Region\",\"<Background>k__BackingField\":{\"r\":255,\"g\":255,\"b\":255,\"a\":255},\"<Revision>k__BackingField\":1,\"_specialPoints\":[],\"_floorLayer\":[[{\"floorType\":2,\"isWalkable\":false,\"isHole\":false,\"tool\":0},{\"floorType\":2,\"isWalkable\":false,\"isHole\":false,\"tool\":0},{\"floorType\":2,\"isWalkable\":false,\"isHole\":false,\"tool\":0},{\"floorType\":2,\"isWalkable\":false,\"isHole\":false,\"tool\":0},{\"floorType\":2,\"isWalkable\":false,\"isHole\":false,\"tool\":0}],[{\"floorType\":2,\"isWalkable\":false,\"isHole\":false,\"tool\":0},{\"floorType\":2,\"isWalkable\":false,\"isHole\":false,\"tool\":0},{\"floorType\":2,\"isWalkable\":false,\"isHole\":false,\"tool\":0},{\"floorType\":2,\"isWalkable\":false,\"isHole\":false,\"tool\":0},{\"floorType\":2,\"isWalkable\":false,\"isHole\":false,\"tool\":0}],[{\"floorType\":2,\"isWalkable\":false,\"isHole\":false,\"tool\":0},{\"floorType\":2,\"isWalkable\":false,\"isHole\":false,\"tool\":0},{\"floorType\":2,\"isWalkable\":false,\"isHole\":false,\"tool\":0},{\"floorType\":2,\"isWalkable\":false,\"isHole\":false,\"tool\":0},{\"floorType\":2,\"isWalkable\":false,\"isHole\":false,\"tool\":0}],[{\"floorType\":2,\"isWalkable\":false,\"isHole\":false,\"tool\":0},{\"floorType\":2,\"isWalkable\":false,\"isHole\":false,\"tool\":0},{\"floorType\":2,\"isWalkable\":false,\"isHole\":false,\"tool\":0},{\"floorType\":2,\"isWalkable\":false,\"isHole\":false,\"tool\":0},{\"floorType\":2,\"isWalkable\":false,\"isHole\":false,\"tool\":0}],[{\"floorType\":2,\"isWalkable\":false,\"isHole\":false,\"tool\":0},{\"floorType\":2,\"isWalkable\":false,\"isHole\":false,\"tool\":0},{\"floorType\":2,\"isWalkable\":false,\"isHole\":false,\"tool\":0},{\"floorType\":2,\"isWalkable\":false,\"isHole\":false,\"tool\":0},{\"floorType\":2,\"isWalkable\":false,\"isHole\":false,\"tool\":0}]],\"_blockLayer\":[[{\"blockType\":5,\"IsFlammable\":false,\"IsLiquid\":false,\"ToolType\":0,\"MaxToughness\":0,\"Toughness\":0},{\"blockType\":5,\"IsFlammable\":false,\"IsLiquid\":false,\"ToolType\":0,\"MaxToughness\":0,\"Toughness\":0},{\"blockType\":5,\"IsFlammable\":false,\"IsLiquid\":false,\"ToolType\":0,\"MaxToughness\":0,\"Toughness\":0},{\"blockType\":5,\"IsFlammable\":false,\"IsLiquid\":false,\"ToolType\":0,\"MaxToughness\":0,\"Toughness\":0},{\"blockType\":5,\"IsFlammable\":false,\"IsLiquid\":false,\"ToolType\":0,\"MaxToughness\":0,\"Toughness\":0}],[{\"blockType\":5,\"IsFlammable\":false,\"IsLiquid\":false,\"ToolType\":0,\"MaxToughness\":0,\"Toughness\":0},null,null,null,{\"blockType\":5,\"IsFlammable\":false,\"IsLiquid\":false,\"ToolType\":0,\"MaxToughness\":0,\"Toughness\":0}],[{\"blockType\":5,\"IsFlammable\":false,\"IsLiquid\":false,\"ToolType\":0,\"MaxToughness\":0,\"Toughness\":0},null,null,null,{\"blockType\":5,\"IsFlammable\":false,\"IsLiquid\":false,\"ToolType\":0,\"MaxToughness\":0,\"Toughness\":0}],[{\"blockType\":5,\"IsFlammable\":false,\"IsLiquid\":false,\"ToolType\":0,\"MaxToughness\":0,\"Toughness\":0},null,null,null,{\"blockType\":5,\"IsFlammable\":false,\"IsLiquid\":false,\"ToolType\":0,\"MaxToughness\":0,\"Toughness\":0}],[{\"blockType\":5,\"IsFlammable\":false,\"IsLiquid\":false,\"ToolType\":0,\"MaxToughness\":0,\"Toughness\":0},{\"blockType\":5,\"IsFlammable\":false,\"IsLiquid\":false,\"ToolType\":0,\"MaxToughness\":0,\"Toughness\":0},{\"blockType\":5,\"IsFlammable\":false,\"IsLiquid\":false,\"ToolType\":0,\"MaxToughness\":0,\"Toughness\":0},{\"blockType\":5,\"IsFlammable\":false,\"IsLiquid\":false,\"ToolType\":0,\"MaxToughness\":0,\"Toughness\":0},{\"blockType\":5,\"IsFlammable\":false,\"IsLiquid\":false,\"ToolType\":0,\"MaxToughness\":0,\"Toughness\":0}]],\"_furnishingLayer\":[[null,null,null,null,null],[null,null,{\"furnishingType\":0},null,null],[null,null,null,null,null],[null,null,null,null,null],[null,null,null,null,null]],\"_collectableLayer\":[[null,null,null,null,null],[null,null,null,null,null],[null,null,null,null,null],[null,null,null,{\"collectableType\":0},null],[null,null,null,null,null]]}";
        private const string NonJsonString = "private-readonly-Vector2Int-InvalidPosition-private-readonly-Vector2Int-InvalidPosition";
        #endregion

        #region Region Map Initialization
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
        public void TrySetFloorFailsOnNullParquetTest()
        {
            var region = new RegionMap();

            var result = region.TrySetFloor(null, Vector2Int.ZeroVector);

            Assert.False(result);
        }

        [Fact]
        public void TrySetFloorFailsOnInvalidPositionTest()
        {
            var region = new RegionMap();
            var parquet = new Floor();

            var result = region.TrySetFloor(parquet, InvalidPosition);

            Assert.False(result);
        }

        [Fact]
        public void TrySetFloorSucceedsOnDefaultParquetAndPositionTest()
        {
            var region = new RegionMap();
            var parquet = new Floor();

            var result = region.TrySetFloor(parquet, Vector2Int.ZeroVector);

            Assert.True(result);
        }

        [Fact]
        public void TrySetBlockFailsOnNullParquetTest()
        {
            var region = new RegionMap();

            var result = region.TrySetBlock(null, Vector2Int.ZeroVector);

            Assert.False(result);
        }

        [Fact]
        public void TrySetBlockFailsOnInvalidPositionTest()
        {
            var region = new RegionMap();
            var parquet = new Block();

            var result = region.TrySetBlock(parquet, InvalidPosition);

            Assert.False(result);
        }

        [Fact]
        public void TrySetBlockSucceedsOnDefaultParquetAndPositionTest()
        {
            var region = new RegionMap();
            var parquet = new Block();

            var result = region.TrySetBlock(parquet, Vector2Int.ZeroVector);

            Assert.True(result);
        }

        [Fact]
        public void TrySetFurnishingFailsOnNullParquetTest()
        {
            var region = new RegionMap();

            var result = region.TrySetFurnishing(null, Vector2Int.ZeroVector);

            Assert.False(result);
        }

        [Fact]
        public void TrySetFurnishingFailsOnInvalidPositionTest()
        {
            var region = new RegionMap();
            var parquet = new Furnishing();

            var result = region.TrySetFurnishing(parquet, InvalidPosition);

            Assert.False(result);
        }

        [Fact]
        public void TrySetFurnishingSucceedsOnDefaultParquetAndPositionTest()
        {
            var region = new RegionMap();
            var parquet = new Furnishing();

            var result = region.TrySetFurnishing(parquet, Vector2Int.ZeroVector);

            Assert.True(result);
        }

        [Fact]
        public void TrySetCollectableFailsOnNullParquetTest()
        {
            var region = new RegionMap();

            var result = region.TrySetCollectable(null, Vector2Int.ZeroVector);

            Assert.False(result);
        }

        [Fact]
        public void TrySetCollectableFailsOnInvalidPositionTest()
        {
            var region = new RegionMap();
            var parquet = new Collectable();

            var result = region.TrySetCollectable(parquet, InvalidPosition);

            Assert.False(result);
        }

        [Fact]
        public void TrySetCollectableSucceedsOnDefaultParquetAndPositionTest()
        {
            var region = new RegionMap();
            var parquet = new Collectable();

            var result = region.TrySetCollectable(parquet, Vector2Int.ZeroVector);

            Assert.True(result);
        }

        [Fact]
        public void TryRemoveFloorFailsOnInvalidPositionTest()
        {
            var region = new RegionMap();

            var result = region.TryRemoveFloor(InvalidPosition);

            Assert.False(result);
        }

        [Fact]
        public void TryRemoveFloorSucceedsOnDefaultPositionTest()
        {
            var region = new RegionMap();

            var result = region.TryRemoveFloor(Vector2Int.ZeroVector);

            Assert.True(result);
        }

        [Fact]
        public void TryRemoveBlockFailsOnInvalidPositionTest()
        {
            var region = new RegionMap();

            var result = region.TryRemoveBlock(InvalidPosition);

            Assert.False(result);
        }

        [Fact]
        public void TryRemoveBlockSucceedsOnDefaultPositionTest()
        {
            var region = new RegionMap();

            var result = region.TryRemoveBlock(Vector2Int.ZeroVector);

            Assert.True(result);
        }

        [Fact]
        public void TryRemoveFurnishingFailsOnInvalidPositionTest()
        {
            var region = new RegionMap();

            var result = region.TryRemoveFurnishing(InvalidPosition);

            Assert.False(result);
        }

        [Fact]
        public void TryRemoveFurnishingSucceedsOnDefaultPositionTest()
        {
            var region = new RegionMap();

            var result = region.TryRemoveFurnishing(Vector2Int.ZeroVector);

            Assert.True(result);
        }

        [Fact]
        public void TryRemoveCollectableFailsOnInvalidPositionTest()
        {
            var region = new RegionMap();

            var result = region.TryRemoveCollectable(InvalidPosition);

            Assert.False(result);
        }

        [Fact]
        public void TryRemoveCollectableSucceedsOnDefaultPositionTest()
        {
            var region = new RegionMap();

            var result = region.TryRemoveCollectable(Vector2Int.ZeroVector);

            Assert.True(result);
        }
        #endregion

        #region Parquet Property Modification Methods
        [Fact]
        public void TryDigFailsOnEmptyMapTest()
        {
            var region = new RegionMap();

            var result = region.TryDig(Vector2Int.ZeroVector);

            Assert.False(result);
        }

        [Fact]
        public void TryDigFailsOnInvalidPostionTest()
        {
            var region = new RegionMap().FillTestPattern();

            var result = region.TryDig(InvalidPosition);

            Assert.False(result);
        }

        [Fact]
        public void TryDigSucceedsOnInitializedMapAndDefaultPositionTest()
        {
            var region = new RegionMap().FillTestPattern();

            var result = region.TryDig(Vector2Int.ZeroVector);

            Assert.True(result);
        }

        [Fact]
        public void TryFillFailsOnEmptyMapTest()
        {
            var region = new RegionMap();

            var result = region.TryFill(Vector2Int.ZeroVector);

            Assert.False(result);
        }

        [Fact]
        public void TryFillFailsOnInvalidPostionTest()
        {
            var region = new RegionMap().FillTestPattern();

            var result = region.TryFill(InvalidPosition);

            Assert.False(result);
        }

        [Fact]
        public void TryFillSucceedsOnInitializedMapAndDefaultPositionTest()
        {
            var region = new RegionMap().FillTestPattern();

            var result = region.TryFill(Vector2Int.ZeroVector);

            Assert.True(result);
        }

        [Fact]
        public void TryReduceToughnessFailsOnEmptyMapTest()
        {
            var region = new RegionMap();

            var result = region.TryReduceToughness(Vector2Int.ZeroVector, 1);

            Assert.False(result);
        }

        [Fact]
        public void TryReduceToughnessFailsOnInvalidPostionTest()
        {
            var region = new RegionMap().FillTestPattern();

            var result = region.TryReduceToughness(InvalidPosition, 1);

            Assert.False(result);
        }

        [Fact]
        public void TryReduceToughnessSucceedsOnInitializedMapAndDefaultPositionTest()
        {
            var region = new RegionMap().FillTestPattern();

            var result = region.TryReduceToughness(Vector2Int.ZeroVector, 1);

            Assert.True(result);
        }

        [Fact]
        public void TryRestoreToughnessFailsOnEmptyMapTest()
        {
            var region = new RegionMap();

            var result = region.TryRestoreToughness(Vector2Int.ZeroVector);

            Assert.False(result);
        }

        [Fact]
        public void TryRestoreToughnessFailsOnInvalidPostionTest()
        {
            var region = new RegionMap().FillTestPattern();

            var result = region.TryRestoreToughness(InvalidPosition);

            Assert.False(result);
        }

        [Fact]
        public void TryRestoreToughnessSucceedsOnInitializedMapAndDefaultPositionTest()
        {
            var region = new RegionMap().FillTestPattern();

            var result = region.TryRestoreToughness(Vector2Int.ZeroVector);

            Assert.True(result);
        }
        #endregion

        #region Special Location Methods
        [Fact]
        public void TrySetSpawnPointFailsOnInvalidPositionTest()
        {
            var region = new RegionMap();
            var point = new SpawnPoint(InvalidPosition);

            var result = region.TrySetSpawnPoint(point);

            Assert.False(result);
        }

        [Fact]
        public void TrySetSpawnPointSucceedsOnValidPositionTest()
        {
            var region = new RegionMap();
            var point = new SpawnPoint(Vector2Int.ZeroVector);

            var result = region.TrySetSpawnPoint(point);

            Assert.True(result);
        }

        [Fact]
        public void TryRemoveSpawnPointFailsOnInvalidPositionTest()
        {
            var region = new RegionMap();
            var point = new SpawnPoint(InvalidPosition);

            var result = region.TryRemoveSpawnPoint(point);

            Assert.False(result);
        }

        [Fact]
        public void TryRemoveSpawnPointSucceedsOnSpawnPointMissingTest()
        {
            var region = new RegionMap();
            var point = new SpawnPoint(Vector2Int.ZeroVector);

            var result = region.TryRemoveSpawnPoint(point);

            Assert.True(result);
        }

        [Fact]
        public void TryRemoveSpawnPointSucceedsOnSpawnPointSetTest()
        {
            var region = new RegionMap();
            var point = new SpawnPoint(Vector2Int.ZeroVector);
            region.TrySetSpawnPoint(point);

            var result = region.TryRemoveSpawnPoint(point);

            Assert.True(result);
        }

        [Fact]
        public void TrySetExitPointFailsOnInvalidPositionTest()
        {
            var region = new RegionMap();
            var point = new ExitPoint(InvalidPosition);

            var result = region.TrySetExitPoint(point);

            Assert.False(result);
        }

        [Fact]
        public void TrySetExitPointSucceedsOnValidPositionTest()
        {
            var region = new RegionMap();
            var point = new ExitPoint(Vector2Int.ZeroVector);

            var result = region.TrySetExitPoint(point);

            Assert.True(result);
        }

        [Fact]
        public void TryRemoveExitPointFailsOnInvalidPositionTest()
        {
            var region = new RegionMap();
            var point = new ExitPoint(InvalidPosition);

            var result = region.TryRemoveExitPoint(point);

            Assert.False(result);
        }

        [Fact]
        public void TryRemoveExitPointSucceedsOnExitPointMissingTest()
        {
            var region = new RegionMap();
            var point = new ExitPoint(Vector2Int.ZeroVector);

            var result = region.TryRemoveExitPoint(point);

            Assert.True(result);
        }

        [Fact]
        public void TryRemoveExitPointSucceedsOnExitPointExistsTest()
        {
            var region = new RegionMap();
            var point = new ExitPoint(Vector2Int.ZeroVector);
            region.TrySetExitPoint(point);

            var result = region.TryRemoveExitPoint(point);

            Assert.True(result);
        }

        [Fact]
        public void GetSpecialDataReturnsNullsOnInvalidPositionTest()
        {
            var region = new RegionMap();

            var specialData = region.GetSpecialPointsAtPosition(InvalidPosition);

            Assert.Empty(specialData);
        }
        #endregion

        #region Serialization Methods
        [Fact]
        public void SerializingKnownMapProducesKnownStringTest()
        {
            var region = new RegionMap().FillTestPattern();

            var result = region.SerializeToString();

            Assert.Equal(KnownGoodJsonString, result);
        }

        [Fact]
        public void DeserializingNullFailsTest()
        {
            var result = RegionMap.TryDeserializeFromString(null, out RegionMap regionMapResults);

            Assert.Null(regionMapResults);
            Assert.False(result);
        }

        [Fact]
        public void DeserializingUnsupportedVersionFailsTest()
        {
            var result = RegionMap.TryDeserializeFromString(UnsupportedVersionJsonString,
                                                            out RegionMap regionMapResults);

            Assert.Null(regionMapResults);
            Assert.False(result);
        }

        [Fact]
        public void DeserializingKnownBadStringFailsTest()
        {
            var result = RegionMap.TryDeserializeFromString(NonJsonString,
                                                            out RegionMap regionMapResults);

            Assert.Null(regionMapResults);
            Assert.False(result);
        }

        [Fact]
        public void DeserializingKnownGoodStringSucceedsTest()
        {
            var result = RegionMap.TryDeserializeFromString(KnownGoodJsonString,
                                                            out RegionMap regionMapResults);

            Assert.NotNull(regionMapResults);
            Assert.True(result);
        }

        #endregion

        #region State Query Methods
        [Fact]
        public void IsFloorWalkableReturnsFalseOnInvalidPositionTest()
        {
            var region = new RegionMap().FillTestPattern();

            var result = region.IsFloorWalkable(InvalidPosition);

            Assert.False(result);
        }

        [Fact]
        public void IsFloorWalkableReturnsFalseOnEmptyMapTest()
        {
            var region = new RegionMap();

            var result = region.IsFloorWalkable(Vector2Int.ZeroVector);

            Assert.False(result);
        }

        [Fact]
        public void IsFloorAHoleReturnsFalseOnInvalidPositionTest()
        {
            var region = new RegionMap().FillTestPattern();

            var result = region.IsFloorAHole(InvalidPosition);

            Assert.False(result);
        }

        [Fact]
        public void IsFloorAHoleReturnsFalseOnEmptyMapTest()
        {
            var region = new RegionMap();

            var result = region.IsFloorAHole(Vector2Int.ZeroVector);

            Assert.False(result);
        }

        [Fact]
        public void IsBlockFlammableReturnsFalseOnInvalidPositionTest()
        {
            var region = new RegionMap().FillTestPattern();

            var result = region.IsBlockFlammable(InvalidPosition);

            Assert.False(result);
        }

        [Fact]
        public void IsBlockFlammableReturnsFalseOnEmptyMapTest()
        {
            var region = new RegionMap();

            var result = region.IsBlockFlammable(Vector2Int.ZeroVector);

            Assert.False(result);
        }

        [Fact]
        public void IsBlockALiquidReturnsFalseOnInvalidPositionTest()
        {
            var region = new RegionMap().FillTestPattern();

            var result = region.IsBlockALiquid(InvalidPosition);

            Assert.False(result);
        }

        [Fact]
        public void IsBlockALiquidReturnsFalseOnEmptyMapTest()
        {
            var region = new RegionMap();

            var result = region.IsBlockALiquid(Vector2Int.ZeroVector);

            Assert.False(result);
        }


        [Fact]
        public void GetBlockToughnessReturnsZeroOnInvalidPositionTest()
        {
            var region = new RegionMap().FillTestPattern();

            var result = region.GetBlockToughnessAtPosition(InvalidPosition);

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
        public void GetFloorReturnsNullOnInvalidPositionTest()
        {
            var region = new RegionMap().FillTestPattern();

            var result = region.GetFloorAtPosition(InvalidPosition);

            Assert.Null(result);
        }

        [Fact]
        public void GetFloorReturnsNullOnEmptyMapTest()
        {
            var region = new RegionMap();

            var result = region.GetFloorAtPosition(Vector2Int.ZeroVector);

            Assert.Null(result);
        }

        [Fact]
        public void GetBlockReturnsNullOnInvalidPositionTest()
        {
            var region = new RegionMap().FillTestPattern();

            var result = region.GetBlockAtPosition(InvalidPosition);

            Assert.Null(result);
        }

        [Fact]
        public void GetBlockReturnsNullOnEmptyMapTest()
        {
            var region = new RegionMap();

            var result = region.GetBlockAtPosition(Vector2Int.ZeroVector);

            Assert.Null(result);
        }

        [Fact]
        public void GetFurnishingReturnsNullOnInvalidPositionTest()
        {
            var region = new RegionMap().FillTestPattern();

            var result = region.GetFurnishingAtPosition(InvalidPosition);

            Assert.Null(result);
        }

        [Fact]
        public void GetFurnishingReturnsNullOnEmptyMapTest()
        {
            var region = new RegionMap();

            var result = region.GetFurnishingAtPosition(Vector2Int.ZeroVector);

            Assert.Null(result);
        }

        [Fact]
        public void GetCollectableReturnsNullOnInvalidPositionTest()
        {
            var region = new RegionMap().FillTestPattern();

            var result = region.GetCollectableAtPosition(InvalidPosition);

            Assert.Null(result);
        }

        [Fact]
        public void GetCollectableReturnsNullOnEmptyMapTest()
        {
            var region = new RegionMap();

            var result = region.GetCollectableAtPosition(Vector2Int.ZeroVector);

            Assert.Null(result);
        }

        [Fact]
        public void GetAllParquetsReturnsNullsOnInvalidPositionTest()
        {
            var region = new RegionMap().FillTestPattern();

            var parquetStack = region.GetAllParquetsAtPosition(InvalidPosition);

            Assert.Null(parquetStack.floor);
            Assert.Null(parquetStack.block);
            Assert.Null(parquetStack.furnishing);
            Assert.Null(parquetStack.collectable);
        }

        [Fact]
        public void GetAllParquetsReturnsNullsOnEmptyMapTest()
        {
            var region = new RegionMap();

            var parquetStack = region.GetAllParquetsAtPosition(Vector2Int.ZeroVector);

            Assert.Null(parquetStack.floor);
            Assert.Null(parquetStack.block);
            Assert.Null(parquetStack.furnishing);
            Assert.Null(parquetStack.collectable);
        }
        #endregion
    }
}
