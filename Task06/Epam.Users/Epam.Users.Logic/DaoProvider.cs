﻿using Epam.Users.DAOContracts;
using Epam.Users.FileDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Users.Logic
{
    internal static class DaoProvider
    {
        static DaoProvider()
        {
            UserDao = new UserFileDao();
        }
        public static IUserDao UserDao { get; }
    }
}
