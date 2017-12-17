using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Console_Application
{
    internal class Program
    {
        private const string FileLocation = "../../../../input/input.txt";

        public static void Main(string[] args)
        {
            Regex inputDeconstructor = new Regex(@"^(\d+) <-> (.+)$");
            VillageCommunicationHandler communicationHandler = new VillageCommunicationHandler();

            foreach (string s in OpenInputFile(FileLocation))
            {
                Match match = inputDeconstructor.Match(s);
                if (match.Success)
                {
                    int villageId = int.Parse(match.Groups[1].Value);
                    int[] connectedToVillages = match.Groups[2].Value
                        .Split(new []{", "}, StringSplitOptions.RemoveEmptyEntries)
                        .Select(int.Parse)
                        .ToArray();
                    
                    communicationHandler.AddVillage(villageId, connectedToVillages);
                }
                else
                    Console.WriteLine($"Line '{s}' failed to parse");
            }
            
            Console.WriteLine(communicationHandler.CountAmountOfVillagesGroups());
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