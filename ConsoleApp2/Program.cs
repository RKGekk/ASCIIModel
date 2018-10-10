using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//домашнее задание Архангельского Олег Анатольевича
//Задание №1
//1. Дан целочисленный массив из 20 элементов. Элементы массива могут принимать 
//целые значения от –10 000 до 10 000 включительно. Написать программу, позволяющую 
//найти и вывести количество пар элементов массива, в которых хотя бы одно
// число делится на 3. В данной задаче под парой подразумевается два подряд идущих
//элемента массива. Например, для массива из пяти элементов: 6; 2; 9; –3; 6 – ответ: 4.
namespace ConsoleApp2 {
    class Program {
        static public bool eachNumber(int number, Func<int, bool> predicate) {

            number = Math.Abs(number);
            while (number != 0) {
                int curr = number % 10;
                if (curr != 0 && predicate(curr % 10)) {
                    return true;
                }
                number /= 10;
            }
            return false;
        }


        static void Main(string[] args) {

            int i = 20;
            int[] a = new int[i];
            Random rnd = new Random((int)DateTime.Now.Ticks);
            for (int j = 0; j < i; ++j) {
                a[j] = (rnd.Next() % 2 == 0 ? 1 : -1) * (rnd.Next() % 10000);
            }

            Func<int, bool> predicate = b => b % 3 == 0;
            int counter = 0;
            int pre = a[0];
            Console.WriteLine(pre.ToString());
            for (int k = 1; k < i; ++k) {

                int curr = a[k];
                bool currRes = eachNumber(curr, predicate);
                bool preRes = eachNumber(pre, predicate);

                Console.Write(curr + (currRes ? " *" : ""));

                if (currRes || preRes) {
                    ++counter;
                    Console.Write(currRes ? " +" : "");
                }

                Console.Write("\n");
                pre = curr;
            }

            Console.WriteLine("Pairs of numbers: " + counter.ToString());

            Console.ReadKey();
        }
    }
}
