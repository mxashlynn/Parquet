using System;
using ParquetClassLibrary.Sandbox.Parquets;
using Xunit;

namespace ParquetUnitTests.Sandbox
{
    public class ParquetMaskUnitTest
    {
        [Fact]
        internal void ParquetMaskSetsFlagsConsistentlyTest()
        {
            foreach (ParquetMask flag in Enum.GetValues(typeof(ParquetMask)))
            {
                var mask = ParquetMask.None;

                mask.Set(flag);

                Assert.Equal(flag, mask);
            }
        }

        [Fact]
        internal void ParquetMaskClearsFlagsConsistentlyTest()
        {
            foreach (ParquetMask flag in Enum.GetValues(typeof(ParquetMask)))
            {
                if (flag != ParquetMask.None)
                {
                    // Produces a mask where every possible flag is set.
                    var mask = (ParquetMask)~0;

                    mask.Clear(flag);

                    Assert.False(mask.HasFlag(flag));
                }
            }
        }

        [Fact]
        internal void ParquetMaskSetToSetsFlagsConsistentlyTest()
        {
            foreach (ParquetMask flag in Enum.GetValues(typeof(ParquetMask)))
            {
                if (flag != ParquetMask.None)
                {
                    var mask = ParquetMask.None;

                    mask.SetTo(flag, true);

                    Assert.True(mask.HasFlag(flag));
                }
            }
        }

        [Fact]
        internal void ParquetMaskSetToClearsFlagsConsistentlyTest()
        {
            foreach (ParquetMask flag in Enum.GetValues(typeof(ParquetMask)))
            {
                if (flag != ParquetMask.None)
                {
                    // Produces a mask where every possible flag is set.
                    var mask = (ParquetMask)~0;

                    mask.SetTo(flag, false);

                    Assert.False(mask.HasFlag(flag));
                }
            }
        }

        [Fact]
        internal void ParquetMaskIsSetEqualsHasFlagTest()
        {
            foreach (ParquetMask flag in Enum.GetValues(typeof(ParquetMask)))
            {
                if (flag != ParquetMask.None)
                {
                    foreach (ParquetMask mask in Enum.GetValues(typeof(ParquetMask)))
                    {
                        Assert.Equal(mask.HasFlag(flag), mask.IsSet(flag));
                    }
                }
            }
        }

        [Fact]
        // Note: I feel like this is a poor test, maybe it can be improved?
        internal void ParquetMaskIsNotSetForAllFlagsOnNoneTest()
        {
            foreach (ParquetMask flag in Enum.GetValues(typeof(ParquetMask)))
            {
                Assert.True(ParquetMask.None.IsNotSet(flag));
            }
        }
    }
}
