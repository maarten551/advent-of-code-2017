﻿using System;
using System.Collections.Generic;
using System.IO;

namespace Console_Application
{
    internal class Program
    {
        private const string FileLocation = "../../../../input/input.txt";
        
        public static void Main(string[] args)
        {
            MemoryBuilder memoryBuilder = new MemoryBuilder();
            
            foreach (string s in OpenInputFile(FileLocation))
            {
                int memoryPosition = memoryBuilder.GetPositionOfIndex(int.Parse(s));
                Console.WriteLine(memoryPosition);
            }
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