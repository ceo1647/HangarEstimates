using HangarEstimates.Infrastructure.Composite;
using HangarEstimates.Infrastructure.Interfaces.Dal;
using Microsoft.Practices.Unity;

namespace HangarEstimates.Dal
{
    public class DalModule : ModuleBase
    {
        public override void Initialize()
        {
            Container.RegisterType<ISessionFactory, SessionFactory>(new ContainerControlledLifetimeManager());
            Container.RegisterType(typeof (IRepository<>), typeof (NhibRepository<>),
                new ContainerControlledLifetimeManager());

            Container.RegisterType<IRepository, NhibRepository>(new ContainerControlledLifetimeManager());
        }
    }
}
