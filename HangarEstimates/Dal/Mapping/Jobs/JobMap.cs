using FluentNHibernate.Mapping;
using HangarEstimates.Domain.Jobs;

namespace HangarEstimates.Dal.Mapping.Jobs
{
    public class JobMap : ClassMap<Job>
    {
        public JobMap()
        {
            Id(x => x.Id);

            Map(x => x.Name);
        }
    }
}
