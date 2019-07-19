using System;

namespace _2._6.RING
{
    class Round//Класс Round одно из предыдущих заданий
    {
        protected double point_x, point_y, radius;

        public double Point_x
        {
            get { return point_x; }
            set { point_x = value; }
        }

        public double Point_y
        {
            get { return point_y; }
            set { point_y = value; }
        }

        public double Radius
        {
            get { return radius; }
            set { if (value > 0) radius = value; }
        }

        public virtual double Area => Math.PI * radius * radius;
        public virtual double Circumference => 2 * Math.PI * radius;

        public Round()
        {
            point_x = 0.0;
            point_y = 0.0;
            radius = 0.0;
        }

        public Round(double x, double y)
        {
            point_x = x;
            point_y = y;
            radius = 0.0;
        }
    }

    class Ring : Round//Кольцо наследуется от круга, добавляем второй радиус и перегружаем Area и Circumference
    {
        protected double secondRadius;
        public Ring():base(0.0, 0.0) {}
        public Ring(double x, double y) : base(x, y){}
        public Ring(double x, double y, double r, double sR) : base(x, y)
        {
            radius = r;
            secondRadius = sR;
        }
        public double SecondRadius
        {
            get { return secondRadius; }
            set { if (value > 0 || value < radius) secondRadius = value; }
        }
        public override double Area => (Math.PI * radius * radius) - (Math.PI * secondRadius * secondRadius);
        public override double Circumference => 2 * Math.PI * radius + 2 * Math.PI * secondRadius;
    }

    class Program
    {
        static void Main(string[] args)
        {
            var MyRing = new Ring {
                Radius = 2,
                SecondRadius = 1,
                Point_x = 1.2,
                Point_y = 1.5
        };
            Console.WriteLine("Point_x = {0}, Point_y = {1}", MyRing.Point_x, MyRing.Point_y);
            Console.WriteLine(MyRing.Area);
            Console.WriteLine(MyRing.Circumference);
            Console.ReadLine();
        }
    }
}

