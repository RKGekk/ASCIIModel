using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadMS3D {
    public struct Color8 {
        public byte R;
        public byte G;
        public byte B;
        public Color8(byte Red, byte Green, byte Blue) {
            R = Red;
            G = Green;
            B = Blue;
        }

        public static System.ConsoleColor FromColor(Color8 c) {
            int index = (c.R > 128 | c.G > 128 | c.B > 128) ? 8 : 0; // Bright bit
            index |= (c.R > 64) ? 4 : 0; // Red bit
            index |= (c.G > 64) ? 2 : 0; // Green bit
            index |= (c.B > 64) ? 1 : 0; // Blue bit
            return (System.ConsoleColor)index;
        }
    }
}
