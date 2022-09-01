using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arrays
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество строк в массиве");
            int customLength = int.Parse(Console.ReadLine()); //пользователь вводит количество строк в массиве
            Console.WriteLine("Введите количество столбцов в массиве");
            int customWidth = int.Parse(Console.ReadLine()); //пользователь вводит количество столбцов в массиве
            int[,] customArray = new int[customLength, customWidth]; //задается массив, количество строк и столбцов в котором определяет пользователь
            Random r = new Random();
            int sum = 0; //сумма всех элементов массива
            
            for (int i = 0; i < customArray.GetLength(0); i++)
            {
                for (int j = 0; j < customArray.GetLength(1); j++)
                {
                    customArray[i, j] = r.Next(1, 100);
                    Console.Write($"{customArray[i, j]} ");
                    sum += customArray[i, j];
                }
                Console.WriteLine("");
            }
            Console.WriteLine($"Сумма всех элементов: {sum}");
            Console.ReadKey();

        }
    }
}
