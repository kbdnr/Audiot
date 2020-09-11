using AudiotEvents;
using AudiotLogic.Devices;
using AudiotModule.Views;
using NAudio.Midi;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System.Collections.Generic;
using System.Linq;
using Unity;

namespace AudiotMainWindow.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        IEventAggregator _ea;
        IRegionManager _region;
        IUnityContainer _container;

        #region Properties
        private List<string> _midiIDevices;
        public List<string> MidiIDevices
        {
            get { return _midiIDevices; }
            set { SetProperty(ref _midiIDevices, value); }
        }

        private int _midiIIndex;
        public int MidiIIndex
        {
            get { return _midiIIndex; }
            set { SetProperty(ref _midiIIndex, value); }
        }

        private List<string> _midiODevices;
        public List<string> MidiODevices
        {
            get { return _midiODevices; }
            set { SetProperty(ref _midiODevices, value); }
        }

        private int _midiOIndex;
        public int MidiOIndex
        {
            get { return _midiOIndex; }
            set { SetProperty(ref _midiOIndex, value); }
        }

        private List<string> _asioDevices;
        public List<string> AsioDevices
        {
            get { return _asioDevices; }
            set { SetProperty(ref _asioDevices, value); }
        }

        private string _selectedAsio;
        public string SelectedAsio 
        {
            get { return _selectedAsio; }
            set { SetProperty(ref _selectedAsio, value); }
        }

        private bool _deviceEnable;
        public bool DeviceEnable 
        {
            get { return _deviceEnable; }
            set { SetProperty(ref _deviceEnable, value); }
        }

        private bool _deviceDisable;
        public bool DeviceDisable 
        {
            get { return _deviceDisable; }
            set { SetProperty(ref _deviceDisable, value); }
        }
        #endregion

        private MidiOut _mOut;
        private MidiIn _mIn;

        public DelegateCommand StartDevicesCommand { get; private set; }
        public DelegateCommand StopDevicesCommand { get; private set; }

        //Loader Command
        public DelegateCommand LoadMidiModuleCommand { get; private set; }
        public DelegateCommand DestroyMidiModuleCommand { get; private set; }

        public MainWindowViewModel(IEventAggregator ea, IRegionManager region, IUnityContainer container)
        {
            _ea = ea;
            _region = region;
            _container = container;

            UpdateStatus("Welcome to Audiot");
            DeviceEnable = true;
            DeviceDisable = false;

            LoadMidiModuleCommand = new DelegateCommand(LoadMidiModule);
            DestroyMidiModuleCommand = new DelegateCommand(DestroyMidiModule);

            //MIDI IO
            MidiIDevices = DeviceLogic.AvailableMidiInDevices();
            MidiODevices = DeviceLogic.AvailableMidiOutDevices();

            //Audio IO
            AsioDevices = DeviceLogic.AvailableAudioDevices();

            StartDevicesCommand = new DelegateCommand(StartDevices);
            StopDevicesCommand= new DelegateCommand(StopDevices);
        }

        private void StartDevices()
        {
            _mOut = DeviceLogic.InitMidiOut(_midiOIndex);
            _mIn = DeviceLogic.InitMidiIn(_midiIIndex);

            //Register for containers
            _container.RegisterInstance(_mOut);
            _container.RegisterInstance(_mIn);

            DeviceEnable = false;
            DeviceDisable = true;

            _ea.GetEvent<InitializedEvent>().Publish(true);
            UpdateStatus("Devices Enabled...");
        }

        private void StopDevices()
        {
            _mIn.Dispose();
            _mOut.Dispose();

            DeviceDisable = false;
            DeviceEnable = true;

            _ea.GetEvent<InitializedEvent>().Publish(false);

            UpdateStatus("Devices Disabled...");
        }

        private void LoadMidiModule()
        {
            var listing = _region.Regions;

            //Find Area For Device
            var regionToUse = listing.Where(x => x.Name.Contains("MidiRegion") && x.ActiveViews.Count() == 0)
                .OrderByDescending(x => x.Name)
                .Reverse()
                .Select(x => x.Name)
                .FirstOrDefault();

            if(regionToUse != null)
            {
                _region.RegisterViewWithRegion(regionToUse, () => this._container.Resolve<MidiControlView>());
            }
        }

        private void DestroyMidiModule()
        {
            var listing = _region.Regions;

            //Find Area For Device
            var regionToUse = listing.Where(x => x.Name.Contains("MidiRegion") && x.ActiveViews.Count() != 0)
                .OrderByDescending(x => x.Name)
                .FirstOrDefault();

            if (regionToUse != null)
            {
                regionToUse.Remove(regionToUse.ActiveViews.First());
            }
        }

        private void UpdateStatus(string status)
        {
            _ea.GetEvent<StatusMessageEvent>().Publish(status);
        }
    }
}
