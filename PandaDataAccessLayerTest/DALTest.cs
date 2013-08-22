using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PandaDataAccessLayer;
using PandaDataAccessLayer.DAL;
using PandaDataAccessLayer.Entities;

namespace PandaDataAccessLayerTest
{
    [TestClass]
    public class DALTest
    {
        [TestMethod]
        public void CreateAndDeleteUsersTest()
        {
            using (var dal = new DAL<MainDbContext>())
            {
                var userCount = dal.DbContext.PromouterUsers.Count();
                var promouter = dal.CreatePromouter("redrick.tmn@gmail.com");
                dal.DbContext.SaveChanges();

                Assert.AreEqual(userCount + 1, dal.DbContext.PromouterUsers.Count());

                dal.DeleteById<PromouterUser>(dal.DbContext.Entry(promouter).Entity.Id);
                dal.DbContext.SaveChanges();

                Assert.AreEqual(userCount, dal.DbContext.PromouterUsers.Count());
            }
        }
    }
}
