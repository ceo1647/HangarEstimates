﻿using FluentNHibernate.Mapping;
using HangarEstimates.Domain.Catalogs;

namespace HangarEstimates.Dal.Mapping
{
    public class WindMap : ClassMap<Wind>
    {
        public WindMap()
        {
            Id(x => x.Id);

            Map(x => x.Width);
            Map(x => x.Height);
        }
    }
}
