
namespace HangarEstimates.Domain.CostIssues
{
    public class MaterialCountableIssue : CostIssueBase, IMultiplyCostIssue<MaterialCostIssue>
    {
        public virtual double Count { get; set; }
        public virtual MaterialCostIssue CostIssue { get; set; }
    }
}
