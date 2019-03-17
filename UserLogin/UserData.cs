using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public static class UserData
    {
        static private List<User> _testUsers;
        static public List<User> TestUsers
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
            _testUsers = new List<User>();
            _testUsers.Add(new User("admin", "parola", "12312321", UserRoles.ADMIN, DateTime.Now, DateTime.MaxValue));
            _testUsers.Add(new User("potrebitel2", "parola2", "222222", UserRoles.STUDENT, DateTime.Now, DateTime.MaxValue));
            _testUsers.Add(new User("potrebitel3", "parola3", "111111", UserRoles.STUDENT, DateTime.Now, DateTime.MaxValue));
        }

        static public User IsUserPassCorrect(string username, string password)
        {
            User user = (from filteredUser in TestUsers where filteredUser.username.Equals(username) select filteredUser).First();
            if (user.password.Equals(password))
            {
                return user;
            }
            return null;
        }

        static public void SetUserActiveTo(int userId, DateTime newActiveTo)
        {
            User user = UserForUserId(userId);
            if (user == null) return;
            user.activeUntil = newActiveTo;
            Logger.LogActivity("Промяна на активност на " + user.username);
            Console.WriteLine(user);
        }

        static public void AssignUserRole(int userId, UserRoles newRole)
        {
            User user = UserForUserId(userId);
            if (user == null) return;
            user.role = newRole;
            Logger.LogActivity("Промяна на роля на " + user.username);
            Console.WriteLine(user);
        }

        static public Dictionary<string, int> AllUsersUsernames()
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            for (int i = 0; i < TestUsers.Count; i++)
            {
                result.Add(TestUsers[i].username, i);
            }
            return result;
        }

        static private User UserForUsername(string username)
        {
            foreach (User user in TestUsers)
            {
                if (user.username.Equals(username))
                {
                    return user;
                }
            }
            Console.WriteLine("Не е намерен потребител с такова потребителско име");
            return null;
        }

        static private User UserForUserId(int userId)
        {
            User user = TestUsers.ElementAt(userId);
            if (user != null) return user;
            Console.WriteLine("Не е намерен потребител с такова потребителско име");
            return null;
        }
    }
}
