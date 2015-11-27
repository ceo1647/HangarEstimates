using FluentNHibernate.Mapping;
using HangarEstimates.Domain.CostIssues;

namespace HangarEstimates.Dal.Mapping.CostIssues
{
    public class CostIssueBaseMap : ClassMap<CostIssueBase>
    {
        public CostIssueBaseMap()
        {
            Id(x => x.Id);

            Map(x => x.Price);
        }
    }
}
