using System;

namespace _4._5.TO_INT_OR_NOT_TO_INT
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = "213412";
            string b = "-213412";
            string c = "213d12";

            Console.WriteLine(string.Format("{0} - {3} \n{1} - {4} \n{2} - {5} \n", a, b, c, a.IsToInt(), b.IsToInt(), c.IsToInt()));
            Console.ReadLine();

        }
    }
    public static class StringExtensions
    {
        public static bool IsToInt(this string myString)
        {
            foreach(char item in myString)
            {
                if (!Char.IsNumber(item)) return false;
            }
            return true;
        } 
    }
}
