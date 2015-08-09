using System;
using System.Collections.Generic;
using ContentConsole;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        BannedWordsDictionary bwDictionary = new BannedWordsDictionary();
        Phrases pa = new Phrases();

        /*Add new Negative Word*/
        [TestMethod]
        public void AddNewNegWord()
        {
            bwDictionary.defaultWordsInDictionary();
            string newNegWord = "impossible";
            string expectedOutput = "wordAdded";

            Assert.AreEqual(expectedOutput, bwDictionary.addNewWord(newNegWord));
        }

        /*Add Negative Word that already exists*/
        [TestMethod]
        public void AddExistingNegWord()
        {
            bwDictionary.defaultWordsInDictionary();
            string newNegWord = "impossible";
            string expectedOutput = "wordExists";

            //add the word to the list first then try adding again.
            bwDictionary.addNewWord(newNegWord);

            Assert.AreEqual(expectedOutput, bwDictionary.addNewWord(newNegWord));
        }

        /*Remove Negative Word that already exists*/
        [TestMethod]
        public void RemoveExistingNegWord()
        {
            bwDictionary.defaultWordsInDictionary();
            string newNegWord = "impossible";
            string expectedOutput = "wordRemoved";

            //add the word to the list first then try adding again.
            bwDictionary.addNewWord(newNegWord);

            Assert.AreEqual(expectedOutput, bwDictionary.removeNegWord(newNegWord));
        }

        /*Remove Negative Word that doesnt exist*/
        [TestMethod]
        public void RemoveNonExistingNegWord()
        {
            string newNegWord = "impossible";
            string expectedOutput = "wordNotExist";

            Assert.AreEqual(expectedOutput, bwDictionary.removeNegWord(newNegWord));
        }

        /*hash words in phrase*/
        [TestMethod]
        public void hashOnephrase()
        {
            bwDictionary.defaultWordsInDictionary();
            string phrase = "this is a bad phrase with horrible words";
            string expectedOutput = "this is a b#d phrase with h######e words";
            
            Assert.AreEqual(expectedOutput, pa.addHashedPhrase(phrase));
        }


        /*Hash One word at a time*/
        [TestMethod]
        public void hashOneBadWord()
        {
            string badWords = "horrible";
            string expectedOutput = "h######e";
            
            Assert.AreEqual(expectedOutput, bwDictionary.hashBannedWord(badWords));
        }

        /*Adding Phrase To Phrase List*/
        [TestMethod]
        public void AddingPhraseToPhraseList()
        {
            string PhraseToBeAdded = "This is a test phrase with the words bad, nasty and swine in it.";
            bool expectedOutput = true;
            Assert.AreEqual(expectedOutput, pa.addPhraseToList(PhraseToBeAdded));
        }

        /*Addin gPhrase That Already Exists To Phrase List*/
        [TestMethod]
        public void AddingPhraseThatAlreadyExistsToPhraseList()
        {
            string PhraseToBeAdded = "This is a test phrase with the words bad, nasty and swine in it.";
            bool expectedOutput = false;

            pa.addPhraseToList("This is a test phrase with the words bad, nasty and swine in it.");

            Assert.AreEqual(expectedOutput, pa.addPhraseToList(PhraseToBeAdded));
        }

        /*Analyse And Count Banned Words In Phrase*/
        [TestMethod]
        public void AnalyseAndCountBannedWordsInPhrase()
        {
            string PhraseToAnlayse = "This is a test phrase with the words bad, nasty and swine in it.";
            int expectedOutput = 3;

            Assert.AreEqual(expectedOutput, pa.AnalayseAndCountNegWordsInPhrase(PhraseToAnlayse));
        }

        /*Hash List of words*/
        [TestMethod]
        public void hashListOfBadWords()
        {
            List<string> listOfBadWords = new List<string>()
	        {
	            "bad",
	            "nasty",
	            "horrible"
	        };
            List<string> expectedListOfBadWords = new List<string>()
	        {
	            "b#d",
	            "n###y",
	            "h######e"
	        };
            for (var i = 0; i < expectedListOfBadWords.Count; i++)
            {
                Assert.AreEqual(expectedListOfBadWords[i], bwDictionary.hashOutBadWords(listOfBadWords)[i]);
            }
        }
    }
}
