using Microsoft.VisualStudio.TestTools.UnitTesting;
using PandaDataAccessLayer;
using PandaDataAccessLayer.DAL;
using PandaDataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaDataAccessLayerTest
{
    [TestClass]
    public class ChecklistDALTest
    {
        [TestInitialize]
        public void InitTests()
        {
            Database.SetInitializer<MainDbContext>(new MainInitializer());
        }

        [TestMethod]
        public void CreateAndDeleteChecklistTest() 
        {
            using (var dal = new DAL<MainDbContext>())
            {
                var promouter = dal.Create<PromouterUser>(
                    new PromouterUser
                    {
                        Email = "email@domain.com"
                    },
                    new SeoEntry
                    {
                        Keyword = "email domain",
                        Title = "Mail",
                        Description = "Send mail to some gays =))"
                    });
                var checklistCount = dal.DbContext.Checklists.Count();
                var checklist = dal.CreateChecklist(promouter, new List<AttribValue>());
                dal.DbContext.SaveChanges();

                Assert.AreEqual(checklistCount + 1, dal.DbContext.Checklists.Count());

                dal.DeleteById<Checklist>(dal.DbContext.Entry(checklist).Entity.Id);
                dal.DeleteById<PromouterUser>(dal.DbContext.Entry(promouter).Entity.Id);
                dal.DbContext.SaveChanges();

                Assert.AreEqual(checklistCount, dal.DbContext.Checklists.Count());
            }
        } 
    }
}
