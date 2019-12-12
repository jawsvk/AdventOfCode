using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace AdventOfCode
{
    public class IntCode
    {
        public string ReadFile(string filePath)
        {
            string output = null;
            using (StreamReader reader = File.OpenText(filePath))
            {
                output = reader.ReadLine();
            }
            return output;
        }

        public int FindNounVerb(int[] inputArray, int targetValue)
        {
            int[] copy = (int[])inputArray.Clone();
            int noun = copy[1] - 1;
            int verb;

            do
            {
                noun++;
                copy = (int[])inputArray.Clone();
                copy[1] = noun;
                verb = FindVerb(copy, targetValue);
                copy[2] = verb;
                Restore(copy);

            }
            while (copy[0] != targetValue);

            return 100 * noun + verb;
        }

        private int FindVerb(int[] arr, int targetValue)
        {
            int verb = arr[2];
            int[] copy = (int[])arr.Clone();

            for (int i = verb; i < copy.Length; i++)
            {
                copy[2] = i;
                Restore(copy);
                if (copy[0] != targetValue) copy = (int[])arr.Clone();
                else return i;
            }

            return verb;
        }

        public int[] GetIntArray(string numberString) => Array.ConvertAll(numberString.Split(","), int.Parse);

        public int[] Restore(int[] input)
        {
            int i = 0;

            while (input[i] != 99)
            {
                var opcode = input[i];
                int var1 = input[input[++i]];
                int var2 = input[input[++i]];
                int position = input[++i];

                if (opcode == 1)
                {
                    input[position] = var1 + var2;
                }
                else if (opcode == 2)
                {
                    input[position] = var1 * var2;
                }

                i++;
            }

            return input;
        }
    }
}
