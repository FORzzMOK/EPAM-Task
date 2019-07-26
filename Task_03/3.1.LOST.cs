using System;
using System.Collections.Generic;

namespace _3._1.LOST
{
    
    class Program
    {
        static void Filling(List<int> humans)//Метод заполняет массив
        {
            for (int i = 1; i <= 10; i++) { humans.Add(i); }
        }
        static int Lost(List<int> humans)//Метод вычеркивающий каждого второго человека. Метод разбит на базовый случай, и случай когда придется воспользоваться рекурсией
        {
            if (humans.Count == 1) return humans[0];//Базовый случай, в кругу остался один человек, просто возвращаем кго изначальный номер.
            List<int> helpArray = new List<int>();
            for (int i = 1; i <= humans.Count; i++)//Не базовый случай, в кругу стоит больше одногочеловека, мы их пересчитываем и каждого второго как бы ставим в новый круг
            {
                if (i % 2 == 0){ helpArray.Add(humans[i - 1]); }
            }
            return Lost(helpArray);//Новый получившийся круг опять передаем нашему методу, и так будет пока мы не дойдем до базового случая, в кругу останется один человек.
        }
        static void Main(string[] args)
        {
            List<int> humans = new List<int>();
            Filling(humans);
            Console.WriteLine(Lost(humans));
            Console.ReadLine();
        }
    }
}
