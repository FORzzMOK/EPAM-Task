using System;
using System.Collections;

namespace _4._4.NUMBER_ARRAY_SUM
{
    class Program
    {
        static void Main(string[] args)
        {
            var a = new int[] { 1, 2, 3, 4 };
            var b = new double[] { 1.1d, 2.4d, 3.1d, 4.7d };
            var c = new float[] { 1.9f, 2.5f, 3.1f, 4.0f };
            Console.WriteLine(a.IntArraySumm());
            Console.WriteLine(b.IntArraySumm());
            Console.WriteLine(c.IntArraySumm());
            Console.ReadLine();
        } 
    }
    public static class NumberExtension
    {
        public static int IntArraySumm(this int[] myArray)
        {
            int summ = 0;
            foreach(int item in myArray)
            {
                summ += item;
            }
            return summ;
        }
        public static double IntArraySumm(this double[] myArray)
        {
            double summ = 0;
            foreach (double item in myArray)
            {
                summ += item;
            }
            return summ;
        }
        public static float IntArraySumm(this float[] myArray)
        {
            float summ = 0;
            foreach (float item in myArray)
            {
                summ += item;
            }
            return summ;
        }
    }
}
