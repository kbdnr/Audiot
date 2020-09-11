using AudiotEvents;
using MahApps.Metro.Controls;
using Prism.Events;
using Prism.Regions;
using System;
using System.ComponentModel;
using System.Timers;
using System.Windows;
using Unity;

namespace Shell.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        IUnityContainer _container;
        IRegionManager _regionManager;
        IEventAggregator _ea;
        string _prevStatusText;

        public MainWindow(IUnityContainer container, IRegionManager regionManager, IEventAggregator ea)
        {
            InitializeComponent();
            _container = container;
            _regionManager = regionManager;
            _ea = ea;

            _ea.GetEvent<StatusMessageEvent>().Subscribe(SetStatusBar);
            _ea.GetEvent<RestoreStatusMessageEvent>().Subscribe(RestoreStatusBar);
        }

        /// <summary>
        /// Shell Closing event for user warning and event publication.  ExitEvent is published in order to accurately cleanup the application_login table record.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Shell_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Do you want to close this window?",
                                          "Confirmation",
                                          MessageBoxButton.YesNo,
                                          MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                Application.Current.Shutdown();
            }
            else
                e.Cancel = true;
        }

        private void MenuExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        #region StatusBarHover
        private void SetStatusBar(string updateStatusString)
        {
            _prevStatusText = StatusTextBlock.Text;
            StatusTextBlock.Text = updateStatusString;
        }

        private void RestoreStatusBar()
        {
            StatusTextBlock.Text = _prevStatusText;
        }

        private void MenuNew_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            _prevStatusText = StatusTextBlock.Text;
            StatusTextBlock.Text = "New";
        }

        private void MenuNew_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            StatusTextBlock.Text = _prevStatusText;
        }

        private void MenuSave_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            _prevStatusText = StatusTextBlock.Text;
            StatusTextBlock.Text = "Save";
        }

        private void MenuSave_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            StatusTextBlock.Text = _prevStatusText;
        }

        private void MenuPrint_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            _prevStatusText = StatusTextBlock.Text;
            StatusTextBlock.Text = "Print";
        }

        private void MenuPrint_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            StatusTextBlock.Text = _prevStatusText;
        }

        private void MenuExit_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            _prevStatusText = StatusTextBlock.Text;
            StatusTextBlock.Text = "Exit";
        }

        private void MenuExit_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            StatusTextBlock.Text = _prevStatusText;
        }

        private void MenuCut_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            _prevStatusText = StatusTextBlock.Text;
            StatusTextBlock.Text = "Cut";
        }

        private void MenuCut_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            StatusTextBlock.Text = _prevStatusText;
        }

        private void MenuCopy_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            _prevStatusText = StatusTextBlock.Text;
            StatusTextBlock.Text = "Copy";
        }

        private void MenuCopy_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            StatusTextBlock.Text = _prevStatusText;
        }

        private void MenuPaste_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            _prevStatusText = StatusTextBlock.Text;
            StatusTextBlock.Text = "Paste";
        }

        private void MenuPaste_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            StatusTextBlock.Text = _prevStatusText;
        }

        private void MenuHelp_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            _prevStatusText = StatusTextBlock.Text;
            StatusTextBlock.Text = "Help";
        }

        private void MenuHelp_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            StatusTextBlock.Text = _prevStatusText;
        }

        private void MenuAbout_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            _prevStatusText = StatusTextBlock.Text;
            StatusTextBlock.Text = "About";
        }

        private void MenuAbout_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            StatusTextBlock.Text = _prevStatusText;
        }
        #endregion

        private void MenuAbout_Click(object sender, RoutedEventArgs e)
        {
            //var result = await AboutDialog.ShowDialog()
        }
    }

    /// <summary>
    /// Ticker Class used for perpetually updating status bar with the correct DateTime
    /// </summary>
    public class TickerC : INotifyPropertyChanged
    {
        public TickerC()
        {
            Timer timer = new Timer();
            timer.Interval = 1000; // 1 second updates
            timer.Elapsed += timer_Elapsed;
            timer.Start();
        }

        public DateTime Now
        {
            get { return DateTime.Now; }
        }

        void timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Now"));
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}