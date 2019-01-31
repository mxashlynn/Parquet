namespace ParquetClassLibrary.Stubs
{
    /// <summary>
    /// Stand-in for Unity Color class.
    /// </summary>
    public struct Color
    {
        public static readonly Color white = new Color(1f, 1f, 1f);

        public float r;
        public float g;
        public float b;
        public float a;

        public Color(float in_r, float in_g, float in_b, float in_a = 1f)
        {
            r = in_r;
            g = in_g;
            b = in_b;
            a = in_a;
        }

    }
}
