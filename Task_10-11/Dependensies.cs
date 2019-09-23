using Entities;
using Users.DAL;

namespace Dependensies
{
    public class Dependensies
    {
        public static IUsersStorable UsersStorage { get; } = new UsersMemoryStorage();
    }
}
