using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using HangarEstimates.Dal.Mapping;
using NHibernate;
using ISessionFactory = HangarEstimates.Infrastructure.Interfaces.Dal.ISessionFactory;

namespace HangarEstimates.Dal
{
    public class SessionFactory : ISessionFactory
    {
        private readonly string _connectionString;
        private NHibernate.ISessionFactory _factory;

        public SessionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public NHibernate.ISessionFactory Factory
        {
            get
            {
                return _factory ??
                    (_factory = CreateFactory());
            }
        }

        public ISession OpenSession()
        {
            return Factory.OpenSession();
        }

        private NHibernate.ISessionFactory CreateFactory()
        {
            return Fluently.Configure()
                    .Database(PostgreSQLConfiguration.Standard.ConnectionString(_connectionString))
                    .Mappings(
                        m =>
                        m.FluentMappings.AddFromAssembly(
                            typeof(WindMap).Assembly))
                    .BuildSessionFactory();
        }
    }
}
