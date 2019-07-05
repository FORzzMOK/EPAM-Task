using System;

namespace _1._11._AVERAGE_STRING_LENGTH
{
    class Program
    {
        static float AverageStringLength(string myString)//Метод расчитывающий среднюю длинну слова
        {//Идея в том что бы подсчитать сколько слов с строке и сколько символов во всех этих словах. Отношение количества символов к количеству слов будет средней длинной слова в строке
            float countLetter = 0, countWord = 0;//счетчики символов и слов
            bool flag = true;//Флаг для того что бы понять что слово началось. Этот флаг равен true только в начаое строки, или если предыдущий символ был разделителем или знаком пунктуации
            for(int i = 0; i < myString.Length; i++)//Цикл пробегает по строке
            {
                if (char.IsDigit(myString[i]) || char.IsLetter(myString[i]) || char.IsNumber(myString[i]))//Если сивол является буквой, цифрой или числом, то мы считаем его частью слова
                {
                    countLetter++;//Увеличиваем на единицу счетчик символов
                    if (flag)//А если еще и флаг равен trye, то мы считаем что слово началось, и прибавляем к счетчику слов единицу, и изменяем значение флага. Мы сюда не попадем пока слово не закончился и не изменится значение флага
                    {
                        countWord++;
                        flag = false;
                    } 
                }
                else if (char.IsPunctuation(myString[i]) || char.IsSeparator(myString[i])) flag = true;//Если нам попался знак разделителя или пунктуации, значит слово знакончилось
            }
            return countLetter / countWord;//Возвращаем отнощшения количества символо к количеству слов.
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the string");
            string myString = Console.ReadLine();//Создаем строку
            Console.WriteLine(AverageStringLength(myString));//Выводим в консоль результат метода
            Console.ReadLine();
        }
    }
}
