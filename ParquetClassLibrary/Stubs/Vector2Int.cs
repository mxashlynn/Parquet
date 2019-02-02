namespace ParquetClassLibrary.Stubs
{
    /// <summary>
    /// Stand-in for Unity Vector2 class.
    /// </summary>
    public struct Vector2Int
    {
        public static readonly Vector2Int ZeroVector = new Vector2Int(0, 0);

        public readonly int x;
        public readonly int y;

        public Vector2Int(int in_x, int in_y)
        {
            x = in_x;
            y = in_y;
        }

        public override int GetHashCode()
        {
            return x.GetHashCode() ^ (y.GetHashCode() << 2);
        }
    }
}