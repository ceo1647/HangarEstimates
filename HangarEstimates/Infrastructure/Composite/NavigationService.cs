using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Unity;

namespace HangarEstimates.Infrastructure.Composite
{
    public class NavigationService
    {
        private readonly IUnityContainer _container;
        private readonly IRegionManager _regionManager;
        private readonly OpenUriService _openUriService;

        public NavigationService(IUnityContainer container, IRegionManager regionManager, OpenUriService openUriService)
        {
            _container = container;
            _regionManager = regionManager;
            _openUriService = openUriService;
        }

        public void OpenView(string regionName, string viewName)
        {
            _regionManager.RequestNavigate(regionName, new Uri(viewName, UriKind.Relative));   
        }

        public void OpenView<TParams>(string regionName, string viewName, TParams navigParameters) where TParams : class 
        {
            var uri = _openUriService.GenerateNavigationUri(
                viewName,
                navigParameters,
                UriKind.Relative);

            _regionManager.RequestNavigate(regionName, uri);
        }

        public void CloseView(string regionName, string viewName)
        {
            if (!_regionManager.Regions.ContainsRegionWithName(regionName)) return;

            var region = _regionManager.Regions[regionName];

            // TODO //
            var ordersView = region.Views.FirstOrDefault();

            // var ordersView = region.GetView(viewName);
            if (ordersView != null)
            {
                region.Remove(ordersView);
            }
        }
    }
}
