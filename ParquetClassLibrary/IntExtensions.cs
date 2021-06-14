namespace Parquet
{
    /// <summary>
    /// Provides extension methods to the built in integer type.
    /// </summary>
    internal static class IntExtensions
    {
        /// <summary>Ensures an integer falls within the given range.</summary>
        /// <param name="value">Integer to normalize.</param>
        /// <param name="lowerBound">The lowest valid value for the integer.</param>
        /// <param name="upperBound">The highest valid value for the integer.</param>
        /// <returns>The integer, normalized.</returns>
        public static int Normalize(this int value, int lowerBound, int upperBound)
        {
            if (value < lowerBound)
            {
                value = lowerBound;
            }
            else if (value > upperBound)
            {
                value = upperBound;
            }

            return value;
        }
    }
}
