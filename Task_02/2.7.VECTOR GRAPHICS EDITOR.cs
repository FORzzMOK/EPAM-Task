using System;

namespace _2._7.VECTOR_GRAPHICS_EDITOR
{
    abstract class Figure//Главный класс фигура, обладает только координатами
    {
        protected double point_x;
        protected double point_y;
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
        protected Figure()
        {
            point_x = 0.0d;
            point_y = 0.0d;
        }
        protected Figure(double x, double y)
        {
            point_x = x;
            point_y = y;
        }
    }
    class Rectangle : Figure//Квадрат наследуется от Figure. 
    {
        private double side_a, side_b;//Добавляются стороны, площадь и периметр
        public double Side_a
        {
            get => side_a;
            set { if (value > 0) side_a = value; }
        }
        public double Side_b
        {
            get => side_b;
            set { if (value > 0) side_b = value; }
        }
        public Rectangle() : base() { }
        public Rectangle(double x, double y) : base(x, y) { }
        public Rectangle(double x, double y, double a, double b) : base(x, y)
        {
            side_a = a;
            side_b = b;
        }
        public double Area => side_a * side_b;
        public double Circumference => 2 * side_a + 2 * side_b;
        public override string ToString()
        {
            return string.Format("Type - Rectangle \nPoint - X = {0}, Y = {1} \nSide - A = {2}, B = {3} \nArea = {4}, \nCircumference = {5}\n", point_x, point_y, side_a, side_b, Area, Circumference);
        }
    }
    class Line : Figure//Линия, имеет две координаты и длинну
    {
        double secondPoint_x, secondPoint_y;
        public double SecondPoint_x
        {
            get { return secondPoint_x; }
            set { secondPoint_x = value; }
        }
        public double SecondPoint_y
        {
            get { return secondPoint_y; }
            set { secondPoint_y = value; }
        }

        public Line() : base()
        {
            secondPoint_x = 0;
            secondPoint_y = 0;
        }
        public Line(double x, double y, double sX, double sY) : base(x, y)
        {
            secondPoint_x = sX;
            secondPoint_y = sY;
        }

        public double Long => Math.Sqrt(Math.Pow((point_x - secondPoint_x), 2) + Math.Pow((point_y - secondPoint_y), 2));

        public override string ToString()
        {
            return string.Format("Type - Line \nFirst point - X = {0}, Y = {1} \nSecond point - X = {2}, Y = {3} \nLong = {4}\n", point_x, point_y, secondPoint_x, secondPoint_y, Long);
        }
    }
    class Circle : Figure//Окружность. Имеет центральные координаты и периметр
    {
        protected double radius;
        public double Radius
        {
            get { return radius; }
            set { if (value > 0) radius = value; }
        }
        public Circle() : base() => radius = 0.0d;
        public Circle(double x, double y) : base(x, y) => radius = 0.0d;
        public Circle(double x, double y, double r) : base(x, y) => radius = r;

        public virtual double Circumference => 2 * Math.PI * radius;

        public override string ToString()
        {
            return string.Format("Type - Circle \nRadius = {0}, \nCircumference = {1}\n", radius, Circumference);
        }
    }
    class Round : Circle//Кольцо наследуется от окружности
    {
        public Round() : base() => radius = 0.0d;
        public Round(double x, double y) : base(x, y, 0.0d) { }
        public Round(double x, double y, double r) : base(x, y, r) { }

        public double Area => Math.PI * radius * radius;

        public override string ToString()
        {
            return string.Format("Type - Round \nRadius = {0}, \nCircumference = {1} \nArea = {2}\n", radius, Circumference, Area);
        }
    }
    class Ring : Circle//Круг наследуется от окружности
    {
        protected double secondRadius;
        public double SecondRadius
        {
            get { return secondRadius; }
            set { if (value > 0 || value < radius) secondRadius = value; }
        }
        public Ring() : base() => radius = 0.0d;
        public Ring(double x, double y) : base(x, y, 0.0d) { }
        public Ring(double x, double y, double r) : base(x, y, r) { }
        public Ring(double x, double y, double r, double sR) : base(x, y, r) => SecondRadius = sR;

        public double Area => (Math.PI * radius * radius) - (Math.PI * secondRadius * secondRadius);
        public override double Circumference => 2 * Math.PI * radius + 2 * Math.PI * secondRadius;

        public override string ToString()
        {
            return string.Format("Type - Ring \nFirst radius = {0}, \nSecond radius = {1}, \nCircumference = {2} \nArea = {3}\n", radius, secondRadius, Circumference, Area);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var myLine = new Line(0, 0, 3, 3);
            var myRectangle = new Rectangle(1, 1, 2, 2);
            var myCircle = new Circle(1, 1, 1);
            var myRound = new Round(1, 1, 1);
            var myRing = new Ring(1, 1, 2, 1);

            Console.WriteLine(myLine);
            Console.WriteLine(myRectangle);
            Console.WriteLine(myCircle);
            Console.WriteLine(myRound);
            Console.WriteLine(myRing);

            Console.ReadLine();
        }
    }
}