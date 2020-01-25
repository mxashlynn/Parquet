using System;

namespace ParquetClassLibrary
{
    /// <summary>
    /// Simple base <see langword="class"/> that guarantees derived classes can provide their own serialization shims.
    /// </summary>
    public abstract class ShimProvider
    {
        /// <summary>
        /// Parent class for all shims.
        /// </summary>
        internal abstract class Shim
        {
            /// <summary>
            /// Converts a shim into the class it corresponds to.
            /// </summary>
            /// <typeparam name="TInstance">The type to convert this shim to.</typeparam>
            /// <returns>An instance.</returns>
            public abstract TInstance ToInstance<TInstance>() where TInstance : ShimProvider;
        }

        /// <summary>
        /// Provides the means to map all members of this class to a CSV file.
        /// </summary>
        /// <returns>The member mapping.</returns>
        internal static Type GetShimType()
            => throw new NotImplementedException("No shim exists on abstract base class.");
    }
}
