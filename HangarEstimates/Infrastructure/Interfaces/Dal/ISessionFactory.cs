using NHibernate;

namespace HangarEstimates.Infrastructure.Interfaces.Dal
{
    public interface ISessionFactory
    {
        ISession OpenSession();
    }
}
