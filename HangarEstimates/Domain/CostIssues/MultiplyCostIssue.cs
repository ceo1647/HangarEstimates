namespace HangarEstimates.Domain.CostIssues
{
    public class MultiplyCostIssue : CostIssueBase
    {
        public double Count { get; set; }
        public CostIssueBase CostIssue { get; set; }
    }
}
