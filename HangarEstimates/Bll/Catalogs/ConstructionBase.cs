using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HangarEstimates.Bll.Catalogs
{
    public abstract class ConstructionBase : BaseObject
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public override string ToString()
        {
            return string.Format("{0}", Name);
        }
    }
}
