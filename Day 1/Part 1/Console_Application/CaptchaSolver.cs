namespace Console_Application
{
    public class CaptchaSolver
    {
        private int firstNumber;

        public int SolveCaptcha(int[] sequence)
        {
            if (sequence == null || sequence.Length == 0)
                return 0;

            int answer = 0;
            int? previousDigit = null;
            firstNumber = sequence[0];

            for (var i = 0; i < sequence.Length; i++)
            {
                var currentDigit = sequence[i];
                if (!previousDigit.HasValue)
                {
                    previousDigit = currentDigit;
                    continue;
                }

                if (i == sequence.Length - 1)
                {
                    if (currentDigit == firstNumber)
                        answer += currentDigit;
                }
                else if (previousDigit == currentDigit)
                    answer += currentDigit;

                previousDigit = currentDigit;
            }

            return answer;
        }
    }
}