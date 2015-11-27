
namespace HangarEstimates.Domain.CostIssues
{
    public class JobCountableIssue : CostIssueBase, IMultiplyCostIssue<JobCostIssue>
    {
        public virtual double Count { get; set; }
        public virtual JobCostIssue CostIssue{ get; set; }
    }
}
