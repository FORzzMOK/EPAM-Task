using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsersEntities
{
    public interface IUsersStorage
    {
        void AddUser(User newUser);
        bool RemoveUser(int usersId);
        int GetId();
        User GetUserById(int usersId);
        string GetUsersList();
        void DataSynchronizationStart();
        void DataSynchronizationEnd();
    }
}
