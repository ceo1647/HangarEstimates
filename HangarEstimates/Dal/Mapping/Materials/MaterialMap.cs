using FluentNHibernate.Mapping;
using HangarEstimates.Domain.Costs;
using HangarEstimates.Domain.Materials;

namespace HangarEstimates.Dal.Mapping.Materials
{
    public class MaterialMap : ClassMap<Material>
    {
        public MaterialMap()
        {
            Id(x => x.Id);

            Map(x => x.TypeSize);
            Map(x => x.Name);

            References(x => x.MesurementType);
        }
    }
}
