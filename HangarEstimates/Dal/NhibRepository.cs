using System;
using System.Collections.Generic;
using HangarEstimates.Domain;
using HangarEstimates.Infrastructure.Interfaces.Dal;

namespace HangarEstimates.Dal
{
    public class NhibRepository<T> : IRepository<T>
        where T : BaseObject
    {
        private readonly ISessionFactory _sessionFactory;

        public NhibRepository(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public IEnumerable<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T Get(object id)
        {
            throw new NotImplementedException();
        }

        public void Save(T obj)
        {
            throw new NotImplementedException();
        }

        public void Add(T obj)
        {
            throw new NotImplementedException();
        }

        public bool Remove(T obj)
        {
            throw new NotImplementedException();
        }
    }
}
