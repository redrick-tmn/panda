using PandaDataAccessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaDataAccessLayer.DAL
{
    public static class DictDAL
    {
        public static KeyValuePair<DictGroup, IEnumerable<DictValue>> CreateDictGroup(this DAL<MainDbContext> dal, DictGroup dictGroup, IEnumerable<DictValue> values)
        {
            var newDictGroup = dal.Create<DictGroup>(dictGroup);
            foreach (var value in values)
            {
                value.DictGroup = newDictGroup;
                dal.Create(value);
            }
            return new KeyValuePair<DictGroup, IEnumerable<DictValue>>(newDictGroup, values);
        }
    }
}
