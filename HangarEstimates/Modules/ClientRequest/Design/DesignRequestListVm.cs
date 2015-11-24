using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Windows;
using HangarEstimates.Domain;
using HangarEstimates.Domain.Catalogs;
using HangarEstimates.Infrastructure;
using HangarEstimates.Infrastructure.Composite;
using HangarEstimates.Infrastructure.Events;
using HangarEstimates.Infrastructure.Interfaces.Dal;
using HangarEstimates.Infrastructure.Interfaces.Services;
using HangarEstimates.Infrastructure.Utils;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.ServiceLocation;
using PrismMVVMLibrary;

namespace HangarEstimates.Modules.ClientRequest.Design
{
    public class DesignRequestListVm : ViewModelBase, IRequestListVm
    {
        private readonly IRepository<Request> _requestRepository;
        private readonly IRepository<City> _cityRepository;
        private readonly IEventAggregator _eventAggregator;
        private readonly NavigationService _navigationService;

        public ObservableCollection<RequestVm> Items
        {
            get { return _items; }
            set
            {
                if (Equals(value, _items)) return;
                _items = value;
                RaisePropertyChanged(() => Items);
            }
        }

        public IEnumerable<HangarCityVm> AwaliableCities { get { return _cityRepository.GetAll().Select(x => new HangarCityVm(x)); } }

        public RequestVm SelectedItem
        {
            get { return _selectedItem; }
            set
            {
                if (Equals(value, _selectedItem)) return;
                _selectedItem = value;
                RaisePropertyChanged(() => SelectedItem);

                RemoveRequestCommand.RaiseCanExecuteChanged();
            }
        }

        public DesignRequestListVm(IRepository<Request> requestRepository, IRepository<City> cityRepository, IEventAggregator eventAggregator, NavigationService navigationService)
        {
            _requestRepository = requestRepository;
            _cityRepository = cityRepository;
            _eventAggregator = eventAggregator;
            _navigationService = navigationService;

            Items = new ObservableCollection<RequestVm>(_requestRepository.GetAll().Select(x => new RequestVm(x)));

            _eventAggregator.GetEvent<ChangeAcceptedEvent<Hangar>>().Subscribe(_ =>

            {
                new ObservableCollection<RequestVm>(_requestRepository.GetAll().Select(x => new RequestVm(x)));
            });

        }

        #region Commanding

        private DelegateCommand _showEstimateCommand;
        public DelegateCommand ShowEstimateCommand
        {
            get { return _showEstimateCommand ?? (_showEstimateCommand = new DelegateCommand(ShowEstimate)); }
        }

        private void ShowEstimate()
        {
            try
            {
                Process.Start(@"Documents\test2.docx");
            }
            catch (Exception)
            {
                
            }
            
        }

        private DelegateCommand _addRequestCommand;
        public DelegateCommand AddRequestCommand
        {
            get { return _addRequestCommand ?? (_addRequestCommand = new DelegateCommand(AddRequest)); }
        }

        private void AddRequest()
        {
            var request = new Request() { Name = "Новый", Client = new Client()
            {
                Name = "новый"
                    
            }, 
            HangarCity = ServiceLocator.Current.GetInstance<IRepository<City>>().Get(0),
            Date = DateTime.Now, Hangar = new Hangar(){}};
            _requestRepository.Add(request);

            var requestVm = new RequestVm(request);
            Items.Add(requestVm);
        }

        private DelegateCommand _removeRequestCommand;
        public DelegateCommand RemoveRequestCommand
        {
            get { return _removeRequestCommand ?? (_removeRequestCommand = new DelegateCommand(RemoveRequest, CanRemoveRequest)); }
        }

        private void RemoveRequest()
        {
            if (MessageBox.Show("Действительно вы хотите удалить заказ?", "Удаление", MessageBoxButton.YesNo) ==
                MessageBoxResult.Yes)
            {
                var request = SelectedItem.Model;
                _requestRepository.Remove(request);
                Items.Remove(SelectedItem);
            }
        }

        private bool CanRemoveRequest()
        {
            return SelectedItem != null;
        }

        private DelegateCommand _editCatalogsCommand;
        public DelegateCommand EditCatalogsCommand
        {
            get { return _editCatalogsCommand ?? (_editCatalogsCommand = new DelegateCommand(EditCatalogs)); }
        }

        public void EditCatalogs()
        {
            _navigationService.OpenView(RegionNames.DialogRegion, ViewNames.CatalogsView);
        }

        private DelegateCommand<Client> _editClientCommand;
        public DelegateCommand<Client> EditClientCommand
        {
            get { return _editClientCommand ?? (_editClientCommand = new DelegateCommand<Client>(EditClient)); }
        }

        private void EditClient(Client client)
        {
            _navigationService.OpenView(RegionNames.DialogRegion, ViewNames.ContractorsListView, client);
        }

        private DelegateCommand<Hangar> _editHangarCommand;
        private RequestVm _selectedItem;
        private ObservableCollection<RequestVm> _items;

        public DelegateCommand<Hangar> EditHangarCommand
        {
            get { return _editHangarCommand ?? (_editHangarCommand = new DelegateCommand<Hangar>(EditHangar)); }
        }

        private void EditHangar(Hangar hangar)
        {
            //var otherHangar = hangar.ConvertTo<Hangar>();
            //otherHangar.FirstEndWall = hangar.FirstEndWall.ConvertTo<EndWall>();
            //otherHangar.SecondEndWall = hangar.SecondEndWall.ConvertTo<EndWall>();
            //otherHangar.SubstuctureType = hangar.SubstuctureType.ConvertTo<SubstuctureType>();
            //otherHangar.AdditionConstructions = new List<AdditionConstruction>(hangar.AdditionConstructions.Select(x => x.ConvertTo<AdditionConstruction>()));


            _navigationService.OpenView(RegionNames.DialogRegion, ViewNames.HangarEditView, hangar);
        }

        #endregion
    }
}
