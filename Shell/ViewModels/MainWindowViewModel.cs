using AudiotEvents;
using Prism.Commands;
using Prism.Events;
using Prism.Logging;
using Prism.Mvvm;

namespace Shell.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        IEventAggregator _ea;
        ILoggerFacade _log;

        #region Private Vars
        private string _status;
        private string _title = "Audiot";
        private string _iconLocation = @"/Shell;component/Resources/SDI_chevron_RGB.jpg";

        #endregion

        #region Public Vars
        public string StatusText
        {
            get { return _status; }
            set { SetProperty(ref _status, value); }
        }

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public string IconLocation
        {
            get { return _iconLocation; }
            set { SetProperty(ref _iconLocation, value); }
        }
        #endregion

        #region Delegate Commands
        public DelegateCommand NewCommand { get; private set; }
        public DelegateCommand SaveCommand { get; private set; }
        public DelegateCommand HelpCommand { get; private set; }
        public DelegateCommand AboutCommand { get; private set; }
        #endregion

        #region Constructor
        public MainWindowViewModel(IEventAggregator eventAggregator, ILoggerFacade log)
        {
            _ea = eventAggregator; _log = log;
            StatusText = "Loading...";

            //Event Handling
            _ea.GetEvent<TitleEvent>().Subscribe(UpdateTitle);
            _ea.GetEvent<StatusMessageEvent>().Subscribe(UpdateStatus);
            _ea.GetEvent<IconEvent>().Subscribe(SetIcon);

            SaveCommand = new DelegateCommand(Save);
            NewCommand = new DelegateCommand(New);
        }
        #endregion

        #region Commands
        private void SetIcon(string iconLocation)
        {
            IconLocation = iconLocation;
        }

        private void UpdateTitle(string title)
        {
            Title = title;
        }

        private void UpdateStatus(string statusMessage)
        {
            StatusText = statusMessage;
        }

        private void New()
        {
            _ea.GetEvent<NewEvent>().Publish();
        }

        private void Save()
        {
            _ea.GetEvent<SaveEvent>().Publish("");
        }
        #endregion
    }
}
