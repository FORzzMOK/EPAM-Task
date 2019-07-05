using System;

namespace _1._12._CHAR_DOUBLER
{
    class Program
    {
        static void CharDouble(ref string myStringFirst, ref string myStringSecond)//Метод дублирующий в первой строке символы, которые находятся во второй строке
        {
            string timeString = "";//Создаем временную переменную
            for(int i = 0; i < myStringFirst.Length; i++)//Пробегаем по нашей строке
            {
                if (myStringSecond.Contains(myStringFirst[i])) timeString += string.Format("{0}{0}",myStringFirst[i]);//Перебираем символы в первой строке и смотрим есть ли они во второй строке
                else timeString += string.Format("{0}", myStringFirst[i]);//Если есть, то дубоируем, если нет то просто добавляем
            }
            myStringFirst = timeString;//Перезаписываем нашу строку
        }
        static void Main(string[] args)
        {
            Console.Write("Введите первую строку: ");
            string myStringFirst = Console.ReadLine();
            Console.Write("Введите вторую строку: ");
            string myStringSecond = Console.ReadLine();
            CharDouble(ref myStringFirst, ref myStringSecond);//Передаем через ref по ссылке, что бы сразу в функции изменить строку
            Console.WriteLine("Результирующая строка: {0}", myStringFirst);
            Console.ReadLine();
        }
    }
}
