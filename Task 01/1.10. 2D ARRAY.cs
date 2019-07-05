using System;

namespace _1._10._2D_ARRAY
{
    class Program
    {
        static void Filing(int[,] myArrey, int myArreySize)//Метод  заполняет массив рандомными числами
        {
            Random r = new Random();
            for (int i = 0; i < myArreySize; i++)
            {
                for(int j = 0; j < myArreySize; j++)
                {
                    myArrey[i,j] = r.Next(-100, 100);
                }
            }
        }
        static void Show(int[,] myArrey, int myArreySize)//Метод вывоДит массив на экран
        {
            for (int i = 0; i < myArreySize; i++)
            {
                for (int j = 0; j < myArreySize; j++)
                {
                    Console.Write("{0} ", myArrey[i,j]);
                }
                Console.Write("\n");
            }
        }
        static int PositiveSumm(int[,] myArrey, int myArreySize)//Подсчитывает сумму чисел стоящих на четных поцизиях
        {
            int timePositiveSumm = 0;//Переменная в которую мы будем суммировать все числа стоящие на четных поцизиях
            for (int i = 0; i < myArreySize; i++)
            {
                for (int j = 0; j < myArreySize; j++)
                {
                    if ((i + j) % 2 == 0 && (i + j) != 0) timePositiveSumm += myArrey[i, j];//Проверяет позоцою н четность, и если позиция четная то прибавляет к переменной
                }
            }
            return timePositiveSumm;
        }
        static void Main(string[] args)
        {
            int arraySize = 10;
            int[,] MyArray = new int[arraySize, arraySize];
            Filing(MyArray, arraySize);
            Show(MyArray, arraySize);
            Console.WriteLine(PositiveSumm(MyArray, arraySize));
            Console.ReadLine();
        }
    }
}
