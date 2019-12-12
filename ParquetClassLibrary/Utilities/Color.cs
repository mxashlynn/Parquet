using System;

namespace ParquetClassLibrary.Utilities
{
    /// <summary>
    /// A simple representation of RGBA color, tailored for Parquet's needs.
    /// </summary>
    public struct PCLColor : IEquatable<PCLColor>
    {
        public static readonly PCLColor White = new PCLColor(255, 255, 255);
        public static readonly PCLColor Grey = new PCLColor(128, 128, 128);
        public static readonly PCLColor Black = new PCLColor(0, 0, 0);
        public static readonly PCLColor SkyBlue = new PCLColor(180, 230, 255);
        public static readonly PCLColor Brown = new PCLColor(153, 77, 0);
        public static readonly PCLColor Transparent = new PCLColor(0, 0, 0, 0);

        public int R { get; }
        public int G { get; }
        public int B { get; }
        public int A { get; }

        public PCLColor(int in_r, int in_g, int in_b, int in_a = 255)
        {
            R = in_r.Normalize(0, 255);
            G = in_g.Normalize(0, 255);
            B = in_b.Normalize(0, 255);
            A = in_a.Normalize(0, 255);
        }

        #region IEquatable Implementation
        public override int GetHashCode()
            => (R, G, B, A).GetHashCode();

        public bool Equals(PCLColor in_color)
            => R == in_color.R
            && G == in_color.G
            && B == in_color.B
            && A == in_color.A;

        public override bool Equals(object obj)
            => obj is PCLColor color && Equals(color);

        public static bool operator ==(PCLColor in_color1, PCLColor in_color2)
            => in_color2.R == in_color1.R
            && in_color2.G == in_color1.G
            && in_color2.B == in_color1.B
            && in_color2.A == in_color1.A;

        public static bool operator !=(PCLColor in_color1, PCLColor in_color2)
            => in_color2.R != in_color1.R
            || in_color2.G != in_color1.G
            || in_color2.B != in_color1.B
            || in_color2.A != in_color1.A;
        #endregion

        #region Conversion Methods
        public static implicit operator PCLColor(ConsoleColor in_color)
        {
            PCLColor result;
            switch (in_color)
            {
                case ConsoleColor.Black:
                    result = Black;
                    break;
                case ConsoleColor.Blue:
                case ConsoleColor.Cyan:
                case ConsoleColor.DarkBlue:
                case ConsoleColor.DarkCyan:
                    result = SkyBlue;
                    break;
                case ConsoleColor.DarkGray:
                case ConsoleColor.Gray:
                    result = Grey;
                    break;
                case ConsoleColor.DarkYellow:
                    result = Brown;
                    break;
                //case ConsoleColor.DarkGreen:
                //case ConsoleColor.DarkMagenta:
                //case ConsoleColor.DarkRed:
                //case ConsoleColor.Green:
                //case ConsoleColor.Magenta:
                //case ConsoleColor.Red:
                //case ConsoleColor.Yellow:
                //case ConsoleColor.White:
                default:
                    result = White;
                    break;
            }

            return result;
        }

        public static implicit operator ConsoleColor(PCLColor in_color)
        {
            ConsoleColor result;

            if (in_color == White)
            {
                result = ConsoleColor.White;
            }
            else if (in_color == Grey)
            {
                result = ConsoleColor.Gray;
            }
            else if (in_color == Black)
            {
                result = ConsoleColor.Black;
            }
            else if (in_color == SkyBlue)
            {
                result = ConsoleColor.Cyan;
            }
            else if (in_color == Brown)
            {
                result = ConsoleColor.DarkYellow;
            }
            else
            {
                result = ConsoleColor.White;
            }

            return result;
        }
        #endregion
    }
}

