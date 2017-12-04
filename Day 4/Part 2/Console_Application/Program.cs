using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;

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
            List<Dictionary<char, int>> lettersInWords = new List<Dictionary<char, int>>();

            string[] words = passphase.Split(' ');
            foreach (string word in words)
            {
                Dictionary<char, int> lettersInWord = WordToChars(word);

                bool anagramFound = lettersInWords.Any(lettersCount => WordsAreAnagrams(lettersCount, lettersInWord));

                if (anagramFound)
                    return false;
                
                lettersInWords.Add(lettersInWord);
            }

            return true;
        }

        private static Dictionary<char, int> WordToChars(string word)
        {
            Dictionary<char, int> letters = new Dictionary<char, int>();

            foreach (char c in word)
                if (!letters.ContainsKey(c))
                    letters.Add(c, 1);
                else
                    letters[c]++;

            return letters;
        }

        private static bool WordsAreAnagrams(Dictionary<char, int> a, Dictionary<char, int> b)
        {
            if (a.Count != b.Count)
                return false;

            foreach (KeyValuePair<char,int> keyValuePair in a)
            {
                if (!b.ContainsKey(keyValuePair.Key) || b[keyValuePair.Key] != keyValuePair.Value)
                    return false;
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