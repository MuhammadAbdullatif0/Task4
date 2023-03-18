using IssuesSystem.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IssuesSystem.BL.View
{
    public record ReadVM(int id , string desc , string title , string sev)
    {
    }
}
