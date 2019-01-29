namespace Queertet.Stubs
{
    /// <summary>
    /// Stand-in for Unity Vector3 class.
    /// </summary>
    public struct Vector3
    {
        public static readonly Vector3 zeroVector = new Vector3(0f, 0f, 0f);

        public float x;
        public float y;
        public float z;

        public Vector3(float in_x, float in_y, float in_z)
        {
            x = in_x;
            y = in_y;
            z = in_z;
        }
    }
}
