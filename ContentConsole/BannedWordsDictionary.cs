using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentConsole
{
    public class BannedWordsDictionary
    {
        //Global List of Banned Words
        public List<string> ListOfBannedWords;

        //constructor
        public BannedWordsDictionary() 
        {
            this.defaultWordsInDictionary();
        }
        
        //Adding some default banned words to Dictionary
        public void defaultWordsInDictionary()
        {
            ListOfBannedWords = new List<string>() 
            {
                "swine", 
                "bad", 
                "nasty", 
                "horrible"
            };
        }

        //Check If Banned Word Exists
        public bool checkIfBannedWordExists(string bannedWord)
        {
            if (ListOfBannedWords.Contains(bannedWord)) { return true; }
            return false;
        }
        
        //Add new Word to Banned word dictionary 
        public string addNewWord(string bannedWord) 
        {
            string newWordStatus = "wordExists";
            if (checkIfBannedWordExists(bannedWord))
            {
                ListOfBannedWords.Add(bannedWord);
                newWordStatus = "wordAdded";
            }
            return newWordStatus;
        }

        //Get Total Count of Banned words
        public int numberOfBannedWords() 
        {
            return ListOfBannedWords.Count();
        }

        //Hash Banned Word
        public string hashBannedWord(string bannedword)
        {
            char[] word = bannedword.ToCharArray();
            for (int i = 1; i < word.Count() - 1; i++)
            {
                word[i] = '#';  
            }
            return new string(word);
        }

        /**Story 3**/
        public List<string> hashOutBadWords(List<string> listOfBadWordsInPhrase)
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
