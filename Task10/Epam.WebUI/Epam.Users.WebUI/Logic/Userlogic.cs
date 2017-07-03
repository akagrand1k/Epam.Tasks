using Epam.Users.Logic;
using Epam.Users.LogicContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.WebPages;

namespace Epam.Users.WebUI.Logic
{
    public class Userlogic
    {
        private static IUserContracts userlogic;
        private static IAwardsCrud awardslogic;
        private static IUserAwardsCrud userawardslogic;
        private static IFileHandler filehandler;

        public Userlogic()
        {
            userlogic = new UserContracts();
            awardslogic = new AwardsContracts();
            userawardslogic = new UserAwardsContracts();
            filehandler = new Handler();
        }
        
        public static object CreateUser()
        {
            
        }
    }
}