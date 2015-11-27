using System.Collections.Generic;
using HangarEstimates.Domain;
using HangarEstimates.Infrastructure.Interfaces.Dal;
using Microsoft.Practices.Unity;

namespace HangarEstimates.Dal
{
    public class NhibRepository : IRepository
    {
        private readonly IUnityContainer _container;

        public NhibRepository(IUnityContainer container)
        {
            _container = container;
        }

        public IEnumerable<T> GetAll<T>() where T : BaseObject
        {
            return GetRepository<T>().GetAll();
        }

        public T Get<T>(object id) where T : BaseObject
        {
            return GetRepository<T>().Get(id);
        }

        public void Save<T>(T obj) where T : BaseObject
        {
            GetRepository<T>().Save(obj);
        }

        public void Add<T>(T obj) where T : BaseObject
        {
            GetRepository<T>().Add(obj);
        }

        public bool Remove<T>(T obj) where T : BaseObject
        {
            return GetRepository<T>().Remove(obj);
        }

        private IRepository<T> GetRepository<T>() where T : BaseObject
        {
            return _container.Resolve<IRepository<T>>();
        }
    }
}
