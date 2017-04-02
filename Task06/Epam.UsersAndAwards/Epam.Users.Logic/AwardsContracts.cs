using Epam.Users.LogicContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Epam.Users.Entities;
using Epam.Users.DAOContracts;

namespace Epam.Users.Logic
{
    public class AwardsContracts : IAwardsCrud
    {
        private IAwardsDao awardslogic;
        public AwardsContracts()
        {
            this.awardslogic = DaoProvider.AwardsDao;
        }
        public IEnumerable<Award> GetAll
        {
            get
            {
                return awardslogic.GetAwards;
            }
        }

        public void AddAwards(Award award)
        {
            if (award == null)
                throw new ArgumentNullException();

            awardslogic.CreateAwards(award);
        }
    }
}
