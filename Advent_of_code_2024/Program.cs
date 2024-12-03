using Advent_of_code_2024.Day_1;
using System;

namespace Advent_of_code_2024 // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string x = Console.ReadLine();

            switch (x)
            {
                case "1":
                    Task1 task1 = new Task1();
                    task1.Solve();
                    break;
                //case 2:
                //    Task2 task2 = new Task2();
                //    task2.Solve();
                //    break;
                default:
                    Console.WriteLine("Invalid input");
                    break;
            }
        }
    }
}