using System.Collections.Generic;

namespace Entities
{
    public interface IUsersStorable
    {
        bool AddUser(User user);
        bool RemoveUser(int users_ID);
        bool EditUser(int users_ID, User user);
        bool AddAward(int users_ID, Award award);
        bool RemoveAward(int users_ID, Award award);
        bool AddImage(int user_ID, byte[] imageByte);
        ICollection<User> GetAllUsers();
    }
}
