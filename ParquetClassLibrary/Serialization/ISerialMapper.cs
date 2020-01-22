using CsvHelper.Configuration;

namespace ParquetClassLibrary.Serialization
{
    /// <summary>
    /// Provides a mapping of the implementing class to a CSVHelper format.
    /// </summary>
    public interface ISerialMapper
    {
        /// <summary>
        /// Provides the means to map all members of <typeparam="TClass"/> to a CSV file.
        /// </summary>
        /// <returns>The member mapping.</returns>
        internal ClassMap InstanceGetClassMap();
    }
}
