using HangarEstimates.Infrastructure.Composite;
using HangarEstimates.Infrastructure.Interfaces.Services;
using Microsoft.Practices.Unity;

namespace HangarEstimates.Modules.InfrastructureServices
{
    public class InfrastructureServicesModule : ModuleBase
    {
        public override void Initialize()
        {
            Container.RegisterType<ISettingsService, SettingsService>(new ContainerControlledLifetimeManager());
        }
    }
}
