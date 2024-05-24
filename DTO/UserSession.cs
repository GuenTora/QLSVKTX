using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLSV.DTO
{
    internal class UserSession
    {
        public static SinhVien LoggedInUser { get; set; }
        public static void LogoutUser()
        {
            LoggedInUser = null;
        }

        public static void LoginUser(SinhVien user)
        {
            LoggedInUser = user;
        }

        public static bool IsUserLoggedIn()
        {
            return LoggedInUser != null;
        }
    }
}
