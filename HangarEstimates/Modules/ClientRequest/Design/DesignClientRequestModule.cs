using HangarEstimates.Infrastructure;
using HangarEstimates.Infrastructure.Composite;
using HangarEstimates.Infrastructure.Interfaces.Services;
using Microsoft.Practices.Unity;

namespace HangarEstimates.Modules.ClientRequest.Design
{
    public class DesignClientRequestModule : ModuleBase
    {
        public override void Initialize()
        {
            Container.RegisterType<object, RequestListView>(ViewNames.RequestListView, new ContainerControlledLifetimeManager())
                .RegisterType<object, ClientRequestView>(ViewNames.ClientRequestView, new ContainerControlledLifetimeManager())
                .RegisterType<IRequestListVm, DesignRequestListVm>();
        }
    }
}
