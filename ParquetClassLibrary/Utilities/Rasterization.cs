using System;
using System.Collections.Generic;

namespace ParquetClassLibrary.Utilities
{
    /// <summary>
    /// Methods and data to assist in rasterization.
    /// </summary>
    internal static class Rasterization
    {
        /// <summary>
        /// Approximates a line segment between two positions.
        /// </summary>
        /// <param name="inStart">One end of the line segment.</param>
        /// <param name="inEend">The other end of the line segment.</param>
        /// <param name="inIsValid">Tests if plotted points are useable in their intended domain.</param>
        /// <returns>The line segment.</returns>
        public static List<Vector2D> PlotLine(Vector2D inStart, Vector2D inEend,
                                                Predicate<Vector2D> inIsValid)
        {
            // Ensures we do not return duplicate positions.
            var deduplicationList = new HashSet<Vector2D>();

            // Uses Bressenham's algorithm.
            var deltaX = Math.Abs(inEend.X - inStart.X);
            var xStep = inStart.X < inEend.X
                    ? 1
                    : -1;

            var deltaY = Math.Abs(inEend.Y - inStart.Y);
            var yStep = inStart.Y < inEend.Y
                    ? 1
                    : -1;

            var largestDifference = deltaX > deltaY
                    ? deltaX
                    : -deltaY;
            var error = largestDifference / 2;

            var x = inStart.X;
            var y = inStart.Y;
            do
            {
                var position = new Vector2D(x, y);
                if (inIsValid(position))
                {
                    deduplicationList.Add(position);
                }

                var errorForComparison = error;
                if (errorForComparison > -deltaX)
                {
                    error -= deltaY;
                    x += xStep;
                }
                if (errorForComparison < deltaY)
                {
                    error += deltaX;
                    y += yStep;
                }
            }
            while (x != inEend.X || y != inEend.Y);

            deduplicationList.Add(inEend);

            return new List<Vector2D>(deduplicationList);
        }

        /// <summary>
        /// Plots a rectangular region including all points contained on and within the rectanle.
        /// </summary>
        /// <param name="inUpperLeft">The upper left corner of the rectangle.</param>
        /// <param name="inLowerRight">The lower right corner of the rectangle.</param>
        /// <param name="inIsValid">Tests if plotted points are useable in their intended domain.</param>
        /// <returns>The filled rectangle.</returns>
        public static List<Vector2D> PlotFilledRectangle(Vector2D inUpperLeft, Vector2D inLowerRight,
                                                           Predicate<Vector2D> inIsValid)
        {
            //Ensures we do not return duplicate positions.
            var deduplicationList = new HashSet<Vector2D>();

            // By scanline, by position.
            for (var y = inUpperLeft.Y; y <= inLowerRight.Y; y++)
            {
                for (var x = inUpperLeft.X; x <= inLowerRight.X; x++)
                {
                    var position = new Vector2D(x, y);
                    if (inIsValid(position))
                    {
                        deduplicationList.Add(position);
                    }
                }
            }

            return new List<Vector2D>(deduplicationList);
        }

        /// <summary>
        /// Plots a rectangular region including all points contained on the rectanle but none within it.
        /// </summary>
        /// <param name="inUpperLeft">The upper left corner of the rectangle.</param>
        /// <param name="inLowerRight">The lower right corner of the rectangle.</param>
        /// <param name="inIsValid">Tests if plotted points are useable in their intended domain.</param>
        /// <returns>The rectangle.</returns>
        public static List<Vector2D> PlotEmptyRectangle(Vector2D inUpperLeft, Vector2D inLowerRight,
                                                          Predicate<Vector2D> inIsValid)
        {
            //Ensures we do not return duplicate positions.
            var deduplicationList = new HashSet<Vector2D>();

            // Outline the edges.
            var upperRight = new Vector2D(inLowerRight.X, inUpperLeft.Y);
            var lowerLeft = new Vector2D(inUpperLeft.X, inLowerRight.Y);

            deduplicationList.UnionWith(PlotLine(inUpperLeft, upperRight, inIsValid));
            deduplicationList.UnionWith(PlotLine(upperRight, inLowerRight, inIsValid));
            deduplicationList.UnionWith(PlotLine(inLowerRight, lowerLeft, inIsValid));
            deduplicationList.UnionWith(PlotLine(lowerLeft, inUpperLeft, inIsValid));

            return new List<Vector2D>(deduplicationList);
        }

        /// <summary>
        /// Plots a circular region including all points contained on the circle but none within it.
        /// </summary>
        /// <param name="inCenter">The circle's center.</param>
        /// <param name="inRadius">The circle's radius.</param>
        /// <param name="inIsFilled">If set to <c>true</c> in is filled.</param>
        /// <param name="inIsValid">Tests if plotted points are useable in their intended domain.</param>
        /// <returns>The circle.</returns>
        public static List<Vector2D> PlotCircle(Vector2D inCenter, int inRadius, bool inIsFilled,
                                                  Predicate<Vector2D> inIsValid)
        {
            //Ensures we do not return duplicate positions.
            var deduplicationList = new HashSet<Vector2D>();

            // Brute force.
            var circleLimit = inRadius * inRadius + inRadius;
            var outlineLimit = inRadius * inRadius - inRadius;
            for (var y = -inRadius; y <= inRadius; y++)
            {
                for (var x = -inRadius; x <= inRadius; x++)
                {
                    if (x * x + y * y < circleLimit
                        // Plot positions within the circle only if:
                        // (1) the circle is filled, or
                        // (2) the position is on the circle proper (that is, the circle's outline).
                        && (inIsFilled || x * x + y * y > outlineLimit))
                    {
                        var position = new Vector2D(inCenter.X + x, inCenter.Y + y);
                        if (inIsValid(position))
                        {
                            deduplicationList.Add(position);
                        }
                    }
                }
            }

            return new List<Vector2D>(deduplicationList);
        }

        /// <summary>
        /// Plots a contiguous section of the positions using a four-way flood fill.
        /// Plots all valid positions adjacent to the given position, provided that they match
        /// the parquets at the given position according to the provided matching criteria.
        /// </summary>
        /// <param name="inStart">The position on which to base the fill.</param>
        /// <param name="inTarget">The parquet type(s) to replace.</param>
        /// <param name="inIsValid">In rule for determining a valid position.</param>
        /// <param name="inMatches">The rule for determining matching parquets.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        /// <returns>A selection of contiguous positions.</returns>
        public static List<Vector2D> PlotFloodFill<T>(Vector2D inStart, T inTarget,
                                                        Predicate<Vector2D> inIsValid,
                                                        Func<Vector2D, T, bool> inMatches)
        {
            var results = new HashSet<Vector2D>();
            var queue = new Queue<Vector2D>();
            queue.Enqueue(inStart);

            while (queue.Count > 0)
            {
                var position = queue.Dequeue();
                if (!results.Contains(position)
                    && inIsValid(position)
                    && inMatches(position, inTarget))
                {
                    results.Add(position);
                    queue.Enqueue(new Vector2D(position.X - 1, position.Y));
                    queue.Enqueue(new Vector2D(position.X, position.Y - 1));
                    queue.Enqueue(new Vector2D(position.X + 1, position.Y));
                    queue.Enqueue(new Vector2D(position.X, position.Y + 1));
                }
            }

            return new List<Vector2D>(results);
        }
    }
}
