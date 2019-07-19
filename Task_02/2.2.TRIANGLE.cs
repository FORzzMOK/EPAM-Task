using System;

namespace _2._2._TRIANGLE
{
    class Triangle
    {
        private int side_a, side_b, side_c;

        public int Side_a
        {
            get => side_a;
            set { if (value > side_b + side_c) side_a = value; }
        }
        public int Side_b
        {
            get => side_b;
            set { if (value > side_a + side_c) side_b = value; }
        }
        public int Side_c
        {
            get => side_c;
            set { if (value > side_b + side_a) side_c = value; }
        }

        private double Semi_Perimeter => (side_a + side_b + side_c) / 2.0;//Полупериметр нужен для расчета площади
        public double Perimeter => side_a + side_b + side_c;

        public double Area//Расчет площади
        {
            get
            {
                double p = Semi_Perimeter;
                return Math.Sqrt(p * (p - side_a) * (p - side_b) * (p - side_c));
            }
        }
        public Triangle()//Конструктор по умолчанию
        {
            side_a = 0;
            side_b = 0;
            side_c = 0;
        }
        public Triangle(int a, int b, int c)
        {
            if (a > b + c || b > a + c || c > a + b)//Проверка на коректность. Одна сторонна не может быть больше чем сумма двух других.
            {
                throw new ArgumentException("One side of a triangle cannot be more than two others!");
            }
            else
            {
                side_a = a;
                side_b = b;
                side_c = c;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Triangle MyTriangle = new Triangle(2,2,3);

            Console.WriteLine("Side_a = {0}, Side_b = {1}, Side_c = {2}", MyTriangle.Side_a, MyTriangle.Side_b, MyTriangle.Side_c);
            Console.WriteLine(MyTriangle.Area);
            Console.WriteLine(MyTriangle.Perimeter);

            Console.ReadLine();
        }
    }
}