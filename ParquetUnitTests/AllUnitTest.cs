using System.Linq;
using ParquetClassLibrary;
using Xunit;

namespace ParquetUnitTests
{
    public class AllUnitTest
    {
        #region Values for Tests
        /// <summary>
        /// The highest <see cref="Range{ModelID}.Maximum"/> defined in <see cref="All"/>
        /// except for <see cref="All.ItemIDs"/>.Maximum.
        /// </summary>
        public static readonly ModelID MaximumIDRangeUpperLimit = typeof(All).GetFields()
            .Where(fieldInfo => fieldInfo.FieldType.IsGenericType
                && fieldInfo.FieldType == typeof(Range<ModelID>)
                && fieldInfo.Name != nameof(All.ItemIDs))
            .Select(fieldInfo => fieldInfo.GetValue(null))
            .Cast<Range<ModelID>>()
            .Select(range => range.Maximum)
            .Max();
        #endregion

        [Fact]
        public void ItemIDMinimumIsGreaterThanMaximumDefinedRangeUpperBoundTest()
        {
            Assert.True(All.ItemIDs.Minimum > MaximumIDRangeUpperLimit);
        }
    }
}
