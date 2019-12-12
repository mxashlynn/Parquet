using System;
using ParquetClassLibrary.Parquets;
using Xunit;

namespace ParquetUnitTests.Map
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
    }
}
