using System.Collections.Generic;
using HangarEstimates.Domain;

namespace HangarEstimates.Infrastructure.Interfaces.Dal
{
    public interface IRepository
    {
        IEnumerable<T> GetAll<T>() where T: BaseObject ;
        T Get<T>(object id) where T: BaseObject ;
        void Save<T>(T obj) where T: BaseObject ;

        void Add<T>(T obj) where T: BaseObject ;
        bool Remove<T>(T obj) where T : BaseObject;
    }
}
