using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler
{
    class WordMatcher
    {
        public List<MatchedWord> Match(string[] scrambledWords, string[] wordList)
        {
            List<MatchedWord> matchedWords = new List<MatchedWord>();

            // if statement for when the file path is invalid
            if(scrambledWords == null)
            {
                return null;
            }
            foreach(var scrambledWord in scrambledWords)
            {
                foreach(var word in wordList)
                {

                    //scrambledWord arleady matches word
                    if (scrambledWord.Equals(word, StringComparison.OrdinalIgnoreCase))
                    {
                        matchedWords.Add(BuildMatchedWord(scrambledWord, word));
                    }
                    else
                    {
                        //convert strings into character arrays
                        char[] scrambledWordArray = scrambledWord.ToCharArray();
                        char[] wordArray = word.ToCharArray();

                        //sort both character arrays (Array.sort())
                        //act -> sort -> act
                        //cat -> sort -> act
                        Array.Sort(scrambledWordArray);
                        Array.Sort(wordArray);

                        //convert char arrays back to strings
                        string scrambledOrdered = "";

                        foreach (var chr in scrambledWordArray)
                        {
                            scrambledOrdered += chr.ToString(); 
                        }

                        string wordOrdered = "";
                        foreach(var chr in wordArray)
                        {
                            wordOrdered += chr.ToString();
                        }

                        //compare the two strings
                        //if they are equal, add to matchedWords list
                        if (scrambledOrdered.Equals(wordOrdered, StringComparison.OrdinalIgnoreCase))
                        {
                            matchedWords.Add(BuildMatchedWord(scrambledWord, word));
                        }

                    }


                }
            }

            MatchedWord BuildMatchedWord(string scrambledWord, string word)
            {
                MatchedWord matchedWord = new MatchedWord
                {
                    ScrambledWord = scrambledWord,
                    Word = word
                };
            return matchedWord;
            }
            return matchedWords;
        }
    }
}
