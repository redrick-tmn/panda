using PandaDataAccessLayer.Entities;
using PandaWebApp.FormModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PandaWebApp.Engine.Binders
{
    public class RegisterPromouterToUsers : BaseBinder<Register.Promouter, UserBase>
    {
        public void Load(Register.Promouter source, UserBase dest)
        {
            dest.Email = source.Email;
            dest.Id = source.Id;
            //TODO password
        }

        public void InverseLoad(UserBase source, Register.Promouter dest)
        {
            dest.Email = source.Email;
            dest.Id = source.Id;
            //TODO password
        }
    }
}