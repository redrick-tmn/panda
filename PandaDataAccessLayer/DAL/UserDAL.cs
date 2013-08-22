using PandaDataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaDataAccessLayer.DAL
{
    public static class UserDAL
    {
        public static PromouterUser CreatePromouter(this DAL<MainDbContext> dal, string email)
        {
            var promouter = dal.Create<PromouterUser>();
            promouter.Email = email;
            promouter.Checklists = new List<Checklist>();
            return promouter;
        }
    }
}
