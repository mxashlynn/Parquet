using System;
using System.Globalization;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace Parquet.Parquets
{
    /// <summary>
    /// Tracks the status of a <see cref="ParquetModelPack"/>.
    /// Instances of this class are mutable during play.
    /// </summary>
    public sealed class ParquetStatusPack
    {

        #region Utilities
        /// <summary>
        /// Returns a <see cref="string"/> that represents the current <see cref="ParquetStatusPack"/>.
        /// </summary>
        /// <returns>The representation.</returns>
        public override string ToString()
            => throw new NotImplementedException();

        /// <summary>
        /// Creates a new instance that is a deep copy of the current instance.
        /// </summary>
        /// <returns>A new instance with the same characteristics as the current instance.</returns>
        public ParquetStatusPack DeepClone()
            => throw new NotImplementedException();
        #endregion
    }
}
