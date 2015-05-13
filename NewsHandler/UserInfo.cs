using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyUtility
{
    public class UserInfo
    {
        private static string username = "thuvanntp90";
        public static string Username
        {
            get { return username; }
            set { username = value; }
        }

        private static string email = "thuvanntp@gmail.com";
        public static string Email
        {
            get { return email; }
            set { email = value; }
        }

        private static string password = "thuvan";
        public static string Password
        {
            get { return password; }
            set { password = value; }
        }

        private static string fullname = "Nguyễn Thị Thu Vân";
        public static string Fullname
        {
            get { return fullname; }
            set { fullname = value; }
        }
    }
}
