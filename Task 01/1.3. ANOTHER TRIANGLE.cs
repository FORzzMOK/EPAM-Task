using System;

namespace _1._3._ANOTHER_TRIANGLE
{
    class Program
    {
        static void Triangle(int N)//Функция рисующая треугольники
        {
            if (N < 1)//Проверка на корректность, если введеное число меньше одного, то выдает ошибку
            {
                Console.WriteLine("Error");
                return;//Выход из функции в случае некорректного значения 
            }
            for (int i = 0; i < N; i++)//два цикла, стльбцы и строки нашего треугольника
            {
                for (int j = 0; j < N * 2 - 1; j++)
                {
                    if ((j + i + 1 >= N) && (j <= i + N - 1)) Console.Write("*");//Если у нас выполняется некоторое условие, то будет рисоваться звездочка
                    else Console.Write(" ");//Или пробел, если условые не выполнилось
                }
                Console.WriteLine();//Переход на новую строку
            }
        }
        static void Main(string[] args)
        {
            int N = 0;
            Console.WriteLine("Enter number");
            Int32.TryParse(Console.ReadLine(), out N);
            Triangle(N);
            Console.ReadLine();//Задержка перед закрытием консоли
        }
    }
}