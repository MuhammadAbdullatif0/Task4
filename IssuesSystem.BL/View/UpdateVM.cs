using IssuesSystem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssuesSystem.BL.View
{
    public record UpdateVM(int id, string title, string desc, Severity sev)
    {

    }
}
