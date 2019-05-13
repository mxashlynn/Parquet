using System;
using System.Collections.Generic;
#if UNITY_2018_4_OR_NEWER
using UnityEngine;
#else
using ParquetClassLibrary.Stubs;
#endif

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
        /// <param name="in_start">One end of the line segment.</param>
        /// <param name="in_end">The other end of the line segment.</param>
        /// <param name="in_isValid">Tests if plotted points are useable in their intended domain.</param>
        /// <returns>The line segment.</returns>
        public static List<Vector2Int> PlotLine(Vector2Int in_start, Vector2Int in_end,
                                                Predicate<Vector2Int> in_isValid)
        {
            // Ensures we do not return duplicate positions.
            var deduplicationList = new HashSet<Vector2Int>();

            // Uses Bressenham's algorithm.
            var deltaX = Math.Abs(in_end.X - in_start.X);
            var xStep = in_start.X < in_end.X
                    ? 1
                    : -1;

            var deltaY = Math.Abs(in_end.Y - in_start.Y);
            var yStep = in_start.Y < in_end.Y
                    ? 1
                    : -1;

            var largestDifference = deltaX > deltaY
                    ? deltaX
                    : -deltaY;
            var error = largestDifference / 2;

            var x = in_start.X;
            var y = in_start.Y;
            do
            {
                var position = new Vector2Int(x, y);
                if (in_isValid(position))
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
            while (x != in_end.X || y != in_end.Y);

            deduplicationList.Add(in_end);

            return new List<Vector2Int>(deduplicationList);
        }

        /// <summary>
        /// Plots a rectangular region including all points contained on and within the rectanle.
        /// </summary>
        /// <param name="in_upperLeft">The upper left corner of the rectangle.</param>
        /// <param name="in_lowerRight">The lower right corner of the rectangle.</param>
        /// <param name="in_isValid">Tests if plotted points are useable in their intended domain.</param>
        /// <returns>The filled rectangle.</returns>
        public static List<Vector2Int> PlotFilledRectangle(Vector2Int in_upperLeft, Vector2Int in_lowerRight,
                                                           Predicate<Vector2Int> in_isValid)
        {
            //Ensures we do not return duplicate positions.
            var deduplicationList = new HashSet<Vector2Int>();

            // By scanline, by position.
            for (var y = in_upperLeft.Y; y <= in_lowerRight.Y; y++)
            {
                for (var x = in_upperLeft.X; x <= in_lowerRight.X; x++)
                {
                    var position = new Vector2Int(x, y);
                    if (in_isValid(position))
                    {
                        deduplicationList.Add(position);
                    }
                }
            }

            return new List<Vector2Int>(deduplicationList);
        }

        /// <summary>
        /// Plots a rectangular region including all points contained on the rectanle but none within it.
        /// </summary>
        /// <param name="in_upperLeft">The upper left corner of the rectangle.</param>
        /// <param name="in_lowerRight">The lower right corner of the rectangle.</param>
        /// <param name="in_isValid">Tests if plotted points are useable in their intended domain.</param>
        /// <returns>The rectangle.</returns>
        public static List<Vector2Int> PlotEmptyRectangle(Vector2Int in_upperLeft, Vector2Int in_lowerRight,
                                                          Predicate<Vector2Int> in_isValid)
        {
            //Ensures we do not return duplicate positions.
            var deduplicationList = new HashSet<Vector2Int>();

            // Outline the edges.
            var upperRight = new Vector2Int(in_lowerRight.X, in_upperLeft.Y);
            var lowerLeft = new Vector2Int(in_upperLeft.X, in_lowerRight.Y);

            deduplicationList.UnionWith(PlotLine(in_upperLeft, upperRight, in_isValid));
            deduplicationList.UnionWith(PlotLine(upperRight, in_lowerRight, in_isValid));
            deduplicationList.UnionWith(PlotLine(in_lowerRight, lowerLeft, in_isValid));
            deduplicationList.UnionWith(PlotLine(lowerLeft, in_upperLeft, in_isValid));

            return new List<Vector2Int>(deduplicationList);
        }

        /// <summary>
        /// Plots a circular region including all points contained on the circle but none within it.
        /// </summary>
        /// <param name="in_center">The circle's center.</param>
        /// <param name="in_radius">The circle's radius.</param>
        /// <param name="in_isFilled">If set to <c>true</c> in is filled.</param>
        /// <param name="in_isValid">Tests if plotted points are useable in their intended domain.</param>
        /// <returns>The circle.</returns>
        public static List<Vector2Int> PlotCircle(Vector2Int in_center, int in_radius, bool in_isFilled,
                                                  Predicate<Vector2Int> in_isValid)
        {
            //Ensures we do not return duplicate positions.
            var deduplicationList = new HashSet<Vector2Int>();

            // Brute force.
            var circleLimit = in_radius * in_radius + in_radius;
            var outlineLimit = in_radius * in_radius - in_radius;
            for (var y = -in_radius; y <= in_radius; y++)
            {
                for (var x = -in_radius; x <= in_radius; x++)
                {
                    if (x * x + y * y < circleLimit
                        // Plot positions within the circle only if:
                        // (1) the circle is filled, or
                        // (2) the position is on the circle proper (that is, the circle's outline).
                        && (in_isFilled || x * x + y * y > outlineLimit))
                    {
                        var position = new Vector2Int(in_center.X + x, in_center.Y + y);
                        if (in_isValid(position))
                        {
                            deduplicationList.Add(position);
                        }
                    }
                }
            }

            return new List<Vector2Int>(deduplicationList);
        }

        /// <summary>
        /// Plots a contiguous section of the positions using a four-way flood fill.
        /// Plots all valid positions adjacent to the given position, provided that they match
        /// the parquets at the given position according to the provided matching criteria.
        /// </summary>
        /// <param name="in_start">The position on which to base the fill.</param>
        /// <param name="in_target">The parquet type(s) to replace.</param>
        /// <param name="in_isValid">In rule for determining a valid position.</param>
        /// <param name="in_matches">The rule for determining matching parquets.</param>
        /// <typeparam name="T">The 1st type parameter.</typeparam>
        /// <returns>A selection of contiguous positions.</returns>
        public static List<Vector2Int> PlotFloodFill<T>(Vector2Int in_start, T in_target,
                                                        Predicate<Vector2Int> in_isValid,
                                                        Func<Vector2Int, T, bool> in_matches)
        {
            var results = new HashSet<Vector2Int>();
            var queue = new Queue<Vector2Int>();
            queue.Enqueue(in_start);

            while (queue.Count > 0)
            {
                var position = queue.Dequeue();
                if (!results.Contains(position)
                    && in_isValid(position)
                    && in_matches(position, in_target))
                {
                    results.Add(position);
                    queue.Enqueue(new Vector2Int(position.X - 1, position.Y));
                    queue.Enqueue(new Vector2Int(position.X, position.Y - 1));
                    queue.Enqueue(new Vector2Int(position.X + 1, position.Y));
                    queue.Enqueue(new Vector2Int(position.X, position.Y + 1));
                }
            }

            return new List<Vector2Int>(results);
        }
    }
}
