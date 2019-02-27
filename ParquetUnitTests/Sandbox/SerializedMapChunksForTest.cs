using System;

namespace ParquetUnitTests.Sandbox
{
    internal struct SerializedMapChunksForTest
    {
        internal const string NonJsonString = "private-readonly-Vector2Int-InvalidPosition-private-readonly-Vector2Int-InvalidPosition";
        internal const string KnownGoodString = "{\"DataVersion\":\"0.1.0\",";
        internal const string UnsupportedVersionString = "{\"DataVersion\":\"0.0.0\",";
    }
}
