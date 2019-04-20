using System;
using ParquetClassLibrary;
using ParquetClassLibrary.Characters;
using ParquetClassLibrary.Sandbox.IDs;
using Xunit;

namespace ParquetUnitTests.Characters
{
    public class CritterUnitUnitTest
    {
        #region Test Values
        /// <summary>Identifier used when creating a new block.</summary>
        private static readonly EntityID newCritterID = TestEntities.TestCritter.ID - 1;
        #endregion

        [Fact]
        public void ValidCritterIDsArePermittedTest()
        {
            var newCritter = new Critter(newCritterID, "will be created", Biome.Forest, Behavior.Still);

            Assert.NotNull(newCritter);
        }

        [Fact]
        public void InvalidCritterIDsRaiseExceptionTest()
        {
            var badCritterID = TestEntities.TestBlock.ID - 1;

            void TestCode()
            {
                var _ = new Critter(badCritterID, "will fail", Biome.Forest, Behavior.Still);
            }

            Assert.Throws<ArgumentOutOfRangeException>(TestCode);
        }
    }
}
