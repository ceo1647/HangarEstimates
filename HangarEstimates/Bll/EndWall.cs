using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using HangarEstimates.Bll.Catalogs;

namespace HangarEstimates.Bll
{
    /// <summary>
    /// Торец
    /// </summary>
    public class EndWall
    {
        public EndWall()
        {
            Gates = new List<Gate>();
            Windows = new List<WindPlacement>();
        }
        /// <summary>
        /// Ворота
        /// </summary>
        public IList<Gate> Gates { get; set; }
        /// <summary>
        /// Окна
        /// </summary>
        public IList<WindPlacement> Windows { get; set; }

        public override string ToString()
        {
            return string.Format("Ворота: {0}; Окна: {1} над воротами", string.Join(",", Gates.Select(x => "{ "+x.ToString()+" }")), Windows.Count);
        }
    }
}
