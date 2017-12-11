using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Console_Application
{
    internal class Program
    {
        private const string FileLocation = "../../../../input/input.txt";

        public static void Main(string[] args)
        {
            HexMazeSolver hexMazeSolver = new HexMazeSolver();

            OpenInputFile(FileLocation).First().Split(',').ToList().ForEach(direction => hexMazeSolver.AddStep(direction));
            
            Console.WriteLine($"Answer: {hexMazeSolver.AmountOfStepsBack()}");
        }

        private static IEnumerable<string> OpenInputFile(string relativeFileLocation)
        {
            String[] seperators = {"\r\n", "\r", "\n"};

            TextReader textReader = File.OpenText(FileLocation);

            String[] result = File.OpenText($"{Environment.CurrentDirectory}/{relativeFileLocation}")
                .ReadToEnd()
                .Split(seperators, StringSplitOptions.RemoveEmptyEntries);

            textReader.Close();

            return result;
        }
    }
}