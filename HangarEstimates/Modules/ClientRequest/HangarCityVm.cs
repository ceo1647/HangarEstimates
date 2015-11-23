using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HangarEstimates.Domain.Catalogs;
using PrismMVVMLibrary;

namespace HangarEstimates.Modules.ClientRequest
{
    public class HangarCityVm : ViewModelBase
    {
        public City City {get; set;}

        public HangarCityVm(City city)
        {
            City = city;
        }

        public int WindRegion
        {
            get { return City.WindRegion; }
            set
            {
                if (value == City.WindRegion) return;
                City.WindRegion = value;
                RaisePropertyChanged(() => WindRegion);
            }
        }

        public int SnowRegion
        {
            get { return City.SnowRegion; }
            set
            {
                if (value == City.SnowRegion) return;
                City.SnowRegion = value;
                RaisePropertyChanged(() => SnowRegion);
            }
        }

        public string Name
        {
            get { return City.ToString(); }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
