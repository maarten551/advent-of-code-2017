namespace Console_Application
{
    public class ChecksumCalculator
    {
        private int currentChecksum = 0;

        public void AddToChecksumByField(int[] rowFields)
        {
            for (var fieldIndex = 0; fieldIndex < rowFields.Length; fieldIndex++)
            {
                int firstValue = rowFields[fieldIndex];
                for (var i = fieldIndex + 1; i < rowFields.Length; i++)
                {
                    int secondValue = rowFields[i];

                    int smallestValue = (firstValue > secondValue) ? secondValue : firstValue;
                    int largerValue = (firstValue > secondValue) ? firstValue : secondValue;
                    float divide = (float)largerValue / smallestValue;

                    if (divide - (int) divide < 0.0001)
                    {
                        currentChecksum += (int) divide;
                        return;
                    }
                }
            }
        }

        public int CurrentChecksum => currentChecksum;
    }
}