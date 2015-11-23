using HangarEstimates.Domain.Catalogs;

namespace HangarEstimates.Domain.TU
{
    public class SubstuctureTypeTU : BaseObject
    {
        public SubstuctureType Substructure { get; set; }
        public double MinimumHangarWidth { get; set; }
        public double MaximumHangarWidth { get; set; }
    }
}
