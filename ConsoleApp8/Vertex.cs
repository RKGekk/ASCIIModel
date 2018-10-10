using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadMS3D {
    public struct Vertex {
        public byte    flags;
        public float[] vertex;
        public byte    boneId;
        public byte    referenceCount;
    }
}
