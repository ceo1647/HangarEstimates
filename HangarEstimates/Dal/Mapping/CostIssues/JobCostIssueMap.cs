using FluentNHibernate.Mapping;
using HangarEstimates.Domain.CostIssues;

namespace HangarEstimates.Dal.Mapping.CostIssues
{
    public class JobCostIssueMap : SubclassMap<JobIssue>
    {
        public JobCostIssueMap()
        {
            References(x => x.Job);
            References(x => x.Measurement);
        }
    }
}
