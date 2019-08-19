using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Users_and_awards.DAL;
using UsersEntities;

namespace Users.Common
{
    public static class Dependensies
    {
        public static IUsersStorage UsersStorage { get; } = new UsersData(); 
    }
}
