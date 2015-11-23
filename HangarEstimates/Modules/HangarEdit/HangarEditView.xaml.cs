using System.Windows.Controls;

namespace HangarEstimates.Modules.HangarEdit
{
    /// <summary>
    /// Логика взаимодействия для HangarEditView.xaml
    /// </summary>
    public partial class HangarEditView : UserControl
    {
        public HangarEditView(HangarEditVm dataContext)
        {
            InitializeComponent();

            DataContext = dataContext;
        }
    }
}
