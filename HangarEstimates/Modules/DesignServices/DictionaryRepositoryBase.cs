using System.Collections.Generic;
using HangarEstimates.Bll;
using HangarEstimates.Infrastructure.Interfaces.Services;

namespace HangarEstimates.Modules.DesignServices
{
    public abstract class DictionaryRepositoryBase<T> : IRepository<T>
        where T : BaseObject 
    {
        private readonly Dictionary<object, T> _source = new Dictionary<object, T>();

        public IEnumerable<T> GetAll()
        {
            return _source.Values;
        }

        public T Get(object id)
        {
            return  _source[id];
        }

        public void Save(T obj)
        {
            throw new System.NotImplementedException();
        }

        public void Add(T client)
        {
            var index = _source.Count;
            _source.Add(index, client);
            client.Id = index;
        }

        public bool Remove(T obj)
        {
            if (_source.ContainsKey(obj.Id))
            {
                return _source.Remove(obj);
            }

            return false;
        }
    }
}
