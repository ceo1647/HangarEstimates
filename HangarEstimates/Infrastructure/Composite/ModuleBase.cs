using Microsoft.Practices.Prism.Modularity;

namespace HangarEstimates.Infrastructure.Composite
{
    using Microsoft.Practices.Prism.Events;
    using Microsoft.Practices.Prism.Regions;
    using Microsoft.Practices.Unity;

    /// <summary>
    /// Базовый класс модуля
    /// </summary>
    public abstract class ModuleBase : IModule
    {
        [Dependency]
        public IUnityContainer Container { get; set; }

        [Dependency]
        public IEventAggregator EventAggregator { get; set; }

        [Dependency]
        public IRegionManager RegionManager { get; set; }

        public abstract void Initialize();
    }
}
