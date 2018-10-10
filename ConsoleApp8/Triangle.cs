using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadMS3D {
    public struct Triangle {
        public short    flags;
        public short[]  vertexIndices;
        public float[,] vertexNormals;
        public float[]  s;
        public float[]  t;
        public byte     smoothingGroup;
        public byte     groupIndex;
    }
}
