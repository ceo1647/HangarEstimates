using System.Collections.Generic;
using PropertyChanged;

namespace HangarEstimates.Domain.CostIssues
{
    [ImplementPropertyChanged]
    public abstract class ResultCostIssue<T> : CostIssueBase
        where T : CostIssueBase
    {
        public IList<T> ChildIssues { get; set; }
    }
}