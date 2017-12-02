namespace Console_Application
{
    public class ChecksumCalculator
    {
        private int currentChecksum = 0;

        public void AddToChecksumByField(int[] rowFields)
        {
            int? minValue = null;
            int? maxValue = null;
            
            foreach (int number in rowFields)
            {
                if (!minValue.HasValue || minValue > number)
                    minValue = number;

                if (!maxValue.HasValue || maxValue < number)
                    maxValue = number;
            }

            currentChecksum += maxValue.Value - minValue.Value;
        }

        public int CurrentChecksum => currentChecksum;
    }
}