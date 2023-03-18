using IssuesSystem.BL.View;
using IssuesSystem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssuesSystem.BL
{
    public interface ITicketManagers
    {
        List<ReadVM> GetAll();
        ReadVM? Get(int id);
        void Add(AddVM ticket);
        void Update(UpdateVM ticket);
        void Delete(int id);
        int SaveChanges();
        UpdateVM GetUpdate(int id);
    }
}
