using System;
using System.Collections.Generic;
using Entities;
using Users.BLL;
using Awards.BLL;


/*
 Картинка, визуальный интерфейс, роли
     */

namespace _10.WEB_UI
{
    class Program
    {
        static void Main(string[] args)
        {
            //UsersManager userManager = new UsersManager();
            //AwardsManager awardManager = new AwardsManager();
            //List<User> usersList = (List<User>)userManager.GetAllUsers();
            //Show(usersList);
            //Console.WriteLine(userManager.AddUser(new User() { Name = "Jon", Surname = "Brown", DateOfBirth = new DateTime(1990,07,07) } ));
            //Show(usersList);
            //Console.WriteLine(userManager.RemoveUser(28));
            //Show(usersList);
            //Console.WriteLine(userManager.EditUser(9, new User() { Name = "Pus", Surname = "Qazar", DateOfBirth = new DateTime(1999,09,09) }));
            //Show(usersList);
            //Console.WriteLine(awardManager.AddAward(26, new Award() { Title = "Strong Man" }));
            //Show(usersList);
            //Console.WriteLine(awardManager.RemoveAward(4, new Award() { Title = "good boy" }));
            //Show(usersList);
            //Console.WriteLine(userManager.AddImage(4, @"C:\Users\pavel\Desktop\join.png"));
        }
        static void Show(List<User> list)
        {
            Console.WriteLine();
            foreach (User item in list)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
        }
    }
}
