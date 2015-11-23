using HangarEstimates.Infrastructure;
using HangarEstimates.Infrastructure.Composite;
using HangarEstimates.Infrastructure.Interfaces.Services;
using Microsoft.Practices.Unity;

namespace HangarEstimates.Modules.Contractors.Design
{
    public class DesignContractorsModule : ModuleBase
    {
        public override void Initialize()
        {
            Container.RegisterType<object, ContractorsListView>(ViewNames.ContractorsListView, new ContainerControlledLifetimeManager())
                .RegisterType<IContractorsListVM, ContractorsListVM>();
        }
    }
}
