using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            User user = null;

            string username = AskForUsername();
            string password = AskForPassword();
            LoginValidation logVal = new LoginValidation(username, password, OnError);
            
            if (logVal.ValidateUserInput(ref user))
            {
                switch (LoginValidation.currentUserRole)
                {
                    case UserRoles.ADMIN:
                        Console.WriteLine("You are the admin. You are the boss.");
                        break;
                    case UserRoles.STUDENT:
                        Console.WriteLine("You are a student. What's up?");
                        break;

                    case UserRoles.ANONYMOUS:
                        Console.WriteLine("You are annonymous. Yey");
                        break;

                    default:
                        Console.WriteLine("You are by default without any role. How is that possible.");
                        break;
                }
                Console.WriteLine(user.username + " " + user.password + " " + user.facultyNumber + " " + user.role);
            }
        }

        static string AskForUsername()
        {
            Console.WriteLine("Please enter username:");
            string username = Console.ReadLine();
            return username;
        }

        static string AskForPassword()
        {
            Console.WriteLine("Please enter password:");
            string password = Console.ReadLine();
            return password;
        }

        static void OnError(string errorMsg)
        {
            Console.WriteLine("!!! " + errorMsg + " !!!");
        }
    }
}
