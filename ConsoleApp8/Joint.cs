using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadMS3D {
    public struct Joint {
        byte    flags;
        string  name;
        string  parentName;
        float[] rotation;
        float[] position;

        short   numKeyFramesRot;
        short   numKeyFramesTrans;

	    KeyframeRotation keyFramesRot;
        KeyframePosition keyFramesTrans;
    }
}
