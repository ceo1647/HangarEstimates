using PropertyChanged;

namespace HangarEstimates.Domain.Costs
 {
    [ImplementPropertyChanged]
    public class Material : IssueBase
    {
        public virtual string Name { get; set; }
        public virtual string TypeSize { get; set; }
        public virtual MeasuredValue Prise { get; set; }
    }
}