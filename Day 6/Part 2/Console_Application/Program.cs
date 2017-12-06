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
            MemoryReallocater memoryReallocater = new MemoryReallocater();

            foreach (string s in OpenInputFile(FileLocation))
            {
                s.Split('\t')
                    .Select(int.Parse)
                    .ToList()
                    .ForEach(memoryReallocater.AddMemoryValue);
            }
            
            Console.WriteLine(memoryReallocater.ReallocateMemory());
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