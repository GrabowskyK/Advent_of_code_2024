using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_code_2024.Day_4
{
    internal class Task4
    {
        //List<List<char>> charList = new List<List<char>>();
        List<string> text = new List<string>();
        private int sum = 0;
        private void ReadInput()
        {
            using (var fileStream = File.OpenRead(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "../../../Day 4", "input.txt")))
            using (var streamReader = new StreamReader(fileStream))
            {
                String line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    text.Add(line);
                }
            }
        }

        void Solve() // When i finished this task i recognized that i could do it better.
                     // Create an array with directions because all of this case are similiar. 
                     // The diffrence bettwen in them is only the row or column. 
        {
            foreach (var line in text)
            {
                int index = text.IndexOf("X");
                while (index != -1)
                {
                    index = text.IndexOf("X", index + 1); // Szukaj od następnego znaku
                }
            }
        }
        private void checkIfWordExist(int index, int row)
        {
            int[][] direction = new int[][]{
                new int[] {1, 1}, //right up
                new int[] {-1, -1}, //left dowb
                new int[] {1, -1}, //right dowb
                new int[] {-1, 1}, //left up
            };
            foreach(var dir in direction)
            {
                try
                {
                    if (text[row + dir[0]][index + dir[1]] == 'M') 
                        if (text[row + dir[0] * 2][index + dir[1] * 2] == 'A')
                            if (text[row + dir[0] * 3][index + dir[1] * 3] == 'S')
                                sum += 1;
                }
                catch (IndexOutOfRangeException)
                {
                    continue;
                }
            }

        }
        private void horizontalCheck(int index, int row)
        {
            if (index >= 3)
            {
                if (text[row][index - 3] == 'S') //backwards
                    if (text[row][index - 2] == 'A')
                        if (text[row][index - 1] == 'M')
                            sum += 1;

            }
            if (index <= text[row].Length - 3) //First because i dont pass the row. All rows have same length
            {
                if (text[row][index + 3] == 'S') //forwards
                    if (text[row][index - 2] == 'A')
                        if (text[row][index - 1] == 'M')
                            sum += 1;
            }
        }

        private void verticalCheck(int index, int row)
        {
            if (index >= 3)
            {
                if (text[row - 3][index] == 'S') //backwards
                {
                    if (text[row - 2][index] == 'A')
                    {
                        if (text[row - 1][index] == 'M')
                        {
                            sum += 1;
                        }
                    }
                }
            }
            if (index <= text[row].Length - 3) //First because i dont pass the row. All rows have same length
            {
                if (text[row + 3][index] == 'S') //forwards
                {
                    if (text[row + 2][index] == 'A')
                    {
                        if (text[row + 1][index] == 'M')
                        {
                            sum += 1;
                        }
                    }
                }
            }
        }
        private void diagonalCheck(int index, int row)
        {
            int[][] direction = new int[][]{
                new int[] {1, 1}, //right up
                new int[] {-1, -1}, //left dowb
                new int[] {1, -1}, //right dowb
                new int[] {-1, 1}, //left up
            };
            foreach (var dir in direction)
            {
                try
                {
                    if (text[row + dir[0]][index + dir[1]] == 'M')
                        if (text[row + dir[0] * 2][index + dir[1] * 2] == 'A')
                            if (text[row + dir[0] * 3][index + dir[1] * 3] == 'S')
                                sum += 1;
                }
                catch (IndexOutOfRangeException)
                {
                    continue;
                }
            }
        }

        private void overlapCheck(int index, int row)
        {
            int overlap = 0;
            int nextrow = 0;
            if (index > text[row].Length - 3)
            {
                
                if (text[row + nextrow][(index + 3) % text[row].Length] == 'S') //forwards
                        if (text[row + nextrow][index - 2] == 'A')
                            if (text[row+ nextrow][index - 1] == 'M')
                                sum += 1;
            }
        }
    }
}
