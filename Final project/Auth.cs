using System.Web.Security;
using Users.DAL;
namespace Great_Album
{
    public static class Auth
    {
        public static bool CanLogin(string login, string password)
        {
            UserMemoryStorage newStorage = new UserMemoryStorage();
            return newStorage.CheckLoginAndPass(login, password);
        }
    }
}