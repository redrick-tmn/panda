using PandaDataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using EntityFramework.Extensions;

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
            var types = new[] 
            { 
                typeof(string),
                typeof(bool),
                typeof(int),
                typeof(DateTime),
                typeof(DictValue),
                typeof(EntityList),
            };
            Array.ForEach(types, x => context.AttribTypes.Add(new AttribType { Type = x.FullName }));
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
