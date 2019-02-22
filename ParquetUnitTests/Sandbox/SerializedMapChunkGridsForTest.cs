using System;

namespace ParquetUnitTests.Sandbox
{
    internal struct SerializedMapChunkGridsForTest
    {
        internal const string NonJsonString = "thisIsNotAJSONStringNopeNope";
        internal const string KnownGoodString = "{\"DataVersion\":\"0.1.0\",\"RegionID\":\"00000000-0000-0000-0000-000000000000\",\"<Title>k__BackingField\":\"New Region\",\"<Background>k__BackingField\":{\"r\":255,\"g\":255,\"b\":255,\"a\":255},\"<GlobalElevation>k__BackingField\":0,\"_chunkTypes\":[[16,16,16,16],[16,41,16,16],[16,16,25,16],[16,16,25,16]],\"_chunkOrientations\":[[0,0,0,0],[0,0,0,0],[0,0,1,0],[0,0,3,0]]}";
        internal const string UnsupportedVersionString = "{\"DataVersion\":\"0.0.0\",\"RegionID\":\"00000000-0000-0000-0000-000000000000\",\"<Title>k__BackingField\":\"New Region\",\"<Background>k__BackingField\":{\"r\":255,\"g\":255,\"b\":255,\"a\":255},\"<GlobalElevation>k__BackingField\":0,\"_chunkTypes\":[[16,16,16,16],[16,41,16,16],[16,16,25,16],[16,16,25,16]],\"_chunkOrientations\":[[0,0,0,0],[0,0,0,0],[0,0,1,0],[0,0,3,0]]}";
    }
}
