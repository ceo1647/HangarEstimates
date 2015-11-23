using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HangarEstimates.Bll.Catalogs;

namespace HangarEstimates.Bll.TU
{
    public class SubstuctureTypeTU : BaseObject
    {
        public SubstuctureType Substructure { get; set; }
        public double MinimumHangarWidth { get; set; }
        public double MaximumHangarWidth { get; set; }
    }
}
