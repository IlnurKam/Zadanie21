using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Homework21

{
    class Program
    {
        static int[,] path = new int[5, 5];
        static void Main(string[] args)
        {
            Thread sadov1 = new Thread(sad1);
            Thread sadov2 = new Thread(sad2);

            sadov1.Start();
            sadov2.Start();

            sadov1.Join();
            sadov2.Join();

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Console.Write($"{path[i, j]}\t");
                }
                Console.WriteLine();
            }
            Console.ReadKey();
        }

        private static void sad1()
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (path[i, j] == 0)
                        path[i, j] = 1;
                    Thread.Sleep(1);
                }
            }
        }

        private static void sad2()
        {
            for (int i = 4; i > 0; i--)
            {
                for (int j = 4; j > 0; j--)
                {
                    if (path[j, i] == 0)
                        path[j, i] = 2;
                    Thread.Sleep(1);
                }
            }
        }
    }
}