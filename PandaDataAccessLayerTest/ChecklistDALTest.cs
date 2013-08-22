using Microsoft.VisualStudio.TestTools.UnitTesting;
using PandaDataAccessLayer;
using PandaDataAccessLayer.DAL;
using PandaDataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaDataAccessLayerTest
{
    [TestClass]
    public class ChecklistDALTest
    {
        [TestMethod]
        public void CreateAndDeleteChecklistTest() 
        {
            using (var dal = new DAL<MainDbContext>())
            {
                var promouter = dal.CreatePromouter("redrick.tmn@gmail.com");
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
