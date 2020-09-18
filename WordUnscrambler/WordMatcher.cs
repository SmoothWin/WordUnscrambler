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
                        char[] scrambledWordArray = word.ToCharArray();




                        //sort both character arrays (Array.sort())
                        //act -> sort -> act
                        //cat -> sort -> act

                        //convert char arrays back to strings

                        //compare the two strings
                        //if they are equal, add to matchedWords list
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
