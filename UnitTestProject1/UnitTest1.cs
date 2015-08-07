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
        /*Hash One word at a time*/
        [TestMethod]
        public void hashOneBadWord()
        {
            string badWords = "horrible";
            string expectedOutput = "h######e";
            
            Assert.AreEqual(expectedOutput, bwDictionary.hashBannedWord(badWords));
        }

        /*Hash One word at a time*/
        [TestMethod]
        public void AddingPhraseToPhraseList()
        {
            string PhraseToBeAdded = "This is a test phrase with the words bad, nasty and swine in it.";
            bool expectedOutput = true;
            Assert.AreEqual(expectedOutput, pa.addPhraseToList(PhraseToBeAdded));
        }

        /*Hash One word at a time*/
        [TestMethod]
        public void AddingPhraseThatAlreadyExistsToPhraseList()
        {
            string PhraseToBeAdded = "This is a test phrase with the words bad, nasty and swine in it.";
            bool expectedOutput = false;

            pa.addPhraseToList("This is a test phrase with the words bad, nasty and swine in it.");

            Assert.AreEqual(expectedOutput, pa.addPhraseToList(PhraseToBeAdded));
        }

        /*Hash One word at a time*/
        [TestMethod]
        public void AnalyseAndCountBannedWordsInPhrase()
        {
            string PhraseToAnlayse = "This is a test phrase with the words bad, nasty and swine in it.";
            int expectedOutput = 3;

            Assert.AreEqual(expectedOutput, pa.CountBannedWordsInPhrase(PhraseToAnlayse));
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
