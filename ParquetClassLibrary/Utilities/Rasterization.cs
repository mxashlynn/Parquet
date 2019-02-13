using System;
using System.Collections.Generic;
using ParquetClassLibrary.Stubs;

namespace ParquetClassLibrary.Utilities
{
    /// <summary>
    /// Methods and data to assist in rasterization.
    /// </summary>
    public static class Rasterization
    {
        /// <summary>
        /// Used to ensure we do not return duplicate positions.
        /// Used by every method EXCEPT PlotLine, insuring that PlotLine can
        /// be called internally without compromising the contents of this list.
        /// </summary>
        private static readonly HashSet<Vector2Int> _deduplicationList = new HashSet<Vector2Int>();

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
            // Uses Bressenham's algorithm.
            // Must not use _deduplicationList.
            var result = new List<Vector2Int>();

            var deltaX = Math.Abs(in_end.x - in_start.x);
            var xStep = in_start.x < in_end.x
                    ? 1
                    : -1;

            var deltaY = Math.Abs(in_end.y - in_start.y);
            var yStep = in_start.y < in_end.y
                    ? 1
                    : -1;

            var largestDifference = deltaX > deltaY
                    ? deltaX
                    : -deltaY;
            var error = largestDifference / 2;

            var x = in_start.x;
            var y = in_start.y;
            do
            {
                var position = new Vector2Int(x, y);
                if (in_isValid(position))
                {
                    result.Add(position);
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
            while (x != in_end.x || y != in_end.y);

            result.Add(in_end);

            return result;
        }

        public static List<Vector2Int> PlotFilledRectangle(Vector2Int in_upperLeft, Vector2Int in_lowerRight,
                                                           Predicate<Vector2Int> in_isValid)
        {
            // By scanline, by position.
            _deduplicationList.Clear();

            for (int y = in_upperLeft.y; y <= in_lowerRight.y; y++)
            {
                for (int x = in_upperLeft.x; x <= in_lowerRight.x; x++)
                {
                    var position = new Vector2Int(x, y);
                    if (in_isValid(position))
                    {
                        _deduplicationList.Add(position);
                    }
                }
            }

            return new List<Vector2Int>(_deduplicationList);
        }

        public static List<Vector2Int> PlotEmptyRectangle(Vector2Int in_upperLeft, Vector2Int in_lowerRight,
                                                          Predicate<Vector2Int> in_isValid)
        {
            // Outline the edges.
            _deduplicationList.Clear();

            var upperRight = new Vector2Int(in_lowerRight.x, in_upperLeft.y);
            var lowerLeft = new Vector2Int(in_upperLeft.x, in_lowerRight.y);

            _deduplicationList.UnionWith(PlotLine(in_upperLeft, upperRight, in_isValid));
            _deduplicationList.UnionWith(PlotLine(upperRight, in_lowerRight, in_isValid));
            _deduplicationList.UnionWith(PlotLine(in_lowerRight, lowerLeft, in_isValid));
            _deduplicationList.UnionWith(PlotLine(lowerLeft, in_upperLeft, in_isValid));

            return new List<Vector2Int>(_deduplicationList);
        }

        public static List<Vector2Int> PlotCircle(Vector2Int in_center, int in_radius, bool in_isFilled,
                                                  Predicate<Vector2Int> in_isValid)
        {
            _deduplicationList.Clear();

            // Brute force.
            var circleLimit = in_radius * in_radius + in_radius;
            var outlineLimit = in_radius * in_radius - in_radius;
            for (int y = -in_radius; y <= in_radius; y++)
                for (int x = -in_radius; x <= in_radius; x++)
                    if (x * x + y * y < circleLimit
                        // Plot positions within the circle only if:
                        // (1) the circle is filled, or
                        // (2) the position is on the circle proper (that is, the circle's outline).
                        && (in_isFilled || x * x + y * y >  outlineLimit))
                    {
                        var position = new Vector2Int(in_center.x + x, in_center.y + y);
                        if (in_isValid(position))
                        {
                            _deduplicationList.Add(position);
                        }
                    }

            return new List<Vector2Int>(_deduplicationList);
        }
    }
}
