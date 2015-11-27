using System.ComponentModel;
using PropertyChanged;

namespace HangarEstimates.Domain
{
    [ImplementPropertyChanged]
    public abstract class BaseObject : INotifyPropertyChanged
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

        #region Inotify property changed
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName, object before, object after)
        {
            if (before == after)
                return;

         //   IsValid = ValidateMe();

            NotifyPropertyChanged(propertyName);
        }

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        //#region Validation
        //private bool _isValid = false;

        //[DoNotNotify]
        //public bool IsValid
        //{
        //    get { return _isValid; }
        //    protected set
        //    {
        //        if (_isValid != value)
        //        {
        //            _isValid = value;
        //            NotifyPropertyChanged("IsValid");
        //        }
        //    }
        //}

        //protected virtual bool ValidateMe()
        //{
        //    return true;
        //}
        //#endregion
    }
}
