using System;
using System.Collections.Generic;
using System.IO;

namespace Console_Application
{
    internal class Program
    {
        private const string FileLocation = "../../../../input/input.txt";
        
        public static void Main(string[] args)
        {
            int amountOfPassphases = 0;
            
            foreach (string s in OpenInputFile(FileLocation))
            {
                amountOfPassphases += (IsPassphaseValid(s)) ? 1 : 0;
            }
            
            Console.WriteLine(amountOfPassphases);
        }

        private static bool IsPassphaseValid(string passphase)
        {
            List<String> foundWords = new List<string>();

            string[] words = passphase.Split(' ');
            foreach (string word in words)
            {
                if (foundWords.Contains(word))
                    return false;
                
                foundWords.Add(word);
            }

            return true;
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