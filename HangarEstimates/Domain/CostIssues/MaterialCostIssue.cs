using HangarEstimates.Domain.Materials;

namespace HangarEstimates.Domain.CostIssues
{
    public class MaterialCostIssue : CostIssueBase
    {
        public virtual Material Material { get; set; }
        public virtual Measurement Measurement { get; set; }
    }
}