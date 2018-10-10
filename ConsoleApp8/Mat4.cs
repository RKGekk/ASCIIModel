using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadMS3D {
    public class Mat4 {

        public Vec4[] data;

        public Mat4() {
            data = new Vec4[4];

            data[0] = new Vec4(1.0f, 0.0f, 0.0f, 0.0f);
            data[1] = new Vec4(0.0f, 1.0f, 0.0f, 0.0f);
            data[2] = new Vec4(0.0f, 0.0f, 1.0f, 0.0f);
            data[3] = new Vec4(0.0f, 0.0f, 0.0f, 1.0f);
        }

        public Mat4(Vec4 row1, Vec4 row2, Vec4 row3, Vec4 row4) {
            data = new Vec4[4];

            data[0] = row1;
            data[1] = row2;
            data[2] = row3;
            data[3] = row4;
        }

        public Quat toQuat() {

            Quat res = new Quat();

            float tr;
            float s;
            float[] q = new float[4];
            int i, j, k;

            int[] nxt = new int[3] {1, 2, 3};

            tr = this.data[0][0] + this.data[1][1] + this.data[2][2];

            if(tr > 0.0f) {
                s = (float)Math.Sqrt(tr + 1.0f);
                res.r = s / 2.0f;
                s = 0.5f / s;
                res.i = (this.data[2][1] - data[1][2]) * s;
                res.j = (this.data[0][2] - data[2][0]) * s;
                res.k = (this.data[1][0] - data[0][1]) * s;
            }
            else {

                i = 0;
                if(this.data[1][1] > this.data[0][0]) i = 1;
                if(this.data[2][2] > this.data[i][i]) i = 2;
                j = nxt[i];
                k = nxt[j];

                s = (float)Math.Sqrt((this.data[i][i] - (this.data[j][j] + this.data[k][k])) + 1.0f);

                q[i] = s * 0.5f;

                if(s != 0.0f) s = 0.5f / s;

                q[3] = (this.data[k][j] - this.data[j][k]) * s;
                q[j] = (this.data[i][j] + this.data[j][i]) * s;
                q[k] = (this.data[i][k] + this.data[k][i]) * s;

                res.i = q[0];
                res.j = q[1];
                res.k = q[2];
                res.r = q[3];
            }

            return res;
        }

        public float this[int i] {
            get {
                if (i == 0)
                    return this.data[0][0];
                if (i == 1)
                    return this.data[0][1];
                if (i == 2)
                    return this.data[0][2];
                if (i == 3)
                    return this.data[0][3];
                if (i == 4)
                    return this.data[1][0];
                if (i == 5)
                    return this.data[1][1];
                if (i == 6)
                    return this.data[1][2];
                if (i == 7)
                    return this.data[1][3];
                if (i == 8)
                    return this.data[2][0];
                if (i == 9)
                    return this.data[2][1];
                if (i == 10)
                    return this.data[2][2];
                if (i == 11)
                    return this.data[2][3];
                if (i == 12)
                    return this.data[3][0];
                if (i == 13)
                    return this.data[3][1];
                if (i == 14)
                    return this.data[3][2];
                return this.data[3][3];
            }
            set {
                if (i == 0)
                    this.data[0][0] = value;
                if (i == 1)
                    this.data[0][1] = value;
                if (i == 2)
                    this.data[0][2] = value;
                if (i == 3)
                    this.data[0][3] = value;
                if (i == 4)
                    this.data[1][0] = value;
                if (i == 5)
                    this.data[1][1] = value;
                if (i == 6)
                    this.data[1][2] = value;
                if (i == 7)
                    this.data[1][3] = value;
                if (i == 8)
                    this.data[2][0] = value;
                if (i == 9)
                    this.data[2][1] = value;
                if (i == 10)
                    this.data[2][2] = value;
                if (i == 11)
                    this.data[2][3] = value;
                if (i == 12)
                    this.data[3][0] = value;
                if (i == 13)
                    this.data[3][1] = value;
                if (i == 14)
                    this.data[3][2] = value;
                this.data[3][3] = value;
            }
        }

        public static Mat4 operator *(Mat4 m1, Mat4 m2) {

            Vec4 ap1 = m1.data[0];
            Vec4 ap2 = m1.data[1];
            Vec4 ap3 = m1.data[2];
            Vec4 ap4 = m1.data[3];

            Vec4 bp1 = m2.data[0];
            Vec4 bp2 = m2.data[1];
            Vec4 bp3 = m2.data[2];
            Vec4 bp4 = m2.data[3];

            Vec4 cp1 = new Vec4();
            Vec4 cp2 = new Vec4();
            Vec4 cp3 = new Vec4();
            Vec4 cp4 = new Vec4();

            float a0, a1, a2, a3;

            a0 = ap1.x;
            a1 = ap1.y;
            a2 = ap1.z;
            a3 = ap1.w;

            cp1.x = a0 * bp1.x + a1 * bp2.x + a2 * bp3.x + a3 * bp4.x;
            cp1.y = a0 * bp1.y + a1 * bp2.y + a2 * bp3.y + a3 * bp4.y;
            cp1.z = a0 * bp1.z + a1 * bp2.z + a2 * bp3.z + a3 * bp4.z;
            cp1.w = a0 * bp1.w + a1 * bp2.w + a2 * bp3.w + a3 * bp4.w;

            a0 = ap2.x;
            a1 = ap2.y;
            a2 = ap2.z;
            a3 = ap2.w;

            cp2.x = a0 * bp1.x + a1 * bp2.x + a2 * bp3.x + a3 * bp4.x;
            cp2.y = a0 * bp1.y + a1 * bp2.y + a2 * bp3.y + a3 * bp4.y;
            cp2.z = a0 * bp1.z + a1 * bp2.z + a2 * bp3.z + a3 * bp4.z;
            cp2.w = a0 * bp1.w + a1 * bp2.w + a2 * bp3.w + a3 * bp4.w;

            a0 = ap3.x;
            a1 = ap3.y;
            a2 = ap3.z;
            a3 = ap3.w;

            cp3.x = a0 * bp1.x + a1 * bp2.x + a2 * bp3.x + a3 * bp4.x;
            cp3.y = a0 * bp1.y + a1 * bp2.y + a2 * bp3.y + a3 * bp4.y;
            cp3.z = a0 * bp1.z + a1 * bp2.z + a2 * bp3.z + a3 * bp4.z;
            cp3.w = a0 * bp1.w + a1 * bp2.w + a2 * bp3.w + a3 * bp4.w;

            a0 = ap4.x;
            a1 = ap4.y;
            a2 = ap4.z;
            a3 = ap4.w;

            cp4.x = a0 * bp1.x + a1 * bp2.x + a2 * bp3.x + a3 * bp4.x;
            cp4.y = a0 * bp1.y + a1 * bp2.y + a2 * bp3.y + a3 * bp4.y;
            cp4.z = a0 * bp1.z + a1 * bp2.z + a2 * bp3.z + a3 * bp4.z;
            cp4.w = a0 * bp1.w + a1 * bp2.w + a2 * bp3.w + a3 * bp4.w;

            return new Mat4(cp1, cp2, cp3, cp4);
        }

        public static Vec4 operator *(Mat4 m1, Vec4 v1) {

            Vec4 outRes = new Vec4();

            outRes.x = v1.x * m1.data[0].x + v1.y * m1.data[1].x + v1.z * m1.data[2].x + m1.data[3].x;
            outRes.y = v1.x * m1.data[0].y + v1.y * m1.data[1].y + v1.z * m1.data[2].y + m1.data[3].y;
            outRes.z = v1.x * m1.data[0].z + v1.y * m1.data[1].z + v1.z * m1.data[2].z + m1.data[3].z;
            float w = v1.x * m1.data[0].w + v1.y * m1.data[1].w + v1.z * m1.data[2].w + m1.data[3].w;

            if(w != 1.0f) {
                outRes.x /= w;
                outRes.y /= w;
                outRes.z /= w;
                outRes.w /= w;
            }

            return outRes;
        }

        public static Mat4 operator +(Mat4 m1, Mat4 m2) {

            Mat4 res = new Mat4();
            res.data[0] = m1.data[0] + m2.data[0];
            res.data[1] = m1.data[1] + m2.data[1];
            res.data[2] = m1.data[2] + m2.data[2];
            res.data[3] = m1.data[3] + m2.data[3];

            return res;
        }

        public static Mat4 ProjectionMatrix4(float angleOfView, float near, float far) {
            float scale = 1.0f / (float)(Math.Tan(angleOfView * 0.5f * (float)(Math.PI) / 180.0f));
            Vec4 row1 = new Vec4(scale, 0.0f, 0.0f, 0.0f);
            Vec4 row2 = new Vec4(0.0f, scale, 0.0f, 0.0f);
            Vec4 row3 = new Vec4(0.0f, 0.0f, -far / (far - near), -1.0f);
            Vec4 row4 = new Vec4(0.0f, 0.0f, -far * near / (far - near), 0.0f);

            return new Mat4(row1, row2, row3, row4);
        }

        public static Mat4 RotationZMatrix(float angle) {

            float cosTheta = (float)Math.Cos(angle);
            float sinTheta = (float)Math.Sin(angle);

            Vec4 row1 = new Vec4(cosTheta, -sinTheta, 0.0f, 0.0f);
            Vec4 row2 = new Vec4(sinTheta, cosTheta, 0.0f, 0.0f);
            Vec4 row3 = new Vec4(0.0f, 0.0f, 1.0f, 0.0f);
            Vec4 row4 = new Vec4(0.0f, 0.0f, 0.0f, 1.0f);

            return new Mat4(row1, row2, row3, row4);
        }

        public static Mat4 RotationYMatrix(float angle) {

            float cosTheta = (float)Math.Cos(angle);
            float sinTheta = (float)Math.Sin(angle);

            Vec4 row1 = new Vec4(cosTheta, 0.0f, sinTheta, 0.0f);
            Vec4 row2 = new Vec4(0.0f, 1.0f, 0.0f, 0.0f);
            Vec4 row3 = new Vec4(-sinTheta, 0.0f, cosTheta, 0.0f);
            Vec4 row4 = new Vec4(0.0f, 0.0f, 0.0f, 1.0f);

            return new Mat4(row1, row2, row3, row4);
        }

        public static Mat4 RotationXMatrix(float angle) {

            float cosTheta = (float)Math.Cos(angle);
            float sinTheta = (float)Math.Sin(angle);

            Vec4 row1 = new Vec4(1.0f, 0.0f, 0.0f, 0.0f);
            Vec4 row2 = new Vec4(0.0f, cosTheta, -sinTheta, 0.0f);
            Vec4 row3 = new Vec4(0.0f, sinTheta, cosTheta, 0.0f);
            Vec4 row4 = new Vec4(0.0f, 0.0f, 0.0f, 1.0f);

            return new Mat4(row1, row2, row3, row4);
        }
    }
}
