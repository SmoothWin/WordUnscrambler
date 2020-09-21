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
                    bool status2 = false;
                    do
                    {
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
            catch (Exception ex)
            {
                Console.WriteLine(Constants.program_termination + ex.Message);
            }
        }

        private static void ExecuteScrambledWordsManualEntryScenario()
        {
            string manualInput = Console.ReadLine();
            char[] separators = { ',', ' ' };
            string[] scrambledWords = manualInput.Split(separators);

            DisplayMatchedUnscrambledWords(scrambledWords);

        }

        private static void ExecuteScrambledWordsInFileScenario()
        {
            string filename = Console.ReadLine();


            string[] scrambledWords = _fileReader.Read(filename);

            DisplayMatchedUnscrambledWords(scrambledWords);

        }

        private static void DisplayMatchedUnscrambledWords(string[] scrambledWords)
        {
            string[] wordList = _fileReader.Read("wordList.txt");

            List<MatchedWord> matchedWords = _wordMatcher.Match(scrambledWords, wordList);

            if (matchedWords == null)
            {
                Console.WriteLine(Constants.file_path_invalid);
            }
            else if (matchedWords.Any())
            {
                foreach (var matchedWord in matchedWords)
                {
                    Console.WriteLine(Constants.match_found, matchedWord.ScrambledWord, matchedWord.Word);
                }


            }
            else
            {
                Console.WriteLine(Constants.no_match_found);
            }
        }
    }
}
