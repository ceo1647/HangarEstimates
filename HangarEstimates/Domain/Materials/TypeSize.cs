namespace HangarEstimates.Domain.Materials
{
    public class TypeSize : BaseObject
    {
        public virtual double Value1 { get; set; }
        public virtual double Value2 { get; set; }
        public virtual double Value3 { get; set; }
        public virtual double Value4 { get; set; }
        public virtual double Value5 { get; set; }

        public virtual string Formula { get; set; }
        public virtual string Format { get; set; }
    }
}