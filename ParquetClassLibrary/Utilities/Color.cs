using System;

namespace ParquetClassLibrary.Utilities
{
    /// <summary>
    /// A simple representation of RGBA color, tailored for Parquet's needs.
    /// </summary>
    public readonly struct PCLColor : IEquatable<PCLColor>
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

        public PCLColor(int inR, int inG, int inB, int inA = 255)
        {
            R = inR.Normalize(0, 255);
            G = inG.Normalize(0, 255);
            B = inB.Normalize(0, 255);
            A = inA.Normalize(0, 255);
        }

        #region IEquatable Implementation
        public override int GetHashCode()
            => (R, G, B, A).GetHashCode();

        public bool Equals(PCLColor inColor)
            => R == inColor.R
            && G == inColor.G
            && B == inColor.B
            && A == inColor.A;

        public override bool Equals(object obj)
            => obj is PCLColor color && Equals(color);

        public static bool operator ==(PCLColor inColor1, PCLColor inColor2)
            => inColor2.R == inColor1.R
            && inColor2.G == inColor1.G
            && inColor2.B == inColor1.B
            && inColor2.A == inColor1.A;

        public static bool operator !=(PCLColor inColor1, PCLColor inColor2)
            => inColor2.R != inColor1.R
            || inColor2.G != inColor1.G
            || inColor2.B != inColor1.B
            || inColor2.A != inColor1.A;
        #endregion

        #region Conversion Methods
        public static implicit operator PCLColor(ConsoleColor inColor)
        {
            PCLColor result;
            switch (inColor)
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

        public static implicit operator ConsoleColor(PCLColor inColor)
        {
            ConsoleColor result;

            if (inColor == White)
            {
                result = ConsoleColor.White;
            }
            else if (inColor == Grey)
            {
                result = ConsoleColor.Gray;
            }
            else if (inColor == Black)
            {
                result = ConsoleColor.Black;
            }
            else if (inColor == SkyBlue)
            {
                result = ConsoleColor.Cyan;
            }
            else if (inColor == Brown)
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

