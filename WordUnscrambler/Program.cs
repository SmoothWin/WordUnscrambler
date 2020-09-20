using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler
{
    class Program
    {
        private static readonly FileReader _fileReader = new FileReader();
        private static readonly WordMatcher _wordMatcher = new WordMatcher();


        static void Main(string[] args)
        {


            try
            {
                bool status = false;
                
                do
                {
                    
                    Console.WriteLine("Enter scrambled word(s) manually or as a file: F - file / M - manual");

                    String option = Console.ReadLine().Trim() ?? throw new Exception("String is empty/null");

                    switch (option.ToUpper())
                    {
                        case "F":
                            Console.WriteLine("Enter full path including the file name: ");
                            ExecuteScrambledWordsInFileScenario();
                            break;
                        case "M":
                            Console.WriteLine("Enter word(s) manually (seperated by commas if multiple)");
                            ExecuteScrambledWordsManualEntryScenario();
                            break;
                        default:
                            Console.WriteLine("The entered option was not recognized");
                            continue;
                    }
                    bool status2 = false; //to exit the next loop (loop validation)
                    do {
                        Console.WriteLine("Would you like to continue Y/N?");
                        String yesNo = Console.ReadLine().Trim() ?? throw new Exception("String is empty/null");
                        switch (yesNo.ToUpper())
                        {
                            case "Y":
                            case "YES":
                                status2 = true;
                                continue;

                            case "N":
                            case "NO":
                                status = true;
                                status2 = true;
                                break;
                            default:
                                Console.WriteLine("The entered option was not recognized");
                                continue;
                        }
                    } while (!status2);
                    
                } while (!status);

            }
            catch(Exception ex){
                Console.WriteLine("The program will be terminated" + ex.Message);
            }
        }

        private static void ExecuteScrambledWordsManualEntryScenario()
        {
            //get user's input - a comma separated string containing scrambled words
            string manualInput = Console.ReadLine();
            //exract the words into a string[] - use Split()
            char[] separators = { ',', ' '};
            string[] scrambledWords = manualInput.Split(separators);

            //display matched words
            DisplayMatchedUnscrambledWords(scrambledWords);

        }

        private static void ExecuteScrambledWordsInFileScenario()
        {
                //user input for scrambled words
                string filename = Console.ReadLine();


                //read words from file and store in string[]
                string[] scrambledWords = _fileReader.Read(filename);

                //display matched words
                DisplayMatchedUnscrambledWords(scrambledWords);

        }

        private static void DisplayMatchedUnscrambledWords(string[] scrambledWords)
        {
            //read the list of words in the wordlist.txt file (unscrambled words)
            string[] wordList = _fileReader.Read("wordList.txt");

            //call a word matcher method, to get a list of MatchedWord structs
            List<MatchedWord> matchedWords = _wordMatcher.Match(scrambledWords, wordList);

            //display the match - print to console

            //if statement Console output for when the file path is not valid
            if(matchedWords == null)
            {
                Console.WriteLine("File path is not valid");
            }
            else if (matchedWords.Any())
            {
                //loop through matchedWords and print to console contents of the structs
                foreach(var matchedWord in matchedWords)
                {
                    //write console
                    //MATCHED FOUND FOR "act": "cat"
                    Console.WriteLine("MATCH FOUND FOR \"{0}\": \"{1}\"", matchedWord.ScrambledWord, matchedWord.Word);
                }
                

            }
            else
            {
                //NO MATCHES HAVE BEEN FOUND
                Console.WriteLine("NO MATCHES HAVE BEEN FOUND");
            }
        }
    }
}
