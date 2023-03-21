using IssuesSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssuesSystem.DAL.Repositories.Repos
{
    public class DeptRepo : IDeptRepo
    {
        private readonly IssuesContext _context;

        public DeptRepo(IssuesContext context)
        {
            _context = context;
        }
        public Department? Get(int id)
        {
           return _context.Set<Department>().Find(id);
        }

        public IEnumerable<Department> GetAll()
        {
           return _context.Set<Department>().ToList();  
        }

        public int SaveChanges()
        {
           return _context.SaveChanges();
        }
    }
}
