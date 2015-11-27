using System.Collections.Generic;

namespace HangarEstimates.Domain.CostIssues
{
    public class ResultCostIssue : CostIssueBase
    {
        public IList<CostIssueBase> ChildIssues { get; set; }
    }
}