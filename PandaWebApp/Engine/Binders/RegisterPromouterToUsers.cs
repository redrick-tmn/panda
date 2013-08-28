using PandaDataAccessLayer.Entities;
using PandaWebApp.FormModels;
using PandaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PandaWebApp.Engine.Binders
{
    public class RegisterPromouterToUsers : BaseBinder<Register.Promouter, UserBase>
    {
        public override void Load(Register.Promouter source, UserBase dest)
        {
            dest.Email = source.Email;
            dest.Id = source.Id;
            dest.Password = source.Password;
            //TODO password
        }

        public override void InverseLoad(UserBase source, Register.Promouter dest)
        {
            dest.Email = source.Email;
            dest.Id = source.Id;
            //TODO password
        }
    }

    public class ViewPromouterToUsers : BaseBinder<Promouter, PromouterUser>
    {
        public override void Load(Promouter source, PromouterUser dest)
        {
            //TODO
        }

        public override void InverseLoad(PromouterUser source, Promouter dest)
        {
            dest.Email = source.Email;

            //fake
            dest.BirthDate = DateTime.UtcNow.AddYears(-10);
        }
    }
}