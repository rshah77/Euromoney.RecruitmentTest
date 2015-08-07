using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ContentConsole
{
    public class Driver
    {
        public Driver() { }

        public static void Main(string[] args)
        {
            Phrases listOfPhrases = new Phrases();

            BannedWordsDictionary dictionary = new BannedWordsDictionary();

            //Initalize the Banned Words Dictionary with default values
            dictionary.defaultWordsInDictionary();

            

            string content = "The weather in Manchester in winter is bad. It rains all the time - it must be horrible for people visiting.";
            System.Diagnostics.Debug.WriteLine(listOfPhrases.addPhraseToList(content));
            System.Diagnostics.Debug.WriteLine(listOfPhrases.addPhraseToList(content));
           
            

            System.Diagnostics.Debug.WriteLine("Scanned the text:");
            System.Diagnostics.Debug.WriteLine(content);
            System.Diagnostics.Debug.WriteLine("Total Number of negative words: " + 0);

            System.Diagnostics.Debug.WriteLine("Press ANY key to exit.");

        }

        public void Menu() 
        {
            while (true) 
            {
                Console.WriteLine("Select the Type of person you are from the list below by typing the number next to your choice:");
                Console.WriteLine("1 - User");
                Console.WriteLine("2 - Administrator");
                Console.WriteLine("3 - Reader");
                Console.WriteLine("4 - Content Curator");
                Console.WriteLine("0 - Exit Program");
                Console.ReadLine();
            }
        }

        public void setUpUser(int userType) 
        {
            switch(userType)
            {
                case 1:
                    Console.WriteLine("Input a phrase to be analysed");
                    string inputText = Console.ReadLine();
                    //AnalysePhrase(inputText);
                    break;
                case 2:
                    break;
                case 3:
                    break;
                case 4:
                    break;
                default:
                    break;
            }
        }

        

    }

    


}
