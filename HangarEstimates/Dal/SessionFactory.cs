using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using HangarEstimates.Dal.Mapping;
using HangarEstimates.Infrastructure.Interfaces.Dal;
using HangarEstimates.Infrastructure.Interfaces.Services;
using NHibernate.PropertyChanged;
using NHibernate.Tool.hbm2ddl;

namespace HangarEstimates.Dal
{
    public class SessionFactory : ISessionFactory
    {
        private readonly string _connectionString;
        private NHibernate.ISessionFactory _factory;

        public SessionFactory(ISettingsService settingsService)
        {
            _connectionString = settingsService.GetDataBaseConnectionString();
        }

        public NHibernate.ISessionFactory Factory
        {
            get
            {
                return _factory ??
                    (_factory = CreateFactory());
            }
        }

        public NHibernate.ISession OpenSession()
        {
            return Factory.OpenSession();
        }

        private NHibernate.ISessionFactory CreateFactory()
        {
            return Fluently.Configure()
                .Database(MsSqlCeConfiguration.Standard.ConnectionString(_connectionString))
                .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(true, true))
                .Mappings(
                    m =>
                    m.FluentMappings.AddFromAssembly(
                        typeof(WindMap).Assembly))
                .ProxyFactoryFactory<PropertyChangedProxyFactoryFactory>()
                .BuildSessionFactory();
        }
    }
}
