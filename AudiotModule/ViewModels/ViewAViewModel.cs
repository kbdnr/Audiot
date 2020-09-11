using AudiotLogic.MidiLogic;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AudiotWPF.ViewModels
{
    public class ViewAViewModel : BindableBase
    {
        private List<string> _midiDevices;
        public List<string> MidiDevices
        {
            get { return _midiDevices; }
            set { SetProperty(ref _midiDevices, value); }
        }

        private int _midiIndex;
        public int MidiIndex
        {
            get { return _midiIndex; }
            set { SetProperty(ref _midiIndex, value); }
        }

        private string _message;
        public string Message
        {
            get { return _message; }
            set { SetProperty(ref _message, value); }
        }

        public ViewAViewModel()
        {
            MidiDevices = DeviceLogic.AvailableDevices();


            Message = "View A from your Prism Module";
        }
    }
}
