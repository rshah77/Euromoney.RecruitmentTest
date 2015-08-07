using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentConsole
{
    public class Phrases
    {
        //Global List Of Phrases
        private List<string> ListOfPhrasesInsertedByUsers = new List<string>();

        //constructor
        public Phrases() { }

        //Get the list of Phrases
        //returns the Global List of phrases entered by users
        public List<string> getListOfPhrases() 
        {
            return ListOfPhrasesInsertedByUsers;
        }

        //Adds a new phrase to the list of global list of phrases
        //returns true: to signify if the new phrase was added
        //or return false: if phrases is not added; that means phrase already exists
        public bool addPhraseToList(string phrase) 
        {
            List<string> ListOfPhrasesInsertedByUsers = getListOfPhrases();

            if (ListOfPhrasesInsertedByUsers.Count > 0) 
            {
                if (!ListOfPhrasesInsertedByUsers.Contains(phrase))
                {
                    ListOfPhrasesInsertedByUsers.Add(phrase);
                    return true;
                }
            }
            else
            {
                ListOfPhrasesInsertedByUsers.Add(phrase);
                return true;
            }
            return false;
        }

        public int CountBannedWordsInPhrase(string phrase) 
        {
            int bannedWordsCounted = 0;
            BannedWordsDictionary dwDict = new BannedWordsDictionary();
            var bannedWords = dwDict.ListOfBannedWords;
            foreach (var badWord in bannedWords)
            {
                if (phrase.Contains(badWord))
                {
                    bannedWordsCounted++;
                    //listOfBadWordsInPhrase.Add(badWord);
                    //phrase = phrase.Replace(badWord, new BannedWordsDictionary().hashBannedWord(badWord));
                }
            }

            return bannedWordsCounted;
        }
    }
}
