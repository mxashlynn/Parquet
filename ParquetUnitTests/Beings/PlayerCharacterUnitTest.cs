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
        private static readonly EntityID newPlayerID = TestEntities.TestPlayer.ID - 1;
        #endregion

        [Fact]
        public void ValidPlayerIDsArePermittedTest()
        {
            var newPlayer = new PlayerCharacter(newPlayerID, "player character", "will be created", "", "");

            Assert.NotNull(newPlayer);
        }

        [Fact]
        public void InvalidNpcIDsRaiseExceptionTest()
        {
            var badNpcID = TestEntities.TestBlock.ID - 1;

            void TestCode()
            {
                var _ = new PlayerCharacter(badNpcID, "player character", "will fail", "", "");
            }

            Assert.Throws<ArgumentOutOfRangeException>(TestCode);
        }
    }
}
