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
            using(var session = _sessionFactory.OpenSession())
                return session.CreateCriteria(typeof(T)).List<T>();
        }

        public T Get(object id)
        {
            using (var session = _sessionFactory.OpenSession())
                return session.Get<T>(id);
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
            using (ISession session = _sessionFactory.OpenSession())
            using (ITransaction transaction = session.BeginTransaction())
            {
                session.Delete(obj);
                transaction.Commit();
            }
        }
    }
}
