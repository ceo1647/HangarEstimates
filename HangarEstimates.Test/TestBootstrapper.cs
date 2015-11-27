using HangarEstimates.Dal;
using HangarEstimates.Infrastructure.Interfaces.Services;
using HangarEstimates.Test.Mocks;
using Microsoft.Practices.Unity;

namespace HangarEstimates.Test
{
    public class TestBootstrapper
    {
        public void RunDal()
        {
            DalModule dal = new DalModule();
            var container = new UnityContainer();

            container.RegisterInstance(typeof (IUnityContainer), container);

            container.RegisterType<ISettingsService, MockSettingsService>();

            dal.Container = container;
            dal.Initialize();

            TestServiceLocator.Insance.Init(container);
        }
    }
}
