using Epam.Users.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epam.Users.LogicContracts
{
    public interface IAwardsCrud
    {
        void AddAwards(Award award);
        IEnumerable<Award> GetAll { get; }
        string GetById(int id);
    }
}