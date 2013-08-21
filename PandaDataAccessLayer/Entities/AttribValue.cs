using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaDataAccessLayer.Entities
{
    public class AttribValue
    {
        [Key, Column(Order = 1)]
        public Guid AttribId { get; set; }
        [Key, Column(Order = 2)]
        public Guid ChecklistId { get; set; }

        [ForeignKey("AttribId")]
        public virtual Attrib Attrib { get; set; }
        [ForeignKey("ChecklistId")]
        public virtual Checklist Checklist { get; set; }

        public string Value { get; set; }
    }
}
