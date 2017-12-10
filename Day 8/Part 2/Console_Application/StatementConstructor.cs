using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Console_Application
{
    public class StatementConstructor
    {
        private readonly Dictionary<string, StatementCompareMethod> compareMethods = new Dictionary<string, StatementCompareMethod>();
        private readonly Dictionary<string, StatementNumberManipulationMethod> manipulationMethods = new Dictionary<string, StatementNumberManipulationMethod>();
        
        private Regex statementDeconstructor = new Regex(@"^([a-z]+) ([a-z]{3,3}) (-?\d+) if ([a-z]+) ([^ ]+) (-?\d+)$");
        
        public StatementConstructor()
        {
            Setup();
        }

        public Statement CreateStatementFromString(string statementLine)
        {
            Match match = statementDeconstructor.Match(statementLine);
            if (!match.Success)
                throw new Exception($"Failed to deconstruct line: '{statementLine}'");
            
            Statement statement = new Statement()
            {
                ChangeVariableWithName = match.Groups[1].Value,
                ManipulationMethod = manipulationMethods[match.Groups[2].Value],
                ManipulateWithValue = Int32.Parse(match.Groups[3].Value),
                CompareVariableWithName = match.Groups[4].Value,
                CompareMethod = compareMethods[match.Groups[5].Value],
                CompareToValue = Int32.Parse(match.Groups[6].Value)
            };

            return statement;
        }

        private void Setup()
        {
            compareMethods.Add("==", StatementCompareMethod.Equal);
            compareMethods.Add("!=", StatementCompareMethod.NotEqual);
            compareMethods.Add(">=", StatementCompareMethod.BiggerThanOrEqualTo);
            compareMethods.Add(">", StatementCompareMethod.BiggerThan);
            compareMethods.Add("<=", StatementCompareMethod.SmallerThanOrEqualTo);
            compareMethods.Add("<", StatementCompareMethod.SmallerThan);
            
            manipulationMethods.Add("inc", StatementNumberManipulationMethod.Increase);
            manipulationMethods.Add("dec", StatementNumberManipulationMethod.Decrease);
        }
    }
}