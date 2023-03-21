using IssuesSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssuesSystem.DAL.Repositories.Repos
{
    public interface IDevRepo
    {
        IEnumerable<Devoloper> GetAll();
        Devoloper? Get(int id);
        int SaveChanges();
    }
}
