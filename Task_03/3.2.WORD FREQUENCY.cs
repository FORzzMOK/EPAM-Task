using System;
using System.Collections.Generic;

namespace _3._2.WORD_FREQUENCY
{
    class Program
    {
        static Dictionary<string, int> Frequency(string myString)
        {
            Dictionary<string, int> countWord = new Dictionary<string, int>();
            string helpString = "";
            for (int i = 0; i < myString.Length; i++)
            {
                if (char.IsDigit(myString[i]) || char.IsLetter(myString[i]) || char.IsNumber(myString[i])) { helpString += myString[i]; }//Считаем символы в строке, если не символ, не цифра и не номер, значит слово закончилось
                else if (helpString.Length == 0) { continue; }
                else
                {
                    helpString = helpString.ToLower();//Если такое слово есть то увеличиваем счетчик, если такого слова нет то добавляем его
                    if (countWord.ContainsKey(helpString)) { countWord[helpString]++; }
                    else countWord.Add(helpString, 1);
                    helpString = "";
                }
            }
            return countWord;
        }
        static void Main(string[] args)
        {
            Dictionary<string, int> countWord = Frequency("  Da khja da jhndb sa dada");
            foreach( KeyValuePair<string, int> item in countWord) Console.WriteLine("Word = {0}, Frequency = {1}", item.Key, item.Value);
            Console.ReadLine();
        }
    }
}
