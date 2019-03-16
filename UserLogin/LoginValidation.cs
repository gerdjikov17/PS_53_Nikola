using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserLogin
{
    public class LoginValidation
    {
        static private UserRoles _currentUserRole;
        static public UserRoles currentUserRole
        {
            get
            {
                return _currentUserRole;
            }
            private set
            {
                _currentUserRole = value;
            }
        }

        public delegate void ActionOnError(string errorMsg);
        private string username;
        private string password;
        private string errorMessage;
        private ActionOnError errorDelegate;

        public LoginValidation(string username, string password, ActionOnError errorDelegate)
        {
            this.username = username;
            this.password = password;
            this.errorDelegate = errorDelegate;
        }

        public Boolean ValidateUserInput(ref User user)
        {
            currentUserRole = UserRoles.ANONYMOUS;
            Boolean emptyUserName = username.Equals(String.Empty);
            if (emptyUserName)
            {
                errorMessage = "Не е посочено потребителско име";
                errorDelegate(errorMessage);
                return false;
            }
            Boolean emptyPassword = password.Equals(String.Empty);
            if (emptyPassword)
            {
                errorMessage = "Не е посочена парола";
                errorDelegate(errorMessage);
                return false;
            }
            Boolean usernameTooShort = username.Length < 5;
            if (usernameTooShort)
            {
                errorMessage = "Потребителското име не трябва да е по-късо от 5 символа.";
                errorDelegate(errorMessage);
                return false;
            }
            Boolean passwordTooShort = password.Length < 5;
            if (passwordTooShort)
            {
                errorMessage = "Паролата не трябва да е по-късо от 5 символа.";
                errorDelegate(errorMessage);
                return false;
            }

            user = UserData.IsUserPassCorrect(username, password);
            if (user != null)
            {
                currentUserRole = (UserRoles)user.role;
                return true;
            }
            else
            {
                errorMessage = "Грешно потребителско име или парола.";
                errorDelegate(errorMessage);
                return false;
            }
        }
    }
}
