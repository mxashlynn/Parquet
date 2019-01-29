namespace Queertet.Stubs
{
    /// <summary>
    /// Stand-in for Unity Vector2 class.
    /// </summary>
    public struct Vector2Int
    {
        public static readonly Vector2Int zeroVector = new Vector2Int(0, 0);

        public int x;
        public int y;

        public Vector2Int(int in_x, int in_y)
        {
            x = in_x;
            y = in_y;
        }
    }
}