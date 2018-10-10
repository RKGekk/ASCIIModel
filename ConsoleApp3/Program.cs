using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//домашнее задание Архангельского Олег Анатольевича
//Задание №3
//3. Решить задачу с логинами из предыдущего урока, только логины и пароли считать из файла в массив.
namespace ConsoleApp3 {
    class Program {
        static bool autorize(string login, string password) {

            StreamReader sr = new StreamReader("..\\..\\users.dat");
            string loginData = sr.ReadLine();
            string passwordData = sr.ReadLine();
            sr.Close();

            if (login == loginData && password == passwordData) {
                return true;
            }
            return false;
        }

        static void Main(string[] args) {

            int count = 0;
            string pass;
            string login;
            bool authenticity = false;
            while (count < 3) {

                Console.Write("Please enter login: ");
                login = Console.ReadLine();

                Console.Write("Please enter password: ");
                pass = Console.ReadLine();

                authenticity = autorize(login, pass);
                if (authenticity) {
                    Console.WriteLine("Authorization success.");
                    break;
                }

                Console.WriteLine("No such user or wrong password!!!");
                ++count;
            }

            if (!authenticity) {
                Console.WriteLine("Authorization false.");
            }

            Console.ReadKey();
        }
    }
}
