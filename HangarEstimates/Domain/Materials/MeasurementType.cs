using PropertyChanged;

namespace HangarEstimates.Domain.Materials
{
    [ImplementPropertyChanged]
    public class MeasurementType : BaseObject
    {
        public virtual string Name { get; set; }
    }
}
