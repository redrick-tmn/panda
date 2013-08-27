using PandaWebApp.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PandaWebApp.Controllers
{
    public class PromouterController : ModelCareController
    {
        [HttpGet]
        public ActionResult Create()
        {
            var model = new FormModels.Register.Promouter();
            return View();
        }

        [HttpPost]
        public ActionResult Create(FormModels.Register.Promouter model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Detail", new { id =  });
            }

            return View(model);
        }

    }
}
