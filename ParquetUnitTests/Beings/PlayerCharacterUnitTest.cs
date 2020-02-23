using System;
using ParquetClassLibrary;
using ParquetClassLibrary.Beings;
using Xunit;

namespace ParquetUnitTests.Beings
{
    public class PlayerCharacterUnitTest
    {
        #region Test Values
        /// <summary>Identifier used when creating a new block.</summary>
        private static readonly EntityID newPlayerID = TestModels.TestPlayer.ID - 1;
        #endregion

        [Fact]
        public void ValidPlayerIDsArePermittedTest()
        {
            var newPlayer = new PlayerCharacterModel(newPlayerID, "player character", "will be created", "", All.BiomeIDs.Minimum, Behavior.PlayerControlled);

            Assert.NotNull(newPlayer);
        }

        [Fact]
        public void InvalidNpcIDsRaiseExceptionTest()
        {
            var badNpcID = TestModels.TestBlock.ID - 1;

            void TestCode()
            {
                var _ = new PlayerCharacterModel(badNpcID, "player character", "will fail", "", All.BiomeIDs.Minimum, Behavior.PlayerControlled);
            }

            Assert.Throws<ArgumentOutOfRangeException>(TestCode);
        }
    }
}
