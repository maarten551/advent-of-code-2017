using System.Collections.Generic;

namespace Console_Application
{
    public class CPUJumper
    {
        private List<int> jumpTable;

        public CPUJumper(List<int> jumpTable)
        {
            this.jumpTable = jumpTable;
        }

        public int ResolveJumpTable()
        {
            int currentCPUStep = 0;
            int jumpTableIndex = 0;

            while (jumpTableIndex < jumpTable.Count)
            {
                int value;
                
                if (jumpTable[jumpTableIndex] >= 3)
                    value = jumpTable[jumpTableIndex]--;
                else
                    value = jumpTable[jumpTableIndex]++;
                
                jumpTableIndex += value;

                currentCPUStep++;
            }
            
            return currentCPUStep;
        }
    }
}