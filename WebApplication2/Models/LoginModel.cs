using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication2.Models
{
    public class LoginModel
    {
        public string Login { get; set; }
        public string Password { get; set; }

        public static bool isInit { get; set; }

        public static Dictionary<string, string> ValidKeys { get; set; }

    }
}