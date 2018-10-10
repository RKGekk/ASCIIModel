using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1 {
    public class MyArray {

        private int[] arr;
        private int capacity;

        public MyArray() {
            arr = new int[10];
            capacity = arr.Length;
        }

        public MyArray(int capacity, int first, int step) {
            this.capacity = capacity;
            arr = new int[capacity];
            for (int i = 0; i < capacity; ++i) {
                arr[i] = first + i * step;
            }
        }

        public int Sum {
            get {
                int res = 0;
                foreach (int el in arr) {
                    res += el;
                }
                return res;
            }
        }

        public int MaxCount {
            get {
                int max = 0;
                foreach (int el in arr) {
                    if (el > max) {
                        max = el;
                    }
                }

                int res = 0;
                foreach (int el in arr) {
                    if (el == max) {
                        ++res;
                    }
                }
                return res;
            }
        }

        public void inverse() {
            for (int i = 0; i < capacity; ++i) {
                arr[i] *= -1;
            }
        }

        public void multi(int num) {
            for (int i = 0; i < capacity; ++i) {
                arr[i] *= -1;
            }
        }

        public override string ToString() {
            string res = "";
            for (int i = 0; i < capacity; ++i) {
                res += arr[i].ToString() + " ";
            }
            return res;
        }
    }
}
