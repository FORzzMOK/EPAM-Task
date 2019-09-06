using System;
using System.Text.RegularExpressions;

namespace _7._2.HTML_REPLACER
{
    class Program
    {
        static void Main(string[] args)
        {
            string myString = "<b>Это</b> текст <i>с</i> <font color=\"red\">HTML</font> кодами";
            string pattern = "<[^>]*>";
            string replacement = "_";
            Regex tegRegex = new Regex(pattern);
            string result = tegRegex.Replace(myString, replacement);
            Console.WriteLine("Replacement String: {0}", result);
            Console.ReadLine();
        }
    }
}
