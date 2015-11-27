using System;

namespace HangarEstimates.Domain.CostIssues
{
    public interface IMultiplyCostIssue<T>
        where T : CostIssueBase
    {
         double Count { get; set; }
         T CostIssue { get; set; }
    }
}
