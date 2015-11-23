using System.Collections.ObjectModel;
using System.Linq;
using HangarEstimates.Bll;
using HangarEstimates.Infrastructure;
using HangarEstimates.Infrastructure.Composite;
using HangarEstimates.Infrastructure.Interfaces.Services;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.ServiceLocation;

namespace HangarEstimates.Modules.Contractors
{
    public class ContractorsListVM : ParameterizedNavigationVmBase<Client>, IContractorsListVM
    {
        private readonly IRepository<Client> _repository;
        private readonly IYesNoUserAnswerService _yesNoUserAnswerService;

        public ObservableCollection<ContractorDetailsVM> Items { get; set; }

        public ContractorDetailsVM SelectedClient
        {
            get { return _selectedClient; }
            set
            {
                if (Equals(value, _selectedClient)) return;
                _selectedClient = value;
                RaisePropertyChanged(() => SelectedClient);
            }
        }

        public ContractorsListVM(IRepository<Client> repository, IYesNoUserAnswerService yesNoUserAnswerService)
        {
            _repository = repository;
            _yesNoUserAnswerService = yesNoUserAnswerService;
        }

        public override void ApplyParametersOnNavigatedTo(Client client)
        {
            var itemsModel = _repository.GetAll();
            Items = new ObservableCollection<ContractorDetailsVM>(itemsModel.Select(x => new ContractorDetailsVM(x)));
            SelectedClient = Items.FirstOrDefault(x => Equals(x.Model, client));
        }

        #region Commanding
        private DelegateCommand _addClientCommand;
        public DelegateCommand AddClientCommand
        {
            get { return _addClientCommand ?? (_addClientCommand = new DelegateCommand(AddClient)); }
        }

        private void AddClient()
        {
            var client = new Client {Name = "<Новый>"};
            _repository.Add(client);

            var clientVm = new ContractorDetailsVM(client);
            Items.Add(clientVm);

            SelectedClient = clientVm;
        }

        private DelegateCommand _removeClientCommand;
        public DelegateCommand RemoveClientCommand
        {
            get { return _removeClientCommand ?? (_removeClientCommand = new DelegateCommand(RemoveCommand)); }
        }

        private void RemoveCommand()
        {
           if(SelectedClient == null)
                return;

            var clientToRemove = SelectedClient.Model;

            if (_yesNoUserAnswerService.AskUser("Вы действительно хотите удалить запись", "Удаление контрагента"))
            {
                Items.Remove(SelectedClient);
                _repository.Remove(clientToRemove);

                SelectedClient = Items.FirstOrDefault();
            }
        }
        #endregion

        #region Dialog Commanding 

        private DelegateCommand _acceptCommand;
        public DelegateCommand AcceptCommand
        {
            get { return _acceptCommand ?? (_acceptCommand = new DelegateCommand(Accept)); }
        }

        public void Accept()
        {
            //Hack
            ServiceLocator.Current.GetInstance<NavigationService>().CloseView(RegionNames.DialogRegion, ViewNames.HangarEditView);
        }


        private DelegateCommand _rejectCommand;
        public DelegateCommand RejectCommand
        {
            get { return _rejectCommand ?? (_rejectCommand = new DelegateCommand(Accept)); }
        }

        public void Reject()
        {
            //Hack
            ServiceLocator.Current.GetInstance<NavigationService>().CloseView(RegionNames.DialogRegion, ViewNames.HangarEditView);
        }
        #endregion

        #region privates
        private ContractorDetailsVM _selectedClient;
        #endregion
    }
}
