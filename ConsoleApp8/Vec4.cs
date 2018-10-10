using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadMS3D {
    public class Vec4 : IEquatable<Vec4> {

        public float x;
        public float y;
        public float z;
        public float w;

        public Vec4() {
            this.x = 0.0f;
            this.y = 0.0f;
            this.z = 0.0f;
            this.w = 0.0f;
        }

        public Vec4(float x, float y, float z, float w) {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        public float dot(Vec4 other) {
            return this.x * other.x + this.y * other.y + this.z * other.z + this.w * other.w;
        }

        public float len() {
            return (float)Math.Sqrt(this.x * this.x + this.y * this.y + this.z * this.z + this.w * this.w);
        }

        public float square() {
            return this.x * this.x + this.y * this.y + this.z * this.z + this.w * this.w;
        }

        public void normalize() {
            float lenght = len();
            if (lenght > 0.0f) {
                this.x /= lenght;
                this.y /= lenght;
                this.z /= lenght;
                this.w /= lenght;
            }
        }

        public Vec4 unit() {
            Vec4 result = new Vec4();
            result.x = this.x;
            result.y = this.y;
            result.z = this.z;
            result.w = this.w;
            result.normalize();
            return result;
        }

        public bool Equals(Vec4 other) {

            double difference_x = Math.Abs(this.x * .0001 + float.Epsilon);
            double difference_y = Math.Abs(this.y * .0001 + float.Epsilon);
            double difference_z = Math.Abs(this.z * .0001 + float.Epsilon);
            double difference_w = Math.Abs(this.w * .0001 + float.Epsilon);

            if (Math.Abs(this.x - other.x) <= difference_x && Math.Abs(this.y - other.y) <= difference_y && Math.Abs(this.z - other.z) <= difference_z && Math.Abs(this.w - other.w) <= difference_w) {
                return true;
            }
            else {
                return false;
            }
        }

        public float this[int i] {
            get {
                if (i == 0) return this.x;
                if (i == 1) return this.y;
                if (i == 2) return this.z;
                return this.w;
            }
            set {
                if (i == 0) this.x = value;
                if (i == 1) this.y = value;
                if (i == 2) this.z = value;
                this.w = value;
            }
        }

        public static Vec4 operator +(Vec4 v1, Vec4 v2) {
            return new Vec4(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z, v1.w + v2.w);
        }

        public static Vec4 operator -(Vec4 v1, Vec4 v2) {
            return new Vec4(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z, v1.w - v2.w);
        }

        public static Vec4 operator *(Vec4 v1, float s1) {
            return new Vec4(v1.x * s1, v1.y * s1, v1.z * s1, v1.w * s1);
        }
    }
}
