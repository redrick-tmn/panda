using PandaDataAccessLayer.DAL;
using PandaDataAccessLayer.Entities.Checklists;
using PandaDataAccessLayer.Entities.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaDataAccessLayer.Entities
{
    public class Checklist : IGuidIdentifiable
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }

        public virtual UserBase User { get; set; }
        public virtual ChecklistType ChecklistType { get; set; }
        public virtual List<AttribValue> AttrbuteValues { get; set; }
    }
}
