using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterLogin
{
    public class Login(string username, string password)
    {
        private readonly string username = username;
        private string password = password;

        public string GetUsername()
        {
            return username;
        }

        public bool CheckPassword(string input)
        {
            return password.Equals(input);
        }

        public bool ChangePassword(string oldPass, string newPass)
        {
            if (oldPass.Equals(password))
            {
                password = newPass;
                return true;
            }
            return false;
        }
    }
}
