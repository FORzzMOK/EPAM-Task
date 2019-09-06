using System;
using System.Text.RegularExpressions;

namespace _7._1.DATE_EXISTANCE
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = "((0[1-9]|1[012])-(0[1-9]|1[0-9]|2[0-9]|3[01])-[0-9]{4})";
            Regex rgx = new Regex(pattern);
            string names = "2016 год наступит 01-01-2016";
            foreach (Match match in rgx.Matches(names))
                Console.WriteLine($"В тексте '{names}' содержится дата '{match.Value}'.");
            Console.ReadLine();
        }
    }
}
