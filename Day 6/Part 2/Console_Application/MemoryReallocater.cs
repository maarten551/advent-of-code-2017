using System;
using System.Collections.Generic;
using System.Linq;

namespace Console_Application
{
    public class MemoryReallocater
    {
        private List<int> memoryValues = new List<int>();

        public int ReallocateMemory()
        {
            int iterationCounter;
            Dictionary<string, int> combinationHistory = new Dictionary<string, int>();
            string memoryAsString = MemoryToString();

            for (iterationCounter = 0; !combinationHistory.ContainsKey(memoryAsString); iterationCounter++)
            {
                combinationHistory.Add(memoryAsString, iterationCounter);
                
                SingleReallocate(FindHighestValueIndex());
                
                memoryAsString = MemoryToString();
            }

            return iterationCounter - combinationHistory[memoryAsString];
        }

        public void AddMemoryValue(int value)
        {
            memoryValues.Add(value);
        }

        private void SingleReallocate(int index)
        {
            int remainder = memoryValues[index] % memoryValues.Count;
            int addValueToEachField = (memoryValues[index] - remainder) / memoryValues.Count;
            memoryValues[index] = 0;

            for (var i = 0; i < memoryValues.Count; i++)
            {
                var memoryIndex = (i + index + 1) % memoryValues.Count;
                memoryValues[memoryIndex] += addValueToEachField;

                if (remainder > 0)
                {
                    memoryValues[memoryIndex]++;
                    remainder--;
                }
            }
        }

        private string MemoryToString()
        {
            return string.Join("-", memoryValues.Select(number => number.ToString()));
        }

        private int FindHighestValueIndex()
        {
            int lowestValueIndex = 0;

            for (var i = 1; i < memoryValues.Count; i++)
            {
                if (memoryValues[i] > memoryValues[lowestValueIndex])
                    lowestValueIndex = i;
            }

            return lowestValueIndex;
        }
    }
}