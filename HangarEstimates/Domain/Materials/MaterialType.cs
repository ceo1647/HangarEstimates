namespace HangarEstimates.Domain.Materials
 {
    public class MaterialType : BaseObject
    {
        public virtual string Name { get; set; }
        public virtual MesurementType MesurementType { get; set; }
    }
}