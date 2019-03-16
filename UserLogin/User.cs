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

        public User(string username, string password, string facultyNumber, UserRoles role)
        {
            this.username = username;
            this.password = password;
            this.facultyNumber = facultyNumber;
            this.role = role;
        }
    }
}
