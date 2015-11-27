using PropertyChanged;

namespace HangarEstimates.Domain.CostIssues
{
    [ImplementPropertyChanged]
    public abstract class CostIssueBase : BaseObject
    {
        public virtual MeasuredValue Amount { get; set; }

        public abstract double GetPrice();
    }
}