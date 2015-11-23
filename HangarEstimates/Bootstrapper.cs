using System.Windows;
using HangarEstimates.Modules.Catalogs;
using HangarEstimates.Modules.ClientRequest;
using HangarEstimates.Modules.ClientRequest.Design;
using HangarEstimates.Modules.Contractors.Design;
using HangarEstimates.Modules.DesignServices;
using HangarEstimates.Modules.HangarEdit;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.Unity;

namespace HangarEstimates
{
    public class Bootstrapper : UnityBootstrapper
    {
        public new void Run()
        {
            base.Run();

            Container.RegisterType<ShellController>(new ContainerControlledLifetimeManager());
            var controller = Container.Resolve<ShellController>();
            controller.Start();
        }

        protected override void InitializeShell()
        {
            Application.Current.MainWindow = (Shell)Shell;
            Application.Current.MainWindow.WindowState = WindowState.Maximized;
            Application.Current.MainWindow.ResizeMode = ResizeMode.CanResizeWithGrip;
            Application.Current.MainWindow.WindowStyle = WindowStyle.ThreeDBorderWindow;
            Application.Current.MainWindow.Show();
        }

        protected override DependencyObject CreateShell()
        {
            var shell = new Shell();
            return shell;
        }

        protected override IModuleCatalog CreateModuleCatalog()
        {
            var catalog = new ModuleCatalog();
            catalog.AddModule(typeof(DesignServicesModule));
            catalog.AddModule(typeof(DesignClientRequestModule));
            catalog.AddModule(typeof (DesignContractorsModule));
            catalog.AddModule(typeof (HangarEditModule));
            catalog.AddModule(typeof (CatalogsModule));
         
            return catalog;
        }
    }
}
