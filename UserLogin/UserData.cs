using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public static class UserData
    {
        static private User[] _testUsers;
        static public User[] TestUsers
        {
            get
            {
                ResetTestUserData();
                return _testUsers;
            }
            set { }
        }

        static private void ResetTestUserData()
        {
            _testUsers = new User[3];
            _testUsers[0] = new User("admin", "parola", "12312321", UserRoles.ADMIN);
            _testUsers[1] = new User("potrebitel2", "parola2", "222222", UserRoles.STUDENT);
            _testUsers[2] = new User("potrebitel3", "parola3", "111111", UserRoles.STUDENT);
        }

        static public User IsUserPassCorrect(string username, string password)
        {
            foreach (User user in TestUsers) {
                if (user.username.Equals(username) && user.password.Equals(password))
                {
                    return user;
                }
            }
            return null;
        }
    }
}
