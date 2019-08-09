using ParquetClassLibrary.Map.SpecialPoints;
using ParquetClassLibrary.Utilities;
using Xunit;

namespace ParquetUnitTests.Map.SpecialPoints
{
    public class SpawnPointUnitTest
    {
        [Fact]
        public void SpawnPointKnowsWhatToSpawnTest()
        {
            var spawnPoint = new SpawnPoint(Vector2D.Zero, SpawnType.Player);

            Assert.Equal(SpawnType.Player, spawnPoint.WhatToSpawn);
        }
    }
}