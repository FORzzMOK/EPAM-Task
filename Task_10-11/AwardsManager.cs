using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using Entities;

namespace Awards.BLL
{
    public class AwardsManager
    {
        private IUsersStorable UsersStorage = Dependensies.Dependensies.UsersStorage;
        public bool AddAward(int user_ID, Award award)
        {
            if (UsersStorage.AddAward(user_ID, award)) return true;
            else return false;
        }
        public bool RemoveAward(int user_ID, Award award)
        {
            if (UsersStorage.RemoveAward(user_ID, award)) return true;
            else return false;
        }
    }
}
