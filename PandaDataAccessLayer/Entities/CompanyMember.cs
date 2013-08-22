using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaDataAccessLayer.Entities
{
    public class CompanyMember : EmployerUser
    {
        public string CompanyName { get; set; }
        public DictValue CompanyType { get; set; }
        public string Description { get; set; }
        public string Position { get; set; }
    }
}
