using System;
using System.Text.RegularExpressions;

namespace _7._3.EMAIL_FINDER
{
    class Program
    {
        static void Main(string[] args)
        {
            string pattern = @"([a-z0-9_-]+\.)*[a-z0-9_-]+@[a-z0-9_-]+(\.[a-z0-9_-]+)*\.[a-z]{2,6}";
            Regex rgx = new Regex(pattern);
            string names = "Иван: ivan@mail.ru, Петр: p_ivanov@mail.rol.ru";
            if (rgx.IsMatch(names)) Console.WriteLine("Найденные адреса электронной почты:");
            foreach (Match match in rgx.Matches(names))
                Console.WriteLine(match.Value);
            Console.ReadLine();
        }
    }
}
