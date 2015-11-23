using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HangarEstimates.Bll;

namespace HangarEstimates.Modules.HangarEdit
{
    public class HangarVm
    {
        private readonly Hangar _hangar;

        public HangarVm(Hangar hangar)
        {
            _hangar = hangar;
        }

        public string FullName
        {
            get { return string.Format("Ширина: {0}, Торец №1 : {1}", _hangar.Width, _hangar.FirstEndWall); }
        }
    }
}
