using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadMS3D {
    public struct Material {
        string  name;
        float[] ambient;
        float[] diffuse;
        float[] specular;
        float[] emissive;
        float   shininess;
        float   transparency;
        char    mode;
        string  texture;
        string  alphamap;
    }
}
