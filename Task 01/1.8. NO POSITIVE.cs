using System;

namespace _1._8._NO_POSITIVE
{
    class Program
    {
        static void Show(int[,,] OurArray, int ArraySize)//функция выводит массив на экран 
        {
            for (int i = 0; i < ArraySize; i++)//Проходим по элементам всех массивов
            {
                for (int j = 0; j < ArraySize; j++)
                {
                    for (int g = 0; g < ArraySize; g++)
                    {
                        Console.Write("{0} ", OurArray[i, j, g]);//Выводим на экран через пробел
                    }
                    Console.Write("\n");
                }
                Console.Write("\n");
            }
        }
        static void Filling(int[,,] OurArray, int ArraySize)
        {//заполняет массив случайными числами от 0 до 200 
            Random r = new Random();
            for (int i = 0; i < ArraySize; i++)//Проходим по элементам всех массивов
            {
                for (int j = 0; j < ArraySize; j++)
                {
                    for (int g = 0; g < ArraySize; g++)
                    {
                        OurArray[i, j, g] = r.Next(-100,100);

                    }
                }
            }
        }
        static void replacement(int[,,] OurArray, int ArraySize)
        {
            for (int i = 0; i < ArraySize; i++)//Проходим по элементам всех массивов
            {
                for (int j = 0; j < ArraySize; j++)
                {
                    for (int g = 0; g < ArraySize; g++)
                    {
                        if (OurArray[i, j, g] > 0) OurArray[i, j, g] = 0;//Проверяем элементы, если элемент положительный то заменяем на ноль
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            int ArraySize = 10;//размер нашего массива 
            int[,,] OurArray = new int[ArraySize, ArraySize, ArraySize];// Размер массива фиксированный, 1000 элементов 
            Filling(OurArray, ArraySize);//Вызываем функцию заполнения массива 
            Console.WriteLine("\n_____Array without replacement._____\n");
            Show(OurArray, ArraySize);//Выводим массив в экран 
            replacement(OurArray, ArraySize);
            Console.WriteLine("\n_____Array with replacement._____\n");
            Show(OurArray, ArraySize);//Выводим массив в консоль 
            Console.ReadLine();
        }
    }
}