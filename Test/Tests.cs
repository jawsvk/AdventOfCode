using NUnit.Framework;
using AdventOfCode;

namespace Test
{
    public class Tests
    {
        private IntCode intCode;


        [SetUp]
        public void Setup()
        {
            intCode = new IntCode();
        }

        [Test]
        public void ProgramShouldReadCommaSeparatedStringFromFile()
        {
            string filePath = "C:\\Users\\javo\\source\\repos\\AdventOfCode\\inputs\\Day2.txt";
            string day2 = "1,0,0,3,1,1,2,3,1,3,4,3,1,5,0,3,2,9,1,19,1,5,19,23,2,9,23,27,1,27,5,31,2,31,13,35,1,35,9,39,1,39,10,43,2,43,9,47,1,47,5,51,2,13,51,55,1,9,55,59,1,5,59,63,2,6,63,67,1,5,67,71,1,6,71,75,2,9,75,79,1,79,13,83,1,83,13,87,1,87,5,91,1,6,91,95,2,95,13,99,2,13,99,103,1,5,103,107,1,107,10,111,1,111,13,115,1,10,115,119,1,9,119,123,2,6,123,127,1,5,127,131,2,6,131,135,1,135,2,139,1,139,9,0,99,2,14,0,0";
            
            Assert.AreEqual(intCode.ReadFile(filePath),day2);
        }

        [Test]
        public void ProgramShouldConvertCommaSeparatedStringToIntArray()
        {
            string numberString = "1,0,0,3,1,1,2,3,1,3,4,3,1,5";
            Assert.AreEqual(intCode.GetIntArray(numberString), new int[] { 1, 0, 0, 3, 1, 1, 2, 3, 1, 3, 4, 3, 1, 5 });
        }

        [Test]
        public void ProgramShouldRestoreProgram_opcode1()
        {
            var input = new int[] { 1, 0, 0, 0, 99 };
            var expected = new int[] { 2, 0, 0, 0, 99 };

            intCode.Restore(input);

            Assert.AreEqual(expected, input);
        }

        [Test]
        public void ProgramShouldRestoreProgram_opcode2()
        {
            var input = new int[] { 2, 3, 0, 3, 99 };
            var expected = new int[] { 2, 3, 0, 6, 99 };

            intCode.Restore(input);
            Assert.AreEqual(expected, input);
        }

        [Test]
        public void ProgramShouldRestoreProgram_opcode2_outputValueAtPos5()
        {
            var input = new int[] { 2, 4, 4, 5, 99, 0 };
            var expected = new int[] { 2, 4, 4, 5, 99, 9801 };
            intCode.Restore(input);

            Assert.AreEqual(expected, input);
        }

        [Test]
        public void ProgramShouldRestoreProgram_multipleCycles()
        {
            var input = new int[] { 1, 1, 1, 4, 99, 5, 6, 0, 99 };
            var expected = new int[] { 30, 1, 1, 4, 2, 5, 6, 0, 99 };
            intCode.Restore(input);

            Assert.AreEqual(expected, input);
        }

        [Test]
        public void ProgramShoulFindNoun_3500_shouldReturn910()
        {
            var input = new int[] { 1, 0, 0, 3, 2, 3, 11, 0, 99, 30, 40, 50 };
      
            int output = intCode.FindNounVerb(input,3500);

            Assert.AreEqual(100*9 + 10, output);
        }
    }
}