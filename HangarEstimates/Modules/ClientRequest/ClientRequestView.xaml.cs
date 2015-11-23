using System.Windows.Controls;
using HangarEstimates.Modules.ClientRequest.Design;

namespace HangarEstimates.Modules.ClientRequest
{
    /// <summary>
    /// Логика взаимодействия для ClientRequestView.xaml
    /// </summary>
    public partial class ClientRequestView : UserControl
    {
        public ClientRequestView(DesignClientRequestVm dataContext)
        {
            InitializeComponent();

            DataContext = dataContext;
        }
    }
}
