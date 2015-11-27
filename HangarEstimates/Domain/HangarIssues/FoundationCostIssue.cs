using System.Collections.Generic;
using HangarEstimates.Domain.CostIssues;

namespace HangarEstimates.Domain.HangarIssues
{
    public class FoundationCostIssue : CostIssueBase
    {
        public FoundationCostIssue()
        {
            MaterialIssues = new List<MaterialCountableIssue>();
            JobIssues = new List<JobCountableIssue>();
        }

        public virtual string FoundationName { get; set; }
        public virtual IList<MaterialCountableIssue> MaterialIssues { get; set; }
        public virtual IList<JobCountableIssue> JobIssues { get; set; }
    }
}