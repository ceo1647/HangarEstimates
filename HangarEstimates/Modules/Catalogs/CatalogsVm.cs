using HangarEstimates.Infrastructure;
using HangarEstimates.Infrastructure.Composite;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Regions;

namespace HangarEstimates.Modules.Catalogs
{
    public class CatalogsVm : ParameterizedNavigationVmBase<string>
    {
        private readonly NavigationService _navigationService;

        public CatalogsVm(NavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        public override void ApplyParametersOnNavigatedTo(string catalogName)
        {
            if (string.IsNullOrEmpty(catalogName))
                catalogName = CatalogsNames.Gates;
        }

        #region Commanding

        private DelegateCommand _acceptCommand;
        public DelegateCommand AcceptCommand
        {
            get { return _acceptCommand ?? (_acceptCommand = new DelegateCommand(Accept)); }
        }

        public void Accept()
        {
            //Hack
            _navigationService.CloseView(RegionNames.DialogRegion, ViewNames.CatalogsView);
        }

        #endregion
    }
}
