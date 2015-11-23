using System.Windows.Controls;
using HangarEstimates.Domain.Catalogs;

namespace HangarEstimates.Modules.Catalogs
{
    /// <summary>
    /// Логика взаимодействия для GatesCatalogView.xaml
    /// </summary>
    public partial class GatesCatalogView : UserControl
    {
        public GatesCatalogView()
        {
            InitializeComponent();

            DataContext = new CatalogVm<Gate>();
        }
    }
}
