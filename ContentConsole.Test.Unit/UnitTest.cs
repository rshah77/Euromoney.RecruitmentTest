using System;
using System.Collections.Generic;
using ContentConsole;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class UnitTests
    {
        BannedWordsDictionary bwDictionary = new BannedWordsDictionary();
        Phrases pa = new Phrases();

        /*Add new Negative Word*/
        [TestMethod]
        public void AddNewNegWord()
        {
            bwDictionary.DefaultWordsInDictionary();
            string newNegWord = "impossible";
            string expectedOutput = "Word Added";

            Assert.AreEqual(expectedOutput, bwDictionary.AddNewWord(newNegWord));
        }

        /*Add Negative Word that already exists*/
        [TestMethod]
        public void AddExistingNegWord()
        {
            bwDictionary.DefaultWordsInDictionary();
            string newNegWord = "impossible";
            string expectedOutput = "Word Exists";

            //add the word to the list first then try adding again.
            bwDictionary.AddNewWord(newNegWord);

            Assert.AreEqual(expectedOutput, bwDictionary.AddNewWord(newNegWord));
        }

        /*Remove Banned Word that already exists*/
        [TestMethod]
        public void RemoveExistingNegWord()
        {
            bwDictionary.DefaultWordsInDictionary();
            string newNegWord = "impossible";
            string expectedOutput = "Word Removed";

            //add the word to the list first then try adding again.
            bwDictionary.AddNewWord(newNegWord);

            Assert.AreEqual(expectedOutput, bwDictionary.RemoveNegWord(newNegWord));
        }

        /*Remove Banned Word that doesnt exist*/
        [TestMethod]
        public void RemoveNonExistingNegWord()
        {
            string newNegWord = "impossible";
            string expectedOutput = "Word Doesn't Exist";

            Assert.AreEqual(expectedOutput, bwDictionary.RemoveNegWord(newNegWord));
        }

        /*hash words in phrase*/
        [TestMethod]
        public void hashOnephrase()
        {
            bwDictionary.DefaultWordsInDictionary();
            string phrase = "this is a bad phrase with horrible words";
            string expectedOutput = "this is a b#d phrase with h######e words";
            
            Assert.AreEqual(expectedOutput, pa.AddHashedPhrase(phrase));
        }


        /*Hash One word at a time*/
        [TestMethod]
        public void hashOneBadWord()
        {
            string badWords = "horrible";
            string expectedOutput = "h######e";
            
            Assert.AreEqual(expectedOutput, bwDictionary.HashBannedWord(badWords));
        }

        /*Adding Phrase To Phrase List*/
        [TestMethod]
        public void AddingPhraseToPhraseList()
        {
            string PhraseToBeAdded = "This is a test phrase with the words bad, nasty and swine in it.";
            bool expectedOutput = true;
            Assert.AreEqual(expectedOutput, pa.AddPhraseToList(PhraseToBeAdded));
        }

        /*Adding Phrase That Already Exists To Phrase List*/
        [TestMethod]
        public void AddingPhraseThatAlreadyExistsToPhraseList()
        {
            string PhraseToBeAdded = "This is a test phrase with the words bad, nasty and swine in it.";
            bool expectedOutput = false;

            pa.AddPhraseToList("This is a test phrase with the words bad, nasty and swine in it.");

            Assert.AreEqual(expectedOutput, pa.AddPhraseToList(PhraseToBeAdded));
        }

        /*Analyse And Count Banned Words In Phrase*/
        [TestMethod]
        public void AnalyseAndCountBannedWordsInPhrase()
        {
            string PhraseToAnlayse = "This is a test phrase with the words bad, nasty and swine in it.";
            int expectedOutput = 3;

            Assert.AreEqual(expectedOutput, pa.AnalayseAndCountNegWordsInPhrase(PhraseToAnlayse));
        }
    }
}
