using System;
using System.Collections.Generic;
using ContentConsole;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        /*Hash One word at a time*/
        [TestMethod]
        public void hashOneBadWord()
        {
            string badWords = "horrible";
            string expectedOutput = "h######e";

            Assert.AreEqual(expectedOutput, Program.hashBadWord(badWords));
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
                Assert.AreEqual(expectedListOfBadWords[i], Program.hashOutBadWords(listOfBadWords)[i]);
            }
        }
    }
}
