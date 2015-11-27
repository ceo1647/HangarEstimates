using HangarEstimates.Domain.Costs;
using PropertyChanged;

namespace HangarEstimates.Domain.CostIssues
{
    [ImplementPropertyChanged]
    public class MaterialIssue : CostIssueBase
    {
        public virtual Material Material { get; set; }
        public virtual MeasuredValue Amount { get; set; }
    }
}