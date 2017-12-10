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
            string input = OpenInputFile(FileLocation).First();
            input = GarbageCleaner.RemoveCanceledCharacters(input);
            input = GarbageCleaner.RemoveGarbageFromStream(input);
            
            Console.WriteLine($"Group score: '{GroupScoreCounter.CountGroupScore(input)}'");
            Console.WriteLine($"Amount of removed garbage: '{GarbageCleaner.AmountOfRemovedGarbage}'");
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