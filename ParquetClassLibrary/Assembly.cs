using System.Configuration;

[assembly: System.Runtime.CompilerServices.InternalsVisibleTo("ParquetUnitTests")]

namespace ParquetClassLibrary
{
    /// <summary>
    /// Provides assembly-wide information.
    /// </summary>
    public struct Assembly
    {
        /// <summary>Describes the version of the serialized data that this class understands.</summary>
        public const string SupportedDataVersion = "0.1.0";

        /// <summary>The length of each chunk dimension in parquets.</summary>
        public const int ParquetsPerChunkDimension = 16;

        /// <summary>The length of each region dimension in chunks.</summary>
        public const int ChunksPerRegionDimension = 4;

        /// <summary>The length of each region dimension in parquets.</summary>
        public const int ParquetsPerRegionDimension = ChunksPerRegionDimension * ParquetsPerChunkDimension;

        public static string DoTheThing()
        {
            var temp = ConfigurationManager.AppSettings["paige"].ToString();
            temp = string.IsNullOrEmpty(temp)
                ? "(empty)"
                : temp;
            return $"paige {temp}";
        }
    }
}
