﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContentConsole
{
    public class Phrases
    {
        //Global List Of Phrases
        private List<string> ListOfPhrases = new List<string>();
        private List<string> ListOfHashedPhrases = new List<string>();
        BannedWordsDictionary dwDict = new BannedWordsDictionary();

        //constructor
        public Phrases() { }

        //Get the list of Phrases   
        //returns the Global List of phrases entered by users
        public List<string> getListOfPhrases() 
        {
            return ListOfPhrases;
        }

        //
        public List<string> getListOfHashedPhrases()
        {
            return ListOfHashedPhrases;
        }

        public string addHashedPhrase(string phrase) 
        {
            //uncomment the below line when running unit test
            //dwDict.defaultWordsInDictionary();
            var bannedWords = dwDict.ListOfBannedWords;
            foreach (var badWord in bannedWords)
            {
                if (phrase.ToLower().Contains(badWord))
                {
                    phrase = phrase.ToLower().Replace(badWord, new BannedWordsDictionary().hashBannedWord(badWord));
                }
            }
            return phrase;
            //ListOfHashedPhrases.Add(phrase);
        }

        public List<string> sensitizePhrasesForReaders() 
        {
            ListOfHashedPhrases = new List<string>();
            foreach (var phrase in ListOfPhrases) 
            {
                ListOfHashedPhrases.Add(addHashedPhrase(phrase));
            }
            return ListOfHashedPhrases;
        }

        //Adds a new phrase to the list of global list of phrases
        //returns true: to signify if the new phrase was added
        //or return false: if phrases is not added; that means phrase already exists
        public bool addPhraseToList(string phrase) 
        {
            //List<string> ListOfPhrasesInsertedByUsers = getListOfPhrases();

            if (ListOfPhrases.Count > 0) 
            {
                if (!ListOfPhrases.Contains(phrase))
                {
                    ListOfPhrases.Add(phrase);
                    return true;
                }
            }
            else
            {
                ListOfPhrases.Add(phrase);
                return true;
            }
            return false;
        }

        public int AnalayseAndCountNegWordsInPhrase(string phrase) 
        {
            int bannedWordsCounted = 0;
            
            var bannedWords = new BannedWordsDictionary().ListOfBannedWords;
            foreach (var badWord in bannedWords)
            {
                if (phrase.ToLower().Contains(badWord))
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