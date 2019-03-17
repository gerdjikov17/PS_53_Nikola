using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public class User
    {
        public string username;
        public string password;
        public string facultyNumber;
        public UserRoles role;
        public DateTime created;
        public DateTime activeUntil;

        public User(string username, string password, string facultyNumber, UserRoles role, DateTime created, DateTime activeUntil)
        {
            this.username = username;
            this.password = password;
            this.facultyNumber = facultyNumber;
            this.role = role;
            this.created = created;
            this.activeUntil = activeUntil;
        }

        override public string ToString()
        {
            return "username: " + username + ", " +
                "password: " + password + ", " +
                "facultyNumber: " + facultyNumber + ", " +
                "role: " + role + ", " +
                "created: " + created + ", " +
                "activeUntil: " + activeUntil;
        }
    }
}
