using PandaDataAccessLayer.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaDataAccessLayer.Entities
{
    public abstract class UserBase : IGuidIdentifiable
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Salt { get; set; }

        public virtual SeoEntry SeoEntry { get; set; }
        public virtual Photo Avatar { get; set; }
        public virtual Album MainAlbum { get; set; }

        public virtual ICollection<Checklist> Checklists { get; set; }
        public virtual ICollection<Session> Sessions { get; set; }
        public virtual ICollection<Album> Albums { get; set; }
    }
}
