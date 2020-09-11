using AudiotLogic.MidiLogic;
using AudiotLogic.TheoryLogic;
using MidiModule.State;
using NAudio.Midi;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading;
using Unity;

namespace AudiotModule.ViewModels
{
    public class MidiControlViewModel : BindableBase
    {
        IEventAggregator _ea;
        IRegionManager _region;
        IRegionManager _scopedRegion;
        IUnityContainer _container;

        MidiIn _mIn;
        MidiOut _mOut;

        #region Properties
        public List<string> ScaleList { get; set; }
        public List<int> MidiChannels { get; set; }
        public List<string> KeyList { get; set; }
        public Scale ChosenScale;
        public Key ChosenKey;
        private int _userInputCycle;

        //UI State Handler for visibility/edit modes
        private MidiControlState _uiState;

        public MidiControlState UIState
        {
            get { return this._uiState; }
            set { SetProperty(ref _uiState, value); }
        }

        private bool _userInputMode;
        public bool UserInputMode
        {
            get { return this._userInputMode; }
            set
            {
                SetProperty(ref _userInputMode, value);

                if (UserInputMode == true)
                {
                    UIState = new MidiControlState(MidiControlStateEnum.MidiMode);
                    MidiInputListener(true);
                }
                else
                {
                    UIState = new MidiControlState(MidiControlStateEnum.CompositionMode);
                    MidiInputListener(false);
                }
            }
        }

        private bool _chordMode;

        public bool ChordMode
        {
            get { return this._chordMode; }
            set { SetProperty(ref _chordMode, value); }
        }        

        #region Player Notes
        private int _s1Value;
        public int S1Value
        {
            get { return _s1Value; }
            set { SetProperty(ref _s1Value, value); }
        }

        private int _s2Value;
        public int S2Value
        {
            get { return _s2Value; }
            set { SetProperty(ref _s2Value, value); }
        }

        private int _s3Value;
        public int S3Value
        {
            get { return _s3Value; }
            set { SetProperty(ref _s3Value, value); }
        }

        private int _s4Value;
        public int S4Value
        {
            get { return _s4Value; }
            set { SetProperty(ref _s4Value, value); }
        }
        #endregion

        private string _selectedScale;

        public string SelectedScale
        {
            get { return this._selectedScale; }
            set
            {
                SetProperty(ref _selectedScale, value);
                ChosenScale = Scales.ConstructScaleFromName(_selectedScale);
            }
        }

        private string _shapeList;

        public string ShapeList
        {
            get { return this._shapeList; }
            set { SetProperty(ref _shapeList, value); }
        }

        private string _progressionList;

        public string ProgressionList
        {
            get { return this._progressionList; }
            set
            {
                SetProperty(ref _progressionList, value);

                if (_progressionList != "")
                    ProgressionPattern = _progressionList.Split(',').Select(Int32.Parse).ToList();
                else
                    ProgressionPattern = null;
            }
        }

        private List<int> ProgressionPattern { get; set; }

        private string _lengthList;

        public string LengthList
        {
            get { return this._lengthList; }
            set
            {
                SetProperty(ref _lengthList, value);
                if (_lengthList != "")
                    LengthPattern = _lengthList.Split(',').Select(Int32.Parse).ToList();
                else
                    LengthPattern = new List<int>(new int[] { 500 }); //default to 500ms
            }
        }

        private List<int> LengthPattern { get; set; }

        private string _inversionList;

        public string InversionList
        {
            get { return this._inversionList; }
            set
            {
                SetProperty(ref _inversionList, value);
                if (_inversionList != "")
                    InversionPattern = _inversionList.Split(',').Select(Int32.Parse).ToList();
                else
                    InversionPattern = new List<int>(new int[] { 0 });
            }
        }

        private List<int> InversionPattern { get; set; }

        private string _octaveList;

        public string OctaveList
        {
            get { return this._octaveList; }
            set
            {
                SetProperty(ref _octaveList, value);
                if (_octaveList != "")
                    OctavePattern = _octaveList.Split(',').Select(int.Parse).ToList();
                else
                    OctavePattern = new List<int>(new int[] { 0 });
            }
        }

