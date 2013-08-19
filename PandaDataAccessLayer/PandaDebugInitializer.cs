using PandaDataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using EntityFramework.Extensions;
using PandaDataAccessLayer.Entities.Users;

namespace PandaDataAccessLayer
{
    public class PandaDebugInitializer : DropCreateDatabaseIfModelChanges<PandaDbContext>
    {
        protected override void Seed(PandaDbContext context)
        {
            addDefaultAttribTypes(context);
            context.SaveChanges();
        }

        private void addDefaultAttribTypes(PandaDbContext context) 
        {
            var defaultAttribTypes = new List<AttribType> { 
                new AttribType{
                    Code = "bool"
                },
                new AttribType{
                    Code = "string"
                },
                new AttribType{
                    Code = "int"
                },
                new AttribType{
                    Code = "dict"
                },
                new AttribType{
                    Code = "datetime"
                },
                new AttribType{
                    Code = "entities"
                },
            };
            defaultAttribTypes.ForEach(x => context.AttribTypes.Add(x));
        }
    }
}
