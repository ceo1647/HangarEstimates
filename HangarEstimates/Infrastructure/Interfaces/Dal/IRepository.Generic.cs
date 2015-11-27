using System.Collections.Generic;
using HangarEstimates.Domain;

namespace HangarEstimates.Infrastructure.Interfaces.Dal
{
    public interface IRepository<T>
        where T : BaseObject
    {
        IEnumerable<T> GetAll();
        T Get(object id);
        void Save(T obj);

        void Add(T obj);
        bool Remove(T obj);
    }
}
