using System;

namespace _2._8.GAME
{
    enum Move//Для передвижения персонажей
    {
        UP = 1,
        DOWN = 2,
        RIGHT = 3,
        LEFT = 4
    }
    interface IMovable//Позволяет двигаться
    {
        void Move(Enum direction);
        int Speed { get; }
    }
    interface IDamage//Позволяет наносить урон
    {
        int Damage { get; }
        void DamageGet();
    }

    abstract class Person : IMovable//Главный персонаж и враги
    {
        public int Speed => 10;//Обладают скоростью и координатами
        private double point_x, point_y;
        public Person()
        {
            point_x = 0.0d;
            point_y = 0.0d;
        }
        public Person(double x, double y)
        {
            point_x = x;
            point_y = y;
        }

        public void Move(Enum direction)
        {
            switch (direction.ToString())
            {
                case "UP":
                    Console.WriteLine("Move up");
                    break;
                case "DOWN":
                    Console.WriteLine("Move down");
                    break;
                case "RIGHT":
                    Console.WriteLine("Move right");
                    break;
                case "LEFT":
                    Console.WriteLine("Move left");
                    break;
            }
        }
    }
    abstract class Bonuses//Бонусы, дают буст скорости или здоровья. Имеют координаты
    {
        public readonly int healthUp = 0;
        public readonly int speedUp = 0;
        private double point_x, point_y;
        public Bonuses()
        {
            point_x = 0.0d;
            point_y = 0.0d;
        }
        public Bonuses(double x, double y)
        {
            point_x = x;
            point_y = y;
        }
    }
    abstract class Barrier//Препятствия, имеют только размеры и координаты
    {
        private double point_x, point_y;
        private double width, height;
        public Barrier()
        {
            point_x = 0.0d;
            point_y = 0.0d;
        }
        public Barrier(double x, double y)
        {
            point_x = x;
            point_y = y;
        }
        public Barrier(double x, double y, double w, double h)
        {
            point_x = x;
            point_y = y;
            width = w;
            height = h;
        }
    }
    class Map//Наша карта имеет только размеры
    {
        private double width, height;
        public Map(double w, double h)
        {
            width = w;
            height = h;
        }
        public double Width
        {
            get => width;
            set { if (value > 0) width = value; }
        }
        public double Height
        {
            get => height;
            set { if (value > 0) height = value; }
        }
    }
    class Character : Person//Главный персонаж обладает здоровьем и скоростью которые можгут понижаться или повышаться
    {
        private int healthPoint = 100;
        public int HealthPoint
        {
            get => healthPoint;
            set { if (value > 0) healthPoint = value; }
        }
        public void HealthUp(int bonuses)
        {
            if (bonuses > 0) healthPoint += bonuses;
        }
        public void HealthDown(int damage)
        {
            if (damage > healthPoint)
            {
                healthPoint = 0;
                Console.WriteLine("Our hero dead!");
                return;
            }
            else if (damage > 0)
            {
                healthPoint -= damage;
            }
        }
    }
    class Wolf : Person, IDamage//Враг волк, быстрый но наносит не большой урон
    {
        public int Damage => 20;
        public new int Speed => 11;
        public void DamageGet() { Console.WriteLine("Damage done"); }
    }
    class Bear : Person, IDamage//Враг медведь, медленный, но наносит большой урон
    {
        public int Damage => 50;
        public new int Speed => 9;
        public void DamageGet() { Console.WriteLine("Damage done"); }
    }
    class Cherry : Bonuses//Вишня повышает здоровье
    {
        public readonly new int healthUp = 15;
    }
    class Apple : Bonuses//Яблоко повышает скорость
    {
        public readonly new int speedUp = 1;
    }
    
    class Stone : Barrier//Барьер камень
    {
        public Stone() : base(0, 0, 1, 1) { }
        public Stone(double x, double y) : base(x,y,1,1) { }
    }
    class Tree : Barrier//Барьер дерево
    {
        public Tree() : base(0, 0, 1, 1) { }
        public Tree(double x, double y) : base(x, y, 1, 3) { }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var myMap = new Map(100, 100);
            var myPerson = new Character();
            var myWolf = new Wolf();
            var myBear = new Bear();
            var myCherry = new Cherry();
            var myApple = new Apple();
            var myStone = new Stone();
            var myTree = new Tree();
        }
    }
}
