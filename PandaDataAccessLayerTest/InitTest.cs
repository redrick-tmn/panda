using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PandaDataAccessLayer;
using System.Data.Entity;
using System.Linq;
using PandaDataAccessLayer.Entities.Users;
using EntityFramework.Extensions;
using PandaDataAccessLayer.DAL;
using PandaDataAccessLayer.Entities;
using System.Collections.Generic;


namespace PandaDataAccessLayerTest
{
    [TestClass]
    public class InitTest
    {
        [TestMethod]
        public void DefaultAttribTypesExistsTest()
        {
            using (var dal = new DAL<MainDbContext>())
            {
                Assert.IsTrue(dal.DbContext.AttribTypes.Count() > 0);
            }
        }

        [TestMethod]
        public void DefaultChecklistTypesExistsTest()
        {
            using (var dal = new DAL<MainDbContext>())
            {
                Assert.IsTrue(dal.DbContext.ChecklistTypes.Count() > 0);
            }
        }
    }
}
