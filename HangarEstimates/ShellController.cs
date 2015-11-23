using HangarEstimates.Infrastructure;
using HangarEstimates.Infrastructure.Composite;
using Microsoft.Practices.Prism.Regions;

namespace HangarEstimates
{
    public class ShellController
    {
        private readonly IRegionManager _regionManager;
        private readonly NavigationService _navigationService;

        public ShellController(IRegionManager regionManager, NavigationService navigationService)
        {
            _regionManager = regionManager;
            _navigationService = navigationService;
        }

        public void Start()
        {
            _navigationService.OpenView(RegionNames.MainRegion, ViewNames.RequestListView);
        }
    }
}
