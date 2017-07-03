using Epam.Users.DAOContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Users.Entities;

namespace Epam.Users.FileDAL
{
    public class AwardsDao : IAwardsDao
    {
        private FileHandler handler = new FileHandler();

        public IEnumerable<Award> GetAwards
        {
            get
            {
                return handler.ReadAllAwards();
            }
        }

        public bool CreateAwards(Award award)
        {
            if (award == null)
                throw new ArgumentNullException();

            handler.CSVWriter(award);
            return true;
        }

        public string GetAwardsById(int id)
        {
            return GetAwards.Where(x => x.Id.ToString().Contains(id.ToString())).FirstOrDefault().Title;
        }
    }
}
