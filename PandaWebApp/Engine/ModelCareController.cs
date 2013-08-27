using PandaDataAccessLayer;
using PandaDataAccessLayer.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PandaWebApp.Engine
{
    public class ModelCareController : Controller
    {
        protected DAL<MainDbContext> DataAccessLayer;

        public ModelCareController()
        {
            DataAccessLayer = new DAL<MainDbContext>();
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (disposing)
            {
                DataAccessLayer.Dispose();
            }
        }
    }
}