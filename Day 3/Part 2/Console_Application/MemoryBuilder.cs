using System.Collections.Generic;

namespace Console_Application
{
    public class MemoryBuilder
    {
        Dictionary<int, Dictionary<int, int>> memoryValues = new Dictionary<int, Dictionary<int, int>>();
        
        public int GetPositionOfIndex(int reachTillMemory)
        {
            int outerGridLevel;
            int memoryCounter = 0;
            for (outerGridLevel = 0; memoryCounter < reachTillMemory; outerGridLevel++)
            {
                var amountOfNumbersInOuterGrid = 0;
                memoryCounter += (amountOfNumbersInOuterGrid = AmountOfNumbersInOuterGrid(outerGridLevel + 1));
                
                (int, int) currentPosition = GetBeginPositionByOuterGridLevel(outerGridLevel);
                for (int currentNumber = (memoryCounter - amountOfNumbersInOuterGrid) + 1; currentNumber <= memoryCounter; currentNumber++)
                {
                    int sum = CalculateSumOfMemoryPostion(currentPosition);
                    if (sum >= reachTillMemory)
                        return sum;

                    SetMemoryValue(currentPosition, sum);

                    (int, int) movementDirection = DecideMovementDirection(currentNumber, memoryCounter, amountOfNumbersInOuterGrid);
                    currentPosition.Item1 += movementDirection.Item1;
                    currentPosition.Item2 += movementDirection.Item2;
                }
            }
            
            return 0;
        }

        private int AmountOfNumbersInOuterGrid(int outerGridLevel)
        {
            if (outerGridLevel == 1)
                return 1;

            return ((outerGridLevel + outerGridLevel - 1) * 4) - 4;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="outerGridLevel"></param>
        /// <returns>(Horizontal position, Vertical position)</returns>
        private (int, int) GetBeginPositionByOuterGridLevel(int outerGridLevel)
        {
            if (outerGridLevel == 0)
                return (0, 0);

            return (outerGridLevel, -(outerGridLevel - 1));
        }

        private (int, int) DecideMovementDirection(int currentNumber, int maxNumberInOuterGrid, int numbersInOuterGrid)
        {
            if (maxNumberInOuterGrid == 1)
                return (0, 0);

            int cornerNumber = numbersInOuterGrid / 4;
            int numberOnGrid = (currentNumber - maxNumberInOuterGrid) + numbersInOuterGrid;

            // Right
            if (numberOnGrid < cornerNumber && numberOnGrid >= -cornerNumber)
                return (0, 1);

            // Up
            int nextCornerNumber = cornerNumber + cornerNumber;
            if (numberOnGrid < nextCornerNumber && numberOnGrid >= -nextCornerNumber)
                return (-1, 0);

            // Left
            nextCornerNumber += cornerNumber;
            if (numberOnGrid < nextCornerNumber && numberOnGrid >= -nextCornerNumber)
                return (0, -1);

            // Down
            return (1, 0);
        }

        private int CalculateSumOfMemoryPostion((int, int) position)
        {
            if (position.Item1 == 0 && position.Item2 == 0)
                return 1;

            int sum = 0;
            for (int i = 1; i >= -1; i--)
                for (int j = 1; j >= -1; j--)
                {
                    if (i == 0 && j == 0)
                        continue;

                    int? memoryValue = GetMemoryValue((position.Item1 + i, position.Item2 + j));
                    if (memoryValue.HasValue)
                        sum += memoryValue.Value;
                }

            return sum;
        }

        private void SetMemoryValue((int, int) position, int value)
        {
            if (!memoryValues.ContainsKey(position.Item1))
                memoryValues.Add(position.Item1, new Dictionary<int, int>());
            
            memoryValues[position.Item1].Add(position.Item2, value);
        }

        private int? GetMemoryValue((int, int) position)
        {
            if (!memoryValues.ContainsKey(position.Item1))
                return null;
                
            if (!memoryValues[position.Item1].ContainsKey(position.Item2))
                return null;
            
            return memoryValues[position.Item1][position.Item2];
        }
    }
}