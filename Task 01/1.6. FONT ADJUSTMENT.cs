using System;
using System.Collections;

namespace _1._6._FONT_ADJUSTMENT
{
    class Program
    {
        static void Adjustmenr()//Метод позволяющий включать и выключать различные начертания для текста
        {
            short timeFlag = 0;//Переменная хранящая значение введеное с клавиатуры
            string parameter;//Строка для вывода параметров
            bool[] flagInscriptions = new bool[] { false, false, false };//Два массива с хранение флагов и наименований для начертаний
            string[] Inscriptions = new string[] { "bold", "italic", "underline"};
            while (true)//Бесконечный цикл
            {
                parameter = "";//Каждый раз обнуляем нашу строку
                Console.Write("Параметры надписи:");
                for(int i = 0; i < 3; i++)//Проходим по массиву flagInscriptions, смотрим что там
                {
                    if (flagInscriptions[i])//Если в массиве trye, то мы выводим соответствующее значение по ключу из массива Inscriptions
                    {
                        if (parameter.Length != 0) parameter += ",";//Ставим запятую если строка не пустая
                        parameter += string.Format(" {0}", Inscriptions[i]);//Из массива Inscriptions выводим названия начертаний
                    }
                }
                if (parameter.Length == 0) Console.Write(" None");//Если все начертания выключены, и строка по итогу получается пустая, то выводим None
                else Console.Write(parameter);
                Console.WriteLine("\n\t1: bold \n\t2: italic \n\t3: underline");//Выводим возможные начертания
                short.TryParse(Console.ReadLine(), out timeFlag);//Ввод с клавиатуры числа для управления начертаниями
                if (0 < timeFlag && timeFlag < 4) flagInscriptions[timeFlag - 1] = !flagInscriptions[timeFlag - 1];//Здесь мы меняем значения bool в flagInscriptions. Предварительно проверяя на коректность ввода
            }
        }
        static void Main(string[] args)
        {
            Adjustmenr();
            Console.ReadLine();
        }
    }
}
