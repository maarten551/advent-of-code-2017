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
            Regex regex = new Regex(@"([a-z]{1,}) \((\d{1,})\)( -> )?([a-z, ]+)?");
            TreeBuilder treeBuilder = new TreeBuilder();

            foreach (string s in OpenInputFile(FileLocation))
            {
                Match match = regex.Match(s);
                string parentName = match.Groups[1].Value;
                int parentValue = int.Parse(match.Groups[2].Value);
                string[] childNames = new string[0];

                if (match.Groups[4].Success)
                {
                    childNames = match.Groups[4].Value.Split(new[] {", "}, StringSplitOptions.RemoveEmptyEntries);
                }

                treeBuilder.AddTreeData(parentName, parentValue, childNames);
            }

            TreeNode firstTreeNode = treeBuilder.GetFirstTreeNode();
            (TreeNode, int) answer = treeBuilder.FindInbalancedNode(firstTreeNode).Value;
            
            Console.WriteLine($"{answer.Item1.Parent.Name} => {answer.Item1.Name}: {answer.Item1.Value} => {answer.Item2}");
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