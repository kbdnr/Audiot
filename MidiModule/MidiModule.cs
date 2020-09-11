using AudiotModule.Views;
using Prism.Events;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace AudiotModule
{
    public class MidiModule : IModule
    {
        IContainerProvider _container;

        public MidiModule(IContainerProvider container)
        {
            _container = container;
        }

        public void OnInitialized(IContainerProvider containerProvider)
        {
            
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {

            containerRegistry.RegisterForNavigation<ControlChangeLine>();
        }
    }
}