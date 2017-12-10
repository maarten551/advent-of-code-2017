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
            KnotHasher hasher = new KnotHasher();

            List<byte> lengthSequence = OpenInputFile(FileLocation)
                .First()
                .Select(character => (byte) character)
                .Append((byte) 17).Append((byte) 31).Append((byte) 73).Append((byte) 47).Append((byte) 23)
                .ToList();

            for (int i = 0; i < 64; i++)
                lengthSequence.ForEach(hasher.PinchAndTwist);
            
            Console.WriteLine(BitConverter.ToString(hasher.CalculateDenseHash()).Replace("-", ""));
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