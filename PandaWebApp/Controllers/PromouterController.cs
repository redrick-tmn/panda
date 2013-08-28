using PandaWebApp.Engine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


using PandaWebApp.Engine.Binders;
using PandaDataAccessLayer.Entities;
using PandaDataAccessLayer.DAL;

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
                //salt
                model.Password = Password.MakePassword(model.Password, DateTime.UtcNow);
                var binder = new RegisterPromouterToUsers();
                var entry = new PromouterUser();
                binder.Load(model, entry);
                DataAccessLayer.Create(entry);

                return RedirectToAction("Detail", new { id = model.Id });
            }

            return View(model);
        }

        [HttpGet]
        public ActionResult Detail(Guid id)
        {
            var model = DataAccessLayer.GetById<PromouterUser>(id);
            if (model == null)
            {
                return HttpNotFound("Promouter not found");
            }
            return View();
        }

    }
}
