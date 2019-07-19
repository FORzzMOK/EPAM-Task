using System;

namespace _2._4.MY_STRING
{
    class MyString
    {
        private char[] charMassive;//Массив который хранит символы
        public MyString()//Конструктор по умолчанию
        {
            charMassive = new char[0];
        }
        public MyString(string myString)//Конструктор с аргументом
        {
            charMassive = new char[myString.Length];
            for (int i = 0; i < myString.Length; i++)
            {
                charMassive[i] = myString[i];
            }
        }
        public override string ToString()//Перегрузка метода ToString, для удобного вывода в консоль и сложения
        {
            string myString = "";
            for (int i = 0; i < charMassive.Length; i++)
            {
                myString += charMassive[i];
            }
            return myString;
        }
        public static bool operator ==(MyString firstString, MyString secondString)//Перегрузка сравнения
        { 
            if (firstString.ToString().Equals(secondString.ToString())) return true;
            else return false;
        }
        public static bool operator !=(MyString firstString, MyString secondString)//Перегрузка сравнения
        {
            if (firstString.ToString().Equals(secondString.ToString())) return false;
            else return true;
        }
        public static string operator +(MyString firstString, MyString secondString)//Конкатенация
        {
            return firstString.ToString() + secondString.ToString();
        }
        public int LastIndex(char myChar)//ПОказывает последний индекс вхождения символа в строку
        {
            for(int i = charMassive.Length - 1; i >= 0; i-- )
            {
                if (charMassive[i] == myChar) return i;
            }
            return -1;
        }
        public int FirstIndex(char myChar)//ПОказывает первый индекс вхождения символа в строку
        {
            for (int i = 0; i < charMassive.Length; i++)
            {
                if (charMassive[i] == myChar) return i;
            }
            return -1;
        }
        public char[] ToArray()//Возвращает массив символов
        {
            return charMassive;
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var a = new MyString("Hello");
            var b = new MyString(" World!");
            var c = new MyString(a + b);
            char[] r = c.ToArray(); 
            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(a + b);
            Console.WriteLine(a != b);
            Console.WriteLine(r);
            Console.WriteLine(c.FirstIndex('o'));
            Console.WriteLine(c.LastIndex('o'));
            
            Console.ReadLine();
        }
    }
}
