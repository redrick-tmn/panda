using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PandaDataAccessLayer;
using System.Data.Entity;
using System.Linq;
using PandaDataAccessLayer.Entities.Users;

namespace PandaDataAccessLayerTest
{
    [TestClass]
    public class Tests
    {
        private PandaDbContext mPandaDbContext;

        [TestInitialize()]
        public void Init() 
        {
            Database.SetInitializer<PandaDbContext>(new PandaDebugInitializer());
            mPandaDbContext = new PandaDbContext();
        }

        [TestCleanup()]
        public void Clean() 
        {
            if (mPandaDbContext != null)
            {
                mPandaDbContext.Dispose();
            }
        }
        [TestMethod]
        public void DefaultAttribTypesExistsTest()
        {
            Assert.IsTrue(mPandaDbContext.AttribTypes.Count() > 0);
        }

        [TestMethod]
        public void CreateUsersTest() 
        {
            var user = new UserBase()
            {
                Email = "redrick.tmn@gmail.com"
            };
            mPandaDbContext.Users.Add(user);
            var recruiter = new PrivateRecruiter()
            {
                Email = "redrick.tmn@gmail.com"
            };
            mPandaDbContext.PrivateRecruiters.Add(recruiter);
            mPandaDbContext.SaveChanges();
        }
    }
}
