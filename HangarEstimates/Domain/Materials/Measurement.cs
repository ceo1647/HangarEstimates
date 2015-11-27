using PropertyChanged;

namespace HangarEstimates.Domain.Materials
{
    [ImplementPropertyChanged]
    public class Measurement : BaseObject
    {
        public virtual string ShortName { get; set; }
        public virtual string FullName { get; set; }
        public virtual double Factor { get; set; }
        public virtual MeasurementType MesurementType { get; set; }
    }
}
