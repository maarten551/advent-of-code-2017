namespace Console_Application
{
    public class GroupScoreCounter
    {
        public static int CountGroupScore(string groupChars)
        {
            int score = 0;
            int level = 0;

            foreach (char groupChar in groupChars)
            {
                if (groupChar == '{')
                    level++;
                else
                    score += level--;
            }

            return score;
        }
    }
}