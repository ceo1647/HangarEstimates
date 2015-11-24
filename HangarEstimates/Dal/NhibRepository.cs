using System;
using System.Collections.Generic;
using HangarEstimates.Domain;
using HangarEstimates.Infrastructure.Interfaces.Dal;
using NHibernate;
using ISessionFactory = HangarEstimates.Infrastructure.Interfaces.Dal.ISessionFactory;

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

        }

        public T Get(object id)
        {
            throw new NotImplementedException();
        }

        public void Save(T obj)
        {
            using (var session = _sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Update(obj);
                transaction.Commit();
            }
        }

        public void Add(T obj)
        {
            using (var session = _sessionFactory.OpenSession())
            using (var transaction = session.BeginTransaction())
            {
                session.Save(obj);
                transaction.Commit();
            }
        }

        public bool Remove(T obj)
        {
            throw new NotImplementedException();
        }
    }
}
