using System.Collections.Generic;
using System.Linq;
using HangarEstimates.Domain.Catalogs;

namespace HangarEstimates.Domain
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
