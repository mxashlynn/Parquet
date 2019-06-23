using System.Collections.Generic;

namespace ParquetClassLibrary.Utilities
{
    /// <summary>
    /// The structure that describes the search space used by <see cref="DFSID"/>.
    /// </summary>
    public struct Node
    {
        public int id;
        public List<Node> neighbors;
    }

    /// <summary>
    /// Provides a depth-first search with iterative deepening.
    /// </summary>
    public static class DFSID
    {
        /// <summary>
        /// Performs a depth-first search with iterative deepening for the given goal beginning at the given node.
        /// </summary>
        /// <param name="in_start">Where to begin.</param>
        /// <param name="in_maxDepth">How deep to search.</param>
        /// <param name="in_goalID">How to identify the goal.</param>
        /// <returns>The path to the goal.</returns>
        public static Stack<Node> DepthFirstSearchIterativeDeepening(Node in_start, int in_maxDepth, int in_goalID)
        {
            for (var depth = 0; depth <= in_maxDepth; ++depth)
            {
                Stack<Node> goalPath = DepthLimitedSearch(in_start, depth, in_goalID);
                if (null != goalPath)
                {
                    // Return path to the goal.
                    return goalPath;
                }
            }

            // No path to the goal was found.
            return null;
        }

        /// <summary>
        /// Performs a depth-limited search for the given goal beginning at the given node.
        /// </summary>
        /// <param name="in_node">Where to begin.</param>
        /// <param name="in_depth">How deep to search.</param>
        /// <param name="in_goalID">How to identify the goal.</param>
        /// <returns>The path to the goal.</returns>
        private static Stack<Node> DepthLimitedSearch(Node in_node, int in_depth, int in_goalID)
        {
            if (in_depth == 0 && in_node.id == in_goalID)
            {
                var path = new Stack<Node>();
                path.Push(in_node);

                // Goal found!
                return path;
            }
            else if (in_depth > 0)
            {
                foreach (Node next in in_node.neighbors)
                {
                    var path = DepthLimitedSearch(next, in_depth - 1, in_goalID);

                    if (null != path)
                    {
                        // Reconstructing the path to the goal.
                        path.Push(in_node);

                        return path;
                    }
                }
            }

            // Goal not found.
            return null;
        }
    }
}
