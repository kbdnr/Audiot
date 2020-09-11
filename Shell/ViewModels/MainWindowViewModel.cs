using AudiotEvents;
using Prism.Commands;
using Prism.Events;
using Prism.Logging;
using Prism.Mvvm;

namespace Audiot.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        IEventAggregator _ea;
        ILoggerFacade _log;

        #region Private Vars
        private string _status;
        private string _title = "Audiot";

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

            SaveCommand = new DelegateCommand(Save);
            NewCommand = new DelegateCommand(New);
        }
        #endregion

        #region Commands
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