        private List<int> OctavePattern { get; set; }

        private string _colorList;
        public string ColorList
        {
            get { return _colorList; }
            set
            {
                SetProperty(ref _colorList, value);
                if (_colorList != "")
                    ColorPattern = _colorList.Split(',').Select(int.Parse).ToList();
                else
                    ColorPattern = null;
            }
        }

        private List<int> ColorPattern { get; set; }

        private int _repeat;

        public int Repeat
        {
            get { return this._repeat; }
            set { SetProperty(ref _repeat, value); }
        }

        private int _selectedChannel;
        public int SelectedChannel
        {
            get { return _selectedChannel; }
            set
            {
                SetProperty(ref _selectedChannel, value);
            }
        }

        private string _selectedKey;

        public string SelectedKey
        {
            get { return this._selectedKey; }
            set
            {
                SetProperty(ref _selectedKey, value);
                ChosenKey = Keys.ConstructKeyFromName(_selectedKey);
            }
        }

        //Back Properties
        private ObservableCollection<string> _configList;
        public ObservableCollection<string> ConfigList
        {
            get { return _configList; }
            set { SetProperty(ref _configList, value); }
        }

        private string _selectedConfig;
        public string SelectedConfig
        {
            get { return _selectedConfig; }
            set
            {
                SetProperty(ref _selectedConfig, value);
                ControlChangeParameters = new List<ControlChange>(ControlChangeLogic.XMLDeserialize(_selectedConfig).ControlChange);
            }
        }

        private List<ControlChange> _controlChangeParameters;

        public List<ControlChange> ControlChangeParameters
        {
            get { return this._controlChangeParameters; }
            set { SetProperty(ref _controlChangeParameters, value); }
        }

        private int _remainingCount;
        public int RemainingCount
        {
            get { return _remainingCount; }
            set { SetProperty(ref _remainingCount, value); }
        }
        #endregion

        #region Commands
        //Interactions
        public DelegateCommand PlayMelody1 { get; private set; }
        public DelegateCommand PlayMelody2 { get; private set; }
        public DelegateCommand PlayMelody3 { get; private set; }
        public DelegateCommand PlayMelody4 { get; private set; }
        public DelegateCommand StartInvProgressionCommand { get; private set; }

        public DelegateCommand Strum1BCommand { get; private set; }
        public DelegateCommand Strum2BCommand { get; private set; }
        public DelegateCommand Strum3BCommand { get; private set; }
        public DelegateCommand Strum4BCommand { get; private set; }

        public DelegateCommand Strum1ECommand { get; private set; }
        public DelegateCommand Strum2ECommand { get; private set; }
        public DelegateCommand Strum3ECommand { get; private set; }
        public DelegateCommand Strum4ECommand { get; private set; }

        public DelegateCommand RollTheDiceCommand { get; private set; }

        public DelegateCommand AddControlCommand { get; private set; }
        public DelegateCommand RemoveControlCommand { get; private set; }
        #endregion

