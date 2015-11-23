using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;

namespace HangarEstimates
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            try
            {
                //VNM.Style.SplashScreen.SplashInstance.Instance.ShowAsync(_description, _version.ToString(), 2014);
                var bootstrapper = new Bootstrapper();

                bootstrapper.Run();
                ShutdownMode = ShutdownMode.OnMainWindowClose;
            }
            catch (Exception ex)
            {
                
            }
            finally
            {
                //VNM.Style.SplashScreen.SplashInstance.Instance.CloseAsync();
                //   this.MainWindow.WindowState = WindowState.Maximized;
                //   this.MainWindow.Activate();
            }
        }
    }
}
