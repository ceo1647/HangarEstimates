using FluentNHibernate.Mapping;
using HangarEstimates.Domain.Materials;

namespace HangarEstimates.Dal.Mapping.Materials
{
    public class MeasurementMap : ClassMap<Measurement>
    {
        public MeasurementMap()
        {
            Id(x => x.Id);

            Map(x => x.FullName);
            Map(x => x.Factor);
            Map(x => x.ShortName);

            References(x => x.MesurementType);
        }
    }
}
