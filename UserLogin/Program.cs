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
                        AdminMenu();
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
                Console.WriteLine(user);
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

        static void AdminMenu()
        {
            Console.WriteLine();
            Console.WriteLine("Изберете опция:\n" + 
                "0: Изход\n" + 
                "1: Промяна на роля на потребител\n" + 
                "2: Промяна на активност на потребител\n" +
                "3: Списък на всички потребители\n" +
                "4: Преглед на лог на активност\n" +
                "5: Преглед на текущата активност");
            string userInputString = Console.ReadLine();
            Int16 userInput;
            if (string.IsNullOrEmpty(userInputString) || !Int16.TryParse(userInputString, out userInput))
            {
                Console.WriteLine("Грешно въведен избор. Опитайте пак!");
                userInput = -1;
            }
            else 
            {
                userInput = Int16.Parse(userInputString);
            }
            Dictionary<string, int> allUsers = UserData.AllUsersUsernames();
            string username;
            int userId = -1;
            switch (userInput)
            {
                case 0:
                    return;
                case 1:
                    Console.WriteLine("Въведете потребителско име:");
                    username = Console.ReadLine();
                    if (!allUsers.ContainsKey(username))
                    {
                        Console.WriteLine("Невалидно потребителско име");
                        break;
                    }
                    userId = allUsers[username];
                    Console.WriteLine("0: Анонимен\n" + 
                        "1: Админ\n" + 
                        "2: Инспектор\n" +
                        "3: Професор\n" +
                        "4: Студент\n" +
                        "Въведете роля:");
                    string roleString = Console.ReadLine();
                    if (string.IsNullOrEmpty(roleString))
                    {
                        Console.WriteLine("Неуспешно въведена роля.");
                        break;
                    }
                    Int16 role = Convert.ToInt16(roleString);
                    if (role < 0 || role > 4) break;
                    UserData.AssignUserRole(userId, (UserRoles)role);
                    break;
                case 2:
                    Console.WriteLine("Въведете потребителско име:");
                    username = Console.ReadLine();
                    if (!allUsers.ContainsKey(username))
                    {
                        Console.WriteLine("Невалидно потребителско име");
                        break;
                    }
                    userId = allUsers[username];
                    Console.WriteLine("Въведете дата(dd.mm.yyyy):");
                    string date = Console.ReadLine();
                    if (string.IsNullOrEmpty(date))
                    {
                        Console.WriteLine("Неуспешно въведена дата.");
                        break;
                    }
                    DateTime newDate = Convert.ToDateTime(date);
                    UserData.SetUserActiveTo(userId, newDate);
                    break;
                case 3:
                    foreach (string key in allUsers.Keys)
                    {
                        Console.WriteLine("[" + allUsers[key] + "] " + key);
                    }
                    break;
                case 4:
                    Console.WriteLine(Logger.AllLogs());
                    break;
                case 5:
                    Console.WriteLine("Въведете ключ(филтър):");
                    string filter = Console.ReadLine();
                    if (string.IsNullOrEmpty(filter))
                    {
                        Console.WriteLine("Неуспешно въведен филтър.");
                        break;
                    }
                    Console.WriteLine(Logger.GetCurrentSessionLogs(filter));
                    break;
                default:
                    break;
            }
            AdminMenu();
        }
    }
}
