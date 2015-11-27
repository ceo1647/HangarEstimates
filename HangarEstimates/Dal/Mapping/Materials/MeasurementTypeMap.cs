using FluentNHibernate.Mapping;
using HangarEstimates.Domain.Materials;

namespace HangarEstimates.Dal.Mapping.Materials
{
    public class MeasurementTypeMap : ClassMap<MeasurementType>
    {
        public MeasurementTypeMap()
        {
            Id(x => x.Id);

            Map(x => x.Name);
        }
    }
}
