using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace HangarEstimates.Infrastructure.Controls
{
    /// <summary>
    /// Логика взаимодействия для WpfModalDialog.xaml
    /// </summary>
    public partial class WpfModalDialog
    {
        public WpfModalDialog()
        {
            this.InitializeComponent();
            this.Visibility = Visibility.Hidden;
        }

        private bool _hideRequest = false;

        private bool _result = false;

        private UIElement _parent;

        public void SetParent(UIElement parent)
        {
            this._parent = parent;
        }

        #region ViewModel

        public object ViewModel
        {
            get
            {
                return this.GetValue(ViewModelProperty);
            }
            set
            {
                this.SetValue(ViewModelProperty, value);
            }
        }

        // Using a DependencyProperty as the backing store for Message.
        // This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ViewModelProperty = DependencyProperty.Register(
            "ViewModel", typeof(object), typeof(WpfModalDialog), new UIPropertyMetadata(null));

        #endregion

        #region DialogControllTemplate

        public ControlTemplate DialogControllTemplate
        {
            get
            {
                return (ControlTemplate)this.GetValue(ContentDataTemplateProperty);
            }
            set
            {
                this.SetValue(ContentDataTemplateProperty, value);
            }
        }

        public static readonly DependencyProperty ContentDataTemplateProperty =
            DependencyProperty.Register(
                "DialogControllTemplate", typeof(ControlTemplate), typeof(WpfModalDialog), new UIPropertyMetadata());

        #endregion

        public void ShowHandlerDialog()
        {
            this.Visibility = Visibility.Hidden;

            this.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate { }));

            this.Visibility = Visibility.Visible;

            this.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate { }));
        }

        public bool ShowHandlerDialog(dynamic dataContext)
        {
            this.ViewModel = null;
            this.ViewModel = dataContext;
            this.ShowHandlerDialog();

            return this._result;
        }

        private void HideHandlerDialog()
        {
            this._hideRequest = true;
            this.Visibility = Visibility.Hidden;
            this.Dispatcher.Invoke(DispatcherPriority.Background, new ThreadStart(delegate { }));
            // _parent.IsEnabled = true;
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            this._result = true;
            this.HideHandlerDialog();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this._result = false;
            this.HideHandlerDialog();
        }
    }
}
