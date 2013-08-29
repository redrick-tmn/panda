using PandaDataAccessLayer.Entities;
using PandaWebApp.FormModels;
using PandaWebApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;

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
}