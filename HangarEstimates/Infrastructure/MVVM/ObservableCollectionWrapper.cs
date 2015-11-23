using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;

namespace HangarEstimates.Infrastructure.MVVM
{
    public class ObservableCollectionWrapper<T> : ObservableCollection<ItemVm<T>>
    {
        private readonly IList<T> _items;

        public ObservableCollectionWrapper(IList<T> items)
            : base(items.Select(x => new ItemVm<T>{Model = x}))
        {
            _items = items;
        }

        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            base.OnCollectionChanged(e);

            switch (e.Action )
            {
                case NotifyCollectionChangedAction.Add: _items.Add(((ItemVm<T>)e.NewItems[0]).Model); break;
                case NotifyCollectionChangedAction.Remove: _items.Remove(((ItemVm<T>)e.OldItems[0]).Model); break;
                //Todo
                default: break;
            }
        }
    }
}
