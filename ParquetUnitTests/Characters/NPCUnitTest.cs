using System;
using ParquetClassLibrary.Biomes;
using ParquetUnitTests;
using Xunit;

namespace ParquetClassLibrary.Characters
{
    public class NPCUnitTest
    {
        #region Test Values
        /// <summary>Identifier used when creating a new block.</summary>
        private static readonly EntityID newNpcID = TestEntities.TestNPC.ID - 1;
        #endregion

        [Fact]
        public void ValidNpcIDsArePermittedTest()
        {
            var newNPC = new NPC(newNpcID, "NPC", "will be created", Biome.Forest, Behavior.Still);

            Assert.NotNull(newNPC);
        }

        [Fact]
        public void InvalidNpcIDsRaiseExceptionTest()
        {
            var badNpcID = TestEntities.TestBlock.ID - 1;

            void TestCode()
            {
                var _ = new NPC(badNpcID, "NPC", "will fail", Biome.Forest, Behavior.Still);
            }

            Assert.Throws<ArgumentOutOfRangeException>(TestCode);
        }
    }
}
