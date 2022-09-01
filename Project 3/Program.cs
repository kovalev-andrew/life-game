using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{

    public class LifeSimulation
    {
        private int _heigth;
        private int _width;
        private int[,] cells;

        /// <summary>
        /// Создаем новую игру
        /// </summary>
        /// <param name="Heigth">Высота поля.</param>
        /// <param name="Width">Ширина поля.</param>
        public LifeSimulation(int Heigth, int Width)
        {
            _heigth = Heigth;
            _width = Width;
            cells = new int[Heigth, Width];
            GenerateField();
        }

        /// <summary>
        /// Перейти к следующему поколению и вывести результат на консоль.
        /// </summary>
        public void DrawAndGrow()
        {
            DrawGame();
            Grow();
        }

        /// <summary>
        /// Двигаем состояние на одно вперед, по установленным правилам
        /// </summary>

        private void Grow()
        {
            for (int i = 0; i < _heigth; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    int numOfAliveNeighbors = GetNeighbors(i, j);
                    int numOfNeighborVirus = GetVirus(i, j);
                    if (cells[i, j] == 2)
                    {
                        if (numOfAliveNeighbors < 1)
                        {
                            cells[i, j] = 0;
                        }

                    }
                    if (cells[i, j] == 1)
                    {
                        if (numOfNeighborVirus >= 1)
                        {
                            cells[i, j] = 2;
                            continue;
                        }

                        if (numOfAliveNeighbors < 2)
                        {
                            cells[i, j] = 1;
                        }

                        if (numOfAliveNeighbors > 3)
                        {
                            cells[i, j] = 0;
                        }
                    }
                    else
                    {
                        if (numOfAliveNeighbors == 3)
                        {
                            cells[i, j] = 1;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Смотрим сколько живых соседий вокруг клетки.
        /// </summary>
        /// <param name="x">X-координата клетки.</param>
        /// <param name="y">Y-координата клетки.</param>
        /// <returns>Число живых клеток.</returns>

        private int GetNeighbors(int x, int y)
        {
            int NumOfAliveNeighbors = 0;
            int NeighborVirus = 0;

            for (int i = x - 1; i < x + 2; i++)
            {
                for (int j = y - 1; j < y + 2; j++)
                {
                    if (!((i < 0 || j < 0) || (i >= _heigth || j >= _width)))
                    {
                        if (cells[i, j] == 1) NumOfAliveNeighbors++;
                        if (cells[i, j] == 2) NeighborVirus++;
                    }
                }
            }
            return NumOfAliveNeighbors;
        }
        private int GetVirus(int x, int y)
        {
            int NumOfNeighborVirus = 0;

            for (int i = x - 1; i < x + 2; i++)
            {
                for (int j = y - 1; j < y + 2; j++)
                {
                    if (!((i < 0 || j < 0) || (i >= _heigth || j >= _width)))
                    {
                        if (cells[i, j] == 2) NumOfNeighborVirus++;
                    }
                }
            }
            return NumOfNeighborVirus;
        }


        /// <summary>
        /// Нарисовать Игру в консоле
        /// </summary>

        private void DrawGame()
        {
            for (int i = 0; i < _heigth; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    switch (cells[i, j])
                        {
                        case 0: 
                            Console.Write(" ");
                            break;
                        case 1:
                            Console.Write("X");
                            break;
                        case 2:
                            Console.Write("0");
                            break;

                    }
                    if (j == _width - 1) Console.WriteLine("\r");
                    /*
                    bool temp;
                    if (cells[i, j] == 1) temp = true;
                    else temp = false;
                    Console.Write(temp ? "x" : " ");
                    if (j == _width - 1) Console.WriteLine("\r");
                    */
                }
            }
            Console.SetCursorPosition(0, Console.WindowTop);
        }

        /// <summary>
        /// Инициализируем случайными значениями
        /// </summary>

        private void GenerateField()
        {
            
            Random generator = new Random();
            int virusPositionX = generator.Next(_heigth);
            int virusPositionY = generator.Next(_width);
            int number;
            for (int i = 0; i < _heigth; i++)
            {
                for (int j = 0; j < _width; j++)
                {
                    number = generator.Next(2);
                    cells[i, j] = ((number == 0) ? 0 : 1);
                }
            }
            cells[virusPositionX, virusPositionY] = 2; // добавляем вирус

        }
    }

    internal class Program
    {

        // Ограничения игры
        private const int Heigth = 20;
        private const int Width = 60;
        private const uint MaxRuns = 100;

        private static void Main(string[] args)
        {
            int runs = 0;
            LifeSimulation sim = new LifeSimulation(Heigth, Width);

            while (runs++ < MaxRuns)
            {
                sim.DrawAndGrow();

                // Дадим пользователю шанс увидеть, что происходит, немного ждем
                System.Threading.Thread.Sleep(100);
            }
        }
    }
}

