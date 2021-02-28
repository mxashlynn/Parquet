using System.Linq;
using Parquet;
using Xunit;

namespace ParquetUnitTests
{
    /// <summary>
    /// Unit tests <see cref="All"/>.
    /// </summary>
    public class AllUnitTest
    {
        #region Values for Tests
        /// <summary>
        /// The highest <see cref="Range{ModelID}.Maximum"/> defined in <see cref="All"/>
        /// except for <see cref="All.ItemIDs"/>.Maximum.
        /// </summary>
        internal static readonly ModelID MaximumIDRangeUpperLimit = typeof(All).GetFields()
            .Where(fieldInfo => fieldInfo.FieldType.IsGenericType
                && fieldInfo.FieldType == typeof(Range<ModelID>)
                && fieldInfo.Name != nameof(All.ItemIDs))
            .Select(fieldInfo => fieldInfo.GetValue(null))
            .Cast<Range<ModelID>>()
            .Select(range => range.Maximum)
            .Max();
        #endregion

        [Fact]
        internal void ItemIDMinimumIsGreaterThanMaximumDefinedRangeUpperBoundTest()
        {
            Assert.True(All.ItemIDs.Minimum > MaximumIDRangeUpperLimit);
        }
    }
}
