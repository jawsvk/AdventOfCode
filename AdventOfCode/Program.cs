using System;

namespace AdventOfCode
{
    class Program
    {
        static void Main(string[] args)
        {
            string filePath = "C:\\Users\\javo\\source\\repos\\AdventOfCode\\inputs\\Day2.txt";
            var program = new IntCode();

            int[] inputArray = program.GetIntArray(program.ReadFile(filePath));

            int answer = program.FindNounVerb(inputArray, 19690720);

            Console.WriteLine(" answer is " + answer);

        }


    }
}
