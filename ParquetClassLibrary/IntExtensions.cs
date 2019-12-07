namespace ParquetClassLibrary
{
    /// <summary>
    /// Provides extension methods to the built in integer type.
    /// </summary>
    internal static class IntExtensions
    {
        /// <summary>Ensures an integer falls within the given range.</summary>
        /// <param name="in_int">Integer to normalize.</param>
        /// <param name="in_lowBound">The lowest valid value for the integer.</param>
        /// <param name="in_upBound">The highest valid value for the integer.</param>
        /// <returns>The integer, normalized.</returns>
        public static int Normalize(this int in_int, int in_lowBound, int in_upBound)
        {
            if (in_int < in_lowBound)
            {
                in_int = in_lowBound;
            }
            else if (in_int > in_upBound)
            {
                in_int = in_upBound;
            }

            return in_int;
        }
    }
}
