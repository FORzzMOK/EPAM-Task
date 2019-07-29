using System;
using System.Linq;
using System.Collections.Generic;
using static _4._6.I_SEEK_YOU.SearchMethods;

namespace _4._6.I_SEEK_YOU
{
    public static class SearchMethods
    { 
        public delegate int[] Function(int[] myArray);
        public static int[] SearchForPositiveNumbers(int[] myArray)//метод, непосредственно реализующего поиск;
        {
            var helpArray = new List<int>();
            foreach(int item in myArray)
            {
                if (item.CompareTo(0) >= 0) helpArray.Add(item);
            }
            return helpArray.ToArray();
        }

        public static int[] LINQSearch(int[] myArray)//метод поиска элементов в массиве при помощи LINQ-выражения
        {
            var helpArray = from item in myArray
                            where item > 0
                            select item;
            return helpArray.ToArray();
        }

        public static int[] SearchForPositiveNumbersDelegate(int[] myArray, Func<int[], int[]> SearchFunc) => SearchFunc(myArray);//метод, которому условие поиска передаётся через экземпляр делегата;
    }
    class Program
    {
        static void Main(string[] args)
        {
            var a = new int[] { 1, 2, 3, -3, -4, 1, 55, -1 };
            var b = SearchForPositiveNumbersDelegate(a, //метод, которому условие поиска передаётся через делегат в виде анонимного метода;
                delegate (int[] myArray)
            {
                var helpArray = new List<int>();
                foreach (int item in myArray)
                {
                    if (item.CompareTo(0) >= 0) helpArray.Add(item);
                }
                return helpArray.ToArray();
            });

            var с = SearchForPositiveNumbersDelegate(a, //метод, которому условие поиска передаётся через делегат в виде лямбда-выражения;
                (int[] myArray) =>
                {
                    var helpArray = new List<int>();
                    foreach (int item in myArray)
                    {
                        if (item.CompareTo(0) >= 0) helpArray.Add(item);
                    }
                    return helpArray.ToArray();
                });

            foreach (int item in b)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
            Console.ReadLine();
        }

    }
}
