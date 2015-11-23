namespace HangarEstimates.Bll
{
    public abstract class BaseObject
    {
        public virtual int Id { get; set; }

        protected bool Equals(BaseObject other)
        {
            return Id == other.Id;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            var other = obj as BaseObject;
            return other != null && Equals(other);
        }

        public override int GetHashCode()
        {
            return Id;
        }
    }
}
