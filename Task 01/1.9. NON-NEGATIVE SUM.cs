using System;

namespace _1._9._NON_NEGATIVE_SUM
{
    class Program
    {
        static void Filing(int[] myArrey, int myArreySize)//Метод  заполняет массив рандомными числами
        {
            Random r = new Random();
            for(int i = 0; i < myArreySize; i++)
            {
                myArrey[i] = r.Next(-100, 100);
            }
        }
        static void Show(int[] myArrey, int myArreySize)//Метод вывожит массив на экран
        {
            for (int i = 0; i < myArreySize; i++)
            {
                Console.Write("{0} ",myArrey[i]);
                if ((i + 1)% 10 == 0) Console.Write("\n");
            }
        }
        static int Summ(int[] myArrey, int myArreySize)//Считает сумму положительных чисел
        {
            int timeSumm = 0;//Переменная в которую мы будем сумировать наши элементы массива
            for (int i = 0; i < myArreySize; i++)//Перебираем элементы массива
            {
                if (myArrey[i] > 0) timeSumm += myArrey[i];//Делаем проверку, если число положительное, то суммируем его с нашей переменной
            }
            return timeSumm;//Возвращаем сумму
        }
        static void Main(string[] args)
        {
            int myArreySize = 10;//Задаем размер массива
            int[] myArrey = new int[myArreySize];//Создаем массив
            Filing(myArrey, myArreySize);//Заполняем массив
            Show(myArrey, myArreySize);//Выводим его на экран
            Console.WriteLine(Summ(myArrey, myArreySize));//Выводим на экран результат выполнения метода суммирования положительных чисел
            Console.ReadLine();//Задерживаем консоль
        }
    }
}
