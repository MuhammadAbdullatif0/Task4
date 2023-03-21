using IssuesSystem.BL.View;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssuesSystem.BL.Managers
{
    public interface IDeptManagers
    {
        List<SelectListItem> GetAll();
     
        int SaveChanges();
    }
}
