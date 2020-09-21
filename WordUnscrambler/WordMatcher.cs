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

            if (scrambledWords == null)
            {
                return null;
            }
            foreach (var scrambledWord in scrambledWords)
            {
                foreach (var word in wordList)
                {

                    if (scrambledWord.Equals(word, StringComparison.OrdinalIgnoreCase))
                    {
                        matchedWords.Add(BuildMatchedWord(scrambledWord, word));
                    }
                    else
                    {
                        char[] scrambledWordArray = scrambledWord.ToCharArray();
                        char[] wordArray = word.ToCharArray();

                        Array.Sort(scrambledWordArray);
                        Array.Sort(wordArray);

                        string scrambledOrdered = "";

                        foreach (var chr in scrambledWordArray)
                        {
                            scrambledOrdered += chr.ToString();
                        }

                        string wordOrdered = "";
                        foreach (var chr in wordArray)
                        {
                            wordOrdered += chr.ToString();
                        }

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