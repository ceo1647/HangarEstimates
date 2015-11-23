using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using HangarEstimates.Bll.Catalogs;

namespace HangarEstimates.Modules.Catalogs
{
    /// <summary>
    /// Логика взаимодействия для WindsCatalogView.xaml
    /// </summary>
    public partial class WindsCatalogView : UserControl
    {
        public WindsCatalogView()
        {
            InitializeComponent();

            DataContext = new CatalogVm<Wind>();
        }
    }
}
