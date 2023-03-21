using IssuesSystem.DAL.Repositories.Repos;
using Microsoft.AspNetCore.Mvc.Rendering;


namespace IssuesSystem.BL.Managers
{
    public class DevManagers:IDevManagers
    {
        private readonly IDevRepo _devRepo;
        public DevManagers(IDevRepo DevRepo)
        {
            this._devRepo = DevRepo;
        }


        public List<SelectListItem> GetAll()
        {
            var DeptDB = _devRepo.GetAll();
            return DeptDB.Select(d => new SelectListItem
            {
                Text = d.Name,
                Value = d.Id.ToString()
            }).ToList();
        }

        public int SaveChanges()
        {
            return _devRepo.SaveChanges();
        }
    }
}

