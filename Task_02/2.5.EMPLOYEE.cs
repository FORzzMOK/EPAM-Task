using System;

namespace _2._5.EMPLOYEE
{
    class User//Класс User, одно из предыдущих заданий
    {
        protected string name, surName, patrinymic;
        protected DateTime dateOfBirth;
        public string Name
        {
            get => name;
            set => name = value;
        }
        public string SurName
        {
            get => surName;
            set => surName = value;
        }
        public string Patrinymic
        {
            get => patrinymic;
            set => patrinymic = value;
        }
        public DateTime DateOfBirth
        {
            get => dateOfBirth;
            set
            {
                if(DateTime.Now > value.Date) dateOfBirth = value;
            }
        }
        public int Age => (int)(DateTime.Now - dateOfBirth).TotalDays / 365;

        public User()
        {
            dateOfBirth = new DateTime(1900, 1, 1);
        }
        public User(int year, int month, int day)
        {
            dateOfBirth = new DateTime(year, month, day);
        }
    }
    class Employee : User//Наследуется от User. Добавляет стаж работы и должность
    {
        private string position;
        private DateTime employmentDate;

        public Employee():base()//Только конструктор по умолчанию потому что слишком много аргументов которые надо передать, удобнее сделать черезсвойства
        {
            position = "Defolt";
            employmentDate = new DateTime(1950, 1, 1);
        }

        public string Position
        {
            get => position;
            set => position = value;
        }
        public DateTime EmploymentDate
        {
            get => employmentDate;
            set
            {
                if(value.Date > dateOfBirth) employmentDate = value;
            }
        }
        public int Experience => (int)(DateTime.Now - employmentDate).TotalDays / 365;

    }
    class Program
    {
        static void Main(string[] args)
        {
            var myUser = new Employee()
            {
                Name = "Igor",
                SurName = "Ivanov",
                Patrinymic = "Abduashvili",
                DateOfBirth = new DateTime(1990, 12, 11),
                EmploymentDate = new DateTime(2008, 1, 1),
                Position = "Junior"
            };
            Console.WriteLine("My User \nName = {0} \nSurName = {1} \nPatrinymic = {2} \nDateOfBirth = {3} \nAge = {4}", myUser.Name, myUser.SurName, myUser.Patrinymic, myUser.DateOfBirth.ToString("d"), myUser.Age);
            Console.WriteLine("EmploymentDate = {0} \nPosition = {1} \nExperience = {2} year", myUser.EmploymentDate.ToString("d"), myUser.Position, myUser.Experience);
            Console.ReadLine();
        }
    }
}