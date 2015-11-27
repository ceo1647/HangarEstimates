namespace HangarEstimates.Domain.Materials
 {
    public class Material : BaseObject
    {
        public virtual string Name { get; set; }
        public virtual string TypeSize { get; set; }
        public virtual MeasurementType MesurementType { get; set; }
    }
}