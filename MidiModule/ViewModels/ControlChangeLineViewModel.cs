using AudiotLogic.MidiLogic;
using NAudio.Midi;
using Prism.Events;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Threading;

namespace AudiotModule.ViewModels
{
    public class ControlChangeLineViewModel : BindableBase
    {
        MidiOut _mOut;
        Random _rand;

        #region Properties
        private List<ControlChange> _configItems;

        public List<ControlChange> ConfigItems
        {
            get { return this._configItems; }
            set { SetProperty(ref _configItems, value); }
        }

        private ControlChange _selectedParameter;

        public ControlChange SelectedParameter
        {
            get { return this._selectedParameter; }
            set { SetProperty(ref _selectedParameter, value); }
        }

        private int _ccValue;

        public int CCValue
        {
            get { return this._ccValue; }
            set
            {
                SetProperty(ref _ccValue, value);
                SendControlChangeUpdate();
            }
        }

        private int _midiChannel;

        public int MidiChannel
        {
            get { return this._midiChannel; }
            set { SetProperty(ref _midiChannel, value); }
        }
        #endregion

        public ControlChangeLineViewModel(MidiOut mOut)
        {
            _mOut = mOut;
            _rand = new Random();
        }

        public void RandomizeControl()
        {
            CCValue = _rand.Next(127);
        }

        private void SendControlChangeUpdate()
        {
            ThreadPool.QueueUserWorkItem(
                o =>
                {
                    ControlChangeLogic.SendControlChange(_mOut, SelectedParameter, CCValue, MidiChannel);
                }
            );
        }
    }
}
