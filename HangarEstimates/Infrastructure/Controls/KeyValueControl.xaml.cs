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

namespace HangarEstimates.Infrastructure.Controls
{
    /// <summary>
    /// Логика взаимодействия для KeyValueControl.xaml
    /// </summary>
    public partial class KeyValueControl : UserControl
    {
        public static readonly DependencyProperty KeyProperty = DependencyProperty.RegisterAttached(
            "Key", typeof(string), typeof(KeyValueControl));

        public static readonly DependencyProperty ValueProperty = DependencyProperty.RegisterAttached(
            "Value", typeof(object), typeof(KeyValueControl));

        public static readonly DependencyProperty MaxValueLengthProperty =
            DependencyProperty.RegisterAttached("MaxValueLength", typeof(int), typeof(KeyValueControl));

        public KeyValueControl()
        {
            this.InitializeComponent();

            var keyBinding = new Binding();
            keyBinding.Source = this;
            keyBinding.Path = new PropertyPath("Key");
            keyBinding.Mode = BindingMode.TwoWay;

            this.keyTextBlock.SetBinding(TextBlock.TextProperty, keyBinding);

            var valueBinding = new Binding();
            valueBinding.Source = this;
            valueBinding.Path = new PropertyPath("Value");
            valueBinding.Mode = BindingMode.TwoWay;
            valueBinding.UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged;

            var maxValueLengthBinding = new Binding();
            maxValueLengthBinding.Source = this;
            maxValueLengthBinding.Path = new PropertyPath("MaxValueLength");
            maxValueLengthBinding.Mode = BindingMode.TwoWay;

            this.valueTextBox.SetBinding(TextBox.TextProperty, valueBinding);
            this.valueTextBox.SetBinding(TextBox.MaxLengthProperty, maxValueLengthBinding);
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

        public object Value
        {
            get
            {
                return this.GetValue(ValueProperty);
            }
            set
            {
                this.SetValue(ValueProperty, value);
            }
        }

        public int MaxValueLength
        {
            get
            {
                return (int)this.GetValue(MaxValueLengthProperty);
            }
            set
            {
                this.SetValue(MaxValueLengthProperty, value);
            }
        }
    }
}
