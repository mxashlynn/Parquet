using System;
using ParquetClassLibrary;
using ParquetClassLibrary.Beings;
using Xunit;

namespace ParquetUnitTests.Beings
{
    public class NPCUnitTest
    {
        #region Test Values
        /// <summary>Identifier used when creating a new block.</summary>
        private static readonly EntityID newNpcID = TestModels.TestNPC.ID - 1;
        #endregion

        [Fact]
        public void ValidNpcIDsArePermittedTest()
        {
            var newNPC = new NPCModel(newNpcID, "NPC", "will be created", "", All.BiomeIDs.Minimum, Behavior.Still);

            Assert.NotNull(newNPC);
        }

        [Fact]
        public void InvalidNpcIDsRaiseExceptionTest()
        {
            var badNpcID = TestModels.TestBlock.ID - 1;

            void TestCode()
            {
                var _ = new NPCModel(badNpcID, "NPC", "will fail", "", All.BiomeIDs.Minimum, Behavior.Still);
            }

            Assert.Throws<ArgumentOutOfRangeException>(TestCode);
        }
    }
}
