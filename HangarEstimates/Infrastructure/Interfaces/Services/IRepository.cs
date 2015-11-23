using System.Collections.Generic;

namespace HangarEstimates.Infrastructure.Interfaces.Services
{
    public interface IRepository<T>
        where T: class 
    {
        IEnumerable<T> GetAll();
        T Get(object id);
        void Save(T obj);

        void Add(T obj);
        bool Remove(T obj);
    }
}
