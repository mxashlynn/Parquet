using System;
using System.Linq;
using System.Reflection;
using CsvHelper.TypeConversion;
using ParquetClassLibrary.Beings;
using Xunit;

namespace ParquetUnitTests.Serialization
{
    public class ITypeConverterTest
    {
        /// <summary>
        /// Ensures that all concrete classes implementing the ITypeConverter interface also implement the ConverterFactory static property.
        /// </summary>
        [Fact]
        public void AllTypeConvertersProvideFactoriesTest()
        {
            var converterProviders = AppDomain.CurrentDomain.GetAssemblies()
                                              .SelectMany(x => x.GetTypes())
                                              .Where(x => typeof(ITypeConverter).IsAssignableFrom(x)
                                                       && !x.IsInterface
                                                       && !x.IsAbstract);

            foreach (var provider in converterProviders)
            {
                // PronounGroup is taken as a kind of archetype for this behavior.
                Assert.NotNull(provider.GetProperty(nameof(PronounGroup.ConverterFactory), BindingFlags.Static & BindingFlags.NonPublic));
            }
        }
    }
}
