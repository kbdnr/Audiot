using AudiotModule.Views;
using Prism.Modularity;
using Prism.Regions;
using System;
using Prism.Unity;
using Microsoft.Practices.Unity;

namespace AudiotWPF
{
    public class AudiotModule : IModule
    {
        private IRegionManager _regionManager;
        private IUnityContainer _container;

        public AudiotModule(IUnityContainer container, IRegionManager regionManager)
        {
            _container = container;
            _regionManager = regionManager;
        }

        public void Initialize()
        {
            _container.RegisterTypeForNavigation<ViewA>();
        }
    }
}