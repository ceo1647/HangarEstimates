using HangarEstimates.Domain.Costs;
using PropertyChanged;

namespace HangarEstimates.Domain.Jobs
{
    [ImplementPropertyChanged]
    public class Job : IssueBase
    {
        public virtual string Name { get; set; }
        public virtual MeasuredValue Prise { get; set; }
    }
}