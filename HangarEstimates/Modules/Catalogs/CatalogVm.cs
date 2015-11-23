using System.Collections.ObjectModel;
using System.Collections.Specialized;
using HangarEstimates.Infrastructure.Interfaces.Services;
using Microsoft.Practices.ServiceLocation;
using PrismMVVMLibrary;

namespace HangarEstimates.Modules.Catalogs
{
    public class CatalogVm<T> : ViewModelBase
        where T: class 
    {
        private readonly IRepository<T> _gateRepository;

        public CatalogVm()
        {
            _gateRepository = ServiceLocator.Current.GetInstance<IRepository<T>>();
            Items = new ObservableCollection<T>(_gateRepository.GetAll());
            Items.CollectionChanged += Items_CollectionChanged;
        }

        void Items_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.Action == NotifyCollectionChangedAction.Add)
            {
                _gateRepository.Add((T)e.NewItems[0]);
            }

            if (e.Action == NotifyCollectionChangedAction.Remove)
            {
                _gateRepository.Remove((T)e.OldItems[0]);
            }
        }

        public ObservableCollection<T> Items { get; set; }
    }
}
