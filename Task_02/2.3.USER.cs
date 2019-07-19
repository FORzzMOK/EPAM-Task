using System;

namespace _2._3._USER
{
    class User
    {
        private string name, surName, patrinymic;//Имя, фамилия, отчество
        private DateTime dateOfBirth;//Дата рождения
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
        public int Age => (int)(DateTime.Now - dateOfBirth).TotalDays / 365;//Возраст

        public User()//КОнструктор по умолчанию
        {
            dateOfBirth = new DateTime(1900, 1, 1);
        }
        public User(int year, int month, int day)//Конструктор с параметрами
        {
                dateOfBirth = new DateTime(year, month, day);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            User myUser = new User()
            {
                Name = "Igor",
                SurName = "Ivanov",
                Patrinymic = "Abduashvili",
                DateOfBirth = new DateTime(2000, 12, 11)
        };
            Console.WriteLine("My User \nName = {0} \nSurName = {1} \nPatrinymic = {2} \nDateOfBirth = {3} \nAge = {4}", myUser.Name, myUser.SurName, myUser.Patrinymic, myUser.DateOfBirth.ToString("d"), myUser.Age);
            Console.ReadLine();
        }
    }
}
