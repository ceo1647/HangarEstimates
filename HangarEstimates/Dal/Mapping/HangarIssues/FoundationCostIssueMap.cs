using FluentNHibernate.Mapping;
using HangarEstimates.Domain.HangarIssues;

namespace HangarEstimates.Dal.Mapping.HangarIssues
{
    public class FoundationCostIssueMap : SubclassMap<FoundationCostIssue>
    {
        public FoundationCostIssueMap()
        {
            Map(x => x.FoundationName);

            HasMany(x => x.JobIssues);
            HasMany(x => x.MaterialIssues);
        }
    }
}
