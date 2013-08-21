using PandaDataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using EntityFramework.Extensions;
using PandaDataAccessLayer.Entities.Users;
using PandaDataAccessLayer.Entities.Checklists;

namespace PandaDataAccessLayer
{
    public class MainInitializer : DropCreateDatabaseIfModelChanges<MainDbContext>
    {
        protected override void Seed(MainDbContext context)
        {
            addDefaultAttribTypes(context);
            addDefaultChecklistTypes(context);
            context.SaveChanges();
        }

        private void addDefaultAttribTypes(MainDbContext context) 
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

        private void addDefaultChecklistTypes(MainDbContext context)
        {
            var defaultChecklistTypes = new List<ChecklistType> { 
                new ChecklistType {
                    Code = "Promouter"
                },
                new ChecklistType {
                    Code = "Company"
                },
             };
            defaultChecklistTypes.ForEach(x => context.ChecklistTypes.Add(x));
        }
    }
}
