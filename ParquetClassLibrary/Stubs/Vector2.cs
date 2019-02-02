namespace ParquetClassLibrary.Stubs
{
    /// <summary>
    /// Stand-in for Unity Vector2 class.
    /// </summary>
    public struct Vector2
    {
        public static readonly Vector2 zeroVector = new Vector2(0f, 0f);

        public readonly float x;
        public readonly float y;

        public Vector2(float in_x, float in_y)
        {
            x = in_x;
            y = in_y;
        }
    }
}