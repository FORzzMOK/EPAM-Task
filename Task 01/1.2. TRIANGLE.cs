using System;

namespace _1._2._TRIANGLE
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
            for (int i = 0; i < N; i++)//два цикла, столбцы и строки нашего треугольника
            {
                for (int j = 0; j < N; j++)
                {
                    if (i >= j) Console.Write("*");//Если номер столбца меньше или равен номеру строки, то рисуется звездочка, в противном случае не рисуется ничего
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
