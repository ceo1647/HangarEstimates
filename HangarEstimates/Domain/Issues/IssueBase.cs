namespace HangarEstimates.Domain.Costs
{
    public abstract class IssueBase : BaseObject
    {
        public virtual string Name { get; set; }
        public virtual MeasuredValue Prise { get; set; }
    }
}