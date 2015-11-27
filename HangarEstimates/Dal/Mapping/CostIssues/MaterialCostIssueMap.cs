using FluentNHibernate.Mapping;
using HangarEstimates.Domain.CostIssues;

namespace HangarEstimates.Dal.Mapping.CostIssues
{
    public class MaterialCostIssueMap : SubclassMap<MaterialIssue>
    {
        public MaterialCostIssueMap()
        {
            References(x => x.Material);
            References(x => x.Measurement);
        }
    }
}
