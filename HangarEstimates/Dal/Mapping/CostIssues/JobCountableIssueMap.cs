using FluentNHibernate.Mapping;
using HangarEstimates.Domain.CostIssues;

namespace HangarEstimates.Dal.Mapping.CostIssues
{
    public class JobCountableIssueMap : SubclassMap<JobCountableIssue>
    {
        public JobCountableIssueMap()
        {
            Map(x => x.Count);

            References(x => x.CostIssue);
        }
    }
}