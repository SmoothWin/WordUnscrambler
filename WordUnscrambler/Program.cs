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
                    
                    Console.WriteLine(Constants.enter_scrambled_words);

                    String option = Console.ReadLine().Trim() ?? throw new Exception(Constants.string_empty);

                    switch (option.ToUpper())
                    {
                        case "F":
                            Console.WriteLine(Constants.enter_full_path);
                            ExecuteScrambledWordsInFileScenario();
                            break;
                        case "M":
                            Console.WriteLine(Constants.enter_words);
                            ExecuteScrambledWordsManualEntryScenario();
                            break;
                        default:
                            Console.WriteLine(Constants.enter_NotRecognized);
                            continue;
                    }
                    bool status2 = false; //to exit the next loop (loop validation)
                    do {
                        Console.WriteLine(Constants.would_continueYN);
                        String yesNo = Console.ReadLine().Trim() ?? throw new Exception(Constants.string_empty);
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
                                Console.WriteLine(Constants.post_enter_recognition);
                                continue;
                        }
                    } while (!status2);
                    
                } while (!status);

            }
            catch(Exception ex){
                Console.WriteLine(Constants.program_termination + ex.Message);
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
                Console.WriteLine(Constants.file_path_invalid);
            }
            else if (matchedWords.Any())
            {
                //loop through matchedWords and print to console contents of the structs
                foreach(var matchedWord in matchedWords)
                {
                    //write console
                    //MATCHED FOUND FOR "act": "cat"
                    Console.WriteLine(Constants.match_found, matchedWord.ScrambledWord, matchedWord.Word);
                }
                

            }
            else
            {
                //NO MATCHES HAVE BEEN FOUND
                Console.WriteLine(Constants.no_match_found);
            }
        }
    }
}
