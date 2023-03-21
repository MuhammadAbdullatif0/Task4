using IssuesSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssuesSystem.DAL.Repositories.Repos
{
    public interface IDeptRepo
    {
        IEnumerable<Department> GetAll();
        Department? Get(int id);
        int SaveChanges();
    }
}
