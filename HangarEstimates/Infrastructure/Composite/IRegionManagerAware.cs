using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.Regions;

namespace HangarEstimates.Infrastructure.Composite
{
    public interface IRegionManagerAware
    {
        IRegionManager RegionManager { get; set; }
    }
}
