namespace HangarEstimates.Domain.Materials
{
    public class Material : BaseObject
    {
        public virtual MaterialType Type { get; set; }
        public virtual string TypeSize { get; set; }
        public virtual decimal Prise { get; set; }
    }
}