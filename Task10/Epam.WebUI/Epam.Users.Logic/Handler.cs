using Epam.Users.Constants;
using Epam.Users.DAOContracts;
using Epam.Users.Extension;
using Epam.Users.LogicContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Users.Logic
{
    public class Handler : IFileHandler
    {
        private IFileDao fileDao;

        public Handler()
        {
            fileDao = DaoProvider.fileDao;
        }

        public void ExtensionInit()
        {
            AppExtension.CheckSystemFolder();
            AppExtension.CheckSystemFile();
            fileDao.WriteHeader(AppExtension.GetUserHeader, AppConst.dataPath);
            fileDao.WriteHeader(AppExtension.GetAwardsProperty, AppConst.awardsPath);
            fileDao.WriteHeader(AppExtension.GetUserAwardsProperty, AppConst.userAwardsPath);
        }
    }
}
