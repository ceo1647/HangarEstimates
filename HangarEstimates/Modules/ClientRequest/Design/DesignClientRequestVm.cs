using HangarEstimates.Bll;
using HangarEstimates.Infrastructure.Composite;

namespace HangarEstimates.Modules.ClientRequest.Design
{
    public class DesignClientRequestVm : ParameterizedNavigationVmBase<Request>
    {
        public Request Request { get; set; }

        public override void ApplyParametersOnNavigatedTo(Request request)
        {
            Request = request;
        }
    }
}
