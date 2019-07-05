using System;

namespace _1._1._RECTANGLE
{
    class Program
    {
        static int RectangleArea(int rectangleLength, int rectangleHeight)//Получает длину и высоту в виде аргументов
        {
            return rectangleLength * rectangleHeight;//Возвращает их перемноженое значение
        }
        static void Main(string[] args)
        {
            int rectangleLength = 0, rectangleHeight = 0;//Создаем переменные
            Console.WriteLine("Enter the length of the rectangle");//Просим ввести высоту и длину
            Int32.TryParse(Console.ReadLine(), out rectangleLength);//Присваиваем значение нашим переменным
            Console.WriteLine("Enter the height of the rectangle");
            Int32.TryParse(Console.ReadLine(), out rectangleHeight);
            if(rectangleLength > 0 && rectangleHeight > 0) Console.WriteLine("Rectangle area = " + RectangleArea(rectangleLength, rectangleHeight));//Проверка на коректность и вывод в консоль результат вызова функции
            else Console.WriteLine("Incorrect values entered");
            Console.ReadLine();
        }
    }
}
