namespace HangarEstimates.Domain.Materials
{
    public class Measurement : BaseObject
    {
        public virtual string ShortName { get; set; }
        public virtual string FullName { get; set; }
        public virtual double Factor { get; set; }
        public virtual MesurementType MesurementType { get; set; }
    }
}
