using System;

namespace ConsoleApp1
{
    class Round
    {
        private double point_x, point_y, radius;
        
        public double Point_x//Свойство
        {
            get { return point_x; }
            set { point_x = value; }
        }

        public double Point_y//Свойство
        {
            get { return point_y; }
            set { point_y = value; }
        }

        public double Radius//Свойство
        {
            get { return radius; }
            set { if (value > 0) radius = value; }
        }

        public double Area => Math.PI * radius * radius;//Свойство
        public double Circumference => 2 * Math.PI * radius;//Свойство

        public Round()//Конструктор
        {
            point_x = 0.0;
            point_y = 0.0;
            radius = 0.0;
        }

        public Round(double x, double y)//Конструктор
        {
            point_x = x;
            point_y = y;
            radius = 0.0;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Round MyRound = new Round { Radius = 1 };
            MyRound.Point_x = 1.2;
            MyRound.Point_y = 1.5;
            Console.WriteLine("Point_x = {0}, Point_y = {1}", MyRound.Point_x, MyRound.Point_y);
            Console.WriteLine(MyRound.Area);
            Console.WriteLine(MyRound.Circumference);
            Console.ReadLine();
        }
    }
}
