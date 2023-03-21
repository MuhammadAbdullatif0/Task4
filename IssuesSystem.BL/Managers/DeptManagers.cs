using IssuesSystem.BL.View;
using IssuesSystem.DAL;
using IssuesSystem.DAL.Repositories.Repos;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssuesSystem.BL.Managers
{
    public class DeptManagers : IDeptManagers
    {
        private readonly IDeptRepo _deptRepo;
        public DeptManagers(IDeptRepo DeptRepo)
        {
            this._deptRepo = DeptRepo;
        }
        

        public List<SelectListItem> GetAll()
        {
            var DeptDB = _deptRepo.GetAll();
            return DeptDB.Select(d => new SelectListItem
            {
                Text = d.Name,
                Value = d.Id.ToString()
            }).ToList();
        }

        public int SaveChanges()
        {
            return _deptRepo.SaveChanges();
        }
    }
}
