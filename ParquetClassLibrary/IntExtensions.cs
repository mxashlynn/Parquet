namespace ParquetClassLibrary
{
    /// <summary>
    /// Provides extension methods to the built in integer type.
    /// </summary>
    internal static class IntExtensions
    {

        /// <summary>Ensures an integer falls within the given range.</summary>
        /// <param name="inInt">Integer to normalize.</param>
        /// <param name="inLowerBound">The lowest valid value for the integer.</param>
        /// <param name="inUpperBound">The highest valid value for the integer.</param>
        /// <returns>The integer, normalized.</returns>
        public static int Normalize(this int inInt, int inLowerBound, int inUpperBound)
        {
            if (inInt < inLowerBound)
            {
                inInt = inLowerBound;
            }
            else if (inInt > inUpperBound)
            {
                inInt = inUpperBound;
            }

            return inInt;
        }
    }
}
