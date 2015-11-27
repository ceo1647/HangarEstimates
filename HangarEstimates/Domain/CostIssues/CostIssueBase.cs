namespace HangarEstimates.Domain.CostIssues
{
    public abstract class CostIssueBase : BaseObject
    {
        public virtual decimal Price { get; set; }
    }
}
