using System;
using ParquetClassLibrary.Sandbox.IDs;
using Xunit;

namespace ParquetUnitTests.Sandbox
{
    public class ElevationMaskUnitTest
    {
        [Fact]
        internal void ElevationMaskSetsFlagsConsistentlyTest()
        {
            foreach (ElevationMask flag in Enum.GetValues(typeof(ElevationMask)))
            {
                var mask = ElevationMask.None;

                mask.Set(flag);

                Assert.Equal(flag, mask);
            }
        }

        [Fact]
        internal void ElevationMaskClearsFlagsConsistentlyTest()
        {
            foreach (ElevationMask flag in Enum.GetValues(typeof(ElevationMask)))
            {
                if (flag != ElevationMask.None)
                {
                    // Produces a mask where every possible flag is set.
                    var mask = (ElevationMask)~0;

                    mask.Clear(flag);

                    Assert.False(mask.HasFlag(flag));
                }
            }
        }

        [Fact]
        internal void ElevationMaskSetToSetsFlagsConsistentlyTest()
        {
            foreach (ElevationMask flag in Enum.GetValues(typeof(ElevationMask)))
            {
                if (flag != ElevationMask.None)
                {
                    var mask = ElevationMask.None;

                    mask.SetTo(flag, true);

                    Assert.True(mask.HasFlag(flag));
                }
            }
        }

        [Fact]
        internal void ElevationMaskSetToClearsFlagsConsistentlyTest()
        {
            foreach (ElevationMask flag in Enum.GetValues(typeof(ElevationMask)))
            {
                if (flag != ElevationMask.None)
                {
                    // Produces a mask where every possible flag is set.
                    var mask = (ElevationMask)~0;

                    mask.SetTo(flag, false);

                    Assert.False(mask.HasFlag(flag));
                }
            }
        }

        [Fact]
        internal void ElevationMaskIsSetEqualsHasFlagTest()
        {
            foreach (ElevationMask flag in Enum.GetValues(typeof(ElevationMask)))
            {
                if (flag != ElevationMask.None)
                {
                    foreach (ElevationMask mask in Enum.GetValues(typeof(ElevationMask)))
                    {
                        Assert.Equal(mask.HasFlag(flag), mask.IsSet(flag));
                    }
                }
            }
        }

        [Fact]
        // Note: I feel like this is a poor test, maybe it can be improved?
        internal void ElevationMaskIsNotSetForAllFlagsOnNoneTest()
        {
            foreach (ElevationMask flag in Enum.GetValues(typeof(ElevationMask)))
            {
                Assert.True(ElevationMask.None.IsNotSet(flag));
            }
        }
    }
}
