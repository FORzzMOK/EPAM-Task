using System;

namespace _1._5._SUM_OF_NUMBERS
{
    class Program
    {
        static int SumOfNumbers(int N)//Метод возвращающий сумму чисел от 0 до N, кратных 3 и 5
        {
            int sumOfNumbers = 0;//Создаем временную переменную, которая будет хранить значение суммы
            for(int i = 0; i < N; i++)//Цикл который будет перебирать все значения
            {
                if (i % 3 == 0 || i % 5 == 0) sumOfNumbers += i;//Проверка на четность, и суммирование в случае true
            }
            return sumOfNumbers;//Возвращаем значение
        }
        static void Main(string[] args)
        {
            Console.WriteLine(SumOfNumbers(1000));//выводим в консоль результат работы функции
            Console.ReadLine();//Ввод, что бы консоль не закрылась
        }
    }
}
