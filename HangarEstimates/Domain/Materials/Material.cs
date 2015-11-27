namespace HangarEstimates.Domain.Materials
 {
    public class Material : BaseObject
    {
        public virtual string Name { get; set; }
        public virtual string TypeSize { get; set; }
        public virtual MesurementType MesurementType { get; set; }
    }
}