        public MidiControlViewModel(IEventAggregator ea, IRegionManager region, IUnityContainer container, MidiIn midiIn, MidiOut midiOut)
        {
            _ea = ea; _region = region; _container = container;

            //Inject midi + event subscriptions
            _mIn = midiIn;
            _mOut = midiOut;
            _mIn.MessageReceived += _mIn_MessageReceived;
            _mIn.ErrorReceived += _mIn_ErrorReceived;

            _scopedRegion = _region.CreateRegionManager();

            //Initialize midi and scale listings
            ScaleList = new List<string>(Scales.GetScaleNames());
            MidiChannels = Enumerable.Range(1, 16).ToList();
            KeyList = Keys.GetKeyNames();
            SelectedChannel = MidiChannels.First();
            SelectedScale = ScaleList.First();
            SelectedKey = KeyList.First();

            UserInputMode = false;

            //Initialize Values
            LengthList = "500"; //500ms
            OctaveList = "0"; //Middle-Octave
            Repeat = 1; //Play Once

            //Init to Middle-C value to sliders
            SetNotes(NoteLogic.OctaveC[4], NoteLogic.OctaveC[4], NoteLogic.OctaveC[4], NoteLogic.OctaveC[4]);

            //Bind Commands to Methods
            StartInvProgressionCommand = new DelegateCommand(StartInversion);

            PlayMelody1 = new DelegateCommand(StartMelody1);
            PlayMelody2 = new DelegateCommand(StartMelody2);
            PlayMelody3 = new DelegateCommand(StartMelody3);
            PlayMelody4 = new DelegateCommand(StartMelody4);

            RollTheDiceCommand = new DelegateCommand(RollTheDice);

            //Strum begin
            Strum1BCommand = new DelegateCommand(Strum1B);
            Strum2BCommand = new DelegateCommand(Strum2B);
            Strum3BCommand = new DelegateCommand(Strum3B);
            Strum4BCommand = new DelegateCommand(Strum4B);
            //Strum end
            Strum1ECommand = new DelegateCommand(Strum1E);
            Strum2ECommand = new DelegateCommand(Strum2E);
            Strum3ECommand = new DelegateCommand(Strum3E);
            Strum4ECommand = new DelegateCommand(Strum4E);

            //CC Panel
            ConfigList = new ObservableCollection<string>(ControlChangeLogic.GetSynthConfigs());
        }

        private void MidiInputListener(bool enableListener)
        {
            if (enableListener)
                _mIn.Start();
            else
                _mIn.Stop();

            _userInputCycle = 0;
        }

