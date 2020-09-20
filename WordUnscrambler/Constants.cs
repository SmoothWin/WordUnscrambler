using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler
{
    static class Constants
    {
        //main
        public const string enter_scrambled_words = "Enter scrambled word(s) manually or as a file: F - file / M - manual";

        public const string enter_full_path = "Enter full path including the file name: ";

        public const string enter_words = "Enter word(s) manually (seperated by commas if multiple)";

        public const string enter_NotRecognized = "The entered option was not recognized";

        public const string would_continueYN = "Would you like to continue Y/N?";

        public const string post_enter_recognition = "The entered option was not recognized";

        //main error
        public const string string_empty = "String is empty/null";

        public const string program_termination = "The program will be terminated";

        //DisplayMatchedUnscrambledWords 
        public const string file_path_invalid = "File path is not valid";

        public const string match_found = "MATCH FOUND FOR \"{0}\": \"{1}\"";

        public const string no_match_found = "NO MATCHES HAVE BEEN FOUND";
    }
}
