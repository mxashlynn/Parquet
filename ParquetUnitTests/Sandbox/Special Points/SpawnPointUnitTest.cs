using ParquetClassLibrary.Map;
using ParquetClassLibrary.Map.SpecialPoints;
using ParquetClassLibrary.Stubs;
using Xunit;

namespace ParquetUnitTests.Sandbox
{
    public class SpawnPointUnitTest
    {
        [Fact]
        public void SpawnPointKnowsWhatToSpawnTest()
        {
            var spawnPoint = new SpawnPoint(Vector2Int.ZeroVector, SpawnType.Player);

            Assert.Equal(SpawnType.Player, spawnPoint.WhatToSpawn);
        }
    }
}