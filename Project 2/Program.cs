using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество строк в массиве");
            int customLength = int.Parse(Console.ReadLine()); //пользователь вводит количество строк в массиве
            Console.WriteLine("Введите количество столбцов в массиве");
            int customWidth = int.Parse(Console.ReadLine()); //пользователь вводит количество столбцов в массиве
            int[,] matrixSource = new int[customLength, customWidth];
            int[,] matrixNew = new int[customLength, customWidth];//задается массив, количество строк и столбцов в котором определяет пользователь
            Random r = new Random();

            Console.WriteLine("\nПервая матрица: \n");
            for (int i = 0; i < matrixSource.GetLength(0); i++)
            {
                for (int j = 0; j < matrixSource.GetLength(1); j++)
                {
                    matrixSource[i, j] = r.Next(1, 100);
                    matrixNew[i, j] = r.Next(1, 100);
                    Console.Write($"{matrixSource[i, j]} ");
                }
                Console.WriteLine("");
            }

            Console.WriteLine("\nВторая матрица: \n");
            for (int k = 0; k < matrixNew.GetLength(0); k++)
            {
                for (int h = 0; h < matrixNew.GetLength(1); h++)
                {
                    Console.Write($"{matrixNew[k, h]} ");
                }
                Console.WriteLine("");
            }

            int[,] matrixSum = new int[customLength, customWidth];
            Console.WriteLine("\nСумма двух матриц: \n");
            for (int l = 0; l < customLength; l++)
            {
                for (int m = 0; m < customWidth; m++)
                {
                    matrixSum[l,m] = matrixSource[l, m] + matrixNew[l, m];
                    Console.Write($"{matrixSum[l, m]} ");
                }
                Console.WriteLine("");
            }
            Console.ReadKey();
        }
    }
}
