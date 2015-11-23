namespace HangarEstimates.Domain.Catalogs
{
    public abstract class ConstructionBase : BaseObject
    {
        public string Name { get; set; }

        public double Price { get; set; }

        public override string ToString()
        {
            return string.Format("{0}", Name);
        }
    }
}
