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
        public static TEntity Create<TEntity>(this DAL<MainDbContext> dal, TEntity user, SeoEntry seo)
             where TEntity : UserBase
        {
            //user.SeoEntry = dal.Create(seo);
            user.Checklists = new List<Checklist>();
            return dal.Create<TEntity>(user);
        }
    }
}
