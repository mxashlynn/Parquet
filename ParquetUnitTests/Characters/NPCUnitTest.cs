using System;
using ParquetClassLibrary.Sandbox.IDs;
using ParquetUnitTests;
using Xunit;

namespace ParquetClassLibrary.Characters
{
    /// <summary>
    /// Models the definition for a non-player character, such as a shop keeper.
    /// </summary>
    public class NPCUnitTest
    {
        #region Test Values
        /// <summary>Identifier used when creating a new block.</summary>
        private static readonly EntityID newNpcID = TestEntities.TestNPC.ID - 1;
        #endregion

        [Fact]
        public void ValidNpcIDsArePermittedTest()
        {
            var newNPC = new NPC(newNpcID, "will be created", Biome.Forest, Behavior.Still);

            Assert.NotNull(newNPC);
        }

        [Fact]
        public void InvalidNpcIDsRaiseExceptionTest()
        {
            var badNpcID = TestEntities.TestBlock.ID - 1;

            void TestCode()
            {
                var _ = new NPC(badNpcID, "will fail", Biome.Forest, Behavior.Still);
            }

            Assert.Throws<ArgumentOutOfRangeException>(TestCode);
        }
    }
}
