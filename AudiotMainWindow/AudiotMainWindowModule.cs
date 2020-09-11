using AudiotMainWindow.Views;
using AudiotModule.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;
using Unity;

namespace AudiotMainWindow
{
    public class AudiotMainWindowModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("ContentRegion", typeof(MainWindow));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<MidiControlView>();
            containerRegistry.RegisterForNavigation<ControlChangeLine>();
        }
    }
}