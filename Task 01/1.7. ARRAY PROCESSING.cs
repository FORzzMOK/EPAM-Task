using System;

namespace _1._7._ARRAY_PROCESSING
{
    class Program
    {
        static void Quicksort(int[] OurArray, int ArraySize)
        {//функция сортировки подсчетом. Преимущество данной сортировки в линейной асимптотике. Её недостаток в том что вспомогательный массив, в иделае должен быть значительно меньше основного массива
            int min = OurArray[0], max = OurArray[0], SizeHelpArray = 0, j = 0;//так же, вспомогательный массив может занимать очень много памяти, но для нашей ситуации сортировка подходит, так как вспомогательный массив будет не больше 200 значений.
            for (int i = 0; i < ArraySize; i++)
            {//Находим минимум и максимум для того что бы создать вспомогательный массив
                if (OurArray[i] > max) max = OurArray[i];
                if (OurArray[i] < min) min = OurArray[i];
            }
            Console.WriteLine("Min = {0}\nMax = {1}", min, max);
            SizeHelpArray = max - min + 1;//размер вспомогательного массива
            int[] HelpArroy = new int[SizeHelpArray];//создаем вспомогательный массив и заполняем его нулями
            for (int i = 0; i < SizeHelpArray; i++)
            {
                HelpArroy[i] = 0;
            }
            for (int i = 0; i < ArraySize; i++)//подсчитываем числа в основном массиве
            {
                HelpArroy[OurArray[i] - min]++;//делаем смещение на минимум, для того что бы минимальное значение соответствовало нулевому индексу мссива
            }
            for (int i = 0; i < SizeHelpArray; i++)
            {//переписываем наш массив согласно подсчитанным числам из вспомогательного в основной
                while (HelpArroy[i] != 0)
                {
                    OurArray[j] = i + min;
                    HelpArroy[i]--;
                    j++;
                }
            }
        }
        static void Show(int[] OurArray, int ArraySize)
        {//функция выводит массив на экран, в строку по 20 чисел для удобства чтения
            for (int i = 0; i < ArraySize; i++)
            {
                Console.Write("{0} ", OurArray[i]);
                if ((i + 1) % 20 == 0 && i != 0) Console.Write("\n");
            }
            Console.Write("\n");
        }
        static void Filling(int[] OurArray, int ArraySize)
        {//заполняет массив случайными числами от 0 до 200
            Random r = new Random();
            for (int i = 0; i < ArraySize; i++)
            {
                OurArray[i] = r.Next(200);
            }
        }
        static void Main(string[] args)
        {
            int ArraySize = 400;//размер нашего массива
            int[] OurArray = new int[ArraySize];// Размер массива фиксированный, 1000 элементов
            Filling(OurArray, ArraySize);//Вызываем функцию заполнения массива
            Console.WriteLine("This is not a sorted array.");
            Show(OurArray, ArraySize);//Выводим массив в экран
            Quicksort(OurArray, ArraySize);//Сортируем массив
            Console.WriteLine("This is a sorted array.");
            Show(OurArray, ArraySize);//Выводим массив в консоль
            Console.ReadLine();
        }
    }
}
