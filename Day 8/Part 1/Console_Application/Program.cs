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
            StatementConstructor statementConstructor = new StatementConstructor();
            RegisterHandler registerHandler = new RegisterHandler();
            
            foreach (string s in OpenInputFile(FileLocation))
            {
                Statement statement = statementConstructor.CreateStatementFromString(s);
                registerHandler.ProcessStatement(statement);
            }

            var highestValue = registerHandler.GetRegisterWithHighestValue();
            
            Console.WriteLine($"Register '{highestValue.Item1}' with value: {highestValue.Item2}");
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