using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadMS3D {
    public struct Complex : IEquatable<Complex> {
        public float r;
        public float i;

        public Complex(float r, float i) {
            this.r = r;
            this.i = i;
        }

        public Complex(float phi) {
            this.r = (float)(Math.Cos(phi));
            this.i = (float)(Math.Sin(phi));
        }

        public float getAbs() {
            double _r = (double)this.r;
            double _i = (double)this.i;
            return (float)Math.Sqrt(_r * _r + _i * _i);
        }

        public float getPhi() {
            double _r = (double)this.r;
            double _i = (double)this.i;

            if (_r >= 0.0d) {
                return (float)Math.Atan(_i / _r);
            }
            else {
                return (float)(Math.Atan(_i / _r) + Math.PI);
            }
            //return (float)Math.Asin(_r / (Math.Sqrt(_r * _r + _i * _i)));
        }

        public Complex mult(Complex other) {
            double _r1 = (double)this.r;
            double _i1 = (double)this.i;
            double _r2 = (double)other.r;
            double _i2 = (double)other.i;
            double _abs1 = Math.Sqrt(_r1 * _r1 + _i1 * _i1);
            double _abs2 = Math.Sqrt(_r2 * _r2 + _i2 * _i2);
            double _phi1 = _r1 >= 0.0d ? (float)Math.Atan(_i1 / _r1) : (float)(Math.Atan(_i1 / _r1) + Math.PI);
            double _phi2 = _r2 >= 0.0d ? (float)Math.Atan(_i2 / _r2) : (float)(Math.Atan(_i2 / _r2) + Math.PI); ;

            return new Complex((float)(_abs1 * _abs2 * Math.Cos(_phi1 + _phi2)), (float)(_abs1 * _abs2 * Math.Sin(_phi1 + _phi2)));
        }

        public static Complex operator +(Complex c1, Complex c2) {
            return new Complex(c1.r + c2.r, c1.i + c2.i);
        }

        public static Complex operator -(Complex c1, Complex c2) {
            return new Complex(c1.r - c2.r, c1.i - c2.i);
        }

        public static Complex operator *(Complex c1, Complex c2) {
            return new Complex(c1.r * c2.r - c1.i * c2.i, c1.r * c2.i + c1.i * c2.r);
        }

        public static Complex operator /(Complex c1, Complex c2) {
            return new Complex((c1.r * c2.r + c1.i * c2.i) / (c2.r * c2.r + c2.i * c2.i), (c1.i * c2.r - c1.r * c2.i) / (c2.r * c2.r + c2.i * c2.i));
        }

        public bool Equals(Complex other) {

            double difference_r = Math.Abs(this.r * .0001 + float.Epsilon);
            double difference_i = Math.Abs(this.i * .0001 + float.Epsilon);

            if (Math.Abs(this.r - other.r) <= difference_r && Math.Abs(this.i - other.i) <= difference_i) {
                return true;
            }
            else {
                return false;
            }
        }

        public override bool Equals(Object obj) {
            if (obj == null)
                return false;

            Complex personObj = (Complex)obj;
            if (personObj == null) {
                return false;
            }
            else {
                return Equals(personObj);
            }
        }

        public override int GetHashCode() {
            return this.ToString().GetHashCode();
        }

        public static bool operator ==(Complex c1, Complex c2) {
            return c1.Equals(c2);
        }

        public static bool operator !=(Complex c1, Complex c2) {
            return !c1.Equals(c2);
        }

        public override string ToString() {
            return this.r.ToString("N2") + " + " + this.i.ToString("N2") + "i";
        }
    }
}
