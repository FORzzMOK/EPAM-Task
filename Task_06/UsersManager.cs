using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersEntities;
using Users_and_awards.DAL;
using Users.Common;


namespace Users_and_awards.BLL
{
    public static class UsersManager
    {
        static UsersManager()
        {
            Dependensies.UsersStorage.DataSynchronizationStart();
        }
        public static void DataSynchronization()
        {
            Dependensies.UsersStorage.DataSynchronizationEnd();
        }
        public static void CreateNewUser(string _name, DateTime _dateOfBirth)
        {
            User newUser = new User
            {
                Name = _name,
                DateOfBirth = _dateOfBirth
            };
            newUser.Id = Dependensies.UsersStorage.GetId();
            Dependensies.UsersStorage.AddUser(newUser);
        }
        public static bool DeleteUser(int usersId)
        {
            if (Dependensies.UsersStorage.RemoveUser(usersId)) return true;
            else return false;
        }
        public static string ShowUser(int usersId)
        {
            User myUser = Dependensies.UsersStorage.GetUserById(usersId);
            if (myUser != null) return myUser.ToString();
            else return "Null";
        }
        public static string ShowUsersList()
        {
            return Dependensies.UsersStorage.GetUsersList();
        }
        public static bool AppendAwards(int usersId, string award)
        {
            User myUser = Dependensies.UsersStorage.GetUserById(usersId);
            if (myUser != null)
            {
                myUser.AddAward(award);
                return true;
            }
            else return false;
        }
    }
}
