using PandaDataAccessLayer.Entities.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaDataAccessLayer.Entities.Checklists
{
    public class EmployerChecklist : Checklist
    {
        public virtual EmployerUser EmployerUser { get; set; }
    }
}
