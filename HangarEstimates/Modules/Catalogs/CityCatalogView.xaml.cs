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
using HangarEstimates.Domain.Catalogs;

namespace HangarEstimates.Modules.Catalogs
{
    /// <summary>
    /// Логика взаимодействия для CityCatalogView.xaml
    /// </summary>
    public partial class CityCatalogView : UserControl
    {
        public CityCatalogView()
        {
            InitializeComponent();

            DataContext = new CatalogVm<City>();
        }
    }
}
