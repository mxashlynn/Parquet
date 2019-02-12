using System;

namespace ParquetClassLibrary.Stubs
{
    /// <summary>
    /// Stand-in for Unity Color class.
    /// </summary>
    public struct Color : IEquatable<Color>
    {
        public static readonly Color White = new Color(255, 255, 255);
        public static readonly Color Grey = new Color(128, 128, 128);
        public static readonly Color Black = new Color(0, 0, 0);
        public static readonly Color SkyBlue = new Color(180, 230, 255);
        public static readonly Color Brown = new Color(153, 77, 0);
        public static readonly Color Transparent = new Color(0, 0, 0, 0);

        public readonly int r;
        public readonly int g;
        public readonly int b;
        public readonly int a;

        public Color(int in_r, int in_g, int in_b, int in_a = 255)
        {
            r = in_r.Normalize(0, 255);
            g = in_g.Normalize(0, 255);
            b = in_b.Normalize(0, 255);
            a = in_a.Normalize(0, 255);
        }

        public override int GetHashCode()
        {
            return r.GetHashCode() ^
                   (g.GetHashCode() << 2) ^
                   (b.GetHashCode() >> 2) ^
                   (a.GetHashCode() >> 1);
        }

        public bool Equals(Color in_color)
        {
            return r == in_color.r
                   && g == in_color.g
                   && b == in_color.b
                   && a == in_color.a;
        }

        public override bool Equals(object obj)
        {
            var result = false;

            if (obj is Color color)
            {
                result = Equals(color);
            }

            return result;
        }

        public static bool operator ==(Color in_color1, Color in_color2)
        {
            if (object.ReferenceEquals(in_color1, in_color2)) return true;
            if (object.ReferenceEquals(in_color1, null)) return false;
            if (object.ReferenceEquals(in_color2, null)) return false;

            return in_color1.Equals(in_color2);
        }

        public static bool operator !=(Color in_color1, Color in_color2)
        {
            if (object.ReferenceEquals(in_color1, in_color2)) return false;
            if (object.ReferenceEquals(in_color1, null)) return true;
            if (object.ReferenceEquals(in_color2, null)) return true;

            return !in_color1.Equals(in_color2);
        }

        public static implicit operator Color(ConsoleColor in_color)
        {
            Color result;
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
                case ConsoleColor.White:
                default:
                    result = White;
                    break;
            }

            return result;
        }

        public static implicit operator ConsoleColor(Color in_color)
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
    }
}
