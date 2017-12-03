namespace Console_Application
{
    public class MemoryBuilder
    {
        public (int, int) GetPositionOfIndex(int reachTillMemory)
        {
            int outerGridLevel, amountOfNumbersInOuterGrid = 0, memoryCounter = 0;
            for (outerGridLevel = 0; memoryCounter < reachTillMemory; outerGridLevel++)
            {
                memoryCounter += (amountOfNumbersInOuterGrid = AmountOfNumbersInOuterGrid(outerGridLevel + 1));
            }

            (int, int) currentPosition = GetBeginPositionByOuterGridLevel(outerGridLevel);
            for (int currentNumber = (memoryCounter - amountOfNumbersInOuterGrid) + 1; currentNumber <= memoryCounter; currentNumber++)
            {
                if (currentNumber == reachTillMemory)
                    return currentPosition;

                (int, int) movementDirection = DecideMovementDirection(currentNumber, memoryCounter, amountOfNumbersInOuterGrid);
                currentPosition.Item1 += movementDirection.Item1;
                currentPosition.Item2 += movementDirection.Item2;
            }

            return currentPosition;
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
            if (outerGridLevel == 1)
                return (0, 0);

            return (outerGridLevel - 1, -(outerGridLevel - 2));
        }

        private (int, int) DecideMovementDirection(int currentNumber, int maxNumberInOuterGrid, int numbersInOuterGrid)
        {
            if (maxNumberInOuterGrid == 1)
                return (0, 0);

            int beginNumber = (maxNumberInOuterGrid - numbersInOuterGrid) + 1;
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
    }
}