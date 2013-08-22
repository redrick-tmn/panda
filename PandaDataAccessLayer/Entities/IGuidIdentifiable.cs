using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PandaDataAccessLayer
{
    public interface IGuidIdentifiable
    {
        Guid Id { get; set; }
    }
}
