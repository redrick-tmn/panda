using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PandaWebApp.Engine.Binders
{
    public abstract class BaseBinder<TSource, TDest>
    {
        public abstract void Load(TSource source, TDest dest);

        public abstract void InverseLoad(TDest source, TSource dest);
    }
}