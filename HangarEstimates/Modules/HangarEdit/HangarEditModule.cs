using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HangarEstimates.Infrastructure;
using HangarEstimates.Infrastructure.Composite;
using HangarEstimates.Modules.ClientRequest;
using HangarEstimates.Modules.ClientRequest.Design;
using Microsoft.Practices.Unity;

namespace HangarEstimates.Modules.HangarEdit
{
    public class HangarEditModule : ModuleBase
    {
        public override void Initialize()
        {
            Container.RegisterType<object, HangarEditView>(ViewNames.HangarEditView,
                new ContainerControlledLifetimeManager());
        }
    }
}
