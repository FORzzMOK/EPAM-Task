//Дописать событие
using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;


namespace _4._1.CUSTOM_SORT
{
    public static class Sort<T>
    {
        public static event Action<T[]> OnSortEnd;
        public static bool Comparison<Tn>(Tn number_1, Tn number_2) where Tn : IComparable<Tn>//Метод сортировки
        {
            return number_1.CompareTo(number_2) > 0;
        }
        public static void CustomSort(T[] myArray, Func<T, T, bool> comparison)//Основной метод
        {
            for (int i = 0; i < myArray.Length; i++)
            {
                for (int j = 1; j < myArray.Length; j++)
                {
                    if (comparison(myArray[j - 1], myArray[j]))
                    {
                        T thirdGlass = myArray[j - 1];
                        myArray[j - 1] = myArray[j];
                        myArray[j] = thirdGlass;
                    }
                }
            }
            if( myArray[0] is string)//Если мы передали массив строк, то он еще отсортирует строки по длинне, а предыдущая сортировка сортирует строки по алфавиту.
            {
                for (int i = 0; i < myArray.Length; i++)
                {
                    for (int j = 1; j < myArray.Length; j++)
                    {
                        if (myArray[j - 1].ToString().Length.CompareTo(myArray[j].ToString().Length) > 0)
                        {
                            T thirdGlass = myArray[j - 1];
                            myArray[j - 1] = myArray[j];
                            myArray[j] = thirdGlass;
                        }
                    }
                }
            }
            OnSortEnd(myArray);//Событие вызывающее метод, который вывод массив на экран
        }
        public static void CustomSortThread(T[] myArray, Func<T, T, bool> comparison, Action<T[], Func<T, T, bool>> customSort)//Метод запускающий всё в отдельном потоке
        {
            Thread sortThread = new Thread(() => customSort(myArray, comparison));
            sortThread.Start();
        }
        public static void Show(T[] myArray)
        {
            foreach (T item in myArray) Console.Write(string.Format("{0} ", item));
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            Sort<double>.OnSortEnd += Sort<double>.Show;
            Sort<string>.OnSortEnd += Sort<string>.Show;
            double[] myArray = new double[] { 3.4d, 3.1d, 4.5d, 1.5d, 5.2d, 8.7d, 9.8d, 1.4d, 4.2d, 6.8d };
            string[] myArrayString = new string[] { "few","fefg","gtyhg", "ku", "b", "c", "a", "hdfgf", "gdfesf", "ttt", "nm"};//вызываем метод, который в отдельном методе будет пробегать по массиву, и при помощи сортировки пузырьком, будет сравнивать соседние элементы методом Comparison
            Sort<string>.CustomSortThread(myArrayString, Sort<string>.Comparison, Sort<string>.CustomSort);
            //Sort<double>.CustomSortThread(myArray, Sort<double>.Comparison, Sort<double>.CustomSort);
            Console.ReadLine();
        }
    }
}
