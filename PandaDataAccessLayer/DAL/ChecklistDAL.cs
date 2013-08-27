using PandaDataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaDataAccessLayer.DAL
{
    public static class ChecklistDAL
    {
        public static Checklist CreateChecklist(this DAL<MainDbContext> dal, UserBase user, IEnumerable<AttribValue> attributeValues) 
        {
            var checkList = dal.Create<Checklist>();
            checkList.AttrbuteValues = new List<AttribValue>(attributeValues);
            checkList.ChecklistType = dal.DbContext.ChecklistTypes.Single(x => x.Code == "Company");
            checkList.User = user;
            return checkList;
        }

        public static IEnumerable<Attrib> GetAttributes(this DAL<MainDbContext> dal, Checklist checklist)
        {
            return dal.DbContext
                .Attribs
                .Where(x => checklist.AttrbuteValues.Any(y => y.AttribId == x.Id))
                .ToList(); 
        }

        public static double GetFillingPercentage(this DAL<MainDbContext> dal, Checklist checklist)
        {
            var join = from av in checklist.AttrbuteValues
                        join a in dal.DbContext.Attribs on av.AttribId equals a.Id
                        select new {
                            Weight = a.Weight,
                            Value = av.Value != null
                        };

            return join.Sum(x => x.Value ? x.Weight : 0) * 100 / join.Sum(x => x.Weight);
        }

        public static IEnumerable<DictValue> GetRangeByAttribTypeId(this DAL<MainDbContext> dal, Guid attribTypeId)
        {
            var dictGroup = dal.GetById<AttribType>(attribTypeId);
            if (dictGroup.Type != typeof(DictValue).FullName)
            {
                throw new Exception("Not dictionary attribute");
            }
            return dictGroup.DictGroup.DictValues.ToList();
        }

        public static IEnumerable<Attrib> GetAllAttributes(this DAL<MainDbContext> dal)
        {
            return dal.DbContext.Attribs.ToList();
        }

        public static IEnumerable<Attrib> GetAttributes(this DAL<MainDbContext> dal, Guid checklistTypeId)
        {
            return dal.DbContext.Attribs.Where(x => dal.DbContext.Attrib2ChecklistType.Any(y => y.ChecklistType.Id == checklistTypeId)).ToList();
        }

        public static IEnumerable<AttribValue> GetAttributeValues(this DAL<MainDbContext> dal, Guid checklistId)
        {
            return dal.DbContext.AttribValues.Where(x => x.ChecklistId == checklistId).ToList();
        }

        public static AttribType GetAttribType(this DAL<MainDbContext> dal, Type type)
        {
            return dal.DbContext.AttribTypes.Single(x => x.Type == type.FullName);
        }

        public static Checklist UpdateChecklist(this DAL<MainDbContext> dal, Guid checklistId, IEnumerable<AttribValue> attributeValues)
        {
            var user = dal.GetById<Checklist>(checklistId).User;
            dal.DeleteById<Checklist>(checklistId);
            return dal.CreateChecklist(user, attributeValues);
        }
    }
}
