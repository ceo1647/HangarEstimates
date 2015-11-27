using HangarEstimates.Domain.Jobs;
using HangarEstimates.Domain.Materials;

namespace HangarEstimates.Domain.CostIssues
{
    public class JobCostIssue : CostIssueBase
    {
        public virtual Job Job { get; set; }
        public virtual Measurement Measurement { get; set; }
    }
}
