using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using HangarEstimates.Domain;
using HangarEstimates.Domain.Catalogs;
using HangarEstimates.Infrastructure;
using HangarEstimates.Infrastructure.Composite;
using HangarEstimates.Infrastructure.Events;
using HangarEstimates.Infrastructure.Interfaces.Dal;
using HangarEstimates.Infrastructure.Interfaces.Services;
using HangarEstimates.Infrastructure.MVVM;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Events;
using Microsoft.Practices.ServiceLocation;
using NSubstitute.Core;

namespace HangarEstimates.Modules.HangarEdit
{
    public class HangarEditVm : ParameterizedNavigationVmBase<Hangar>
    {
        private readonly IEventAggregator _eventAggregator;
        private readonly IRepository<Hangar> _hangarRepository;
        private readonly IRepository<Gate> _gateRepository;
        private readonly IRepository<Wind> _windRepository;
        private readonly IRepository<SubstuctureType> _substuctureTypeRepository;
        private readonly IRepository<InsulationType> _insulationRepository;
        private readonly IRepository<AdditionConstruction> _additonRepository;

        private Gate[] _awaliableGates;
        public Hangar Model { get; set; }

        public HangarEditVm(
            IEventAggregator eventAggregator,
            IRepository<Hangar> hangarRepository,
            IRepository<Gate> gateRepository,
            IRepository<Wind> windRepository,
            IRepository<SubstuctureType> substuctureTypeRepository,
            IRepository<InsulationType> insulationRepository,
            IRepository<AdditionConstruction> additonRepository)
        {
            _eventAggregator = eventAggregator;
            _hangarRepository = hangarRepository;
            _gateRepository = gateRepository;
            _windRepository = windRepository;
            _substuctureTypeRepository = substuctureTypeRepository;
            _insulationRepository = insulationRepository;
            _additonRepository = additonRepository;
        }

        public override void ApplyParametersOnNavigatedTo(Hangar hangar)
        {
            Model = hangar;

            FirstWallGates = new ObservableCollectionWrapper<Gate>(Model.FirstEndWall.Gates);
            SecondWallGates = new ObservableCollectionWrapper<Gate>(Model.SecondEndWall.Gates);
            FirstWallWinds = new ObservableCollection<WindPlacement>(Model.FirstEndWall.Windows);
            SecondWallWinds = new ObservableCollection<WindPlacement>(Model.SecondEndWall.Windows);
            AdditionConstructions = new ObservableCollectionWrapper<AdditionConstruction>(Model.AdditionConstructions);
        }

        public Gate[] AwaliableGates
        {
            get { return _gateRepository.GetAll().ToArray(); }
        }

        public Wind[] AwaliableWinds
        {
            get { return _windRepository.GetAll().ToArray(); }
        }

        public InsulationType[] AwaliableInsulations
        {
            get { return _insulationRepository.GetAll().ToArray(); }
        }

        public SubstuctureType[] AwaliableSubstructures
        {
            get { return _substuctureTypeRepository.GetAll().ToArray(); }
        }

        public AdditionConstruction[] AwaliableAdditionConstructions
        {
            get { return _additonRepository.GetAll().ToArray(); }
        }

        public IEnumerable<EWindPosition> WindPositions
        {
            get { return Enum.GetValues(typeof(EWindPosition)).Cast<EWindPosition>(); }
        } 

        public ObservableCollectionWrapper<Gate> FirstWallGates { get; set; }
        public ObservableCollectionWrapper<Gate> SecondWallGates { get; set; }
        public ObservableCollection<WindPlacement> FirstWallWinds { get; set; }
        public ObservableCollection<WindPlacement> SecondWallWinds { get; set; }
        public ObservableCollectionWrapper<AdditionConstruction> AdditionConstructions { get; set; }

        #region Commanding

        private DelegateCommand _acceptCommand;
        public DelegateCommand AcceptCommand
        {
            get { return _acceptCommand ?? (_acceptCommand = new DelegateCommand(Accept)); }
        }

        public void Accept()
        {
            var hangar = _hangarRepository.Get(Model.Id);
            _hangarRepository.Remove(hangar);
            _hangarRepository.Add(Model);

            _eventAggregator.GetEvent<ChangeAcceptedEvent<Hangar>>().Publish(Model);
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
    }
}
