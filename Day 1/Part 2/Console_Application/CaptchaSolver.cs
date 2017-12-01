namespace Console_Application
{
    public class CaptchaSolver
    {
        public int SolveCaptcha(int[] sequence)
        {
            if (sequence == null || sequence.Length == 0)
                return 0;

            int answer = 0;

            for (var i = 0; i < sequence.Length; i++)
            {
                int currentDigit = sequence[i];

                if (currentDigit == GetCircularNextHalfRoundDigit(sequence, i))
                    answer += currentDigit;
            }

            return answer;
        }

        private int GetCircularNextHalfRoundDigit(int[] sequence, int currentIndex)
        {
            int nextIndex = (sequence.Length / 2) + currentIndex;
            if (nextIndex >= sequence.Length)
                nextIndex -= sequence.Length;
            
            return sequence[nextIndex];
        }
    }
}