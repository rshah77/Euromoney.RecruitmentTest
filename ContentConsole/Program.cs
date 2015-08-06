using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ContentConsole
{
    public class Program
    {
        public Program() { }

        public static void Main(string[] args)
        {
            string[] bannedWords = { "swine", "bad", "nasty", "horrible" };

            string content = "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";

            List<string> listOfBadWordsInPhrase = new List<string>();
            int badWords = 0;
            foreach (var badWord in bannedWords)
            {
                if (content.Contains(badWord))
                {
                    badWords++;
                    listOfBadWordsInPhrase.Add(badWord);
                    content = content.Replace(badWord, hashBadWord(badWord));
                }
            }

            System.Diagnostics.Debug.WriteLine("Scanned the text:");
            System.Diagnostics.Debug.WriteLine(content);
            System.Diagnostics.Debug.WriteLine("Total Number of negative words: " + badWords);

            System.Diagnostics.Debug.WriteLine("Press ANY key to exit.");

        }

        /**Story 3**/
        public static List<string> hashOutBadWords(List<string> listOfBadWordsInPhrase)
        {
            List<string> returnList = new List<string>();
            foreach (var word in listOfBadWordsInPhrase)
            {
                char[] badword = word.ToCharArray();
                for (int i = 1; i < badword.Count() - 1; i++)
                {
                    badword[i] = '#';
                }
                returnList.Add(new string(badword));
            }

            return returnList;
        }

    }

    


}
