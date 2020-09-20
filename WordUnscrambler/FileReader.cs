using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordUnscrambler
{
    class FileReader
    {
        public string[] Read(string fullname)
        {
            //declare string[] hold content of file

            //try/catch

            //read from file - ReadAllLines()

            //return file contents.which string[]
            try
            {
                string[] fileContent = File.ReadAllLines(fullname);

                return fileContent;

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            

        }
    }
}
