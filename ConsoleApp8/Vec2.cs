using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadMS3D {
    class Vec2 : IEquatable<Vec2> {

        public float x;
        public float y;

        public Vec2() {
            this.x = 0.0f;
            this.y = 0.0f;
        }

        public Vec2(float x, float y) {
            this.x = x;
            this.y = y;
        }

        public float dot(Vec2 other) {
            return this.x * other.x + this.y * other.y;
        }

        public float len() {
            return (float)Math.Sqrt(this.x * this.x + this.y * this.y);
        }

        public float square() {
            return this.x * this.x + this.y * this.y;
        }

        public void normalize() {
            float lenght = len();
            if (lenght > 0.0f) {
                this.x /= lenght;
                this.y /= lenght;
            }
        }

        public Vec2 unit() {
            Vec2 result = new Vec2();
            result.x = this.x;
            result.y = this.y;
            result.normalize();
            return result;
        }

        public Vec2 lcross() {
            Vec2 result = new Vec2();
            result.x = -this.y;
            result.y = this.x;
            return result;
        }

        public Vec2 rcross() {
            Vec2 result = new Vec2();
            result.x = this.y;
            result.y = -this.x;
            return result;
        }

        public bool Equals(Vec2 other) {
            
            double difference_x = Math.Abs(this.x * .0001 + float.Epsilon);
            double difference_y = Math.Abs(this.y * .0001 + float.Epsilon);

            if (Math.Abs(this.x - other.x) <= difference_x && Math.Abs(this.y - other.y) <= difference_y) {
                return true;
            }
            else {
                return false;
            }
        }

        public float this[int i] {
            get {
                if (i == 0) return this.x;
                return this.y;
            }
            set {
                if (i == 0) this.x = value;
                this.y = value;
            }
        }

        public static Vec2 operator +(Vec2 v1, Vec2 v2) {
            return new Vec2(v1.x + v2.x, v1.y + v2.y);
        }

        public static Vec2 operator -(Vec2 v1, Vec2 v2) {
            return new Vec2(v1.x - v2.x, v1.y - v2.y);
        }

        public static Vec2 operator *(Vec2 v1, float s1) {
            return new Vec2(v1.x * s1, v1.y * s1);
        }
    }
}
