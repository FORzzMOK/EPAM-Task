using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsersEntities;
using Users_and_awards.DAL;


namespace Users_and_awards.BLL
{
    public class UsersManager
    {
        public static void DataSynchronization()
        {
            UsersData.DataSynchronizationEnd();
        }
        public static void CreateNewUser(string _name, DateTime _dateOfBirth)
        {
            User newUser = new User
            {
                Name = _name,
                DateOfBirth = _dateOfBirth
            };
            newUser.Id = UsersData.GetId();
            UsersData.AddUser(newUser);
        }
        public static bool DeleteUser(int usersId)
        {
            if (UsersData.RemoveUser(usersId)) return true;
            else return false;
        }
        public static string ShowUser(int usersId)
        {
            User myUser = UsersData.GetUserById(usersId);
            if (myUser != null) return myUser.ToString();
            else return "Null";
        }
        public static string ShowUsersList()
        {
            return UsersData.GetUsersList();
        }
        public static bool AppendAwards(int usersId, string award)
        {
            User myUser = UsersData.GetUserById(usersId);
            if (myUser != null)
            {
                myUser.AddAward(award);
                return true;
            }
            else return false;
        }
    }
}
