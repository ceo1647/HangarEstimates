using System;
using System.Collections;
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

namespace HangarEstimates.Infrastructure.Controls
{
    /// <summary>
    /// Логика взаимодействия для KeyValueComboControl.xaml
    /// </summary>
    public partial class KeyValueComboControl : UserControl
    {
        public static readonly DependencyProperty KeyProperty = DependencyProperty.RegisterAttached(
            "Key", typeof(string), typeof(KeyValueComboControl));

        public static readonly DependencyProperty SelectedValueProperty;

        public static readonly DependencyProperty DisplayMemberPathProperty;

        public static readonly DependencyProperty ItemsSourceProperty;

        static KeyValueComboControl()
        {
            SelectedValueProperty = DependencyProperty.RegisterAttached(
                "SelectedValue", typeof(object), typeof(KeyValueComboControl));
            ItemsSourceProperty = DependencyProperty.RegisterAttached(
                "ItemsSource", typeof(IEnumerable), typeof(KeyValueComboControl));
            DisplayMemberPathProperty = DependencyProperty.RegisterAttached(
                "DisplayMemberPath", typeof(string), typeof(KeyValueComboControl));
        }

        public KeyValueComboControl()
        {
            this.InitializeComponent();

            var selectedValueBinding = new Binding();
            selectedValueBinding.Source = this;
            selectedValueBinding.Path = new PropertyPath("SelectedValue");
            selectedValueBinding.Mode = BindingMode.TwoWay;

            var displayMemberPathBinding = new Binding();
            displayMemberPathBinding.Source = this;
            displayMemberPathBinding.Path = new PropertyPath("DisplayMemberPath");
            displayMemberPathBinding.Mode = BindingMode.TwoWay;

            var itemsSourceBinding = new Binding();
            itemsSourceBinding.Source = this;
            itemsSourceBinding.Path = new PropertyPath("ItemsSource");
            itemsSourceBinding.Mode = BindingMode.TwoWay;

            var keyBinding = new Binding();
            keyBinding.Source = this;
            keyBinding.Path = new PropertyPath("Key");
            keyBinding.Mode = BindingMode.TwoWay;

            this.cbValue.SetBinding(ComboBox.SelectedValueProperty, selectedValueBinding);
            this.cbValue.SetBinding(ComboBox.ItemsSourceProperty, itemsSourceBinding);
            this.cbValue.SetBinding(ComboBox.DisplayMemberPathProperty, displayMemberPathBinding);
            this.tblText.SetBinding(TextBlock.TextProperty, keyBinding);
        }

        public IEnumerable ItemsSource
        {
            get
            {
                return (IEnumerable)this.GetValue(ItemsSourceProperty);
            }
            set
            {
                this.SetValue(ItemsSourceProperty, value);
            }
        }

        public string DisplayMemberPath
        {
            get
            {
                return (string)this.GetValue(DisplayMemberPathProperty);
            }
            set
            {
                this.SetValue(DisplayMemberPathProperty, value);
            }
        }

        public string Key
        {
            get
            {
                return (string)this.GetValue(KeyProperty);
            }
            set
            {
                this.SetValue(KeyProperty, value);
            }
        }

        public object SelectedValue
        {
            get
            {
                return this.GetValue(SelectedValueProperty);
            }
            set
            {
                this.SetValue(SelectedValueProperty, value);
            }
        }

        private static void OnDemoChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            d.SetValue(SelectedValueProperty, e.NewValue);
            var dd = (KeyValueComboControl)d;
            dd.SelectedValue = e.NewValue;
        }
    }
}
