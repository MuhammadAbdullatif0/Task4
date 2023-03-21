using IssuesSystem.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssuesSystem.DAL.Repositories.Repos
{
    public class DevRepo:IDevRepo
    {
        private readonly IssuesContext _context;

        public DevRepo(IssuesContext context)
        {
            _context = context;
        }
        public Devoloper? Get(int id)
        {
            return _context.Set<Devoloper>().Find(id);
        }

        public IEnumerable<Devoloper> GetAll()
        {
            return _context.Set<Devoloper>().ToList();
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

       
    }
}

