using PropertyChanged;

namespace HangarEstimates.Bll.Catalogs
{
    [ImplementPropertyChanged]
    public class City : BaseObject
    {
        public string Name { get; set; }
        public string District { get; set; }
        public int SnowRegion { get; set; }
        public int WindRegion { get; set; }

        public override string ToString()
        {
            return string.Format("г. {0}\r\n,{1}", Name, District);
        }
    }
}
