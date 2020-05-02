using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace HotelManagement.API.AuthHelper
{
    public class APISecurity
    {
        public static bool VaidateUser(string username, string passwprd)
        {
            string user = ConfigurationManager.AppSettings["UserName"];
            string pass = ConfigurationManager.AppSettings["Password"];
            if (username == user && passwprd == pass)
                return true;
            return false;
        }
    }
}