using HangarEstimates.Domain.Materials;

namespace HangarEstimates.Domain
{
    public struct MeasuredValue
    {
        public Measurement Measurement { get; set; }
        public double Value { get; set; }
    }
}
