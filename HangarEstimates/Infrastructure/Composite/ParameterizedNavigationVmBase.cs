using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Practices.Prism;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.ServiceLocation;
using PrismMVVMLibrary;

namespace HangarEstimates.Infrastructure.Composite
{
    public abstract class ParameterizedNavigationVmBase<TNavigationParameters> : ViewModelBase, IConfirmNavigationRequest
        where TNavigationParameters : class
    {
        protected readonly OpenUriService OpenViewRequestUriService;

        protected ParameterizedNavigationVmBase()
        {
            OpenViewRequestUriService = ServiceLocator.Current.GetInstance<OpenUriService>();
        }

        public abstract void ApplyParametersOnNavigatedTo(TNavigationParameters navigationParameters);



        public virtual void OnNavigatedTo(NavigationContext navigationContext)
        {
            var parameters = ExtractParamsFromUri(navigationContext.Parameters);
            ApplyParametersOnNavigatedTo(parameters);
        }

        public virtual bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public virtual void OnNavigatedFrom(NavigationContext navigationContext)
        {
            
        }

        public virtual void ConfirmNavigationRequest(NavigationContext navigationContext, Action<bool> continuationCallback)
        {
            continuationCallback(true);
        }

        private TNavigationParameters ExtractParamsFromUri(UriQuery uriQuery)
        {
            return OpenViewRequestUriService.ParseNavigationUri<TNavigationParameters>(uriQuery);
        }
    }
}
