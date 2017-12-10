using System;
using System.Collections.Generic;
using System.Linq;

namespace Console_Application
{
    public class RegisterHandler
    {
        private readonly Dictionary<string, int> registers = new Dictionary<string, int>();
        private (string, int)? highestValueWhileProcessing = null;

        public void ProcessStatement(Statement statement)
        {
            if (CompareStatement(statement))
            {
                int changeWithValue = (statement.ManipulationMethod == StatementNumberManipulationMethod.Increase)
                    ? statement.ManipulateWithValue
                    : -statement.ManipulateWithValue;

                int valueOfRegister = GetValueOfRegister(statement.ChangeVariableWithName) + changeWithValue;
                registers[statement.ChangeVariableWithName] = valueOfRegister;

                if (!highestValueWhileProcessing.HasValue)
                    highestValueWhileProcessing = (statement.ChangeVariableWithName, valueOfRegister);
                else if (highestValueWhileProcessing.Value.Item2 < valueOfRegister)
                    highestValueWhileProcessing = (statement.ChangeVariableWithName, valueOfRegister);
            }
        }

        public (string, int) GetRegisterWithHighestValue()
        {
            // Ugly ass solution, but works for now
            return registers
                .OrderBy(register => -register.Value)
                .Select(register => (register.Key, register.Value))
                .First();
        }
        
        public (string, int)? GetHighestRegisterValueWhileProcessing()
        {
            return highestValueWhileProcessing;
        }

        private bool CompareStatement(Statement statement)
        {
            int compareToRegisterValue = GetValueOfRegister(statement.CompareVariableWithName);

            switch (statement.CompareMethod)
            {
                case StatementCompareMethod.Equal: return compareToRegisterValue == statement.CompareToValue;
                case StatementCompareMethod.NotEqual: return compareToRegisterValue != statement.CompareToValue;
                case StatementCompareMethod.BiggerThanOrEqualTo: return compareToRegisterValue >= statement.CompareToValue;
                case StatementCompareMethod.BiggerThan: return compareToRegisterValue > statement.CompareToValue;
                case StatementCompareMethod.SmallerThanOrEqualTo: return compareToRegisterValue <= statement.CompareToValue;
                case StatementCompareMethod.SmallerThan: return compareToRegisterValue < statement.CompareToValue;
                default: throw new Exception("Compare method not found");
            }
        }

        private int GetValueOfRegister(string name)
        {
            if (!registers.ContainsKey(name))
                registers.Add(name, 0);

            return registers[name];
        }
    }
}