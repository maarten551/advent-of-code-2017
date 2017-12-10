using System.Text;

namespace Console_Application
{
    public class GarbageCleaner
    {
        public static int AmountOfRemovedGarbage = 0;
        
        public static string RemoveCanceledCharacters(string charStream)
        {
            StringBuilder streamWithoutCanceledChars = new StringBuilder();

            for (var i = 0; i < charStream.Length; i++)
            {
                if (charStream[i] == '!')
                {
                    // Ignore next char
                    i++;
                    continue;
                }

                streamWithoutCanceledChars.Append(charStream[i]);
            }

            return streamWithoutCanceledChars.ToString();
        }

        /// <summary>
        /// Basically, removes every thing that isn't '{' or '}', it also accounts for garbage groups
        /// </summary>
        /// <param name="charStream"></param>
        /// <returns></returns>
        public static string RemoveGarbageFromStream(string charStream)
        {
            StringBuilder streamWithoutGarbage = new StringBuilder();
            bool isInGarbage = false;

            foreach (char character in charStream)
            {
                if (isInGarbage)
                {
                    isInGarbage = character != '>';

                    if (isInGarbage)
                        AmountOfRemovedGarbage++;
                    
                    continue;
                }
                
                if (character == '<')
                {
                    isInGarbage = true;
                    continue;
                }

                if (character == '{' || character == '}')
                streamWithoutGarbage.Append(character);
            }

            return streamWithoutGarbage.ToString();
        }
    }
}