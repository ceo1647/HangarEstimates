using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HangarEstimates.Infrastructure;
using HangarEstimates.Infrastructure.Composite;
using HangarEstimates.Modules.HangarEdit;
using Microsoft.Practices.Unity;

namespace HangarEstimates.Modules.Catalogs
{
    public class CatalogsModule : ModuleBase
    {
        public override void Initialize()
        {
            Container.RegisterType<object, CatalogsView>(ViewNames.CatalogsView,
                new ContainerControlledLifetimeManager());
        }
    }
}
