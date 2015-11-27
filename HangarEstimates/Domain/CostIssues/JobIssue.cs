using HangarEstimates.Domain.Jobs;
using PropertyChanged;

namespace HangarEstimates.Domain.CostIssues
{
    [ImplementPropertyChanged]
    public class JobIssue : CostIssueBase
    {
        public virtual Job Job { get; set; }
        
    }
}