        private void _mIn_ErrorReceived(object sender, MidiInMessageEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void _mIn_MessageReceived(object sender, MidiInMessageEventArgs e)
        {
            //Only regard event if it matches selected channel
            if(e.MidiEvent.Channel == SelectedChannel)
            {
                if(e.MidiEvent.CommandCode == MidiCommandCode.NoteOn)
                {
                    var noteOnEvent = (NoteEvent)e.MidiEvent;
                    PlayFromInput(noteOnEvent);
                }
                if(e.MidiEvent.CommandCode == MidiCommandCode.NoteOff)
                {
                    var noteEvent = (NoteEvent)e.MidiEvent;
                    MidiLogic.StopNote(_mOut, SelectedChannel, noteEvent.NoteNumber);
                }
            }
        }

        private void PlayFromInput(NoteEvent noteEvent)
        {
            if(noteEvent.Velocity > 0)
                SetInputKey(noteEvent);

            if (!ChordMode)
            {
                S1Value = noteEvent.NoteNumber;
                MidiLogic.PlayNote(_mOut, SelectedChannel, noteEvent.NoteNumber, noteEvent.Velocity);
            }
            else
            {
                var chord = Triad.InputChordGen(noteEvent.NoteNumber, TriadShapeEnum.Major);
                if (noteEvent.Velocity > 0)
                    SetNotes(chord.Notes);

                MidiLogic.PlayChord(_mOut, SelectedChannel, noteEvent.Velocity, chord.Notes.ToArray());
            }
        }

        private void RemoveControlChange()
        {

        }

        private void RollTheDice()
        {
            Random x = new Random();
            var numSteps = x.Next(ChosenScale.Steps.Count);

            //for(int i = 0; i < numSteps; i++)
            //{

            //}

            //ProgressionList = 
        }

        private void StartInversion()
        {
            var scale = ChosenScale;
            var progression = Triad.ChordGen(scale, ProgressionPattern, ColorPattern, Repeat);
            var chordInv = Triad.Inversion(progression, OctavePattern, InversionPattern, ChosenKey);
            var counter = 0;
            RemainingCount = chordInv.Chords.Count;

            ThreadPool.QueueUserWorkItem(
                o =>
                {
                    foreach (var chord in chordInv.Chords)
                    {
                        SetNotes(chord.Notes);

                        MidiLogic.PlayChord(_mOut, SelectedChannel, 127, chord.Notes.ToArray());
                        Thread.Sleep(LengthPattern[counter % LengthPattern.Count]);
                        MidiLogic.StopChord(_mOut, SelectedChannel, 127, chord.Notes.ToArray());
                        counter++;
                        RemainingCount -= 1;
                    }
                }
            );
        }

        private void StartMelody(int line)
        {
            var scale = ChosenScale;
            int counter = 0;

            ThreadPool.QueueUserWorkItem(
                o =>
                {
                    if(ProgressionPattern != null && ProgressionPattern.Count > 0)
                    {
                        foreach(var root in ProgressionPattern)
                        {
                            var adjustedNote = NoteLogic.OctaveC[OctavePattern[counter % OctavePattern.Count] + 4] + scale.Steps[root % scale.Steps.Count] + ChosenKey.Offset;

                            switch (line)
                            {
                                case 1:
                                    S1Value = adjustedNote;
                                    break;
                                case 2:
                                    S2Value = adjustedNote;
                                    break;
                                case 3:
                                    S3Value = adjustedNote;
                                    break;
                                case 4:
                                    S4Value = adjustedNote;
                                    break;
                            }

                            MidiLogic.PlayNote(_mOut, SelectedChannel, adjustedNote);
                            Thread.Sleep(LengthPattern[counter % LengthPattern.Count]);
                            MidiLogic.StopNote(_mOut, SelectedChannel, adjustedNote);
                            counter++;
                        }
                    }
                    else
                    {
                        for(int i = 0; i < scale.Steps.Count; i++)
                        {
                            var adjustedNote = NoteLogic.OctaveC[OctavePattern[counter % OctavePattern.Count] + 4] + scale.Steps[i % scale.Steps.Count] + ChosenKey.Offset;

                            switch (line)
                            {
                                case 1:
                                    S1Value = adjustedNote;
                                    break;
                                case 2:
                                    S2Value = adjustedNote;
                                    break;
                                case 3:
                                    S3Value = adjustedNote;
                                    break;
                                case 4:
                                    S4Value = adjustedNote;
                                    break;
                            }

                            MidiLogic.PlayNote(_mOut, SelectedChannel, adjustedNote);
                            Thread.Sleep(LengthPattern[counter % LengthPattern.Count]);
                            MidiLogic.StopNote(_mOut, SelectedChannel, adjustedNote);
                            counter++;
                        }
                    }
                });
        }

        #region UISync
        private void SetNotes(params int[] notes)
        {
            if (notes.Any())
            {
                S1Value = notes[0];
                S2Value = notes[1];
                S3Value = notes[2];

                if (notes.Count() == 4)
                    S4Value = notes[3];
            }
        }

        private void SetNotes(List<int> notes)
        {
            SetNotes(notes.ToArray());
        }

        private void SetInputKey(NoteEvent noteEvent)
        {
            var keyMod = noteEvent.NoteNumber % 12;
            SelectedKey = KeyList[keyMod];
        }
        #endregion

        #region Note Playback
        private void StartMelody1()
        {
            StartMelody(1);
        }

        private void StartMelody2()
        {
            StartMelody(2);
        }

        private void StartMelody3()
        {
            StartMelody(3);
        }

        private void StartMelody4()
        {
            StartMelody(4);
        }

        private void Strum1B()
        {
            MidiLogic.PlayNote(_mOut, SelectedChannel, S1Value);
        }

        private void Strum2B()
        {
            MidiLogic.PlayNote(_mOut, SelectedChannel, S2Value);
        }

        private void Strum3B()
        {
            MidiLogic.PlayNote(_mOut, SelectedChannel, S3Value);
        }

        private void Strum4B()
        {
            MidiLogic.PlayNote(_mOut, SelectedChannel, S4Value);
        }

        private void Strum1E()
        {
            MidiLogic.StopNote(_mOut, SelectedChannel, S1Value);
        }

        private void Strum2E()
        {
            MidiLogic.StopNote(_mOut, SelectedChannel, S2Value);
        }

        private void Strum3E()
        {
            MidiLogic.StopNote(_mOut, SelectedChannel, S3Value);
        }

        private void Strum4E()
        {
            MidiLogic.StopNote(_mOut, SelectedChannel, S4Value);
        }
        #endregion
    }
}
