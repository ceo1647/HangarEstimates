using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HangarEstimates.Domain.Materials
{
    public class Material
    {
        public virtual MaterialType Type { get; set; }
        public virtual string TypeSize { get; set; }
        public virtual decimal Prise { get; set; }
    }
}