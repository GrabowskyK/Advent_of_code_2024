using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_code_2024.Day_1
{
    public class Task1
    {
        private List<int> FirstNumbers = new List<int>();
        private List<int> SecondNumbers = new List<int>();
        private void ReadInput()
        {
            using (var fileStream = File.OpenRead(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../Day 1", "input.txt")))
            using (var streamReader = new StreamReader(fileStream))
            {
                String line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    var splitedString = line.Split(" ");
                    FirstNumbers.Add(int.Parse(splitedString[0]));
                    SecondNumbers.Add(int.Parse(splitedString[splitedString.Length-1]));
                }
            }
        }
        public void Solve()
        {
            ReadInput();
            int similarity = 0;
            foreach (var number in FirstNumbers)
            {
                int count = SecondNumbers.Count(x => x == number);
                similarity += count * number;
            }
            Console.WriteLine($"Similarity: {similarity}");

            FirstNumbers.Sort();
            SecondNumbers.Sort();

            int sum = FirstNumbers.Zip(SecondNumbers, (first, second) => Math.Abs(first - second)).Sum();
            Console.WriteLine($"Sum: {sum}");


        }

        
    }
}
