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
        public List<string> ListOfBannedWords = new List<string>();

        //constructor
        public BannedWordsDictionary() 
        {
            if (ListOfBannedWords.Count() == 0)
            {
                this.DefaultWordsInDictionary();
            }
        }
        
        //Adding some default banned words to Dictionary
        public void DefaultWordsInDictionary()
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
        public bool CheckIfBannedWordExists(string bannedWord)
        {
            if (ListOfBannedWords.Contains(bannedWord)) { return true; }
            return false;
        }
        
        //Add new Word to Banned word dictionary 
        public string AddNewWord(string bannedWord) 
        {
            string newWordStatus = "Word Exists";
            if (!CheckIfBannedWordExists(bannedWord))
            {
                ListOfBannedWords.Add(bannedWord);
                newWordStatus = "Word Added";
            }
            return newWordStatus;
        }

        //Remove Word to Banned word dictionary 
        public string RemoveNegWord(string bannedWord)
        {
            string wordstatus = "Word Doesn't Exist";
            if (CheckIfBannedWordExists(bannedWord))
            {
                ListOfBannedWords.Remove(bannedWord);
                wordstatus = "Word Removed";
            }
            return wordstatus;
        }

        //Get Total Count of Banned words
        public int NumberOfBannedWords() 
        {
            return ListOfBannedWords.Count();
        }

        //Hash Banned Word
        public string HashBannedWord(string bannedword)
        {
            char[] word = bannedword.ToCharArray();
            for (int i = 1; i < word.Count() - 1; i++)
            {
                word[i] = '#';  
            }
            return new string(word);
        }

        /**Story 3**/
        public List<string> HashOutBadWords(List<string> listOfBadWordsInPhrase)
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
