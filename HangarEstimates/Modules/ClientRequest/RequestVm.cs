using HangarEstimates.Bll;
using Microsoft.Practices.Prism.Commands;
using PrismMVVMLibrary;

namespace HangarEstimates.Modules.ClientRequest
{
    public class RequestVm : ViewModelBase
    {
        private HangarCityVm _city;
        public Request Model { get; private set; }
        
        public RequestVm(Request request)
        {
            Model = request;
            City = new HangarCityVm(Model.HangarCity);
        }

        public HangarCityVm City
        {
            get { return new HangarCityVm(Model.HangarCity); }
            set
            {
                Model.HangarCity = value.City;
                RaisePropertyChanged(() => City);
            }
        }

        #region Commanding
        
        #endregion
    }
}