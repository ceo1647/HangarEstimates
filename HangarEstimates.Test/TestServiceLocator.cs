using System.ComponentModel;
using Microsoft.Practices.Unity;

namespace HangarEstimates.Test
{
    public class TestServiceLocator
    {
        public static readonly TestServiceLocator Insance = new TestServiceLocator();

        private UnityContainer _container;
        public void Init(UnityContainer container)
        {
            _container = container;
        }

        public T GetInstance<T>()
        {
            return _container.Resolve<T>();
        }
    }
}
