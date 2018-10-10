﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadMS3D {
    public struct Group {
        byte    flags;
        string  name;
        short   numtriangles;
	    short   triangleIndices;
        char    materialIndex;
    }
}
