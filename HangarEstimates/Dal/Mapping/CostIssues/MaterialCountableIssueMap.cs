using FluentNHibernate.Mapping;
using HangarEstimates.Domain.CostIssues;

namespace HangarEstimates.Dal.Mapping.CostIssues
{
    public class MaterialCountableIssueMap : SubclassMap<MaterialCountableIssue>
    {
        public MaterialCountableIssueMap()
        {
            Map(x => x.Count);

            References(x => x.CostIssue);
        }
    }
}
