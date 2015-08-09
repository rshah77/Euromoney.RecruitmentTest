using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ContentConsole
{
    public class Driver
    {
        Phrases listOfPhrases = new Phrases();
        BannedWordsDictionary dictionary = new BannedWordsDictionary();

        public Driver() 
        {
            dictionary.defaultWordsInDictionary();
            Menu();
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
                Console.WriteLine("0 - Exit Program \n");

                string userChoice = Console.ReadLine();
                int userChoiceNum = 0;
                try
                {
                    userChoiceNum = Convert.ToInt32(userChoice);
                }
                catch (FormatException)
                {
                    Console.WriteLine("\n{0} is not a valid choice. \n", userChoice);
                    Menu();
                }
                
                if (userChoice != null && userChoice != "") 
                {
                    if (userChoiceNum > 0)
                    {
                        setUpUser(userChoiceNum);
                    }
                    else if (userChoiceNum > 4)
                    {
                        Menu();
                    }
                    else 
                    {
                        Environment.Exit(0);
                    }
                }
            }
        }

        public void adminMenu()
        {
            Console.WriteLine("Select an action from below by chosing the number associated to your choice");
            Console.WriteLine("1 : Show List Of Negative Word");
            Console.WriteLine("2 : Add New Negative Word");
            Console.WriteLine("3 : Remove Existing Negative Word");
            Console.WriteLine("0 : Main Menu");
        }

        public void setUpUser(int userType) 
        {
            switch(userType)
            {
                case 1:
                    /*user is able to input a new phrase
                     *that phrase is then analyzed and the user is shown 
                     *the number of Banned words that match Banned words in
                     *the Banned words dictionary
                     */
                    Console.WriteLine("Input a phrase to be analysed");
                    string inputText = Console.ReadLine();


                    Console.WriteLine("Scanned the text:");
                    Console.WriteLine(""+ inputText+"\n");
                    if (listOfPhrases.addPhraseToList(inputText)) 
                    {
                        Console.WriteLine("Total Number of Banned words: " + listOfPhrases.AnalayseAndCountNegWordsInPhrase(inputText));
                    }
                    
                    break;
                case 2:
                    /*Edit Banned Words Dictionary
                     * admin able to see all Banned words so they are able to check list of Banned words
                     * then add or remove Banned words from the dictionary
                    */
                    adminMenu();
                    string adminInput= Console.ReadLine();

                    int adminChoice = 0;
                    try
                    {
                        adminChoice = Convert.ToInt32(adminInput);
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("\n{0} is not a valid choice. \n", adminInput);
                        setUpUser(2);
                    }

                    if (adminChoice > 0)
                    {
                        if(adminChoice > 3)
                        {
                            Console.WriteLine("Choose one of the actions shown.\n");
                            setUpUser(2);
                        }
                        else if (adminChoice == 1)
                        {
                            Console.WriteLine("\nList OF Negatives in the Dictionary");
                            foreach (var negWord in dictionary.ListOfBannedWords) 
                            {
                                Console.WriteLine(negWord);
                            }
                            Console.WriteLine("****End of list****");
                            Console.WriteLine("");
                            setUpUser(2);
                        }
                        else if (adminChoice == 2)
                        {
                            Console.WriteLine("Input New Negative word to be added to list");
                            string newNegWord = Console.ReadLine();
                            Console.WriteLine(dictionary.addNewWord(newNegWord));
                            Console.WriteLine("");
                            setUpUser(2);
                        }
                        else if (adminChoice == 3)
                        {
                            Console.WriteLine("Input New Negative word to be added to list");
                            string existingNegWord = Console.ReadLine();
                            Console.WriteLine(dictionary.removeNegWord(existingNegWord) + "\n");
                            setUpUser(2);
                        }

                    }
                    else 
                    {
                        Menu();
                    }

                    break;
                case 3:
                    //Get List of all phrases with the Banned words sensitized
                    //using foreach loop iterate and print each phrase in the list 
                    List<string> phrasesForReaders = listOfPhrases.sensitizePhrasesForReaders();
                    int phraseNumber = 0;
                    Console.WriteLine("Phrases for Readers : \n");
                    foreach (var phrase in phrasesForReaders) 
                    {
                        phraseNumber++;
                        Console.WriteLine(phraseNumber + " : " + phrase + "\n");
                    }
                    break;
                case 4:
                    //Get list of all phrases inserted by users without sensitizing the negative words
                    //using foreach loop iterate and print each phrase in the list 
                    List<string> phrasesForContentCurator = listOfPhrases.getListOfPhrases();

                    foreach (var phrase in phrasesForContentCurator) 
                    {
                        Console.WriteLine(phrase);
                    }
                    break;
                default:
                    Menu();
                    break;
            }
        }

        //starting call for program.
        public static void Main(string[] args)
        {
            new Driver();
        }

    }

    


}
