using System.Collections.Generic;

namespace HangarEstimates.Domain.CostIssues
{
    public abstract class ResultCostIssue<T> : CostIssueBase
        where T : CostIssueBase
    {
        public IList<T> ChildIssues { get; set; }
    }
}